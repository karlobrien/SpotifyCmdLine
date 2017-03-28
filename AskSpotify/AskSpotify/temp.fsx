#r "../../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#load "CommonLibrary.fs"
#load "ParseSpotifyResponse.fs"
#load "Cli.fs"

open System
open System.Xml
open FSharp.Data
open Library.CLI
open Library.CommonItems
open Library.Parse

let input = stdin.ReadLine()
let result = GetArtistID input

match result with
    | Some art -> 
        printfn "%s %s %d %s" art.Name art.Id art.Followers art.Url
        GetAlbumData art |> printfn "%A"
    | None -> printfn "No artist found"

let test = executeCommand ArtistInfo input
test |> Option.map (fun x -> printfn "%s %d %s" x.Id x.Followers x.Url)
