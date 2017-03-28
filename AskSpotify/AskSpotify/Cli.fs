namespace Library


open System
open System.Xml
open FSharp.Data
open Library.CommonItems
open Library.Parse

module CLI = 
    type Command = 
        | ArtistInfo
        | Album of string
        | Help of string
        | Exit
    
    let executeCommand cmd art = 
        match cmd with
        | ArtistInfo -> GetArtistID art
        | Exit -> None
        
