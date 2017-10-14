[<AutoOpen>]
module ResultOperations

let succeed input = Success (input, [])

let appendMessages messages = function
    | Success (value, existingMessages) -> Success (value, existingMessages @ messages) 
    | Failure error -> Failure error 

let map f = function
    | Success (value, messages) -> Success (f value, messages)
    | Failure error -> Failure error

let bind f = function
    | Success (value, messages) -> f value |> appendMessages messages
    | Failure error -> Failure error

let consider f (errorFrom, warningTo) = function
    | Success (value, warnings) -> 
        let result = f value
        match result with
        | Success (_,_) -> 
            Success (value, warnings)
        | Failure error when error = errorFrom -> 
            Success (value, (warningTo :: warnings))
        | Failure error -> 
            Failure error
    | Failure error -> 
        Failure error

let liftInternalError = function
    | Success (value, messages) -> Success (value, messages)
    | Failure error             -> Failure (InternalError error)

let liftExternalError = function
    | Success (value, messages) -> Success (value, messages)
    | Failure error             -> Failure (ExternalError error)

let liftI f = f >> liftInternalError
let liftE f = f >> liftExternalError

let bindI f = bind <| liftI f
let bindE f = bind <| liftE f

let considerI f = consider <| liftI f
let considerE f = consider <| liftE f

// for tests
let ExtractSuccess = function | Success (x,_) -> x | Failure _ -> failwith "Expected Success here"
let ExtractFailure = function | Failure  x    -> x | Success _ -> failwith "Expected Failure here"
