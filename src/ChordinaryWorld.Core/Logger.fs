module internal Logger

open System
open System.Diagnostics

let LogError = Trace.TraceError

let LogSongError (artist, title) message =
    String.Format("{0} - {1} - {2}", artist, title, message) 
    |> LogError 

let Log song result =
    match result with
    | Success (_, messages) -> 
        let handleMessage = function
            | UnknownDatabaseError ->
                "Something bad happened in database"
                |> LogSongError song
            | UnknownFlavours _
            | ChordsNotFound
            | EmptyInput ->
                failwith "This must not happen here"

        Seq.iter handleMessage messages
    | Failure message ->
        let handleMessage = function 
            | UnknownFlavours flavours -> 
                "Unknown flavours: " + (Seq.toList flavours).ToString()
                |> LogSongError song
            | ChordsNotFound ->
                "Chords not found"
                |> LogSongError song
            | EmptyInput ->
                ()
            | UnknownDatabaseError ->
                failwith "This must not happen here"

        handleMessage message

    result