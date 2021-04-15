using Aeon.Domain;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using Ista.Repository.EntityFramework.Cards;
using Ista.Repository.EntityFramework.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ista.Repository.EntityFramework
{
    public static class Bootstrapper
    {
        public static void ConfigureIstaRepositoryEF(this IServiceCollection services, Action<DbContextOptionsBuilder> dbContextOptions)
        {
            services.AddDbContext<AppContext>(dbContextOptions);
            
            services.AddScoped<ICardListRepository, CardListRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICardListQuery, CardListQuerie>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
