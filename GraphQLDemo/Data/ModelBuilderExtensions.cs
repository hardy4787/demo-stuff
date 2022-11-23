using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(
                new Platform()
                {
                    Id = 1,
                    Name = ".NET 5",
                },
                new Platform()
                {
                    Id = 2,
                    Name = "Docker",
                },
                new Platform()
                {
                    Id = 3,
                    Name = "Windows",
                    LicenseKey = "324324123123"
                }
            );

            modelBuilder.Entity<Command>().HasData(
                new Command()
                {
                    Id = 1,
                    HowTo = "Build a project",
                    CommandLine = "dotnet build",
                    PlatformId = 1,
                },
                new Command()
                {
                    Id = 2,
                    HowTo = "Run a project",
                    CommandLine = "dotnet run",
                    PlatformId = 1,
                },
                new Command()
                {
                    Id = 3,
                    HowTo = "Start a docker compose file",
                    CommandLine = "docker-compose up -d",
                    PlatformId = 2,
                },
                new Command()
                {
                    Id = 4,
                    HowTo = "Stop a docker compose file",
                    CommandLine = "docker-compose stop",
                    PlatformId = 2,
                }
            );
        }
    }
}
