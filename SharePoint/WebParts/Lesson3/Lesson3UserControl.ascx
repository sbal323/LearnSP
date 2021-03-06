﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="VB" AutoEventWireup="true" CodeBehind="Lesson3UserControl.ascx.vb" Inherits="SharePoint.Lesson3UserControl" %>
<h1>
<asp:Label runat="server" ID="lblHeader"></asp:Label>
</h1>
Vendor:
<asp:DropDownList runat="server" ID="ddlVendor" AutoPostBack="false">
    <asp:ListItem Text="All" Value="0"></asp:ListItem>
    <asp:ListItem Text="Apple" Value="1"></asp:ListItem>
    <asp:ListItem Text="Microsoft" Value="2"></asp:ListItem>
</asp:DropDownList>
<div>
    <asp:Button runat="server" ID="btnSave" Text="Save Vendor" />
</div>
<asp:DataGrid runat="server" ID="grdMaterials" AutoGenerateColumns="true"></asp:DataGrid>