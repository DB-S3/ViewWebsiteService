﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewWebsiteService;

namespace Tests
{
    public class TestingWebAppFactory<T> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContext = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<Data.Database>));

                if (dbContext != null)
                    services.Remove(dbContext);

                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<Data.Database>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDB");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<Data.Database>())
                    {
                        try
                        {
                            Common.Website website = new Common.Website() { OwnerId = "testOwnerId", Id = "testId", Url = "test.com", Pages = new List<Common.Page>() };
                            website.Pages.Add(new Common.Page() { Id = "pageId", Name = "testpage", Objects = new List<Common.HTMLObjects>() });
                            appContext.Database.EnsureCreated();
                            appContext.Websites.Add(website);
                            appContext.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            //Log errors
                            throw;
                        }

                    }
                }
            });
        }
    }

}
