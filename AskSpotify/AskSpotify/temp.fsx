#r "/Users/karlobrien/projects/F#/SpotifyCmdLine/packages/FSharp.Data/lib/net40/FSharp.Data.dll"

open FSharp.Data

let apiReq = "https://api.spotify.com/v1/artists/0TnOYISbd1XYRBk9myaseg"
let [<Literal>] SpotifySample = "/Users/karlobrien/projects/F#/SpotifyCmdLine/AskSpotify/AskSpotify/sample.json"
type Json = JsonProvider<SpotifySample>

let samples = Json.Load(apiReq)

let searchApi = "https://api.spotify.com/v1/search?q=Muse&type=artist&market=US"
let [<Literal>] ArtistSample = "/Users/karlobrien/projects/F#/SpotifyCmdLine/AskSpotify/AskSpotify/artist.json"
type ArtistJson = JsonProvider<ArtistSample>

let artistRequest = ArtistJson.Load(searchApi)

let allArtists   = artistRequest.Artists.Items

type Artist = {Name: string; Id: string; Order: int32 }
let specificArtist = allArtists 
                        |> Array.filter (fun c -> c.Name = "Muse") 
                        |> Array.map (fun m -> {Name=m.Name; Id= m.Id; Order=(int32)m.Popularity})
                        |> Array.sortBy (fun o -> o.Order)
                        |> Array.tryHead

match specificArtist with
    | Some art -> printfn "%s %s %d" art.Name art.Id art.Order
    | None -> printfn "No artist found"

module ApiRequest =
    let searchApi = "https://api.spotify.com/v1/search?q=Muse&type=artist&market=US"
    //let fetchArtist(name, url:string) =

