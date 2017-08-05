module AbstractOperations

open Result

let map f input = 
    match input with
    | Success x -> Success (f x)
    | Failure y -> Failure y