using System;
using System.IO;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.Migrations
{
    internal class Runner
    {
        internal static void Main(string[] args)
        {
            var connectionString = GetConnectionString();
            CreateDatabase(connectionString);
            var runner = CreateRunner(connectionString);
            runner.MigrateUp();
        }

        private static void CreateDatabase(string connectionString)
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

        private static string ChangeDatabaseName(string connectionString,
            string databaseName)
        {
            var csb = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = databaseName
            };
            return csb.ConnectionString;
        }

        private static string GetDatabaseName(string connectionString)
        {
            return new SqlConnectionStringBuilder(connectionString)
                .InitialCatalog;
        }

        private static IMigrationRunner CreateRunner(string connectionString)
        {
            var container = new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(_ => _
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(Runner).Assembly).For.All())
                .AddSingleton(new MigrationSettings(){ConnectionString = connectionString})
                .AddLogging(_ => _.AddFluentMigratorConsole())
                .BuildServiceProvider();
            return container.GetRequiredService<IMigrationRunner>();
        }

        private static string GetConnectionString()
        {
            var isDevelopment = GetDevelopmentUsageValue();
            if (isDevelopment)
                return GetDevelopmentConnectionString();
            var connectionString = Environment.GetEnvironmentVariable
                ("CONNECTION_STRING", EnvironmentVariableTarget.Process);
            return connectionString;
        }

        private static string GetDevelopmentConnectionString()
        {
            var configurations = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            return configurations["ConnectionString"];
        }

        public static bool GetDevelopmentUsageValue()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false).Build();
            return bool.Parse(config["IsDevelopment"]);
        }
    }

    public class MigrationSettings
    {
        public string ConnectionString { get; set; }
    }
}