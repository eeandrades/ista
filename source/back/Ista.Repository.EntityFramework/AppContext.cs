using Ista.Repository.EntityFramework.Cards.Mappers;
using Ista.Repository.EntityFramework.Cards.Tables;
using Ista.Repository.EntityFramework.Users.Mappers;
using Ista.Repository.EntityFramework.Users.Tables;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ista.Repository.EntityFramework
{
    internal class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
        : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapper());
            modelBuilder.ApplyConfiguration(new CardListMapper());
            modelBuilder.ApplyConfiguration(new CardMapper());
        }

       async public Task<TTable> CreateAsync<TTable>()
            where TTable: new()
        {
            var table = new TTable();
            await this.AddAsync(table);
            return table;
        }

        public DbSet<CardListTable> CardList => this.Set<CardListTable>();
        public DbSet<CardTable> Card => this.Set<CardTable>();
        public DbSet<UserTable> User => this.Set<UserTable>();

    }
}
