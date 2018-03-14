Imports Microsoft.SharePoint
Imports ConsoleApplication.Bl
Imports System.Runtime.CompilerServices

Module Module1
    Sub Main()
        Using site As New SPSite("http://2013appsrv2/")
            Using web As SPWeb = site.OpenWeb()
                Lesson6(web)
            End Using
        End Using
        Console.WriteLine("Press any key...")
        Console.ReadKey()
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
