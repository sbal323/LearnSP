Imports System
Imports System.Security.Permissions
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Utilities
Imports Microsoft.SharePoint.Workflow

Namespace Handlers

    Public Class LearningList
        Inherits SPItemEventReceiver
        Private webEV As SPWeb
        Dim itemEV As SPListItem
        Public Overrides Sub ItemAdded(properties As SPItemEventProperties)
            Dim item As SPListItem = properties.ListItem
            item("Title") = item("Title") & " hello from handler"
            item.Update()
        End Sub
        Public Overrides Sub ItemUpdated(properties As SPItemEventProperties)
            itemEV = properties.ListItem
            webEV = itemEV.Web
            SPSecurity.RunWithElevatedPrivileges(AddressOf UpdateEv)
        End Sub
        Private Sub UpdateEv()
            Using siteEv As New SPSite(webEV.Site.ID, webEV.Site.SystemAccount.UserToken)
                Using web As SPWeb = siteEv.OpenWeb(webEV.ID)
                    Dim item As SPItem = web.Lists(itemEV.ParentList.Title).GetItemById(itemEV.ID)
                    item("Title") = item("Title") & " updated"
                    Me.EventFiringEnabled = False
                    item.Update()
                    Me.EventFiringEnabled = True
                End Using
            End Using
        End Sub
        Public Overrides Sub ItemDeleting(properties As SPItemEventProperties)
            Dim item As SPListItem = properties.ListItem
            If item("Title").ToString.Contains(" hello from handler") Then
                properties.ErrorMessage = "http://google.com/"
                properties.Status = SPEventReceiverStatus.CancelWithError
            End If
        End Sub
    End Class
End Namespace