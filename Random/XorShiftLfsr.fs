module Random.XorShiftLfsr

let xorShiftLfsr (seed: int option) : BaseRandom =
    let transformState (state: int) =
        
        let mutable s = state
        s <- (s <<< 13) ^^^ s
        s <- (s >>> 17) ^^^ s
        s <- (s <<< 5) ^^^ s
        s

    BaseLfsr (seed, transformState)
