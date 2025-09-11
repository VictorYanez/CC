<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucMenuShortcut.ascx.cs" Inherits="wuc_master_wucMenuShortcut" %>
<%@ Register Src="~/wuc/master/wucAyudaManual.ascx" TagPrefix="wuc" TagName="wucAyudaManual" %>
<%@ Register Src="~/wuc/master/wucAyudaVideo.ascx" TagPrefix="wuc" TagName="wucAyudaVideo" %>


<%--<asp:HiddenField ID="hdfUrlAyudaManual" runat="server" />
<asp:HiddenField ID="hdfUrlAyudaVideo" runat="server" />--%>

<div class="sidebar-shortcuts" id="sidebar-shortcuts">
    <div class="sidebar-shortcuts-large" id="sidebar-shortcuts-large">
        <a class="btn btn-success btn-xs">
            <i class="ace-icon fa fa-signal"></i>
        </a>
        <a class="btn btn-info btn-xs">
            <i class="ace-icon fa fa-pencil"></i>
        </a>
        <wuc:wucAyudaManual runat="server" ID="wucAyudaManual" />
        <wuc:wucAyudaVideo runat="server" ID="wucAyudaVideo" />
        <!-- /section:basics/sidebar.layout.shortcuts -->
    </div>

    <div class="sidebar-shortcuts-mini" id="sidebar-shortcuts-mini">
        <span class="btn btn-success"></span>
        <span class="btn btn-info"></span>
        <span class="btn btn-warning"></span>
        <span class="btn btn-danger"></span>
    </div>
</div>
<!-- /.sidebar-shortcuts -->

