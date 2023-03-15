module Program

open System
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open HEPHAISTOS

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(fun webBuilder ->
            webBuilder.UseStartup<Startup>() |> ignore
        )
        .Build()
        .Run()
    0
