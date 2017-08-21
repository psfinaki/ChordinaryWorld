[<AutoOpen>]
module Types

type ErrorMessage =
    | ChordsNotFound
    | EmptyInput
    | UnknownFlavour

type Result<'TEntity> =
    | Success of 'TEntity
    | Failure of ErrorMessage
