module Result

type ErrorMessage =
    | ChordsNotFound

type Result<'TEntity> =
    | Success of 'TEntity
    | Failure of ErrorMessage
