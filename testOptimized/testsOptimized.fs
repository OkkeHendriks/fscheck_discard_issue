module test
open FsCheck
open FsCheck.Xunit

/// Very simple example.
[<Xunit.Fact>]
let testOptimizedFact () =
    FsCheck.Prop.discard ()
    true



/// Slightly more complex example.
type OnlyTrue = OnlyTrue of bool

let chooseTrueGen =
    gen {
        match! Gen.choose (0, 10) with
        | 0 -> return OnlyTrue true
        | _ -> return FsCheck.Prop.discard ()
    }

type MyArbs =
  static member OnlyTrue () =  Arb.fromGen chooseTrueGen

[<Property(Arbitrary = [| typeof<MyArbs> |])>]
let testOptimizedProperty (OnlyTrue v) =
    v