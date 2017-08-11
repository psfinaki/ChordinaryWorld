module DeflavourerTests

open Xunit
open System.Collections.Generic
open Result

[<Theory>]
[<InlineData("A", "A")>]
[<InlineData("A#6", "A#")>]
[<InlineData("B6", "B")>]
[<InlineData("C7", "C")>]
[<InlineData("Dm", "Dm")>]
[<InlineData("D#m6", "D#m")>]
[<InlineData("Em7", "Em")>]
[<InlineData("Fm9", "Fm")>]
[<InlineData("Gaug", "Gaug")>]
[<InlineData("G#dim", "G#dim")>]
let DeflavoursChord(chord, deflavoured) =
    let expected = deflavoured

    let actual = Deflavourer.DeflavourChord chord

    Assert.Equal(expected, actual)

[<Fact>]
let ThrowsForUnknownFlavour() =
    let chord = "F#UNKNOWN"
    
    let action = fun () -> Deflavourer.DeflavourChord chord |> ignore

    Assert.Throws<KeyNotFoundException> action

[<Fact>]
let Deflavours() =
    let chords = ["E"; "E7"; "Dm"; "Dadd9"]
    let expected = ["E"; "Dm"; "D"]

    let actual = chords |> Deflavourer.Deflavour |> function | Success(x) -> x

    Assert.Equal(expected, actual)

[<Fact>]
let HandlesUnknownFlavours() =
    let chords = ["E"; "F#Weird"; "Dm"; "BbmWrong"]
    let expected = UnknownFlavour

    let actual = chords |> Deflavourer.Deflavour |> function | Failure(x) -> x

    Assert.Equal(expected, actual)