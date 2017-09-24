module internal Validator

open System

let Validate input =
    if String.IsNullOrWhiteSpace input
    then Failure EmptyInput
    else succeed input 

let ValidateSong (artist, title) =
    (Validate artist, Validate title)
    |> function
        | (Success (x,_), Success (y,_)) 
            -> succeed (x,y)
        | (Failure z, _) | (_, Failure z) 
            -> Failure z