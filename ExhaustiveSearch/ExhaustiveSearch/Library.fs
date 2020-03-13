namespace Knapsack

type public ExhaustiveSearch() =
    interface ISolver with
        member this.GetName() = "Точный переборный алгоритм"
        member this.Solve(capacity, m, c) =
            // проверка корректности ввода
            // массивы не могут быть null или разной длинны, а вместимость рюкзака не может быть отрицательной
            if m = null || c = null then raise(System.ArgumentNullException("Null input"))
            if capacity < 0 then raise(System.ArgumentException("Capacity cannot be less than 0"))
            if m.Length <> c.Length then raise(System.ArgumentException("Lists of weights and costs have different lengths"))
            // преобразование массивов в списки
            let weights = List.ofArray m
            let costs = List.ofArray c
            // функция перебирает все варианты, и выбирает среди них последний наиболее выгодный
            let rec _solve capacity weights costs result costsSum =
                match weights, costs with
                [], [] | _, [] | [], _ -> (result, costsSum)
                | (w::weights_tail), (c::costs_tail) when (capacity-w) = 0 -> (_solve capacity weights_tail costs_tail (result @ [true]) (costsSum+c))
                | (w::weights_tail), (c::costs_tail) when (capacity-w) < 0 -> (_solve capacity weights_tail costs_tail (result @ [false]) costsSum)
                | (w::weights_tail), (c::costs_tail) -> 
                    let moreProfitable (res1, sum1) (res2, sum2) =
                        if sum1 > sum2 then (res1, sum1)
                        else (res2, sum2)
                    moreProfitable (_solve (capacity-w) weights_tail costs_tail (result @ [true]) (costsSum+c))
                                   (_solve capacity weights_tail costs_tail (result @ [false]) costsSum)
            List.toArray (fst (_solve capacity weights costs [] 0))
