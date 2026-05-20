using ECommerce.Application.Mappings;
using ECommerce.Application.Service;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using ECommerce.Insfrastructure.Persistence;
using ECommerce.Insfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container. 

builder.Services.AddControllers()

.AddJsonOptions(options =>

{

    //Disable Camel case naming conventions for JSON Serialization and Deserialization 

    options.JsonSerializerOptions.PropertyNamingPolicy = null;

});





builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<ECommerceDbContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();



builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<OrderDomainService>();



builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});



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