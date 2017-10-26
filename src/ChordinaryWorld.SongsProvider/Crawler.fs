module Crawler

open System
open FSharp.Configuration
open FSharp.Data

type Config = YamlConfig<"config.yaml">

type Top   = JsonProvider<"topTracksExample.json">
type Error = JsonProvider<"errorExample.json">

let GetTopTracks count artist =
    let config = Config()
    let url = 
        String.Format(
            "http://ws.audioscrobbler.com/2.0/" +
            "?method=artist.getTopTracks&limit={0}&artist={1}&api_key={2}&format=json", 
            count, artist, config.ApiKey.ToString "N")

    try
        url
        |> Top.Load
        |> fun top -> top.Toptracks.Track
        |> Seq.map (fun track -> (track.Artist.Name, track.Name))
        |> succeed
    with
        _ -> 
            let error = (Error.Load url).Error
            match error with
            | 6 -> Failure BadArtist
            | _ -> reraise()
