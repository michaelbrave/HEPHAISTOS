namespace HEPHAISTOS.Pages


open System
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Mvc.RazorPages
open Microsoft.AspNetCore.Http

type ClickCounterModel() =
    inherit PageModel()

    member this.OnGet() = ()

    [<HttpPost>]
    member this.OnPostIncrement() =
        let mutable clickCount = this.HttpContext.Session.GetInt32("clickCount").GetValueOrDefault(0)
        clickCount <- clickCount + 1
        this.HttpContext.Session.SetInt32("clickCount", clickCount)
        JsonResult(clickCount) // Use JsonResult to return a JSON object