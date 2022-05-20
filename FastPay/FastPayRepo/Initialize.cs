using FastPayRepo.Mapper;
using FastPayDB.Repositories.Address;
using FastPayRepo.Services.AddressServises;
using FastPayRepo.Services.UserServices.SendUserMessage;
using FastPayRepo.Services.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FastPayRepo.Services;

namespace FastPayRepo;

public static class Initialize
{
    public static void FastPayServicesDependencies(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IUserServices, UserServices>();
        services.AddScoped<IGeneralServices, GeneralServices>();
        services.AddAutoMapper(typeof(UserProfile));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        //services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IUserSettingsService, UserSettingsService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<ISendMessage, SendMailActivationCode>();
        services.AddScoped<ISendMessage, SendPhoneActivationCode>();
        services.Configure<MailSettings>(config.GetSection("MailSettings"));

        services.AddSingleton<IEmailSenderService, EmailSenderService>();
        services.Configure<SmtpSettings>(config.GetSection(SmtpSettings.Name));

        services.AddSingleton<ILogger>(svc => svc.GetRequiredService<ILogger<UserServices>>());
    }
}
