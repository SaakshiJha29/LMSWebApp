using DataAccessLayer.AppDatabase;
using DataAccessLayer.Interfaces;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LMSWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<BookDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            }); 


            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IBookRequestRepository, BookRequestRepository>();


            builder.Services.AddTransient<ITransient, TaskService>();
            builder.Services.AddScoped<IScoped, TaskService>();
            builder.Services.AddSingleton<ISingleton, TaskService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Students}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
