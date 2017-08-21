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