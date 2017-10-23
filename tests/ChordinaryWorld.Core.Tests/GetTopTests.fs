module GetTopTests

open Xunit
open Core

[<Fact>]
let GetsTop() =
    let expected =
        [
            "Queen", "Bohemian Rhapsody", 24
        ]

    let actual = GetTop 1 |> ExtractSuccess

    Assert.Equal<'T list>(expected, actual)

[<Theory>]
[<InlineData(-42)>]
[<InlineData(1000)>]
let HandlesBadCount input =
    let expected = InternalError UnknownDatabaseError
    
    let actual = GetTop input |> ExtractFailure

    Assert.Equal(expected, actual)

