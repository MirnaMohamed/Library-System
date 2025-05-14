using Business.Contracts;
using Business.Services.Contracts;
using Business.Services.Implementation;
using Common.Contracts;
using Data.Context;
using Data.Repositories;
using Library_System.Mapper;
using Microsoft.EntityFrameworkCore;
using Services.Mapper;

namespace Library_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //register dbcontext
            builder.Services.AddDbContext<LibraryDbContext>((options) =>
                options
                .UseInMemoryDatabase("LibraryDB").UseLazyLoadingProxies()
            );
            //DI for contracts
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(ServiceMapperConfig), typeof(WebMapperConfig));

            builder.Services.AddScoped<IAuthorService, AuthorService> ();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBorrowService, BorrowService>();


            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                context.Database.EnsureCreated(); // Ensure the database is created

                // Seed data
                var authors = DataSeeder.SeedAuthors();
                context.Authors.AddRange(authors);
                context.SaveChanges();
                context.Books.AddRange(DataSeeder.SeedBooks(context.Authors.ToList()));
                context.SaveChanges();
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
