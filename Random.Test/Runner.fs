module TestRandom.Runner

#if FABLE_COMPILER
open Fable.Mocha
#else
open Expecto
#endif

let allTests =
    testList "all tests" [
        TestLibrary.tests
    ]

[<EntryPoint>]
let main args =
    try
#if FABLE_COMPILER
        ignore args // avoid unused variable warning
        Mocha.runTests allTests
#else
        runTestsWithArgs { defaultConfig with runInParallel = true } args allTests
#endif
    with
    | e ->
        printfn "Error: %s" e.Message
        -1
