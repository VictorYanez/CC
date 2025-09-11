<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucIcono.ascx.cs" Inherits="sistema_configuracion_wucIcono" %>
<%@ Reference Control="~/master_ajax.master" %>
<asp:HiddenField ID="hdfControl" runat="server" />
<%--<asp:TextBox ID="lblControl" runat="server" CssClass="form-control" ReadOnly="true" Width="100%"></asp:TextBox>--%>
<asp:Label ID="lblControl" runat="server" CssClass="form-control" ReadOnly="true" Width="100%"></asp:Label>

<%--<asp:RequiredFieldValidator ID="rfv_Control" runat="server" ErrorMessage="Requerido:<br /><b>Texto del men&uacute;</b>" ControlToValidate="lblControl" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
<ajax:ValidatorCalloutExtender ID="vce_Control" runat="server" TargetControlID="rfv_Control" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>--%>



<ajax:DropDownExtender ID="ddeControl" runat="server" TargetControlID="lblControl" DropDownControlID="pnlControl" ></ajax:DropDownExtender>
<asp:Panel ID="pnlControl" runat="server" CssClass="dropDownArbol form-control">
    <%--<asp:TreeView ID="tvwControl" runat="server" OnSelectedNodeChanged="tvwControl_SelectedNodeChanged" ShowLines="false" ShowExpandCollapse="false" PathSeparator=".">
        <SelectedNodeStyle BackColor="#C3D9FF" />
        <RootNodeStyle Font-Bold="True" />
    </asp:TreeView>--%><%--<i class='fa fa-cog'></i> fa-cog--%>
    <asp:RadioButtonList ID="rblIconos" runat="server" RepeatLayout="Table" 
        AutoPostBack="true" OnSelectedIndexChanged="rblIconos_SelectedIndexChanged">
    </asp:RadioButtonList>
</asp:Panel>