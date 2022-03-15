namespace Random

type BaseLfsr(seed: int option, transformState: int -> int) =
    let mutable state : int =
        match seed with
        | Some s -> s
        | None -> (1 <<< 31) ||| 1

    let nextBit () =
        state <- transformState state
        state &&& 1

    let next min max : int =
        let diff = max - min
        let mutable bigRndNum = 0
        for _ = 1 to 31 do
            let bit = nextBit ()
            bigRndNum <- bigRndNum <<< 1 ||| bit
        min + abs bigRndNum % diff

    interface BaseRandom with
        member _.Next (min: int, max: int) : int = next min max
        member _.Next () : int = next 0 System.Int32.MaxValue
