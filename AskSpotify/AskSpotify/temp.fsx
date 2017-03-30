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

//let input = stdin.ReadLine()
//executeCommand ArtistInfo input
//executeCommand ArtistAlbums input

let main =
    let rec loop =
        printf "Command: "
        stdin.ReadLine() |> executeCommand ArtistAlbums
    loop
    ()

main