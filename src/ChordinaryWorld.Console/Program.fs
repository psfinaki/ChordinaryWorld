﻿open System

let GetUserInput() = 
    printfn "Select the feature:"
    printfn "1 - Get number of harmonies"

    let choice = Console.ReadLine()
    printfn ""

    choice

let TranslateUserInput = function
    | "1" -> Some Features.GetNumberOfHarmonies
    |  _  -> None

[<EntryPoint>]
let main argv = 
    printfn "Welcome to the Chordinary World!"
    printfn ""

    let inputGenerator _ = GetUserInput() 

    let feature =     
        inputGenerator
        |> Seq.initInfinite
        |> Seq.map TranslateUserInput
        |> Seq.find (fun x -> x.IsSome)
        |> Option.get

    while true do 
        feature()
        printfn ""
    
    0
