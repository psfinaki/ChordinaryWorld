[<AutoOpen>]
module Auxiliary

let cartesian xs ys =
    seq {
        for x in xs do
        for y in ys do
            yield (x, y)
    }

let tupleMap f (a, b) = (f a, f b)
