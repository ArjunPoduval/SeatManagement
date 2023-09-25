using MainAssessment;
using MainAssessment.Interface;
using MainAssessment.services;
using MainAssessment.Tables;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ManagementContext>(options =>
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection"), ServiceLifetime.Singleton);
builder.Services.AddSingleton<IRepository<City>, Repository<City>>();
builder.Services.AddSingleton<IRepository<Building>, Repository<Building>>();
builder.Services.AddSingleton<IRepository<Facility>, Repository<Facility>>();
builder.Services.AddSingleton<IRepository<Department>, Repository<Department>>();
builder.Services.AddSingleton<IRepository<Employee>, Repository<Employee>>();
builder.Services.AddSingleton<IRepository<AssetType>, Repository<AssetType>>();
builder.Services.AddSingleton<IRepository<Assets>, Repository<Assets>>();
builder.Services.AddSingleton<IRepository<MeetingRoom>, Repository<MeetingRoom>>();
builder.Services.AddSingleton<IRepository<Seat>, Repository<Seat>>();
builder.Services.AddSingleton<IRepository<Cabin>, Repository<Cabin>>();
builder.Services.AddSingleton<IRepository<AllocatedSeatsReport>, Repository<AllocatedSeatsReport>>();
builder.Services.AddSingleton<IRepository<UnAllocatedSeatsReport>, Repository<UnAllocatedSeatsReport>>();

builder.Services.AddSingleton<ICity, CityService>();
builder.Services.AddSingleton<IBuilding, BuildingService>();
builder.Services.AddSingleton<IFacility, FacilityService>();
builder.Services.AddSingleton<IDepartment, DepartmentService>();
builder.Services.AddSingleton<IEmployee, EmployeeService>();
builder.Services.AddSingleton<IAsset, AssetsService>();
builder.Services.AddSingleton<IAssetType, AssetTypeService>();
builder.Services.AddSingleton<IMeetingroom, MeetingRoomTableService>();
builder.Services.AddSingleton<ISeat, SeatService>();
builder.Services.AddSingleton<ICabin, CabinService>();
builder.Services.AddSingleton<IReportCall, SeatReportService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", options =>
{
    options.Cookie.Name = "CookieAuthentication";
    options.ExpireTimeSpan = TimeSpan.FromSeconds(600);
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 402;
        return Task.CompletedTask;
    };
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User",
        policy => policy.RequireRole("User"));
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalErrorHandler>();

app.Run();
