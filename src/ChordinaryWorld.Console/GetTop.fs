module internal GetTop

open System

let GetCount() = 
    printfn "Enter top count"
    int <| Console.ReadLine()

let PrintTop top = 
    printfn "Here is the top:"
    top |> Seq.iter (printfn "%A")

let TranslateError = function
    | NegativeCount -> 
        "Negative count is not allowed"
    | TooBigCount ->
        "Rating count is too big"
    | UnknownDatabaseErrorTop -> 
        "Something bad happened in the database"

let TranslateWarning = function 
    | UnknownDatabaseIssue -> 
        "Something bad happened in database"

let Play() =
    Features.PlayFeature 
        Core.GetTop 
        GetCount 
        PrintTop 
        TranslateError
        TranslateWarning