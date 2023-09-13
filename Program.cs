using System.Reflection;
using FluentMigrator.Runner;
using Infrastructure.Database.Context;
using PocFluentMigration.Infrastructure.Database;
using PocFluentMigration.Infrastructure.Database.Enum;
using PocFluentMigration.Infrastructure.Database.Extensions;
using PocFluentMigration.Infrastructure.Database.Migrations;
using PocFluentMigration.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<DatabaseManager>();
builder.Services.AddSingleton<ConnectionFactory>();
builder.Services.AddSingleton<IStateRepository, StateRepository>();

var adapter = builder.Configuration.GetConnectionString("Adapter");
var sqlConnection = builder.Configuration.GetConnectionString("SqlConnection");
var assemblyMigrations = Assembly.GetAssembly(typeof(DatabaseManager));

if (adapter == nameof(RDBMS.MYSQL))
{
    builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(cr => cr.AddMySql5()
            .WithGlobalConnectionString(sqlConnection)
            .ScanIn(assemblyMigrations).For.Migrations());
}

else if (adapter == nameof(RDBMS.POSTGRESQL))
{
    builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(cr => cr.AddPostgres()
            .WithGlobalConnectionString(sqlConnection)
            .ScanIn(assemblyMigrations).For.Migrations());
}

else
{
    builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(cr => cr.AddSqlServer2016()
            .WithGlobalConnectionString(sqlConnection)
            .ScanIn(assemblyMigrations).For.Migrations());
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MigrateDatabase();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
