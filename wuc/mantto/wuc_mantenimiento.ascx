<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wuc_mantenimiento.ascx.cs" Inherits="wuc_mantto_wuc_mantenimiento" %>

<%@ Reference Control="~/master_ajax.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:HiddenField ID="hdf_TipoFiltro" runat="server" />
<div class="row">
    <div class="col-xs-6">

        <div class="btn-toolbarr">
            <div class="btn-groupp">
                <asp:LinkButton ID="lbn_Regresar" runat="server" SkinID="lbn_regresar" OnClick="lbn_Regresar_Click" Visible="false"></asp:LinkButton>
                <asp:LinkButton ID="lbn_Nuevo" runat="server" SkinID="lbn_nuevo" OnClick="lbn_Nuevo_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbn_Editar" runat="server" SkinID="lbn_editar" OnClick="lbn_Editar_Click" Visible="false"></asp:LinkButton>

                <asp:ConfirmButtonExtender ID="cbe_Eliminar" runat="server" TargetControlID="lbn_Eliminar" ConfirmText="¿Confirma la Eliminaci&oacute;n del Registro?"></asp:ConfirmButtonExtender>

                <asp:LinkButton ID="lbn_Guardar" runat="server" SkinID="lbn_guardar" ValidationGroup="vg_guardar" Visible="false" OnClick="lbn_Guardar_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbn_Guardar2" runat="server" SkinID="lbn_guardar2" ValidationGroup="vg_guardar2" Visible="false" OnClick="lbn_Guardar2_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbn_Cancelar" runat="server" SkinID="lbn_cancelar" OnClick="lbn_Cancelar_Click" Visible="false"></asp:LinkButton>
                <asp:LinkButton ID="lbn_Eliminar" runat="server" SkinID="lbn_eliminar" OnClick="lbn_Eliminar_Click" Visible="false"></asp:LinkButton>

                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lb_Finalizar" runat="server" SkinID="lb_CambiarEstado" OnClick="lb_Finalizar_Click" Visible="false"></asp:LinkButton>
                <asp:ConfirmButtonExtender ID="cbe_Finalizar" runat="server" TargetControlID="lb_Finalizar" ConfirmText="¿Confirma que desea finalizar el contrato?"></asp:ConfirmButtonExtender>
                <asp:HiddenField ID="hf_accion" runat="server" />
                &nbsp;
                 <asp:LinkButton ID="lb_AsignarLineas" runat="server" SkinID="lb_LineasContrato" OnClick="lb_AsignarLineas_Click" Visible="false"></asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lb_NuevaModificativa" runat="server" SkinID="lb_NuevaModificativa" OnClick="lb_NuevaModificativa_Click" Visible="false"></asp:LinkButton>
            </div>

        </div>
    </div>
    <div class="col-xs-6">
        <div class="pull-right">
            <asp:LinkButton ID="lbn_Buscar" runat="server" SkinID="lbn_buscar" OnClick="lbn_Buscar_Click" ></asp:LinkButton>
            <asp:LinkButton ID="lbn_Imprimir" runat="server" SkinID="lbn_imprimir" OnClick="lbn_Imprimir_Click"></asp:LinkButton>
            <asp:LinkButton runat="server" ID="lb_Boton_1" OnClick="lb_Boton_1_Click" Visible="false"></asp:LinkButton>
            <asp:LinkButton runat="server" ID="lb_Boton_2" OnClick="lb_Boton_2_Click" Visible="false"></asp:LinkButton>
             <asp:LinkButton ID="lb_BuscarPersonalizado" runat="server" SkinID="lbn_buscar" OnClick="lb_BuscarPersonalizado_Click" ></asp:LinkButton>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-xs-12">
        <asp:UpdatePanel ID="udpFiltro" runat="server">
            <ContentTemplate>
            

        <asp:Panel ID="pnl_filtro" runat="server" DefaultButton="btnFiltro" Visible="false" >
            <hr />
            <div class="filtro alert alert-warning">
                <div class="row">
                    <div class="col-xs-12"><strong>Seleccione el criterio de b&uacute;squeda e ingrese el filtro que desea aplicar:</strong></div>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="lbl_filtro" runat="server" AssociatedControlID="ddl_Filtro" CssClass="col-xs-1 control-label">Criterio:</asp:Label>&nbsp;
                    <div class="col-xs-3">
                        <asp:DropDownList ID="ddl_filtro" runat="server" CssClass="form-control"
                            AutoPostBack="false" >
                        </asp:DropDownList>&nbsp;
                        <%--OnSelectedIndexChanged="ddl_filtro_SelectedIndexChanged"--%>
                    </div>
                    <asp:Label ID="lbl_Descripcion_Filtro" runat="server" AssociatedControlID="txt_Descripcion_Filtro" CssClass="col-xs-1 control-label">Filtro:</asp:Label>
                    <div class="col-xs-3">
                        <%--<asp:UpdatePanel ID="udp" runat="server">
                            <ContentTemplate>--%>
                                <asp:TextBox ID="txt_Descripcion_Filtro" runat="server" Width="100%" CssClass="mayuscula form-control"></asp:TextBox>
                                <asp:DropDownList ID="ddl_Descripcion_Filtro" runat="server" Width="100%" Visible="false" CssClass="form-control"></asp:DropDownList>
                            <%--</ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddl_filtro" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>--%>
                    </div>
                    <div class="col-xs-3">
                        <asp:LinkButton id="btnFiltro" runat="server" class="btn btn-info" onclick="btn_Filtro_Click" title="Aplica el filtro de b&uacute;squeda seg&uacute;n el criterio seleccionado.">
                            <i class="glyphicon glyphicon-filter"></i> Aplicar filtro
                        </asp:LinkButton>
                        <%--<asp:Button ID="btn_Filtro" runat="server" SkinID="btn_Filtro" OnClick="btn_Filtro_Click" Text="Filtro" />--%>
                        <asp:Button ID="btn_Todos" runat="server" SkinID="btn_Todos" OnClick="btn_Todos_Click" />

                    </div>                    
                </div>
                
            </div>
            <div>&nbsp;</div>
        </asp:Panel>
        <hr />
        <%--<asp:CollapsiblePanelExtender ID="cpe_filtro" runat="server" Enabled="True" TargetControlID="pnl_filtro" CollapseControlID="lbn_Buscar" ExpandControlID="lbn_Buscar" Collapsed="true" AutoCollapse="true" SuppressPostBack="false">
</asp:CollapsiblePanelExtender>--%>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>




<%--<asp:AnimationExtender ID="AnimationPanel" runat="server" TargetControlID="lbn_Buscar">
    <Animations>
        <OnClick>
            <Sequence AnimationTarget="pnl_filtro">
                <EnableAction Enabled="false" />
                <Pulse Duration=".1" ></Pulse>
                <EnableAction Enabled="true" />
            </Sequence>
        </OnClick>
    </Animations>
</asp:AnimationExtender>
--%>
