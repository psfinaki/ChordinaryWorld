module AnalyzerTests

open Xunit
   
[<Fact>]
let AnalyzesNaturalChord() =
    let chord = "E7"
    let expected = ("E", "7")

    let actual = Analyzer.AnalyzeChord chord
    
    Assert.Equal(expected, actual)

[<Fact>]
let AnalyzesSharpChord() =
    let chord = "E#7"
    let expected = ("E#", "7")

    let actual = Analyzer.AnalyzeChord chord
    
    Assert.Equal(expected, actual)

[<Fact>]
let AnalyzesFlatChord() =
    let chord = "Eb7"
    let expected = ("Eb", "7")

    let actual = Analyzer.AnalyzeChord chord
    
    Assert.Equal(expected, actual)