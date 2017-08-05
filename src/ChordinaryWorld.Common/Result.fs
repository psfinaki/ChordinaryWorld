module Result

type ErrorMessage =
    | ChordsNotFound
    | EmptyInput

type Result<'TEntity> =
    | Success of 'TEntity
    | Failure of ErrorMessage
