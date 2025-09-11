<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucVideo.ascx.cs" Inherits="sistema_configuracion_wucVideo" %>

<asp:HiddenField ID="hdfVideo" runat="server" />
<asp:TextBox ID="txtVideo" runat="server" CssClass="form-control" ReadOnly="false" Width="100%"></asp:TextBox>
<ajax:DropDownExtender ID="ddeVideo" runat="server" TargetControlID="txtVideo" DropDownControlID="pnlVideo" ></ajax:DropDownExtender>
<asp:Panel ID="pnlVideo" runat="server" CssClass="dropDownArbol form-control">
    <asp:TreeView ID="tvwVideo" runat="server" OnSelectedNodeChanged="tvwVideo_SelectedNodeChanged" ShowLines="false" ShowExpandCollapse="false">
        <SelectedNodeStyle BackColor="#C3D9FF" />
        <RootNodeStyle Font-Bold="True" />
    </asp:TreeView>
</asp:Panel>