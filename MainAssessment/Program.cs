using MainAssessment;
using MainAssessment.Interface;
using MainAssessment.services;
using MainAssessment.Tables;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ManagementContext>(options =>
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection"), ServiceLifetime.Singleton);
builder.Services.AddSingleton<IRepository<City>,Repository<City>>();
builder.Services.AddSingleton<IRepository<Building>,Repository<Building>>();
builder.Services.AddSingleton<IRepository<Facility>,Repository<Facility>>();
builder.Services.AddSingleton<IRepository<Department>,Repository<Department>>();
builder.Services.AddSingleton<IRepository<Employee>,Repository<Employee>>();
builder.Services.AddSingleton<IRepository<AssetType>,Repository<AssetType>>();
builder.Services.AddSingleton<IRepository<Assets>,Repository<Assets>>();
builder.Services.AddSingleton<IRepository<MeetingRoomTable>,Repository<MeetingRoomTable>>();
builder.Services.AddSingleton<IRepository<Seat>,Repository<Seat>>();
builder.Services.AddSingleton<IRepository<Cabin>,Repository<Cabin>>();
builder.Services.AddSingleton<IRepository<UnAllocatedSeat>,Repository<UnAllocatedSeat>>();
builder.Services.AddSingleton<IRepository<AllocatedSeat>,Repository<AllocatedSeat>>();

builder.Services.AddSingleton < ICity,CityService>();
builder.Services.AddSingleton < IBuilding,BuildingService>();
builder.Services.AddSingleton < IFacility,FacilityService>();
builder.Services.AddSingleton < IDepartment,DepartmentService>();
builder.Services.AddSingleton < IEmployee,EmployeeService>();
builder.Services.AddSingleton < IAsset,AssetsService>();
builder.Services.AddSingleton < IAssetType,AssetTypeService>();
builder.Services.AddSingleton < IMeetingroom,MeetingRoomTableService>();
builder.Services.AddSingleton < ISeat,SeatService>();
builder.Services.AddSingleton < ICabin,CabinService>();
builder.Services.AddSingleton < IReportCall,SeatReportService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
