Imports System.Runtime.CompilerServices

Module Extensions
    <Extension()> _
    Public Function DistinctBy(Of T, TKey)(items As IEnumerable(Of T), [property] As Func(Of T, TKey)) As IEnumerable(Of T)
        Return items.GroupBy([property]).Select(Function(x) x.First())
    End Function
End Module
