using fabrikafoodService.DataObjects;
using fabrikafoodService.Models;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;

namespace fabrikafoodService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new fabrikafoodInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<fabrikafoodContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class fabrikafoodInitializer : DropCreateDatabaseIfModelChanges<fabrikafoodContext>
    {
        protected override void Seed(fabrikafoodContext context)
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem { Id = Guid.NewGuid().ToString(), Title = "Garlic Bread", Description = "Individual 200gm sourdough baguette, warmed and smothered with garlic and parsley butter.", Price = 7.00m},
                new MenuItem { Id = Guid.NewGuid().ToString(), Title = "Soup", Description = "Please check the blackboard for the day's flavours. Served with crusty bread.", Price = 11.00m},
                new MenuItem { Id = Guid.NewGuid().ToString(), Title = "CCB (Chicken, Cranberry and Brie Filo)", Description = "A delicious mix of creamy, herbed chicken and béchamel sauce, rolled with brie and cranberry sauce. With salad.", Price = 18.00m},
                new MenuItem { Id = Guid.NewGuid().ToString(), Title = "Café Corn Fritters", Description = "A delicious mix of corn, zucchini, basil, coriander, ginger and garlic. Served with créme fraiche and relish. With salad.", Price = 18.00m},
                new MenuItem { Id = Guid.NewGuid().ToString(), Title = "B.L.T.", Description = "Toasted ciabatta bun, filled with crispy bacon, fresh tomato and lettuce and garnished with our lime and basil mayo and relish. With salad.", Price = 18.00m},
                new MenuItem { Id = Guid.NewGuid().ToString(), Title = "Open Sammie", Description = "Our well known concoction of toasted Italian bread, layered with hummus, sliced tomato, lettuce, roasted vegetables, grilled chicken tenderloins and bacon. And topped with our 'pink' mayo", Price = 22.00m},
                new MenuItem { Id = Guid.NewGuid().ToString(), Title = "Warm Lamb Salad", Description = "Tender sliced marinated backstrap, on a bed of salad and served with carrot hummus, feta cheese and a minted Tzatziki style dressing. Served with bread.", Price = 25.00m},
                new MenuItem { Id = Guid.NewGuid().ToString(), Title = "Fillet Steak Stack", Description = "Prime 200gm aged fillet, grilled to your requirements, stacked on roasted vegetables, caramelised onion relish and topped with a roasted Portobello mushroom and aioli.", Price = 30.00m}
            };

            foreach (var menuItem in menuItems)
            {
                context.Set<MenuItem>().Add(menuItem);
            }

            base.Seed(context);
        }
    }
}

