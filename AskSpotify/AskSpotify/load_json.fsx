#r "../../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
open FSharp.Data
let searchApi = "https://api.spotify.com/v1/search?q=Muse&type=artist&market=US"
type ArtistJson = JsonProvider<"artist.json", EmbeddedResource="MyLib, artist.json">
let artistRequest = ArtistJson.Load(searchApi)
type Artist = {Name: string; Id: string; Order: int32 }

let specificArtist = artistRequest.Artists.Items 
                        |> Array.filter (fun c -> c.Name = "Muse") 
                        |> Array.map (fun m -> {Name=m.Name; Id= m.Id; Order=(int32)m.Popularity})
                        |> Array.sortBy (fun o -> o.Order)
                        |> Array.tryHead

match specificArtist with
    | Some art -> printfn "%s %s %d" art.Name art.Id art.Order
    | None -> printfn "No artist found"

let html = Http.RequestString ("https://api.spotify.com/v1/search/", query=["q", "Muse"; "type", "artist"], httpMethod="GET" )
let test = ArtistJson.Parse(html)