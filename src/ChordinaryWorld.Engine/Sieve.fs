module internal Sieve

let IsSuspend c = (snd (Analyzer.AnalyzeChord c)).Contains("sus")
let IsPower c = snd (Analyzer.AnalyzeChord c) = "5"
let IsCommon c = (not <| IsSuspend c) && (not <| IsPower c)

let GetChordsOnTonic chords tonic =
    chords
    |> Seq.filter (fun c -> Analyzer.GetTonic c = tonic)

let HasFriends chords chord =
    chord
    |> Analyzer.GetTonic
    |> GetChordsOnTonic chords
    |> (not << Seq.isEmpty)

let FilterSuspends chords = 
    let commons = chords |> Seq.filter IsCommon
    let suspends = chords |> Seq.filter IsSuspend
    let friendlySuspends = suspends |> Seq.filter (HasFriends commons)

    chords |> Seq.except friendlySuspends

let FilterPowers chords = 
    let commons = chords |> Seq.filter IsCommon
    let powers = chords |> Seq.filter IsPower
    let friendlyPowers = powers |> Seq.filter (HasFriends commons)

    chords |> Seq.except friendlyPowers

let Sift chords = 
    chords
    |> FilterSuspends
    |> FilterPowers
