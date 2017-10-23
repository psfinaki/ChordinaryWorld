module internal Features

open System

let PrintResult 
        printSuccess 
        (errorTranslator: 'x -> string) 
        (warningTranslator : 'y -> string) = function
    | Success (value, warnings) -> 
        printSuccess value

        warnings 
        |> Seq.map warningTranslator 
        |> Seq.iter Console.WriteLine

    | Failure error -> 
        error 
        |> errorTranslator
        |> Console.WriteLine

let PlayFeature feature inputProvider outputFormatter errorTranslator warningTranslator =
    inputProvider()
    |> feature
    |> PrintResult outputFormatter errorTranslator warningTranslator