[<AutoOpen>]
module Types

open Microsoft.FSharp.Reflection

type Warning =
    | UnknownDatabaseIssue

type Error =
    | ChordsNotFound
    | EmptyInput
    | UnknownFlavours of seq<string>

    // inspiration: https://stackoverflow.com/a/1259500/3232646
    member x.GetErrorName() = 
        match FSharpValue.GetUnionFields(x, x.GetType()) with
        | (case, _) -> case.Name  

type Result<'TSuccess,'TWarning,'TError> =
    | Success of 'TSuccess * 'TWarning list
    | Failure of 'TError