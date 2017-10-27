[<AutoOpen>]
module Types

type Warning =
    | UnknownDatabaseIssue

type HarmoniesError =
    | ChordsNotFound
    | EmptyInput
    | UnknownFlavours of seq<string>
    | UnknownDatabaseErrorHarmonies
    | ChordsNotAvailable

type TopError =
    | NegativeCount
    | TooBigCount
    | UnknownDatabaseErrorTop

type ArtistTopError =
    | BadArtist
    | NoTabsFound

type Result<'TSuccess,'TWarning,'TError> =
    | Success of 'TSuccess * 'TWarning list
    | Failure of 'TError