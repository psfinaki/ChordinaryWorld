module internal Validator

open System

let ValidateSongPart input =
    if String.IsNullOrWhiteSpace input
    then Failure EmptyInput
    else succeed input 

let ValidateSong (artist, title) =
    (ValidateSongPart artist, ValidateSongPart title)
    |> function
        | (Success (x,_), Success (y,_)) 
            -> succeed (x,y)
        | (Failure z, _) | (_, Failure z) 
            -> Failure z

let ValidateCount count = 
    if count < 0
    then Failure NegativeCount
    else succeed count
