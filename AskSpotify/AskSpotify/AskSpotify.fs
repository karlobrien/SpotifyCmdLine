module AskSpotify

open Expecto

[<Tests>]
let tests =
  testCase "yes" <| fun () ->
    let subject = "Hello World"
    Expect.equal subject "Hello World"
                 "The strings should equal"

[<EntryPoint>]
let main argv =
    printfn "%A" argv
    runTestsWithArgs defaultConfig argv tests
    0 // return an integer exit code
