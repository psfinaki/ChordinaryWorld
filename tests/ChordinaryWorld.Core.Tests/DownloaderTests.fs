module DownloaderTests

open System.Net
open Xunit
open Downloader

[<Fact>]
let GetsHtmlFromUrl() =
    let url = "https://tabs.ultimate-guitar.com/l/london_grammar/shyer_crd.htm"
    let html = "<html>"

    let result = DownloadHtml url
    let resultContaintsHtml = result.Value.Contains html

    Assert.True(resultContaintsHtml)

[<Fact>]
let ThrowsForBadUrl() =
    let url = "bad url"

    let action = fun () -> DownloadHtml url |> ignore

    Assert.Throws<WebException> action

[<Fact>]
let HandlesNotFoundUrl() =
    let url = "https://tabs.ultimate-guitar.com/l/nothing_but_thieves/ban_all_the_music_crd.htm"

    let result = DownloadHtml url

    Assert.True(result.IsNone)