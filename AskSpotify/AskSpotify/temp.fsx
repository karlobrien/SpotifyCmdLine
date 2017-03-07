#load "CommonLibrary.fs"
#load "ParseSpotifyResponse.fs"
#r "../../packages/FSharp.Data/lib/net40/FSharp.Data.dll"

open System
open System.Xml
open FSharp.Data
open Library.CommonItems
open Library.Parse

let result = GetArtistID "Muse"
