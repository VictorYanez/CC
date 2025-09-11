<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucPadre.ascx.cs" Inherits="sistema_configuracion_wucPadre" %>
<%@ Reference Control="~/master_ajax.master" %>
<asp:HiddenField ID="hdfControl" runat="server" />
<asp:TextBox ID="txtControl" runat="server" CssClass="form-control" ReadOnly="true" Width="100%"></asp:TextBox>
<ajax:DropDownExtender ID="ddeControl" runat="server" TargetControlID="txtControl" DropDownControlID="pnlControl" ></ajax:DropDownExtender>
<asp:Panel ID="pnlControl" runat="server" CssClass="dropDownArbol form-control">
    <asp:TreeView ID="tvwControl" runat="server" OnSelectedNodeChanged="tvwControl_SelectedNodeChanged" ShowLines="false" ShowExpandCollapse="false" PathSeparator=".">
        <SelectedNodeStyle BackColor="#C3D9FF" />
        <RootNodeStyle Font-Bold="True" />
    </asp:TreeView>
</asp:Panel>
<%--<asp:Literal ID="lit" runat="server"></asp:Literal>--%>
