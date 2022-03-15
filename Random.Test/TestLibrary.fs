module TestRandom.TestLibrary

#if FABLE_COMPILER
open Fable.Mocha
#else
open Expecto
#endif

open Random

let tests =
    let numTestSamples = 1000

    testList "test randomizer" [
        testCase "Can generate a valid number in a range" <| fun _ ->
            let rnd = Random ()
            let nums = Array.init 100 <| fun _ -> rnd.Next (10, 20)
            Expect.all nums (fun num -> num >= 10) "Expected number to be in range (1)"
            Expect.all nums (fun num -> num <= 20) "Expected number to be in range (2)"

        testCase "Can generate random numbers" <| fun _ ->
            let rnd = Random ()
            let nums = Array.init 100 <| fun _ -> rnd.Next ()
            let differentNums =
                Array.distinct nums
                |> Array.length
            Expect.isTrue (differentNums > 95) $"Expected at least 95 different numbers. Got %i{differentNums} in %A{nums}"

        testCase "Can generate the same numbers given the same seed" <| fun _ ->
            let rnd1 = Random 42
            let nums1 : int array = Array.init 100 <| fun _ -> rnd1.Next ()
            let rnd2 = Random 42
            let nums2 : int array = Array.init 100 <| fun _ -> rnd2.Next ()
            Expect.equal nums1 nums2 "Expected random numbers to be the same for the same seed"

        testCase "Can generate a lot of different numbers" <| fun _ ->
            let rnd1 = Random ()
            let set = System.Collections.Generic.HashSet<int> ()

            for i = 1 to numTestSamples do
                let num = rnd1.Next()
                Expect.isTrue (set.Add num) $"Failed at index %i{i}"
        
        testCase "Every seed starts at a different number" <| fun _ ->
            let set = System.Collections.Generic.HashSet<int> ()
            for i = -numTestSamples to numTestSamples do
                let rnd = Random i
                let num = rnd.Next()
                Expect.isTrue (set.Add num) $"Failed at index %i{i}"

        // This test will most likely need to be updated after changes to the randomizer engine
        // But is necessary to prove that the seeds are platform independent
        testCase "Seed works the same for Dotnet and Fable" <| fun _ ->
            let rnd = Random 171

            let expectedSequence = [|
                67; 25; 26; 75; 90; 41; 55; 93; 65; 58; 93; 24; 15;  9; 43; 87; 25; 14; 54; 73;
                87; 72; 15; 82; 33; 62; 50; 23; 34;  8; 34; 46; 19; 57; 14; 32; 94; 49; 75; 51;
                59; 85; 10; 32; 22; 80; 21; 60; 61; 42; 18; 11; 69; 32; 58; 69; 21; 41; 14; 12;
                87; 65; 44; 34; 77; 56; 57; 78; 75; 73; 57; 50; 81;  6; 80; 27; 53; 30;  4; 33;
                96;  9; 16; 30;  3; 30; 66;  2; 81; 92; 38; 39; 57;  6; 37;  8; 70; 32; 59; 26;
            |]
            let actualSequence : int array = Array.init 100 <| fun _ -> rnd.Next (0, 100)
            Expect.equal expectedSequence actualSequence "Should have been the same sequence as it was in dotnet"
    ]
