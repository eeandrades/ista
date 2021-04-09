using Ista.Repository.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ista.Setup
{
    public static class Bootstrapper
    {
        public static ServiceProvider ConfigureServices
            (IServiceCollection services)
        {

            services.AddMediatR(
                 System.Reflection.Assembly.Load("Ista.Application")
            );

            var connectionString = "Data Source=localhost;Initial Catalog=Ista;Trusted_Connection=True;User Id=sa;Password=sasa";
            services.ConfigureIstaRepositoryEF(options => options.UseSqlServer(connectionString));


            return services.BuildServiceProvider();
        }

    }
}
