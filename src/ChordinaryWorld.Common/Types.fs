[<AutoOpen>]
module Types

open Microsoft.FSharp.Reflection

type ErrorMessage =
    | ChordsNotFound
    | EmptyInput
    | UnknownFlavours of seq<string>
    | UnknownDatabaseError

    // inspiration: https://stackoverflow.com/a/1259500/3232646
    member x.GetErrorName() = 
        match FSharpValue.GetUnionFields(x, x.GetType()) with
        | (case, _) -> case.Name  

type Result<'TSuccess,'TMessage> =
    | Success of 'TSuccess * 'TMessage list
    | Failure of 'TMessage