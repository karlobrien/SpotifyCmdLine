#r "../../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#load "CommonLibrary.fs"
#load "ParseSpotifyResponse.fs"


open System
open System.Xml
open FSharp.Data
open Library.CommonItems
open Library.Parse

let result = GetArtistID "Muse"

match result with
    | Some art -> printfn "%s %s %d %s" art.Name art.Id art.Followers art.Url
    | None -> printfn "No artist found"


match result with
    | Some art -> GetAlbumDetail art.Id |> printfn "DEtails: %s"
    | None -> printfn "No artist found"