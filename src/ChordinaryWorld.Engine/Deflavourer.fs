module internal Deflavourer

let DeflavourChord chord =
    chord
    |> Analyzer.AnalyzeChord 
    |> fun (tonic, flavour) ->
        flavour
        |> Flavours.Get
        |> function 
            | Some s -> succeed (tonic + s) 
            | None   -> Failure flavour

let Deflavour chords =
    let results  = Seq.map DeflavourChord chords
    let knowns   = results |> Seq.choose (function | Success (s,_) -> Some s | Failure _ -> None)
    let unknowns = results |> Seq.choose (function | Failure  f    -> Some f | Success _ -> None)

    match Seq.isEmpty unknowns with
    | true ->
        knowns
        |> Seq.distinct
        |> succeed
    | false ->
        unknowns
        |> Seq.distinct
        |> UnknownFlavours
        |> Failure
     