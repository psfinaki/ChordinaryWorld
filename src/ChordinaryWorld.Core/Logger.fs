module internal Logger

open System
open NLog

let LogError (s: string) = (LogManager.GetCurrentClassLogger()).Error s

let LogSongError (artist, title) message =
    String.Format("{0} - {1} - {2}", artist, title, message) 
    |> LogError 

let Log song result =
    match result with
    | Failure (UnknownFlavours flavours) -> 
        "Unknown flavours: " + (Seq.toList flavours).ToString()
        |> LogSongError song
    | Failure ChordsNotFound ->
        "Chords not found"
        |> LogSongError song
    | _ -> 
        ()

    result