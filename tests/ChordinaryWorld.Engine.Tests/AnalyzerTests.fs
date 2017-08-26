module AnalyzerTests

open System
open Xunit
open Analyzer
   
[<Fact>]
let AnalyzesNaturalChord() =
    let chord = "E7"
    let expected = ("E", "7")

    let actual = AnalyzeChord chord
    
    Assert.Equal(expected, actual)

[<Fact>]
let AnalyzesSharpChord() =
    let chord = "E#7"
    let expected = ("E#", "7")

    let actual = AnalyzeChord chord
    
    Assert.Equal(expected, actual)

[<Fact>]
let AnalyzesFlatChord() =
    let chord = "Eb7"
    let expected = ("Eb", "7")

    let actual = AnalyzeChord chord
    
    Assert.Equal(expected, actual)

[<Fact>]
let ThrowsForNotAChord() =
    let chord = "Uprising"

    let action = fun () -> AnalyzeChord chord |> ignore
    
    Assert.Throws<ArgumentException> action
