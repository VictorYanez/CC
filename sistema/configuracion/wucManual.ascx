<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucManual.ascx.cs" Inherits="sistema_configuracion_wucManual" %>

<asp:HiddenField ID="hdfManual" runat="server" />
<asp:TextBox ID="txtManual" runat="server" CssClass="form-control" ReadOnly="false" Width="100%"></asp:TextBox>
<ajax:DropDownExtender ID="ddeManual" runat="server" TargetControlID="txtManual" DropDownControlID="pnlManual" ></ajax:DropDownExtender>
<asp:Panel ID="pnlManual" runat="server" CssClass="dropDownArbol form-control">
    <asp:TreeView ID="tvwManual" runat="server" OnSelectedNodeChanged="tvwManual_SelectedNodeChanged" ShowLines="false" ShowExpandCollapse="false">
        <SelectedNodeStyle BackColor="#C3D9FF" />
        <RootNodeStyle Font-Bold="True" />
    </asp:TreeView>
</asp:Panel>