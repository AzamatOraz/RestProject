namespace RestProject.Migrations
{
    using RestProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RestProject.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<RestProject.DAL.RestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestProject.DAL.RestaurantContext context)
        {
            var staffs = new List<Staff>
            {
                new Staff{FirstName="Serik",LastName="Seidagalimov", Mail = "serik@gmail.com", Password = "qwerty",HireDate=DateTime.Parse("2016-05-01"), Manager_ID = 1, Department_ID = 1},
                new Staff{FirstName="Sharafat",LastName="Tolysbaeva", Mail = "sharafat@gmail.com",Password = "qwerty",HireDate=DateTime.Parse("2016-05-01"),Manager_ID = 2 , Department_ID = 1},
                new Staff{FirstName="Azamat",LastName="Oraz",Mail = "azamat@gmail.com", Password = "qwerty",HireDate=DateTime.Parse("2016-05-01"),Manager_ID = 3, Department_ID = 1}
            };

            staffs.ForEach(s => context.Staffs.AddOrUpdate(p => p.FirstName, s));
            context.SaveChanges();

            var clients = new List<Client>
            {
                new Client{ FirstName = "Dinara", LastName = "Tusupova", Manager_ID = 1, Accumulation = 20000},
                new Client{ FirstName = "Goshan", LastName = "Nurbek", Manager_ID = 1, Accumulation = 30000},
                new Client{ FirstName = "Danil", LastName = "Parshukov", Manager_ID = 1, Accumulation = 40000}
            };
            clients.ForEach(s => context.Clients.AddOrUpdate(p => p.FirstName, s));
            context.SaveChanges();

            var dept = new List<Department>
            {
                new Department{ DepName = "Administration"},
                new Department{ DepName = "Human Resources"},
                new Department{ DepName = "Accounting"},
                new Department{ DepName = "Products"}
            };
            dept.ForEach(s => context.Departments.AddOrUpdate(p => p.DepName, s));
            context.SaveChanges();

            var menu = new List<Menu>
            {
                new Menu{ FoodType = "Meat"},
                new Menu{ FoodType = "Drinks"},
                new Menu{ FoodType = "Fruits"}
            };
            menu.ForEach(s => context.Menus.AddOrUpdate(p => p.FoodType, s));
            context.SaveChanges();

            foreach (Client e in clients)
            {
                var clientInDataBase = context.Clients.Where(
                    s =>
                         s.Manager.ID == e.Manager_ID).SingleOrDefault();
                if (clientInDataBase == null)
                {
                    context.Clients.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}