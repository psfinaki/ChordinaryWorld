module Validator

open System
open Result

let Validate input =
    if String.IsNullOrWhiteSpace input
    then Failure EmptyInput
    else Success input 

let ValidateSong (artist, title) =
    (Validate artist, Validate title)
    |> function
        | (Success x, Success y) 
            -> Success (x,y)
        | (Failure z, _) | (_, Failure z) 
            -> Failure z