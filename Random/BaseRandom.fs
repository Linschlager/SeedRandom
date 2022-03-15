namespace Random

open Fable.Core

[<Mangle>]
type BaseRandom =
    abstract member Next : unit -> int
    abstract member Next : min: int * max: int -> int
