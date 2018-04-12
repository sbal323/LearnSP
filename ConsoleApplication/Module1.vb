Imports Microsoft.SharePoint
Imports ConsoleApplication.Bl
Imports System.Runtime.CompilerServices

Module Module1
    Sub Main()
        Using site As New SPSite("http://2013appsrv2/")
            Using web As SPWeb = site.OpenWeb()
                Lesson8()
            End Using
        End Using
        Console.WriteLine("Press any key...")
        Console.ReadKey()
    End Sub
    Public Sub Lesson8()
        'Lesson8InnerJoinObject()
        'Lesson8InnerJoinString()
        'Lesson8LeftJoin()
        'Lesson8GroupBy()
        'Lesson8DistinctBy()
        Lesson8QA()
    End Sub
    Public Sub Lesson8QA()
        Dim sections As New List(Of Section)
        Dim modules As New List(Of Module42)
        Dim modulesTarget As New List(Of Module42)
        modulesTarget.Add(New Module42 With {.Title = "Module1"})
        '
        modules.Add(New Module42 With {.Title = "Module1"})
        modules.Add(New Module42 With {.Title = "Module2"})
        modules.Add(New Module42 With {.Title = "Module3"})
        '
        sections.Add(New Section With {.Title = "Section1", .Modules = modules.Where(Function(x) x.Title = "Module1" OrElse x.Title = "Module2").ToList})
        sections.Add(New Section With {.Title = "Section2", .Modules = modules.Where(Function(x) x.Title = "Module2" OrElse x.Title = "Module3").ToList})
        sections.Add(New Section With {.Title = "Section3", .Modules = modules.Where(Function(x) x.Title = "Module1").ToList})
        sections.Add(New Section With {.Title = "Section4"})

        sections.SelectMany(Function(x) x.Modules).DistinctBy(Function(x) x.Title).Select(Function(x) x.Title).ToList.ForEach(Sub(x) Console.WriteLine(x))
        sections.Where(Function(x) Not modulesTarget.Any(Function(y) x.Modules.Any(Function(z) z.Title = y.Title))).ToList.ForEach(Sub(x) Console.WriteLine(x.Title))
    End Sub
    Public Sub Lesson8InnerJoinObject()
        Dim joinResult = Employee.GetEmployees.Join(EmployeeBonus.GetEmployeeBonuses,
                                  Function(e) e.Id,
                                  Function(esd) esd.Id,
                                  Function(e, esd) New With {.Name = e.FirstName & " " & e.LastName, .Bonus = esd.Amount & " " & esd.Currency & " " & e.Id & " " & esd.Id})
        joinResult.ToList.ForEach(Sub(x) Console.WriteLine(x.Name & " " & x.Bonus))
    End Sub
    Public Sub Lesson8InnerJoinString()
        Dim warmCountries As String() = {"Turkey", "Italy", "Spain", "Saudi Arabia", "Etiobia"}
        Dim europeanCountries As String() = {"Denmark", "Germany", "Italy", "Portugal", "Spain"}
        Dim joinResult = warmCountries.Join(europeanCountries, Function(warm) warm, Function(european) european, Function(warm, european) warm)
        joinResult.ToList.ForEach(Sub(x) Console.WriteLine(x))
    End Sub
    Public Sub Lesson8LeftJoin()
        Dim joinResult = Employee.GetEmployees.GroupJoin(EmployeeBonus.GetEmployeeBonuses,
                                  Function(e) e.Id,
                                  Function(esd) esd.Id,
                                  Function(e, esd) New With {.Name = e.FirstName & " " & e.LastName, .Bonus = esd.Sum(Function(x) x.Amount) & " " & If(esd.Count > 0, esd(0).Currency, String.Empty)})
        joinResult.ToList.ForEach(Sub(x) Console.WriteLine(x.Name & " " & x.Bonus))
    End Sub
    Public Sub Lesson8GroupBy()
        Dim joinResult = EmployeeBonus.GetEmployeeBonuses.GroupBy(Function(x) x.Currency)
        joinResult.ToList.ForEach(Sub(x) Console.WriteLine(x.Key & " => " & x.Count & " records"))
        Console.WriteLine(New String("-", 15))
        Dim joinResult1 = EmployeeBonus.GetEmployeeBonuses.GroupBy(Function(x) x.Id)
        joinResult1.ToList.ForEach(Sub(x) Console.WriteLine(x.Key & " => " & x.Count & " records"))
    End Sub
    Public Sub Lesson8DistinctBy()
        Dim joinResult = EmployeeBonus.GetEmployeeBonuses.DistinctBy(Function(x) x.Currency)
        joinResult.ToList.ForEach(Sub(x) Console.WriteLine(x.Id & " => " & x.Amount & " " & x.Currency))
        Console.WriteLine(New String("-", 15))
        Dim joinResult1 = EmployeeBonus.GetEmployeeBonuses.DistinctBy(Function(x) x.Id)
        joinResult1.ToList.ForEach(Sub(x) Console.WriteLine(x.Id & " => " & x.Amount & " " & x.Currency))
    End Sub
    Public Sub Lesson6(web As SPWeb)
        Dim bl = New BlLearning(web)
        Dim learningItems As List(Of Types.LearningList) = GenerateCollection()
        Dim ids As New List(Of Integer)(New Integer() {1, 2, 3})
        learningItems.
            Where(Function(x) Not ids.Any(Function(y) y = x.Id)).
            Take(10).
            SelectMany(Function(x) x.OrderLines).
        ToList.ForEach(Sub(x) Console.WriteLine(x))
        'learningItems.
        '    Where(Function(x) Not ids.Any(Function(y) y = x.Id)).
        '    Take(10).
        'ToList.ForEach(Sub(x) Console.WriteLine(x.Title))
        'learningItems.
        '    Where(Function(x) x.Id < 15).
        '    Where(Function(x) x.OrderDate < Date.Today.AddDays(5)).
        '    OrderByDescending(Function(x) x.Id).
        '    Select (Function(x) New With {.TitleNew = x.Title}).
        'ToList.ForEach(Sub(x) Console.WriteLine(x.TitleNew))
        'Console.WriteLine(learningItems.
        '                  Where(Function(x) x.OrderDate > Date.Today.AddDays(5)).
        '                  Skip(10).
        '                  Take(20).
        '                  Average(Function(x) x.Id))
        'Dim element As IEnumerable(Of String) = From el In learningItems Where el.Id = 55 Select el.Title
        'For Each itm As Types.LearningList In learningItems
        '    Console.WriteLine(itm.ToString)
        'Next
        'Console.WriteLine("Completed")
    End Sub
    Public Function GenerateCollection()
        Dim res As New List(Of Types.LearningList)
        For i As Integer = 0 To 1000
            res.Add(New Types.LearningList() With {.Id = i, .Title = "element " & (i + 1).ToString, .OrderDate = DateTime.Today.AddDays(i), .OrderLines = New List(Of String)(New String() {"Line 1 for " & i, "Line 2 for " & i})})
        Next
        Return res
    End Function

    Public Sub Lesson2(web As SPWeb)
        Dim bl = New BlLearning(web)
        Dim learningItems As List(Of Types.LearningList) = bl.GetLearningItems
        For Each itm As Types.LearningList In learningItems
            Console.WriteLine(itm.ToString)
        Next
        Console.WriteLine("Completed")
    End Sub
    Private Sub ReadItems(list As SPList)
        For i As Integer = 3 To 10
            Dim item As SPListItem = list.GetItemById(i + 1)

            item.Recycle()

            Console.Write(".")
        Next
    End Sub
    Private Sub DeleteItems(list As SPList)
        For i As Integer = 3 To 10
            Dim item As SPListItem = list.GetItemById(i + 1)

            item.Recycle()

            Console.Write(".")
        Next
    End Sub
    Private Sub AddItems(list As SPList)
        For i As Integer = 0 To 1000
            Dim item As SPListItem = list.AddItem

            item("Title") = "Auto item " & (i + 1).ToString
            item("OrderDate") = DateTime.Today.AddDays(i)

            item.Update()
            Console.Write(".")
        Next
    End Sub
    Private Sub UpdateItems(list As SPList)
        For i As Integer = 3 To 100
            Dim item As SPListItem = list.GetItemById(i + 1)


            item("MenuOption") = "Menu 3"

            item.Update()
            Console.Write(".")
        Next
    End Sub
    Public Sub Lesson1(web As SPWeb)
        For Each list As SPList In web.Lists
            Console.WriteLine(String.Format("{0} ({1})",
                                            list.Title,
                                            list.ItemCount))
            For Each item As SPListItem In list.Items
                For Each field As SPField In list.Fields.OfType(Of SPField)().Where(Function(x) x.CanBeDeleted OrElse x.InternalName = "Title")
                    Console.WriteLine(String.Format("{0}{1} ({2})",
                                                    vbTab,
                                                field.Title,
                                                If(item(field.InternalName) Is Nothing, String.Empty, item(field.InternalName).ToString)))

                Next
            Next
        Next
    End Sub
End Module
