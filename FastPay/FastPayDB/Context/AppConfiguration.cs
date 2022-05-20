
using Microsoft.Extensions.Configuration;

namespace FastPayDB.Context;

public class AppConfiguration
{
    public AppConfiguration()
    {
        var configurationBuilder = new ConfigurationBuilder();
        var path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
        configurationBuilder.AddJsonFile(path, false);
        var root = configurationBuilder.Build();
        var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
        SqlConnectionString = appSetting.Value;

    }
    public string SqlConnectionString { get; set; }
}

