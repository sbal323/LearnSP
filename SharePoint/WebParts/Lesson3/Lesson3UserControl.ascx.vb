Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Partial Public Class Lesson3UserControl
    Inherits UserControl
    Dim bl As New Bl.BlLearning()

    Public Enum Mode
        HR = 1
        Employee = 2
    End Enum
    Public Property ViewMode As Mode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            lblHeader.Text = "<br/> Hello in " & SPContext.Current.Web.Title & " (Page Load)"
            'SomethingWrong()
            grdMaterials.DataSource = bl.GetLearningItems().Take(20).ToList
            grdMaterials.DataBind()
        Catch ex As Exception
            Response.Write("Something went wrong: " & ex.Message & ex.StackTrace)
        End Try
    End Sub
    Private Sub SomethingWrong()
        Dim z = 0
        Dim i As Integer = 100 / z
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            lblHeader.Text &= "<br/> We love " & ddlVendor.SelectedItem.Text
        Catch ex As Exception
            Response.Write("Something went wrong: " & ex.Message & ex.StackTrace)
        End Try
    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Try
            lblHeader.Text &= "<br/> Hello in " & SPContext.Current.Web.CurrentUser.Name & " (Page Pre-render)"
        Catch ex As Exception
            Response.Write("Something went wrong: " & ex.Message & ex.StackTrace)
        End Try
    End Sub
    Private Sub ddlVendor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlVendor.SelectedIndexChanged
        Try
            lblHeader.Text &= "<br/> New Index " & ddlVendor.SelectedItem.Value
        Catch ex As Exception
            Response.Write("Something went wrong: " & ex.Message & ex.StackTrace)
        End Try
    End Sub
End Class
