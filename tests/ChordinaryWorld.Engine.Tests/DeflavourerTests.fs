module DeflavourerTests

open Xunit

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

    Assert.Equal(expected, actual.Value)

[<Fact>]
let HandlesUnknownChord() =
    let chord = "F#UNKNOWN"
    
    let result = Deflavourer.DeflavourChord chord

    Assert.True(result.IsNone)

[<Fact>]
let Deflavours() =
    let chords = ["E"; "E7"; "Dm"; "Dadd9"]
    let expected = ["E"; "Dm"; "D"]

    let actual = Deflavourer.Deflavour chords

    Assert.Equal(expected, actual)

[<Fact>]
let SkipsUnknownChords() =
    let chords = ["E"; "F#Weird"; "Dm"; "BbmWrong"]
    let expected = ["E"; "Dm"]

    let actual = Deflavourer.Deflavour chords

    Assert.Equal(expected, actual)