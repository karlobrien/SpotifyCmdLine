namespace Library

open System
open System.Xml
open FSharp.Data
open Library.CommonItems
open Library.Parse

module CLI = 
    type Command = 
        | ArtistInfo
        | ArtistAlbums
        | Help
        | Exit
    
    let showArtist(artist: Artist) = 
        printfn "Arist Name: %s" artist.Name
        printfn "Url: %s" artist.Url

    let showAlbums albums =
        printfn "----- Album List -----"
        albums |> Array.iter (fun c -> printfn "%s" c)

    let executeCommand cmd art = 
        match cmd with
        | ArtistInfo -> 
            GetArtistID art
            |> Option.map showArtist
            |> ignore
        | ArtistAlbums -> 
            GetArtistID art 
            |> Option.map GetAlbumData
            |> Option.map showAlbums
            |> ignore
        | Help -> 
            printfn "You can supply artist or album details"
        | Exit ->
            printfn "Exit"
        
