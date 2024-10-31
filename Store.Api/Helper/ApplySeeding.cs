using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Data.DataContext;
using Store.Data.Entities.Identity;
using Store.Repository;

namespace Store.Api.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {   //create scop variable to have any needed services in my program instead of inject one by one in program file

            //WebApplication is the type have all ServicesScope
            //ServicesScope : have all ServicesProvider
            //ServicesProvider : have all Services
            //WebApplication ==> ServicesScope==> ServicesProvider ==>Services
            using (var Scop = app.Services.CreateScope())
            {   //create instance from ServiceProvider(library have all services ex:logger ) To can use the services
                var services = Scop.ServiceProvider;
                //declare variable to carry ILoggerFactory
                var ILoggerfactory = services.GetRequiredService<ILoggerFactory>();
                try
                {   //detect the DbContext which used 
                    var context = services.GetRequiredService<StoreDbContext>();
                    var UserManager = services.GetRequiredService<UserManager<AppUser>>();

                    //firstly check if there were migrations not apply in the database if yes it will apply it firstly to add tables is database to allow adding the data on it
                    await context.Database.MigrateAsync();

                    //call the function which Read the data 
                    await StoreContextSeed.SeedAsync(context, ILoggerfactory);

                    await AppIdentityDbContexSeeding.SeedUserAsync(UserManager);
                }
                catch (Exception ex)
                {
                    var log = ILoggerfactory.CreateLogger<ApplySeeding>();
                    log.LogError(ex.Message);
                }

            }
            //finally call this function in program file
        }
    }
}
