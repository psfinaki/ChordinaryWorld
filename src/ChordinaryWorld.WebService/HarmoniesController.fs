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
        | Failure message -> 
            match message with
            | EmptyInput
            | UnknownFlavours _
            | ChordsNotFound ->
                x.BadRequest(message.GetErrorName())
                :> IHttpActionResult
            | UnknownDatabaseError ->
                failwith "This must not happen here"
