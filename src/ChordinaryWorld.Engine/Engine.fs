module Engine

let GetNumberOfHarmonies chords =
    chords 
    |> Seq.distinct
    |> Deslasher.Deslash
    |> Sieve.RemoveSuspends
    |> Sieve.RemovePowers
    |> Deflavourer.Deflavour
    |> map Seq.length