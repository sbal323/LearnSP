Imports System
Imports System.ComponentModel
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.WebControls

<ToolboxItemAttribute(false)> _
Public Class Lesson3
    Inherits WebPart

    Private _mode As Lesson3UserControl.Mode

    ' Visual Studio might automatically update this path when you change the Visual Web Part project item.
    Private Const _ascxPath As String = "~/_CONTROLTEMPLATES/15/LearnSPSharePoint/Lesson3/Lesson3UserControl.ascx"
    
    Protected Overrides Sub CreateChildControls()
        Dim control As Control = Page.LoadControl(_ascxPath)
        CType(control, Lesson3UserControl).ViewMode = Me.ViewMode
        Controls.Add(control)
    End Sub

    <WebBrowsable(), Personalizable(PersonalizationScope.Shared), WebDisplayName("View Mode (Set All, MyTeam or Employee)"), WebDescription("Set All, MyTeam or Employee")> _
    Public Property ViewMode() As Lesson3UserControl.Mode
        Get
            Return _mode
        End Get
        Set(ByVal value As Lesson3UserControl.Mode)
            _mode = value
        End Set
    End Property
End Class
