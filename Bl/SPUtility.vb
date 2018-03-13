Imports Microsoft.SharePoint

Public Module SpUtility
    Public Function GetListByInternalName(ByVal _web As SPWeb, ByVal internalListName As String) As SPList
        Dim path As String = _web.ServerRelativeUrl
        If Not path.EndsWith("/", StringComparison.OrdinalIgnoreCase) Then
            path &= "/"
        End If
        path &= "Lists/" & internalListName
        Dim list As SPList = _web.GetList(path)
        Return list
    End Function
End Module
