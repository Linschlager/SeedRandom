# Seed based randomness using Linear Feedback Shift Register
## LFSR Algorithm

### Simple example (4-bit):
1 XOR 2

| #   | State   | Next first bit  | Output |
|-----|---------|-----------------|--------|
| 0   | 1001    | 1               | 1      |
| 1   | 1100    | 0               | 0      |
| 2   | 0110    | 1               | 0      |
| 3   | 1011    | 0               | 1      |
| 4   | 0101    | 1               | 1      |
| 5   | 1010    | 1               | 0      |
| 6   | 1101    | 1               | 1      |
| 7   | 1110    | 1               | 0      |
| 8   | 1111    | 0               | 1      |
| 9   | 0111    | 0               | 1      |
| 10  | 0011    | 0               | 1      |
| 11  | 0001    | 1               | 1      |
| 12  | 1000    | 0               | 0      |
| 13  | 0100    | 0               | 0      |
| 14  | 0010    | 1               | 0      |
| 15  | 1001    | 1               | 1      |

## TODO:
- More different LFSR algorithms
    - [x] XOR-Shift
    - [ ] Fibonacci
    - [ ] Galois
    - [ ] Own playground w/ benchmarking
- Fable.Mocha & Expecto Tests to make sure it works in Fable
