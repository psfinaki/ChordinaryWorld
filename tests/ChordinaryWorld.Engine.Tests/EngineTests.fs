module EngineTests

open Xunit
open Engine

[<Fact>]
let GetsNumberOfHarmonies() =
    let chords = ["Am"; "Dm"; "Em"]
    let expected = 3

    let actual = chords |> GetNumberOfHarmonies |> function | Success x -> x

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfHarmoniesWhenDuplicates() =
    let chords = ["Am"; "Dm"; "Em"; "Dm"]
    let expected = 3

    let actual = chords |> GetNumberOfHarmonies |> function | Success x -> x

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfChordsWhenSuspends() =
    let chords = [ "A"; "Asus2"; "E"; "Esus4"; ]
    let expected = 2

    let actual = chords |> GetNumberOfHarmonies |> function | Success x -> x

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfChordsWhenPowers() =
    let chords = [ "A"; "A5"; "E"; "E5"; ]
    let expected = 2

    let actual = chords |> GetNumberOfHarmonies |> function | Success x -> x

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfHarmoniesWhenFlavours() =
    let chords = ["A"; "Amaj7"; "D"; "E"; "Bm"]
    let expected = 4

    let actual = chords |> GetNumberOfHarmonies |> function | Success x -> x

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesUnknownFlavours() =
    let chords = ["A"; "Glass"]
    let expected = UnknownFlavour

    let actual = chords |> GetNumberOfHarmonies |> function | Failure x -> x

    Assert.Equal(expected, actual)