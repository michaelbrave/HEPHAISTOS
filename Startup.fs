namespace HEPHAISTOS

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

type Startup(env: IWebHostEnvironment) =
    let configuration = ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional = false, reloadOnChange = true).AddJsonFile(sprintf "appsettings.%s.json" env.EnvironmentName, optional = true).AddEnvironmentVariables().Build()

    member __.ConfigureServices(services: IServiceCollection) =
        // Add services to the container.
        services.AddControllersWithViews() |> ignore

    member __.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage() |> ignore
        else
            app.UseExceptionHandler("/Home/Error") |> ignore
            // The default HSTS value is 30 days. You may want to change this for production scenarios.
            app.UseHsts() |> ignore

        app.UseHttpsRedirection() |> ignore
        app.UseStaticFiles() |> ignore

        app.UseRouting() |> ignore

        app.UseAuthorization() |> ignore

        app.UseEndpoints(fun endpoints ->
            endpoints.MapControllerRoute(name = "default", pattern = "{controller=Home}/{action=Index}/{id?}") |> ignore
        ) |> ignore
