using Microsoft.Extensions.Logging;
using Store.Data.DataContext;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreContextSeed
    {
        //add static function to Read date from Seed Files
        public static async Task SeedAsync(StoreDbContext context, ILoggerFactory logger)
        {
            try
            {
                //check first that products table is not null && not have any product to full it 
                if (context.Products != null && !context.Products.Any())
                {  //Read all texts from json file==> brands.json
                    var brandsData = File.ReadAllText("../Store.Repository/SeedData/brands.json");
                    //after read data -> convert it to list to can loop in it at write step in database
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    //loop at this List
                    if (brands is not null)
                        foreach (var item in brands)
                            await context.Brands.AddAsync(item);//to add brands in Brands table
                                                                //after adding all Brands in the table save it
                                                                // await context.SaveChangesAsync();

                }
                if (context.Products != null && !context.Products.Any())
                {  //Read all texts from json file==> brands.json
                    var productsData = File.ReadAllText("../Store.Repository/SeedData/products.json");
                    //after read data -> convert it to list to can loop in it at write step in database
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    //loop at this List
                    if (products is not null)
                        foreach (var item in products)
                            await context.Products.AddAsync(item);//to add Products in Brands table
                                                                  //after adding all Products in the table save it
                                                                  // await context.SaveChangesAsync();(new version ) used it for all data in one time

                }
                if (context.ProductTypes != null && !context.ProductTypes.Any())
                {  //Read all texts from json file==> brands.json
                    var ProductTypesData = File.ReadAllText("../Store.Repository/SeedData/types.json");
                    //after read data -> convert it to list to can loop in it at write step in database
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(ProductTypesData);
                    //loop at this List
                    if (Types is not null)
                        foreach (var item in Types)
                            await context.ProductTypes.AddAsync(item);//to add brands in Brands table
                                                                      //after adding all Brands in the table save it
                                                                      //await context.SaveChangesAsync();
                }
                if (context.deliveryMethod != null && !context.deliveryMethod.Any())
                {  //Read all texts from json file==> brands.json
                    var deliveryMethodData = File.ReadAllText("../Store.Repository/SeedData/delivery.json");
                    //after read data -> convert it to list to can loop in it at write step in database
                    var Types = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryMethodData);
                    //loop at this List
                    if (Types is not null)
                        foreach (var item in Types)
                            await context.deliveryMethod.AddAsync(item);//to add brands in Brands table
                                                                        //after adding all Brands in the table save it
                                                                        //await context.SaveChangesAsync();
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var log = logger.CreateLogger<StoreContextSeed>();
                log.LogError(ex.Message);
            }

        }
    }
}
