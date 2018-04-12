Public Class Employee
    Public Property Id As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Shared Function GetEmployees() As List(Of Employee)
        Dim result As New List(Of Employee)
        For i As Integer = 1 To 100
            result.Add(New Employee With {.Id = i, .FirstName = "First Name " & i.ToString, .LastName = "Last Name " & i.ToString})
        Next
        Return result
    End Function
End Class
Public Class EmployeeBonus
    Public Property Id As Integer
    Public Property Amount As Decimal
    Public Property Currency As String
    Public Shared Function GetEmployeeBonuses() As List(Of EmployeeBonus)
        Dim result As New List(Of EmployeeBonus)
        For i As Integer = 1 To 200
            If i = 55 Then
                Continue For
            End If
            result.Add(New EmployeeBonus With {.Id = i, .Amount = 1000 + 10 * i, .Currency = If(i Mod 2 = 0, "USD", "EUR")})
        Next
        For i As Integer = 1 To 200
            If i = 55 Then
                Continue For
            End If
            result.Add(New EmployeeBonus With {.Id = i, .Amount = 1000 + 10 * i, .Currency = If(i Mod 2 = 0, "USD", "EUR")})
        Next
        For i As Integer = 1 To 200
            If i = 55 Then
                Continue For
            End If
            result.Add(New EmployeeBonus With {.Id = i, .Amount = 1000 + 10 * i, .Currency = If(i Mod 2 = 0, "USD", "EUR")})
        Next
        For i As Integer = 1 To 200
            If i = 55 Then
                Continue For
            End If
            result.Add(New EmployeeBonus With {.Id = i, .Amount = 1000 + 10 * i, .Currency = If(i Mod 2 = 0, "USD", "EUR")})
        Next
        Return result
    End Function
End Class

Public Class Section
    Public Property Title As String
    Public Property Modules As New List(Of Module42)

End Class
Public Class Module42
    Public Property Title As String
End Class
