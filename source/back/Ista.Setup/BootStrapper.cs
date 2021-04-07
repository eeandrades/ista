using Ista.Domain.Cards;
using Ista.Domain.Users;
using Ista.Repository.FileSystem.Cards;
using Ista.Repository.FileSystem.Useres;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Ista.Setup
{
    public static class BootStrapper
    {
        public static ServiceProvider RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(

                 System.Reflection.Assembly.Load("Ista.Application")
            );
            services.AddScoped<ICardListRepository, CardListRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICardListQuery, CardListQuery>();
            return services.BuildServiceProvider();
        }

    }
}
