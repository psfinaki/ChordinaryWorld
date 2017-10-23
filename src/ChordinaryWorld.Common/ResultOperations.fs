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

// for tests
let ExtractSuccess = function | Success (x,_) -> x | Failure _ -> failwith "Expected Success here"
let ExtractFailure = function | Failure  x    -> x | Success _ -> failwith "Expected Failure here"
