module Engine

let GetNumberOfHarmonies chords =
    chords 
    |> Seq.distinct
    |> Deslasher.Deslash
    |> Deflavourer.Deflavour
    |> map Sieve.Sift
    |> map Seq.length