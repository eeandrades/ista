using Ista.Application.Cards.Commands.Cards.Create;
using Ista.Application.Cards.Commands.Cards.Update;
using Ista.Application.Cards.Commands.CardsList.Create;
using Ista.Application.Cards.Commands.CardsList.Update;
using Ista.Application.Cards.Queries.GetCardListById;
using Ista.Application.Cards.Queries.GetCardListByUser;
using Ista.Domain.Cards;
using Ista.Domain.Users;
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

            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ista;Trusted_Connection=True;User Id=sa;Password=sasa";
            services.ConfigureIstaRepositoryEF(options => options.UseSqlServer(connectionString));

            services.AddScoped<CreateCardListRequestValidator>();
            services.AddScoped<UpdateCardListRequestValidator>();
            services.AddScoped<CreateCardRequestValidator>();
            services.AddScoped<UpdateCardRequestValidator>();
            services.AddScoped<UserValidator>();
            services.AddScoped<CardListValidator>();

            services.AddScoped<GetCardListByUserRequestValidator>();

            services.AddScoped<GetCardListByIdRequestValidator>();

            return services.BuildServiceProvider();
        }

    }
}
