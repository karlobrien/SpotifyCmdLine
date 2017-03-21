namespace Library
open System
open System.Xml
open FSharp.Data

module CommonItems = 

    type ArtistJson = JsonProvider<"artist.json", EmbeddedResource="AskSpotify, artist.json">
    type Artist = {Name: string; Id: string; Followers: int32; Url: string }

    let searchApi = "https://api.spotify.com/v1/search?q=Muse&type=artist&market=US"

    let GetArtistDetails(name: string) =
        let html = Http.RequestString ("https://api.spotify.com/v1/search/", query=["q", name; "type", "artist"], httpMethod="GET", headers = [ "Accept", "application/json" ])
        html
    
    type AlbumJson = JsonProvider<"album.json", EmbeddedResource="AskSpotify, album.json">

    let GetAlbumDetail artistId =
        let request = sprintf "https://api.spotify.com/v1/artists/%s/albums" artistId
        Http.RequestString (request, httpMethod="GET", headers = [ "Accept", "application/json" ] )
    