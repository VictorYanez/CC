<%@ Page Title="Registra los distintos tipos de perfil por cada uno de los sistemas" Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_Perfil.aspx.cs" Inherits="sistema_wf_Perfil" %>

<%@ MasterType VirtualPath="~/master_ajax.master" %>
<%@ Register Src="~/sistema/configuracion/wucPerfilDetalle.ascx" TagPrefix="wuc" TagName="wucPerfilDetalle" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphEncabezado" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    <div id="div_wuc" runat="server">
        <wuc:uc_mantenimiento
            ID="wuc_mantto" runat="server"
            MostrarBuscar="false"
            OnNuevo="Nuevo" OnEditar="Editar" OnEliminar="Eliminar"
            OnGuardar="Guardar" OnCancelar="Cancelar"
            OnAplicarFiltro="AplicarFiltro" />
    </div>

    <asp:Panel ID="pnl_campos" runat="server" Enabled="false">
        <div class="widget-box widget-color-green">
            <div class="widget-header">
                <h5 class="widget-title">
                    <asp:Label ID="lbl__Accion" runat="server"></asp:Label></h5>
            </div>
            <div class="widget-body">
                <div class="form-horizontal widget-main" role="form">
                    <div class="form-group">
                        <asp:Label ID="lbl_Id_Perfil" runat="server" AssociatedControlID="txt_Id_Perfil" CssClass="col-xs-2 control-label">C&oacute;digo:</asp:Label>
                        <div class="col-xs-2">
                            <asp:TextBox ID="txt_Id_Perfil" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_Id_Perfil" runat="server" ErrorMessage="Requerido:<br /><b>Identificador del Perfil</b>" ControlToValidate="txt_Id_Perfil" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vce_Id_Perfil" runat="server" TargetControlID="rfv_Id_Perfil" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
                        </div>
                    </div>

                    <%--<div class="form-group">
					<asp:Label ID="lbl_Id_Sistema" runat="server" AssociatedControlID="ddl_Id_Sistema" CssClass="col-xs-2 control-label">Sistema:</asp:Label>
					<div class="col-xs-10">
						<asp:DropDownList ID="ddl_Id_Sistema" runat="server" Visible="True" DataValueField="Id_Sistema" DataTextField="Id_Unidad"  Width="100%" CssClass="form-control"></asp:DropDownList>
						<asp:RequiredFieldValidator ID="rfv_Id_Sistema" runat="server" ErrorMessage="Requerido:<br /><b>Identificador del Sistema</b>" ControlToValidate="ddl_Id_Sistema" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Id_Sistema" runat="server" TargetControlID="rfv_Id_Sistema" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
					</div>
				</div>--%>

                    <div class="form-group">
                        <asp:Label ID="lbl_Descripcion" runat="server" AssociatedControlID="txt_Descripcion" CssClass="col-xs-2 control-label">Descripci&oacute;n:</asp:Label>
                        <div class="col-xs-10">
                            <asp:TextBox ID="txt_Descripcion" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="60"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_Descripcion" runat="server" ErrorMessage="Requerido:<br /><b>Descripci&oacute;n del Perfil</b>" ControlToValidate="txt_Descripcion" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vce_Descripcion" runat="server" TargetControlID="rfv_Descripcion" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lbl_Fecha_Creacion" runat="server" AssociatedControlID="" CssClass="col-xs-2 control-label">Fecha de creaci&oacute;n:</asp:Label>
                        <div class="col-xs-2">
                            <asp:Label ID="cal_Fecha_Creacion" runat="server" CssClass="form-control"></asp:Label>
                            <%--<ew:CalendarPopup ID="cal_Fecha_Creacion" runat="server" SkinID="skin_calendario"></ew:CalendarPopup>--%>
                            <%--<asp:RequiredFieldValidator ID="rfv_Fecha_Creacion" runat="server" ErrorMessage="Requerido:<br /><b>Fecha de Creaci&oacute;n</b>" ControlToValidate="cal_Fecha_Creacion" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Fecha_Creacion" runat="server" TargetControlID="rfv_Fecha_Creacion" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>--%>
                        </div>
                        <asp:Label ID="lbl_Fecha_Modificacion" runat="server" AssociatedControlID="cal_Fecha_Modificacion" CssClass="col-xs-2 control-label">Fecha de modificacion:</asp:Label>
                        <div class="col-xs-2">
                            <asp:Label ID="cal_Fecha_Modificacion" runat="server" CssClass="form-control"></asp:Label>
                            <%--<ew:CalendarPopup ID="cal_Fecha_Modificacion" runat="server" SkinID="skin_calendario"></ew:CalendarPopup>--%>
                            <%--<asp:RequiredFieldValidator ID="rfv_Fecha_Modificacion" runat="server" ErrorMessage="Requerido:<br /><b>Fecha de Modificaci&oacute;n</b>" ControlToValidate="cal_Fecha_Modificacion" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Fecha_Modificacion" runat="server" TargetControlID="rfv_Fecha_Modificacion" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>--%>
                        </div>
                        <asp:Label ID="lbl_Nivel_Perfil" runat="server" AssociatedControlID="nbx_Nivel_Perfil" CssClass="col-xs-2 control-label">Nivel:</asp:Label>
                        <div class="col-xs-2">
                            <ew:NumericBox ID="nbx_Nivel_Perfil" runat="server" SkinID="skin_entero" Width="100%"></ew:NumericBox>
                            <asp:RequiredFieldValidator ID="rfv_Nivel_Perfil" runat="server" ErrorMessage="Requerido:<br /><b></b>" ControlToValidate="nbx_Nivel_Perfil" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vce_Nivel_Perfil" runat="server" TargetControlID="rfv_Nivel_Perfil" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
                        </div>
                    </div>

                    <%--<div class="form-group">
					<asp:Label ID="lbl_Id_Tipo_Permiso" runat="server" AssociatedControlID="nbx_Id_Tipo_Permiso" CssClass="col-xs-2 control-label">Tipo de permiso:</asp:Label>
					<div class="col-xs-10">
						<ew:NumericBox ID="nbx_Id_Tipo_Permiso" runat="server" SkinID="skin_entero" Width="50px"></ew:NumericBox>
						<asp:RequiredFieldValidator ID="rfv_Id_Tipo_Permiso" runat="server" ErrorMessage="Requerido:<br /><b></b>" ControlToValidate="nbx_Id_Tipo_Permiso" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Id_Tipo_Permiso" runat="server" TargetControlID="rfv_Id_Tipo_Permiso" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
					</div>
				</div>--%>
                </div>
            </div>
        </div>
        <div>
            <wuc:wucPerfilDetalle runat="server" ID="wucPerfilDetalle" />
        </div>
    </asp:Panel>
    <div id="div_grilla" runat="server" class="widget-box widget-color-blue">
        <div class="widget-header">
            <h5 class="widget-title">Lista de registros</h5>
        </div>
        <div class="widget-body">
            <div class="widget-main">
                <asp:GridView ID="gv_Datos" runat="server" Width="100%" SkinID="skin_grilla_sin_paginacion"
                    PageSize="12" AllowPaging="True" DataKeyNames="Id_Perfil"
                    OnRowDataBound="gv_Datos_RowDataBound" OnSelectedIndexChanged="gv_Datos_SelectedIndexChanged"
                    OnPageIndexChanging="gv_Datos_PageIndexChanging">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="&nbsp;">
                            <HeaderStyle Width="1px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="Id_Perfil" HeaderText="C&oacute;digo">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripci&oacute;n">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fecha_Creacion" HeaderText="Fecha de creaci&oacute;n">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fecha_Modificacion" HeaderText="Fecha de modificacion">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
    <script type="text/javascript">

        function pageLoad()
        {
            $("#cbxTod").change(function () {
                var valor = $("#cbxTod").prop("checked");
                $("td.tod input[type=checkbox]").prop("checked", valor);
                $("td.act input[type=checkbox]").prop("checked", valor);
                $("td.sel input[type=checkbox]").prop("checked", valor);
                $("td.ins input[type=checkbox]").prop("checked", valor);
                $("td.edi input[type=checkbox]").prop("checked", valor);
                $("td.eli input[type=checkbox]").prop("checked", valor);
                $("td.imp input[type=checkbox]").prop("checked", valor);
                $("#cbxAct").prop("checked", valor);
                $("#cbxSel").prop("checked", valor);
                $("#cbxIns").prop("checked", valor);
                $("#cbxEdi").prop("checked", valor);
                $("#cbxEli").prop("checked", valor);
                $("#cbxImp").prop("checked", valor);
            });
            $("#cbxAct").change(function () {
                $("td.act input[type=checkbox]").prop("checked", $("#cbxAct").prop("checked"));
            });
            $("#cbxSel").change(function () {
                $("td.sel input[type=checkbox]").prop("checked", $("#cbxSel").prop("checked"));
            });
            $("#cbxIns").change(function () {
                $("td.ins input[type=checkbox]").prop("checked", $("#cbxIns").prop("checked"));
            });
            $("#cbxEdi").change(function () {
                $("td.edi input[type=checkbox]").prop("checked", $("#cbxEdi").prop("checked"));
            });
            $("#cbxEli").change(function () {
                $("td.eli input[type=checkbox]").prop("checked", $("#cbxEli").prop("checked"));
            });
            $("#cbxImp").change(function () {
                $("td.imp input[type=checkbox]").prop("checked", $("#cbxImp").prop("checked"));
            });

            $("td.tod input[type=checkbox]").change(function () {
                var clase = "." + $(this).parent().parent().prop("class") + " input[type=checkbox]";
                $(clase).prop("checked", $(this).prop("checked"));
            });
        }

    </script>
</asp:Content>
