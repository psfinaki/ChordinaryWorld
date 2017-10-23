module TopController

open System.Web.Http

type TopController() =
    inherit ApiController()

    member x.Get count =
        let result = Core.GetTop count

        match result with
        | Success (top,_) ->
            x.Ok top
            :> IHttpActionResult
        | Failure error ->
            match error with
            | InternalError error ->
                match error with
                | UnknownFlavours _
                | UnknownDatabaseError ->
                    x.InternalServerError()
                    :> IHttpActionResult
            | ExternalError error ->
                match error with
                | EmptyInput
                | ChordsNotFound 
                | NegativeCount ->
                    x.BadRequest()
                    :> IHttpActionResult
