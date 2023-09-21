using MainAssessment;
using MainAssessment.Interface;
using MainAssessment.services;
using MainAssessment.Tables;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ManagementContext>(options =>
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection"), ServiceLifetime.Singleton);
builder.Services.AddSingleton<IRepository<CityLookup>,Repository<CityLookup>>();
builder.Services.AddSingleton<IRepository<Building>,Repository<Building>>();
builder.Services.AddSingleton<IRepository<Facility>,Repository<Facility>>();
builder.Services.AddSingleton<IRepository<Department>,Repository<Department>>();
builder.Services.AddSingleton<IRepository<Employee>,Repository<Employee>>();
builder.Services.AddSingleton<IRepository<AssetLookup>,Repository<AssetLookup>>();
builder.Services.AddSingleton<IRepository<Assets>,Repository<Assets>>();
builder.Services.AddSingleton<IRepository<MeetingRoomTable>,Repository<MeetingRoomTable>>();
builder.Services.AddSingleton<IRepository<SeatTable>,Repository<SeatTable>>();
builder.Services.AddSingleton<IRepository<CabinTable>,Repository<CabinTable>>();
builder.Services.AddSingleton<IRepository<UnAllocatedSeat>,Repository<UnAllocatedSeat>>();
builder.Services.AddSingleton<IRepository<AllocatedSeat>,Repository<AllocatedSeat>>();

builder.Services.AddSingleton < ICity,CityService>();
builder.Services.AddSingleton < IBuilding,BuildingService>();
builder.Services.AddSingleton < IFacility,FacilityService>();
builder.Services.AddSingleton < IDepartment,DepartmentService>();
builder.Services.AddSingleton < IEmployee,EmployeeService>();
builder.Services.AddSingleton < IAsset,AssetsService>();
builder.Services.AddSingleton < IAssetType,AssetLookupService>();
builder.Services.AddSingleton < IMeetingroom,MeetingRoomTableService>();
builder.Services.AddSingleton < ISeat,SeatTableService>();
builder.Services.AddSingleton < ICabin,CabinTableService>();
builder.Services.AddSingleton < IUnAllocatedReportCall,UnAllocatedService>();
builder.Services.AddSingleton < IAllocatedReportCall,AllocatedService>();
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
