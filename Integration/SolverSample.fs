namespace Knapsack

type public MySuperSolver() =
  interface ISolver with
    member this.GetName() = "Самый лучший алгоритм"
    member this.Solve(M, m, c) = 
      let weights = List.ofArray m // Теперь в weights обычный F#-список масс ...
      let costs = List.ofArray c   // ... а в costs  - обычный F#-список стоимостей
      let solve M (w1::wTail) (c1::cTail) =
        if w1 < M then [true] else [false] // вместо этой "заглушки" должна быть собственно реализация алгоритма
      List.toArray (solve M weights costs) // в конце с помощью toArray F#-список превращается в массив
