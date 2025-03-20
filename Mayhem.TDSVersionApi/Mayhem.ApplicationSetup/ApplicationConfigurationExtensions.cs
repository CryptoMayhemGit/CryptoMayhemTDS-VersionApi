using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Mayhem.Bl.Interfaces;
using Mayhem.Bl.Services;
using Mayhem.Dal.Context;
using Mayhem.Dal.Mappings;
using Mayhem.Dal.Repositories.Interfaces;
using Mayhem.Dal.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mayhem.ApplicationSetup
{
    public static class ApplicationConfigurationExtensions
    {
        public static void AddMayhemContext(this IServiceCollection services, string connectionString)
        {
            services
                .AddDbContext<MayhemDataContext>
                (
                    options => options.UseSqlServer(connectionString)
                );
        }

        public static void ConfigureKeyVault(this IConfigurationBuilder configuration)
        {
            string? keyVaultEndpoint = Environment.GetEnvironmentVariable("TDSVersionApiKeyVaultEndpoint");
            if (keyVaultEndpoint is null)
            {
                throw new InvalidOperationException("Store the Key Vault endpoint in a TDSVersionApiKeyVaultEndpoint enviroment variable => " + keyVaultEndpoint);
            }
            SecretClient? secretClient = new SecretClient(new(keyVaultEndpoint), new DefaultAzureCredential());
            configuration.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
        }

        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TableDtoMappings));
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGameVersionService, GameVersionService>();
            services.AddScoped<IGameVersionRepository, GameVersionRepository>();
        }
    }
}