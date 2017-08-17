module internal Sieve

let RemoveSuspends chords =
    chords
    |> Seq.filter (fun (c: string) -> not (c.Contains("sus")))

let RemovePowers chords =
    chords 
    |> Seq.filter (fun c -> snd (Analyzer.AnalyzeChord c) <> "5")
