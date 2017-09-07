module internal Logger

open System
open NLog

let LogError (s: string) = (LogManager.GetCurrentClassLogger()).Error s

let Log (artist, title) result =
    match result with
    | Failure (UnknownFlavours flavours) -> 
        let s = String.Format("{0} - {1} - Unknown flavours: {2}", artist, title, Seq.toList flavours)
        LogError s
    | _ -> 
        ()

    result