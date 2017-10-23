module ValidatorTests

open Xunit
open Validator

[<Fact>]
let ValidatesSongNormalInput() =
    let song = ("Pixies", "Where Is My Mind?")
    let expected = song
    
    let actual = song |> ValidateSong |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData("", "where is my mind?")>]
[<InlineData("pixies", "")>]
[<InlineData(" ", "   ")>]
let ValidatesSongBadInput artist title = 
    let song = (artist, title)
    let expected = EmptyInput

    let actual = song |> ValidateSong |> ExtractFailure

    Assert.Equal(expected, actual)

[<Fact>]
let ValidatesNormalInput() =
    let songPart = "Pixies"
    let expected = songPart

    let actual = songPart |> ValidateSongPart |> ExtractSuccess

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData "">]
[<InlineData " ">]
[<InlineData "     ">]
let ValidatesBadInput songPart =
    let expected = EmptyInput

    let actual = songPart |> ValidateSongPart |> ExtractFailure

    Assert.Equal(expected, actual)

[<Fact>]
let ValidatesNegativeCount() =
    let expected = NegativeCount

    let actual = -42 |> ValidateCount |> ExtractFailure

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData 0>]
[<InlineData 42>]
let ValidatesNormalCount input =
    let expected = input

    let actual = input |> ValidateCount |> ExtractSuccess

    Assert.Equal(expected, actual)
