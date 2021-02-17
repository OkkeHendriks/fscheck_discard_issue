module test
open FsCheck

[<Xunit.Fact>]
let testUnoptimized () =
    FsCheck.Prop.discard ()
    true
