module Engine

let GetNumberOfHarmonies (chords: seq<string>) =
    chords 
    |> Seq.distinct
    |> Deslasher.Deslash
    |> Sieve.RemoveSuspends
    |> Sieve.RemovePowers
    |> Deflavourer.Deflavour
    |> Seq.length