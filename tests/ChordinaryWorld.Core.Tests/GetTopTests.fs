module GetTopTests

open Xunit
open Core

[<Fact>]
let GetsTop() =
    let expected =
        [
            "queen", "bohemian rhapsody", 24
            "the beatles", "here there and everywhere", 12
            "the beatles", "here comes the sun", 10
        ]

    let actual = GetTop 3 |> ExtractSuccess

    Assert.Equal<'T list>(expected, actual)

[<Theory>]
[<InlineData(-42)>]
[<InlineData(1000)>]
let HandlesBadCount input =
    let expected = InternalError UnknownDatabaseError
    
    let actual = GetTop input |> ExtractFailure

    Assert.Equal(expected, actual)

