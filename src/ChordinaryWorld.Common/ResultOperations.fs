[<AutoOpen>]
module ResultOperations

let succeed input = Success (input, [])

let appendMessages messages input = 
    match input with
    | Success (value, existingMessages) -> Success (value, existingMessages @ messages) 
    | Failure message -> Failure message 

let map f input = 
    match input with
    | Success (value, messages) -> Success (f value, messages)
    | Failure message -> Failure message

let bind f input = 
    match input with
    | Success (value, messages) -> f value |> appendMessages messages
    | Failure message -> Failure message

let consider f input = 
    match input with
    | Success (value, messages) -> 
        let result = f value
        match result with
        | Success (_,_) -> Success (value, messages)
        | Failure message -> Success (value, (message :: messages))
    | Failure message -> 
        Failure message

// for tests
let ExtractSuccess = function | Success (x,_) -> x | Failure _ -> failwith "Expected Success here"
let ExtractFailure = function | Failure  x    -> x | Success _ -> failwith "Expected Failure here"
