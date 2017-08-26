module EngineTests

open System
open Xunit
open Engine

[<Fact>]
let GetsNumberOfHarmonies() =
    let chords = ["Am"; "Dm"; "Em"]
    let expected = 3

    let actual = chords |> GetNumberOfHarmonies |> ExtractSuccess
    
    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfHarmoniesWhenDuplicates() =
    let chords = ["Am"; "Dm"; "Em"; "Dm"]
    let expected = 3

    let actual = chords |> GetNumberOfHarmonies |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfChordsWhenSuspends() =
    let chords = [ "A"; "Asus2"; "E"; "Esus4"; ]
    let expected = 2

    let actual = chords |> GetNumberOfHarmonies |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfChordsWhenPowers() =
    let chords = [ "A"; "A5"; "E"; "E5"; ]
    let expected = 2

    let actual = chords |> GetNumberOfHarmonies |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfHarmoniesWhenFlavours() =
    let chords = ["A"; "Amaj7"; "D"; "E"; "Bm"]
    let expected = 4

    let actual = chords |> GetNumberOfHarmonies |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfHarmoniesWhenZeroChords() =
    let chords = []
    let expected = 0

    let actual = chords |> GetNumberOfHarmonies |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesUnknownFlavours() =
    let chords = ["A"; "Glass"]
    let expected = UnknownFlavour

    let actual = chords |> GetNumberOfHarmonies |> ExtractFailure

    Assert.Equal(expected, actual)

[<Fact>]
let ThrowsForNotChords() =
    let chords = [ "Random" ]

    let action = fun () -> GetNumberOfHarmonies chords |> ignore
    
    Assert.Throws<ArgumentException> action