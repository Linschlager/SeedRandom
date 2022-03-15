namespace Random

open Random

type LsfrApproach =
    | XorShift

type RandomizerAlgorithm =
    | LSFR of LsfrApproach

module RandomizerAlgorithm =
    let defaultAlgorithm = RandomizerAlgorithm.LSFR LsfrApproach.XorShift

type Random(?seedOpt: int, ?algorithmOpt: RandomizerAlgorithm) =
    let algorithm =
        algorithmOpt
        |> Option.defaultValue RandomizerAlgorithm.defaultAlgorithm
        
    let rndInstance =
        match algorithm with
        | RandomizerAlgorithm.LSFR LsfrApproach.XorShift ->
            XorShiftLfsr.xorShiftLfsr seedOpt

    member _.Next (min, max) = rndInstance.Next (min, max)
    member _.Next () = rndInstance.Next ()