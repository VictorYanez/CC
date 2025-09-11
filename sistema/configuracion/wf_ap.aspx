<%@ Page Title="" Language="C#" MasterPageFile="~/sistema/configuracion/configuracion_simple.master" AutoEventWireup="true" CodeFile="wf_ap.aspx.cs" Inherits="sistema_configuracion_wf_ap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>

    <div class="row">
        <div class="col-xs-8">
            <asp:CheckBoxList ID="cbl_Perfiles" runat="server" DataValueField="IdPerfil" DataTextField="IdPerfil"></asp:CheckBoxList>
        </div>
        <div class="col-xs-4">
            <div class="pull-right">
                <asp:LinkButton ID="lbnAplicar" runat="server" CssClass="btn btn-info" OnClick="lbnAplicar_Click">
                <i class="fa fa-check-circle-o"></i> Aplicar
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>

