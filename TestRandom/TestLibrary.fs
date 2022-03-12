module TestLibrary

open Xunit
open Random

[<Fact>]
let ``Can generate a valid number in a range`` () =
    let rnd = Random ()
    let num = rnd.Next (10, 20)
    Assert.InRange (num, 10, 20)

[<Fact>]
let ``Can generate a valid number in a range (negative)`` () =
    let rnd = Random ()
    let num = rnd.Next (-10, 0)
    Assert.InRange (num, -10, 0)

[<Fact>]
let ``Can generate random numbers`` () =
    let rnd = Random ()
    let nums : int array = Array.init 100 <| fun _ -> rnd.Next ()
    let differentNums =
        Array.distinct nums
        |> Array.length

    Assert.True (differentNums > 95, $"Expected at least 95 different numbers. Got %i{differentNums} in %A{nums}")

[<Fact>]
let ``Can generate the same numbers given the same seed`` ()  =
    let rnd1 = Random 42
    let nums1 : int array = Array.init 100 <| fun _ -> rnd1.Next ()
    let rnd2 = Random 42
    let nums2 : int array = Array.init 100 <| fun _ -> rnd2.Next ()
    Assert.Equal<int array> (nums1, nums2)

[<Fact>]
let ``Can generate any number given the correct seed`` ()  =
    let rnd1 = Random ()
    let set = System.Collections.Generic.HashSet<int> ()

    for i = 1 to System.Int32.MaxValue do
        let num = rnd1.Next()
        Assert.True (set.Add num, $"Failed at index %i{i}")

[<Fact>]
let ``Every seed starts at a different number`` ()  =
    let set = System.Collections.Generic.HashSet<int> ()
    for i = 1 to System.Int32.MaxValue do
        let rnd = Random ()
        let num = rnd.Next()
        Assert.True (set.Add num, $"Failed at index %i{i}")