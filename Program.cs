// using Microsoft.EntityFrameworkCore;


// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddDbContext<MetalMusicContext>(opt =>
//     opt.UseInMemoryDatabase("MetalMusic"));

// var app = builder.Build();

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

// Add services to the container.
builder.Services.AddDbContext<MetalMusicContext>(opt =>
    opt.UseInMemoryDatabase("MetalMusic"));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer(); // Adds support for API documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Metal Music API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve Swagger UI, specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Metal Music API V1");
    });
}

app.MapGet("/bands", async (MetalMusicContext db) =>
    await db.Bands.Include(b => b.Albums).ThenInclude(a => a.Songs).ToListAsync());

app.MapGet("/bands/{id}", async (int id, MetalMusicContext db) =>
    await db.Bands.Include(b => b.Albums).ThenInclude(a => a.Songs).FirstOrDefaultAsync(b => b.BandId == id)
        is Band band
            ? Results.Ok(band)
            : Results.NotFound());

app.MapPost("/bands", async (Band band, MetalMusicContext db) =>
{
    db.Bands.Add(band);
    await db.SaveChangesAsync();
    return Results.Created($"/bands/{band.BandId}", band);
});

app.MapPut("/bands/{id}", async (int id, Band inputBand, MetalMusicContext db) =>
{
    var band = await db.Bands.FindAsync(id);

    if (band is null) return Results.NotFound();

    band.Name = inputBand.Name;
    band.Genre = inputBand.Genre;
    band.FormationDate = inputBand.FormationDate;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/bands/{id}", async (int id, MetalMusicContext db) =>
{
    if (await db.Bands.FindAsync(id) is Band band)
    {
        db.Bands.Remove(band);
        await db.SaveChangesAsync();
        return Results.Ok(band);
    }

    return Results.NotFound();
});

// Similar endpoints can be created for Albums and Songs

app.Run();
