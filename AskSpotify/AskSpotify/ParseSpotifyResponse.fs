namespace Library

open System
open CommonItems

module Parse = 

    let GetArtistID name =  
        let decodedString = GetArtistDetails name |> ArtistJson.Parse
        decodedString.Artists.Items 
            |> Array.filter (fun c -> c.Name = "Muse")
            |> Array.map (fun m -> {Name=m.Name; Id= m.Id; Followers=(int32)m.Followers.Total; Url = m.ExternalUrls.Spotify})
            |> Array.sortBy (fun o -> o.Followers)
            |> Array.tryHead
    
    let GetArtistData(name: string) =
        let decodedString = GetArtistDetails name |> ArtistJson.Parse
        decodedString.Artists.Items