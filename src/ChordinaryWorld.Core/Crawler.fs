module internal Crawler

let GetTabs song =
    let htmlGenerator x = 
        song
        |> Canonicalizer.CanonicalizeSong
        |> UrlMaker.MakeUrl x
        |> Downloader.DownloadHtml

    htmlGenerator
    |> Seq.initInfinite
    |> Seq.skip 1
    |> Seq.takeWhile (fun x -> x.IsSome)
    |> Seq.choose id
