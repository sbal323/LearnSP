﻿Imports System
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

    ' Visual Studio might automatically update this path when you change the Visual Web Part project item.
    Private Const _ascxPath As String = "~/_CONTROLTEMPLATES/15/LearnSPSharePoint/Lesson3/Lesson3UserControl.ascx"
    
    Protected Overrides Sub CreateChildControls()
        Dim control As Control = Page.LoadControl(_ascxPath)
        Controls.Add(control)
    End Sub

End Class
