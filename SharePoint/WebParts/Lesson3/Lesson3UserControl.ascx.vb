Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Partial Public Class Lesson3UserControl
    Inherits UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        lblHeader.Text = "Hello in " & SPContext.Current.Web.Title & " (Page Load)"
    End Sub

    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        lblHeader.Text &= "Hello in " & SPContext.Current.Web.CurrentUser.Name & " (Page Pre-render)"
    End Sub
End Class
