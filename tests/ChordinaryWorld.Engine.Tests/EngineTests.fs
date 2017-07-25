module EngineTests

open Xunit

[<Fact>]
let GetsNumberOfHarmonies() =
    let chords = ["Am"; "Dm"; "Em"]
    let expected = 3

    let actual = Engine.GetNumberOfHarmonies chords

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfHarmoniesWhenDuplicates() =
    let chords = ["Am"; "Dm"; "Em"; "Dm"]
    let expected = 3

    let actual = Engine.GetNumberOfHarmonies chords

    Assert.Equal(expected, actual)

[<Fact>]
let GetsNumberOfHarmoniesWhenFlavours() =
    let chords = ["A"; "Amaj7"; "D"; "E"; "Bm"]
    let expected = 4

    let actual = Engine.GetNumberOfHarmonies chords

    Assert.Equal(expected, actual)