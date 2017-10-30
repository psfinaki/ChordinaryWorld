module internal Logger

open System
open System.Diagnostics

let LogError = Trace.TraceError

let LogHarmonies song result =
    let log (artist, title) message =
        String.Format("{0} - {1} - {2}", artist, title, message) 
        |> LogError 

    match result with
    | Success (_, messages) -> 
        let handle = function
            | UnknownDatabaseIssue ->
                "Something bad happened in database"
                |> log song

        Seq.iter handle messages
    | Failure error ->
        let handle = function
            | ChordsNotFound ->
                "Chords not found"
                |> log song
            | EmptyInput ->
                ()
            | UnknownFlavours flavours -> 
                "Unknown flavours: " + (Seq.toList flavours).ToString()
                |> log song
            | UnknownDatabaseErrorHarmonies ->
                "Something very bad happened in database"
                |> log song
            | ChordsNotAvailable ->
                "Problems with chords provider"
                |> log song

        handle error

let LogCount count result =
    let log count message =
        String.Format("{0} - {1}", count, message) 
        |> LogError 

    match result with
    | Success (_,_) -> 
        ()
    | Failure error ->
        let handle = function
            | NegativeCount -> 
                "Negative count"
                |> log count
            | TooBigCount -> 
                "Too big count"
                |> log count
            | UnknownDatabaseErrorTop -> 
                "Something bad happened in the database"
                |> log count

        handle error

