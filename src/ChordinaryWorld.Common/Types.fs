[<AutoOpen>]
module Types

type InternalError = 
    | UnknownFlavours of seq<string>
    | UnknownDatabaseError

type ExternalError =
    | ChordsNotFound
    | EmptyInput

type Warning =
    | UnknownDatabaseIssue

type Error =
    | ExternalError of ExternalError
    | InternalError of InternalError

type Result<'TSuccess,'TWarning,'TError> =
    | Success of 'TSuccess * 'TWarning list
    | Failure of 'TError