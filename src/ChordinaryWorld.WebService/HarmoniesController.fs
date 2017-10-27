module HarmoniesController

open System.Web.Http

type HarmoniesController() =
    inherit ApiController()

    member x.Get(artist, title) =
        let Unnullify s = if s = null then "" else s 

        let result = 
            (Unnullify artist, Unnullify title)
            |> Core.GetNumberOfHarmonies

        match result with
        | Success (harmonies, _) -> 
            x.Ok harmonies 
            :> IHttpActionResult
        | Failure error -> 
            match error with
            | EmptyInput ->
                x.BadRequest()
                :> IHttpActionResult
            | ChordsNotFound ->
                x.NotFound()
                :> IHttpActionResult
            | ChordsNotAvailable
            | UnknownFlavours _
            | UnknownDatabaseErrorHarmonies ->
                x.InternalServerError()
                :> IHttpActionResult
