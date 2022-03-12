namespace Random

type Random(?seed: int) =
    let lstate = obj
    let mutable state : uint=
        match seed with
        | Some s -> uint s
        | None -> (1u <<< 31) ||| 1u

    member private x.NextBit () : uint =
        lock lstate <| fun _ ->
            let bit = state &&& 1u
            let newFirst : uint = state ^^^ (state >>> 1) ^^^ (state >>> 2) ^^^ (state >>> 7) &&& 1u
            let newState = (state >>> 1) ||| (newFirst <<< 31)
            state <- newState
            bit

    member x.Next (min: int, max: int): int =
        let diff = Util.toUInt32 max - Util.toUInt32 min
        
        let mutable bigRndNum = 0u
        for i = 0 to 63 do
            let bit = x.NextBit () 
            bigRndNum <- bigRndNum <<< 1 ||| bit
        bigRndNum % diff + Util.toUInt32 min
        |> Util.fromUInt32

    member x.Next (): int =
        let min = 0
        let max = System.Int32.MaxValue
        x.Next(min, max)