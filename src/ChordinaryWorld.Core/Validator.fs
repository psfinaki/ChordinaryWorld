module internal Validator

open System

let Validate input =
    if String.IsNullOrWhiteSpace input
    then Failure EmptyInput
    else Success input 

let ValidateSong song =
    (Validate song.Artist, Validate song.Title)
    |> function
        | (Success x, Success y) 
            -> Success (Song.Create(x,y))
        | (Failure z, _) | (_, Failure z) 
            -> Failure z