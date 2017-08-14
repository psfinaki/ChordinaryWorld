[<AutoOpen>]
module AbstractOperations

let map f input = 
    match input with
    | Success x -> Success (f x)
    | Failure y -> Failure y

let bind f input = 
    match input with
    | Success x -> f x
    | Failure y -> Failure y