[<AutoOpen>]
module Operations

let map f input = 
    match input with
    | Success x -> Success (f x)
    | Failure y -> Failure y

let bind f input = 
    match input with
    | Success x -> f x
    | Failure y -> Failure y

let cartesian xs ys =
    seq {
        for x in xs do
        for y in ys do
            yield (x, y)
    }

// for tests
let ExtractSuccess = function | Success x -> x | Failure _ -> failwith "Expected Success here"
let ExtractFailure = function | Failure x -> x | Success _ -> failwith "Expected Failure here"
