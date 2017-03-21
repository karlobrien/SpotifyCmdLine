#r "../../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#load "CommonLibrary.fs"

open System
open System.Xml
open FSharp.Data
open Library.CommonItems

let [<Literal>] sample = """{
  "href" : "https://api.spotify.com/v1/artists/4L6i1I6tFpc1bKui5coGme/albums?offset=0&limit=20&album_type=single,album,compilation,appears_on,ep",
  "items" : [ {
    "album_type" : "album",
    "artists" : [ {
      "external_urls" : {
        "spotify" : "https://open.spotify.com/artist/7zAIs85hAWQUSm8rEq2cUT"
      },
      "href" : "https://api.spotify.com/v1/artists/7zAIs85hAWQUSm8rEq2cUT",
      "id" : "7zAIs85hAWQUSm8rEq2cUT",
      "name" : "Mad Dukez",
      "type" : "artist",
      "uri" : "spotify:artist:7zAIs85hAWQUSm8rEq2cUT"
    } ],
    "available_markets" : [ "AD", "AR", "AT", "AU", "BE", "BG", "BO", "BR", "CA", "CH", "CL", "CO", "CR", "CY", "CZ", "DE", "DK", "DO", "EC", "EE", "ES", "FI", "FR", "GB", "GR", "GT", "HK", "HN", "HU", "ID", "IE", "IS", "IT", "JP", "LI", "LT", "LU", "LV", "MC", "MT", "MX", "MY", "NI", "NL", "NO", "NZ", "PA", "PE", "PH", "PL", "PT", "PY", "SE", "SG", "SK", "SV", "TR", "TW", "US", "UY" ],
    "external_urls" : {
      "spotify" : "https://open.spotify.com/album/3SnB9gB7zKqhchtC2UZSPm"
    },
    "href" : "https://api.spotify.com/v1/albums/3SnB9gB7zKqhchtC2UZSPm",
    "id" : "3SnB9gB7zKqhchtC2UZSPm",
    "images" : [ {
      "height" : 640,
      "url" : "https://i.scdn.co/image/081bb29615ee1a09969c8b4906d1af22dfc284c7",
      "width" : 640
    }, {
      "height" : 300,
      "url" : "https://i.scdn.co/image/b28520ca1031e276f997e70cbc7f203dcf5f3e01",
      "width" : 300
    }, {
      "height" : 64,
      "url" : "https://i.scdn.co/image/31e98fe2703f30a84013086cf0ce55590b06779c",
      "width" : 64
    } ],
    "name" : "Bufgod",
    "type" : "album",
    "uri" : "spotify:album:3SnB9gB7zKqhchtC2UZSPm"
  }, {
    "album_type" : "album",
    "artists" : [ {
      "external_urls" : {
        "spotify" : "https://open.spotify.com/artist/0LyfQWJT6nXafLPZqxe9Of"
      },
      "href" : "https://api.spotify.com/v1/artists/0LyfQWJT6nXafLPZqxe9Of",
      "id" : "0LyfQWJT6nXafLPZqxe9Of",
      "name" : "Various Artists",
      "type" : "artist",
      "uri" : "spotify:artist:0LyfQWJT6nXafLPZqxe9Of"
    } ],
    "available_markets" : [ "AD", "AR", "AT", "AU", "BE", "BG", "BO", "BR", "CH", "CL", "CO", "CY", "CZ", "DE", "DK", "EC", "EE", "ES", "FI", "FR", "GB", "GR", "HK", "HU", "ID", "IE", "IS", "IT", "JP", "LI", "LT", "LU", "LV", "MC", "MT", "MY", "NL", "NO", "NZ", "PE", "PH", "PL", "PT", "PY", "SE", "SG", "SK", "TR", "TW", "UY" ],
    "external_urls" : {
      "spotify" : "https://open.spotify.com/album/4tEfe4fGxeWFrlC3L3VRDe"
    },
    "href" : "https://api.spotify.com/v1/albums/4tEfe4fGxeWFrlC3L3VRDe",
    "id" : "4tEfe4fGxeWFrlC3L3VRDe",
    "images" : [ {
      "height" : 640,
      "url" : "https://i.scdn.co/image/485874a0eeee086e35df2df41e55239fb26f2cb5",
      "width" : 640
    }, {
      "height" : 300,
      "url" : "https://i.scdn.co/image/dc6b6616120df0ce5c0065db54a4f89be6099e4c",
      "width" : 300
    }, {
      "height" : 64,
      "url" : "https://i.scdn.co/image/75b981e8ea25f38b518867a1a3f443fc095e7e66",
      "width" : 64
    } ],
    "name" : "World Dance",
    "type" : "album",
    "uri" : "spotify:album:4tEfe4fGxeWFrlC3L3VRDe"
  } ],
  "limit" : 20,
  "next" : null,
  "offset" : 0,
  "previous" : null,
  "total" : 2
}
"""

type AlbumProvider = JsonProvider<sample>
let provider = AlbumJson.Parse(sample)

let albumNames = provider.Items
                |> Array.map (fun c -> c.Name)