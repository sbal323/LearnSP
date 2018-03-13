Imports Microsoft.SharePoint

Public Class LearningList
    Inherits Item
    'fields
    Public Const FN_MENU_OPTION As String = "MenuOption"
    Public Const FN_VENDOR As String = "Vendor"
    Public Const FN_ORDER_DATE As String = "OrderDate"
    Public Const FN_DESCRIPTION As String = "Description"
    'properties
    Public Property MenuOption As String
    Public Property Vendor As SPFieldLookupValue
    Public Property OrderDate As Date
    Public Property Description As String

    Public Overrides Function ToString() As String
        Return String.Format("{0} at {1} by {2} option {3} Id: {4} ",
                             Title,
                             OrderDate.ToLongDateString,
                             If(Vendor Is Nothing, String.Empty, Vendor.LookupValue),
                             MenuOption,
                             Id)
    End Function
End Class


