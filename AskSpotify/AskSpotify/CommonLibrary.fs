namespace Library
open System
open System.Xml
open FSharp.Data

module CommonItems = 

    type ArtistJson = JsonProvider<"artist.json", EmbeddedResource="MyLib, artist.json">
    type Artist = {Name: string; Id: string; Order: int32 }

    let searchApi = "https://api.spotify.com/v1/search?q=Muse&type=artist&market=US"

    let GetArtistDetails(name: string) =
        let html = Http.RequestString ("https://api.spotify.com/v1/search/", query=["q", name; "type", "artist"], httpMethod="GET", headers = [ "Accept", "application/json" ])
        html
    
    let GetAlbumDetails(artistId: string, albumName: string) =
        Http.RequestString ("https://api.spotify.com/v1/albums/", query=["q", artistId], httpMethod="GET" )
    