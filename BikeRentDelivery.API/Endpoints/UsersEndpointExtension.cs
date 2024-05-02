namespace BikeRentDelivery.API.Endpoints;

public static class UsersEndpointExtension
{
    public static WebApplication AddUsersEndpoints(this WebApplication app)
    {
        //app.GetArtists();
        //app.GetArtistsByName();
        //app.PostArtist();
        //app.UpdateArtist();
        //app.DeleteArtist();

        return app;
    }

    //private static void GetArtists(this WebApplication app) =>
    //    app.MapGet("/artists", (
    //        [FromServices] IGenericRepository<Artist> repository) =>
    //    {
    //        var artists = repository.GetAll();

    //        var artistsResponse = artists.ToModel();

    //        return Results.Ok(artistsResponse);
    //    });

    //private static void GetArtistsByName(this WebApplication app) =>
    //    app.MapGet("/artists/{name}", (
    //        [FromServices] IGenericRepository<Artist> repository,
    //        string name) =>
    //    {
    //        var artist = repository.GetBy(a => string.Equals(a.Name, name, StringComparison.OrdinalIgnoreCase));

    //        if (artist is null)
    //            return Results.NotFound();

    //        var artistResponse = artist.ToModel();

    //        return Results.Ok(artistResponse);
    //    });

    //private static void PostArtist(this WebApplication app) =>
    //    app.MapPost("/artists", async (
    //        [FromServices] IHostEnvironment env,
    //        [FromServices] IGenericRepository<Artist> repository,
    //        [FromBody] CreateArtistRequest request) =>
    //    {
    //        var artist = new Artist(request.Name, request.Bio);

    //        await UploadProfilePhoto(request, env, artist);

    //        repository.Add(artist);

    //        return Results.Ok(request);
    //    });

    //private static void UpdateArtist(this WebApplication app) =>
    //    app.MapPut("/artists/{id}", (
    //        [FromServices] IGenericRepository<Artist> repository,
    //        int id,
    //        [FromBody] UpdateArtistRequest request) =>
    //    {
    //        var artist = new Artist(request.Name, request.Bio) { Id = id };

    //        repository.Update(artist);

    //        return Results.NoContent();
    //    });

    //private static void DeleteArtist(this WebApplication app) =>
    //    app.MapDelete("/artists/{id}", (
    //        [FromServices] IGenericRepository<Artist> repository,
    //        int id) =>
    //    {
    //        repository.Delete(id);

    //        return Results.NoContent();
    //    });

    //private static async Task UploadProfilePhoto(CreateArtistRequest request, IHostEnvironment env, Artist artist)
    //{
    //    var name = request.Name.Trim();
    //    var profilePhotoFileName = $"{DateTime.Now:yyyyMMddHHmm}.{name}.jpeg";

    //    var profilePhotoFullPath = Path.Combine(env.ContentRootPath, "wwwroot", "images", "profilePhotos", profilePhotoFileName);

    //    using var memoryStream = new MemoryStream(Convert.FromBase64String(request.ProfilePhoto!));
    //    using var fileStream = new FileStream(profilePhotoFullPath, FileMode.Create);
    //    await memoryStream.CopyToAsync(fileStream);

    //    artist.AddProfilePhoto(profilePhotoFileName);
    //}
}