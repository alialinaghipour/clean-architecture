using System.Data.SqlClient;
using FluentMigrator.Runner;
using Identity.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var options = GetSettings(args, Directory.GetCurrentDirectory());
var connectionString = options.ConnectionString;
CreateDatabase(connectionString);

var runner = CreateRunner(connectionString, options);
runner.MigrateDown(0);
runner.MigrateUp();

static void CreateDatabase(string connectionString)
{
    var databaseName = GetDatabaseName(connectionString);
    var masterConnectionString =
        ChangeDatabaseName(connectionString, "master");
    var commandScript =
        $"if db_id(N'{databaseName}') is null create database [{databaseName}]";

    using var connection = new SqlConnection(masterConnectionString);
    connection.Open();
    using (var command = new SqlCommand(commandScript, connection))
    {
        command.ExecuteNonQuery();
    }

    connection.Close();
}

static string ChangeDatabaseName(string connectionString,
    string databaseName)
{
    var csb = new SqlConnectionStringBuilder(connectionString)
    {
        InitialCatalog = databaseName
    };
    return csb.ConnectionString;
}

static string GetDatabaseName(string connectionString)
{
    return new SqlConnectionStringBuilder(connectionString)
        .InitialCatalog;
}

static IMigrationRunner CreateRunner(string connectionString,
    MigrationSettings options)
{
    var container = new ServiceCollection()
        .AddFluentMigratorCore()
        .ConfigureRunner(_ => _
            .AddSqlServer()
            .WithGlobalConnectionString(connectionString)
            .ScanIn(typeof(Program).Assembly).For.All())
        .AddSingleton(options)
        .AddSingleton<ScriptResourceManager>()
        .AddLogging(_ => _.AddFluentMigratorConsole())
        .BuildServiceProvider();
    return container.GetRequiredService<IMigrationRunner>();
}

static MigrationSettings GetSettings(string[] args,
    string baseDir)
{
    var configurations = new ConfigurationBuilder()
        .SetBasePath(baseDir)
        .AddJsonFile("appsettings.json", true, true)
        .AddEnvironmentVariables()
        .AddCommandLine(args)
        .Build();

    var settings = new MigrationSettings
    {
        ConnectionString =
            configurations.GetValue<string>("ConnectionString")
    };
    return settings;
}


namespace Identity.Migrations
{
    public class MigrationSettings
    {
        public string ConnectionString { get; set; } = default!;
    }
}