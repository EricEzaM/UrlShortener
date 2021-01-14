# URL Shortener in .NET 5

Really simple URL shortener. No fancy validation or anything at this stage. Basically just a simple project with a View, some API routes, a database connection (using EF Core) and docker for quick no-mess development.

I manually apply migrations to the database by using `Add-Migration` and then `Script-Migration`, rather than `Update-Database` so that there is transparency over what EF is doing when making migrations, and manual control is retained.

**Example Screenshot**

![Example Screenshot](/assets/shortener_snap.png)

### To Run

1. Have Docker and .NET 5 Installed
1. From root directory, start up database using `docker-compose -f database/docker-compose.yml up`
1. Start application using `dotnet run --project src/UrlShortener/UrlShortener.csproj`
1. Navigate to `localhost:5001` for the app, `localhost:8080` for adminer (to explore the database; use username & password "postgres"), and you can use API endpoints of `/shortener` (post, body="link") and `/{shortenedKey}` (get).

### Future Features to add...?

- [ ] Better validation
- [ ] Checking against Google API of malware/blacklisted sites
- [ ] User accounts 
- [ ] Custom URL - make your own URL rather than an auto-generated one
- [ ] Click counter - how often was a link clicked?