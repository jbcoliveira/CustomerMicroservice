using Business.Models;
using Data.Context;
using System;

namespace API.Configurations
{
    public static class SeedSqlConfiguration
    {
        public static IApplicationBuilder UseItToSeedDatabaseServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
            }

            return app;
        }
    }

    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            CustomersSeed(dbContext);
        }

        private static void CustomersSeed(ApplicationDbContext dbContext)
        {
            if (dbContext.Customers.Any()) return;

            List<Customer> customers = new List<Customer> {
                new Customer{Email="joao@email.com", FirstName="Joao", SurName = "Oliveira", Password = "pwd1"},
                new Customer{Email="jose@email.com", FirstName="Jose", SurName = "Silva", Password = "pwd2"},
                new Customer{Email="maria@email.com", FirstName="Maria", SurName = "Ribeiro", Password = "pwd3"},
            };

            dbContext.Customers.AddRange(customers);
            dbContext.SaveChanges();
        }
    }
}
