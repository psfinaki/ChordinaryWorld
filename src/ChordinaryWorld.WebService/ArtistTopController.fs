module ArtistTopController

open System.Web.Http

type ArtistTopController() =
    inherit ApiController()

    member x.Get artist =
        let Unnullify s = if s = null then "" else s 

        let result = artist |> Unnullify |> Core.GetArtistTop

        match result with
        | Success (top,_) ->
            x.Ok top
            :> IHttpActionResult
        | Failure error ->
            match error with
            | BadArtist ->
                x.BadRequest()
                :> IHttpActionResult
            | NoTabsFound ->
                x.NotFound()
                :> IHttpActionResult
            | TabsUnuavailable
            | BadTabs ->
                x.InternalServerError()
                :> IHttpActionResult