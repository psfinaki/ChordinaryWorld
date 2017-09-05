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
let GetsNumberOfChordsWhenFriendlySuspends() =
    let chords = [ "A"; "Asus2"; "E"; "Esus4"; ]
    let expected = 2

    let actual = chords |> GetNumberOfHarmonies |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfChordsWhenLonelySuspends() =
    let chords = [ "A"; "Asus2"; "E"; "Dsus4"; ]
    let expected = 3

    let actual = chords |> GetNumberOfHarmonies |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfChordsWhenFriendlyPowers() =
    let chords = [ "A"; "A5"; "E"; "E5"; ]
    let expected = 2

    let actual = chords |> GetNumberOfHarmonies |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfChordsWhenLonelyPowers() =
    let chords = [ "A"; "A5"; "E"; "D5"; ]
    let expected = 3

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

    let actual = chords |> GetNumberOfHarmonies |> ExtractFailure
    let result = actual |> function | UnknownFlavours _ -> true | _ -> false

    Assert.True(result)

[<Fact>]
let ThrowsForNotChords() =
    let chords = [ "Random" ]

    let action = fun () -> GetNumberOfHarmonies chords |> ignore
    
    Assert.Throws<ArgumentException> action