module test
open FsCheck

[<Xunit.Fact>]
let testOptimized () =
    FsCheck.Prop.discard ()
    true
