Imports Microsoft.SharePoint

Module Module1
    Sub Main()
        Using site As New SPSite("http://2013appsrv2/")
            Using web As SPWeb = site.OpenWeb()
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
            End Using
        End Using
        Console.WriteLine("Press any key...")
        Console.ReadKey()
    End Sub
End Module
