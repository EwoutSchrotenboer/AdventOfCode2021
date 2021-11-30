using System.IO;
using Microsoft.Extensions.Configuration;

namespace AoC.Common.Settings;

public static class SettingsProvider
{
    public static IConfiguration Initialize() => 
        new ConfigurationBuilder()
            .AddJsonFile(Path.Join("Settings", "appsettings.json"))
            .AddJsonFile(Path.Join("Settings", "appsettings.local.json"), true)
            .Build();
}
