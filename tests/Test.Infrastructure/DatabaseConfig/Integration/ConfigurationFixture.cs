using Microsoft.Extensions.Configuration;
using Xunit;

namespace Test.Infrastructure.DatabaseConfig.Integration;

public abstract class ConfigurationFixture
{
    public TestSettings Value { get; private set; }

    protected ConfigurationFixture()
    {
        Value = GetSettings();
    }

    private TestSettings GetSettings()
    {
        var configurations = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables()
            .AddCommandLine(Environment.GetCommandLineArgs())
            .Build();

        var settings = new TestSettings();
        configurations.Bind(settings);
        return settings;
    }
}

public class TestSettings
{
    public string DbConnectionString { get; set; } = default!;
}

[CollectionDefinition(nameof(ConfigurationFixture), DisableParallelization = false)]
public class ConfigurationCollectionFixture : ICollectionFixture<ConfigurationFixture>
{
}