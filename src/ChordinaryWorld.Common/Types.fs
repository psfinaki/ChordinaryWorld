[<AutoOpen>]
module Types

type Warning =
    | UnknownDatabaseIssue

type HarmoniesError =
    | ChordsNotFound
    | EmptyInput
    | UnknownFlavours of seq<string>
    | UnknownDatabaseErrorHarmonies

type TopError =
    | NegativeCount
    | UnknownDatabaseErrorTop

type Result<'TSuccess,'TWarning,'TError> =
    | Success of 'TSuccess * 'TWarning list
    | Failure of 'TError