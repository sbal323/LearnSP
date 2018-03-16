Imports System
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports Microsoft.SharePoint

''' <summary>
''' This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
''' </summary>
''' <remarks>
''' The GUID attached to this class may be used during packaging and should not be modified.
''' </remarks>

<GuidAttribute("563c06ed-fea5-4eda-ad16-db57c38bfd0b")> _
Public Class WebEventReceiver 
    Inherits SPFeatureReceiver

   
    Public Overrides Sub FeatureActivated(ByVal properties As SPFeatureReceiverProperties)
        Dim _web As SPWeb = CType(properties.Feature.Parent, SPWeb)
        'Debugger.Launch()
        RegisterListEventHandler(_web.Lists("Learning LIst"), GetRegistrationTypeName(GetType(SharePoint.Handlers.LearningList)), _
                                     New SPEventReceiverType() {SPEventReceiverType.ItemAdded, SPEventReceiverType.ItemUpdated, SPEventReceiverType.ItemDeleting}, _
                                     Reflection.Assembly.GetExecutingAssembly)

    End Sub

    Public Overrides Sub FeatureDeactivating(ByVal properties As SPFeatureReceiverProperties)
        Dim _web As SPWeb = CType(properties.Feature.Parent, SPWeb)

        UnRegisterListEventHandler(_web.Lists("Learning LIst"), GetRegistrationTypeName(GetType(SharePoint.Handlers.LearningList)), _
                                     New SPEventReceiverType() {SPEventReceiverType.ItemAdded, SPEventReceiverType.ItemUpdated, SPEventReceiverType.ItemDeleting})
    End Sub
    Public Function GetRegistrationTypeName(typeForRegistration As Type) As String
        Return typeForRegistration.FullName.Replace("+", ".")
    End Function
    Public Sub RegisterListEventHandler(ByVal lst As SPList, ByVal className As String, ByVal types() As SPEventReceiverType, assembly As System.Reflection.Assembly)

        For Each type As SPEventReceiverType In types
            Dim evtRsvr As SPEventReceiverDefinition = (From er As SPEventReceiverDefinition In lst.EventReceivers Where er.Class = className And er.Type = type Select er).FirstOrDefault
            If evtRsvr Is Nothing Then
                Dim eventReceiver As SPEventReceiverDefinition = lst.EventReceivers.Add()
                eventReceiver.Type = type
                eventReceiver.Assembly = assembly.FullName
                eventReceiver.Class = className
                'eventReceiver.Synchronization = sync
                eventReceiver.Update()
            End If
        Next

    End Sub
    Public Sub UnRegisterListEventHandler(ByVal lst As SPList, ByVal className As String, ByVal types() As SPEventReceiverType)

        For Each type As SPEventReceiverType In types
            Dim evtRsvr As SPEventReceiverDefinition = (From er As SPEventReceiverDefinition In lst.EventReceivers Where er.Class = className And er.Type = type Select er).FirstOrDefault
            If evtRsvr IsNot Nothing Then
                evtRsvr.Delete()
            End If
        Next
        
    End Sub

End Class
