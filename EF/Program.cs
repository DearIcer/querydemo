using EF.Context;
using EF.Service.UnitOfWork;
using EF.Service.UserinfoRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContextOptions<IceDbEfContext> options;
// options = new DbContextOptionsBuilder<IceDbEfContext>()
//     .UseSqlServer(
//         @"Server=localhost;Database=IceLoginDb;User Id=sa;Password=123456;TrustServerCertificate=True")
//     .Options;
// init(options);

builder.Services.AddDbContext<IceDbEfContext>(options =>
{
    ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {});
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseLoggerFactory(loggerFactory); 

});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<UserinfoRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// static void init(DbContextOptions<IceDbEfContext> dbContext)
// {
//     try
//     {
//         IceDbEfContext db = new(dbContext);
//         db.Database.EnsureDeleted();
//         db.Database.EnsureCreated();
//         Console.WriteLine("IceDbContext init success");
//         Environment.Exit(0);
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine(ex);
//         throw;
//     }
// }