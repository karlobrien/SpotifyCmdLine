namespace Library

open System
open CommonItems

module Parse = 

    let GetArtistID(name: string) =  
        let decodedString = GetArtistDetails name |> ArtistJson.Parse
        decodedString.Artists.Items 
            |> Array.filter (fun c -> c.Name = "Muse")
            |> Array.map (fun m -> {Name=m.Name; Id= m.Id; Order=(int32)m.Popularity})
            |> Array.sortBy (fun o -> o.Order)
            |> Array.tryHead
    
