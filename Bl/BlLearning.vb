Imports Microsoft.SharePoint
Imports Types

Public Class BlLearning
    Private webContext As SPWeb
    Private lstLearningList As SPList
    Private Const C_LIST_NAME_LEARNING_LIST As String = "LearningLIst"

    Public ReadOnly Property ListLearningList As SPList
        Get
            If lstLearningList Is Nothing Then
                lstLearningList = SpUtility.GetListByInternalName(webContext, C_LIST_NAME_LEARNING_LIST)
            End If
            Return lstLearningList
        End Get
    End Property
    Public Sub FillItem(item As SPListItem, itm As Item)
        itm.Title = item(Types.Item.FN_TITLE)
        itm.Id = item(Types.Item.FN_ID)
    End Sub
    Public Function FillLearningItem(item As SPListItem) As LearningList
        Dim res As New LearningList
        FillItem(item, res)
        If item(LearningList.FN_VENDOR) IsNot Nothing Then
            res.Vendor = New SPFieldLookupValue(item(LearningList.FN_VENDOR).ToString)
        End If
        res.Description = item(LearningList.FN_DESCRIPTION)
        res.OrderDate = item(LearningList.FN_ORDER_DATE)
        If item(LearningList.FN_MENU_OPTION) IsNot Nothing Then
            res.MenuOption = New SPFieldMultiChoiceValue(item(LearningList.FN_MENU_OPTION).ToString).Item(0)
        End If
        Return res
    End Function
    Public Function GetLearningItems() As List(Of LearningList)
        Dim res As New List(Of LearningList)
        Dim query As New SPQuery
        'query.Query = "<Where><Eq><FieldRef Name='Vendor' LookupId='TRUE'/><Value Type='Lookup'>2</Value></Eq></Where>"
        Dim collResult As SPListItemCollection = ListLearningList.GetItems(query)
        For Each itm As SPListItem In collResult
            res.Add(FillLearningItem(itm))
        Next
        Return res
    End Function
    Public Sub New(web As SPWeb)
        webContext = web
    End Sub
    Public Sub New()
        webContext = SPContext.Current.Web
    End Sub
End Class



