[<AutoOpen>]
module Auxiliary

let tupleMap f (a, b) = (f a, f b)

let mapZip f sequence = 
    sequence
    |> Seq.map f
    |> Seq.zip sequence

let choose2 f = 
    Seq.filter (fun (_, v) ->  Option.isSome (f v))
    >> Seq.map (fun (k, v) -> (k, Option.get (f v)))
