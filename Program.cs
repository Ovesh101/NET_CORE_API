
using Microsoft.EntityFrameworkCore;
using NET_Core_CRUD_API.DataAccess;

namespace NET_Core_CRUD_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var provider = builder.Services.BuildServiceProvider();
            var config = provider.GetService<IConfiguration>();
            builder.Services.AddDbContext<InventoryContext>(item => item.UseSqlServer(config.GetConnectionString("DefaultConnection")));
          



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
