Imports Microsoft.SharePoint
Imports ConsoleApplication.Bl

Module Module1
    Sub Main()
        Using site As New SPSite("http://2013appsrv2/")
            Using web As SPWeb = site.OpenWeb()
                Lesson2(web)
            End Using
        End Using
        Console.WriteLine("Press any key...")
        Console.ReadKey()
    End Sub

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
            Dim item As SPListItem = List.AddItem

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
        For Each list As SPList In Web.Lists
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
