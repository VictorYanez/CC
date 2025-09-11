<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucMenuPrincipal.ascx.cs" Inherits="wuc_master_wucMenuPrincipal" %>


<asp:Literal ID="litMenu" runat="server" OnInit="litMenu_Init"></asp:Literal>
<asp:HiddenField ID="hdfTitulo" runat="server" />
<%--<asp:HiddenField ID="hdfUrlAyudaManual" runat="server" />
<asp:HiddenField ID="hdfUrlAyudaVideo" runat="server" />--%>


<!-- #section:basics/sidebar.layout.minimize -->
<div id="sidebar-collapse" class="sidebar-toggle sidebar-collapse">
    <i  class="ace-icon fa fa-angle-double-left" 
        data-icon1="ace-icon fa fa-angle-double-left" 
        data-icon2="ace-icon fa fa-angle-double-right"></i>
</div>

