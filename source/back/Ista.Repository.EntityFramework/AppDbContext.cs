using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ista.Repository.EntityFramework
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// Aqui estou obtendo todas as classes de configuração das entidades.
            //// através da interface IEntityConfig, criada única e exclusivamente para isto.
            //// Sendo assim, não precisamos lembrar de, ao criar a configuração de alguma entidade, colocar mais uma linha de código neste trecho.
            //var typesToRegister = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
            //    .Where(x => typeof(IEntityConfig).IsAssignableFrom(x) && !x.IsAbstract).ToList();

            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.ApplyConfiguration(configurationInstance);
            //}
        }

    }
}
