<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucFormulario.ascx.cs" Inherits="sistema_configuracion_wucFormulario" %>
<asp:HiddenField ID="hdfFormulario" runat="server" />
<asp:TextBox ID="txtFormulario" runat="server" CssClass="form-control" ReadOnly="false" Width="100%"></asp:TextBox>
<ajax:DropDownExtender ID="ddeFormulario" runat="server" TargetControlID="txtFormulario" DropDownControlID="pnlFormulario" ></ajax:DropDownExtender>
<asp:Panel ID="pnlFormulario" runat="server" CssClass="dropDownArbol form-control">
    <asp:TreeView ID="tvwFormulario" runat="server" OnSelectedNodeChanged="tvwFormulario_SelectedNodeChanged" ShowLines="false" ShowExpandCollapse="false">
        <SelectedNodeStyle BackColor="#C3D9FF" />
        <RootNodeStyle Font-Bold="True" />
    </asp:TreeView>
</asp:Panel>