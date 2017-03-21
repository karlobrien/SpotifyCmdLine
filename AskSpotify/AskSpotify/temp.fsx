#r "../../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#load "CommonLibrary.fs"
#load "ParseSpotifyResponse.fs"

open System
open System.Xml
open FSharp.Data
open Library.CommonItems
open Library.Parse

let result = GetArtistID "ACDC"

//match result with
//    | Some art -> printfn "%s %s %d %s" art.Name art.Id art.Followers art.Url
//    | None -> printfn "No artist found"


match result with
    | Some art -> 
        GetAlbumData art |> printfn "%A"
    | None -> printfn "No artist found"
