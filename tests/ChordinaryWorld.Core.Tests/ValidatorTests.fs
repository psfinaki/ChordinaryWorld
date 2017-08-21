module ValidatorTests

open Xunit
open Validator

[<Fact>]
let ValidatesSongNormalInput() =
    let song = Song.Create("Pixies", "Where Is My Mind?")
    let expected = Success song
    
    let actual = ValidateSong song

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData("", "where is my mind?")>]
[<InlineData("pixies", "")>]
[<InlineData(" ", "   ")>]
let ValidatesSongBadInput artist title =
    let song = Song.Create(artist, title)
    let expected = EmptyInput

    let actual = song |> ValidateSong |> function | Failure x -> x

    Assert.Equal(expected, actual)

[<Fact>]
let ValidatesNormalInput() =
    let input = "Pixies"
    let expected = Success input

    let actual = Validate input

    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData("")>]
[<InlineData(" ")>]
[<InlineData("     ")>]
let ValidatesBadInput input =
    let expected = EmptyInput

    let actual = input |> Validate |> function | Failure x -> x

    Assert.Equal(expected, actual)