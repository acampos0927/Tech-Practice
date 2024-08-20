// using Microsoft.EntityFrameworkCore;
// using Microsoft.OpenApi.Models;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddDbContext<MetalMusicContext>(opt =>
//     opt.UseInMemoryDatabase("MetalMusic"));

// // Add Swagger services
// builder.Services.AddEndpointsApiExplorer(); // Adds support for API documentation
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Metal Music API", Version = "v1" });
// });

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     // Enable middleware to serve generated Swagger as a JSON endpoint.
//     app.UseSwagger();

//     // Enable middleware to serve Swagger UI, specifying the Swagger JSON endpoint.
//     app.UseSwaggerUI(c =>
//     {
//         c.SwaggerEndpoint("/swagger/v1/swagger.json", "Metal Music API V1");
//     });
// }

// app.MapGet("/bands", async (MetalMusicContext db) =>
//     await db.Bands.Include(b => b.Albums).ThenInclude(a => a.Songs).ToListAsync());

// app.MapGet("/bands/{id}", async (int id, MetalMusicContext db) =>
//     await db.Bands.Include(b => b.Albums).ThenInclude(a => a.Songs).FirstOrDefaultAsync(b => b.BandId == id)
//         is Band band
//             ? Results.Ok(band)
//             : Results.NotFound());

// app.MapPost("/bands", async (Band band, MetalMusicContext db) =>
// {
//     db.Bands.Add(band);
//     await db.SaveChangesAsync();
//     return Results.Created($"/bands/{band.BandId}", band);
// });

// app.MapPut("/bands/{id}", async (int id, Band inputBand, MetalMusicContext db) =>
// {
//     var band = await db.Bands.FindAsync(id);

//     if (band is null) return Results.NotFound();

//     band.Name = inputBand.Name;
//     band.Genre = inputBand.Genre;
//     band.FormationDate = inputBand.FormationDate;

//     await db.SaveChangesAsync();

//     return Results.NoContent();
// });

// app.MapDelete("/bands/{id}", async (int id, MetalMusicContext db) =>
// {
//     if (await db.Bands.FindAsync(id) is Band band)
//     {
//         db.Bands.Remove(band);
//         await db.SaveChangesAsync();
//         return Results.Ok(band);
//     }

//     return Results.NotFound();
// });

// // Similar endpoints can be created for Albums and Songs

// app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Update the database context to EmployeeContext
builder.Services.AddDbContext<EmployeeContext>(opt =>
    opt.UseInMemoryDatabase("EmployeeDB"));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
    });
}

// Define endpoints for employees
app.MapGet("/employees", async (EmployeeContext db) =>
    await db.Employees.Include(e => e.Department).ToListAsync());

app.MapGet("/employees/{id}", async (int id, EmployeeContext db) =>
    await db.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.EmployeeId == id)
        is Employee employee
            ? Results.Ok(employee)
            : Results.NotFound());

app.MapPost("/employees", async (Employee employee, EmployeeContext db) =>
{
    db.Employees.Add(employee);
    await db.SaveChangesAsync();
    return Results.Created($"/employees/{employee.EmployeeId}", employee);
});

app.MapPut("/employees/{id}", async (int id, Employee inputEmployee, EmployeeContext db) =>
{
    var employee = await db.Employees.FindAsync(id);

    if (employee is null) return Results.NotFound();

    employee.Name = inputEmployee.Name;
    employee.Position = inputEmployee.Position;
    employee.Department = inputEmployee.Department;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/employees/{id}", async (int id, EmployeeContext db) =>
{
    if (await db.Employees.FindAsync(id) is Employee employee)
    {
        db.Employees.Remove(employee);
        await db.SaveChangesAsync();
        return Results.Ok(employee);
    }

    return Results.NotFound();
});

// Define endpoints for employee IDs
app.MapGet("/employeeIDs", async (EmployeeContext db) =>
    await db.EmployeeIDs.Include(ei => ei.Employee).ToListAsync());

app.MapGet("/employeeIDs/{id}", async (int id, EmployeeContext db) =>
    await db.EmployeeIDs.Include(ei => ei.Employee).FirstOrDefaultAsync(ei => ei.EmployeeIDId == id)
        is EmployeeID employeeID
            ? Results.Ok(employeeID)
            : Results.NotFound());

app.MapPost("/employeeIDs", async (EmployeeID employeeID, EmployeeContext db) =>
{
    db.EmployeeIDs.Add(employeeID);
    await db.SaveChangesAsync();
    return Results.Created($"/employeeIDs/{employeeID.EmployeeIDId}", employeeID);
});

app.MapPut("/employeeIDs/{id}", async (int id, EmployeeID inputEmployeeID, EmployeeContext db) =>
{
    var employeeID = await db.EmployeeIDs.FindAsync(id);

    if (employeeID is null) return Results.NotFound();

    employeeID.IDNumber = inputEmployeeID.IDNumber;
    employeeID.IssueDate = inputEmployeeID.IssueDate;
    employeeID.EmployeeId = inputEmployeeID.EmployeeId;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/employeeIDs/{id}", async (int id, EmployeeContext db) =>
{
    if (await db.EmployeeIDs.FindAsync(id) is EmployeeID employeeID)
    {
        db.EmployeeIDs.Remove(employeeID);
        await db.SaveChangesAsync();
        return Results.Ok(employeeID);
    }

    return Results.NotFound();
});

app.Run();
