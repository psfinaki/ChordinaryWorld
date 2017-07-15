﻿module SieveTests

open Xunit

[<Fact>]
let RemovesSuspends() =
    let chords = ["A"; "Asus2"; "Dsus4"; "D"; "E7sus4"; "E7"]
    let expected = ["A"; "D"; "E7"]

    let actual = Sieve.RemoveSuspends chords

    Assert.Equal(expected, actual)

[<Fact>]
let RemovesPowers() =
    let chords = ["E"; "D"; "E5"]
    let expected = ["E"; "D"]

    let actual = Sieve.RemovePowers chords

    Assert.Equal(expected, actual)