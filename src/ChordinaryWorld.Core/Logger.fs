module internal Logger

open System
open System.Diagnostics

let LogError = Trace.TraceError
let DoNotLog = ()

let LogHarmonies (artist, title) result =
    let Log message =
        String.Format("{0} - {1} - {2}", artist, title, message) 
        |> LogError 

    match result with
    | Success (_, messages) -> 
        let handle = function
        | UnknownDatabaseIssue ->
            Log "Something bad happened in database"

        Seq.iter handle messages

    | Failure error ->
        match error with
        | ChordsNotFound ->
            Log "Chords not found"
        | EmptyInput ->
            DoNotLog
        | UnknownFlavours flavours -> 
            Log ("Unknown flavours: " + (Seq.toList flavours).ToString())
        | UnknownDatabaseErrorHarmonies ->
            Log "Something very bad happened in database"
        | ChordsNotAvailable ->
            Log "Problems with chords provider"

let LogCount count result =
    let Log message =
        String.Format("{0} - {1}", count, message) 
        |> LogError 

    match result with
    | Success (_,_) -> 
        DoNotLog
    | Failure error ->
        match error with
        | NegativeCount -> 
            Log "Negative count"
        | TooBigCount -> 
            Log "Too big count"
        | UnknownDatabaseErrorTop -> 
            Log "Something bad happened in the database"

let LogArtist artist result =
    let Log message =
        String.Format("{0} - {1}", artist, message) 
        |> LogError 

    match result with
    | Success (_,_) -> 
        DoNotLog
    | Failure error ->
        match error with
        | BadArtist ->
            Log "Invalid artist"
        | NoTabsFound ->
            Log "No chords found"
        | TabsUnavailable ->
            Log "Cannot reach chord provider"
        | BadTabs ->
            Log "All found tabs have problems"
