[<AutoOpen>]
module Auxiliary

let tupleMap f (a, b) = (f a, f b)

let mapZip f sequence = 
    sequence
    |> Seq.map f
    |> Seq.zip sequence