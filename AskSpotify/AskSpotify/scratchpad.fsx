#r "/Users/karlobrien/projects/F#/SpotifyCmdLine/packages/FSharp.Data/lib/net40/FSharp.Data.dll"

open FSharp.Data

let apiReq = "https://api.spotify.com/v1/artists/0TnOYISbd1XYRBk9myaseg"
let [<Literal>] SpotifySample = "/Users/karlobrien/projects/F#/SpotifyCmdLine/AskSpotify/AskSpotify/sample.json"
type Json = JsonProvider<SpotifySample>
let data = Http.Request(apiReq, headers=["content-type", "application-json"])
let samples = Json.Parse(data.Body.ToString())

for d in samples.Genres do
    printfn "%A" d