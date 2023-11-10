using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace ECommPostgresDemo;

public sealed class ConfigurationHelper
{
    private static readonly IConfigurationBuilder _configBuilder;
    public static IConfiguration Config => _configBuilder.Build();

    static ConfigurationHelper()
    {
        _configBuilder = new ConfigurationBuilder();
        _configBuilder.AddUserSecrets(Assembly.GetExecutingAssembly(), optional: false);
    }
}