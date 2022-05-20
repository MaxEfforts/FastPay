using FastPayDB.Models.Util;

namespace FastPayRepo.Services.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }

}
