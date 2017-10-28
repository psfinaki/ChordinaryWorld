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
    let knowns   = results |> Seq.choose optSuccess
    let unknowns = results |> Seq.choose optFailure

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
     