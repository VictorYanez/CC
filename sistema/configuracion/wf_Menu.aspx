<%@   Page Title="Registra el menu de cada sistema" Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_Menu.aspx.cs" Inherits="sistema_wf_Menu" %>

<%@ MasterType VirtualPath="~/master_ajax.master" %>
<%@ Register Src="~/sistema/configuracion/wucPadre.ascx" TagPrefix="wuc" TagName="wucPadre" %>
<%@ Register Src="~/sistema/configuracion/wucFormulario.ascx" TagPrefix="wuc" TagName="wucFormulario" %>
<%@ Register Src="~/sistema/configuracion/wucManual.ascx" TagPrefix="wuc" TagName="wucManual" %>
<%@ Register Src="~/sistema/configuracion/wucVideo.ascx" TagPrefix="wuc" TagName="wucVideo" %>
<%@ Register Src="~/sistema/configuracion/wucIcono.ascx" TagPrefix="wuc" TagName="wucIcono" %>






<asp:Content ID="Content1" ContentPlaceHolderID="cphEncabezado" runat="Server">
    <style type="text/css">
        .dropDownArbol
        {
            height: 200px;
            overflow-y: scroll;
            background-color: #fff;
            border: solid #ccc 1px;
        }

        #menu {
            height: 330px; 
            overflow-y: scroll;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
	<div id="div_wuc" runat="server">
		<wuc:uc_mantenimiento 
			ID="wuc_mantto" runat="server"
			MostrarBuscar="false"
			OnNuevo="Nuevo" OnEditar="Editar" OnEliminar="Eliminar"
			OnGuardar="Guardar" OnCancelar="Cancelar"
			OnAplicarFiltro="AplicarFiltro"
		/>
	</div>

	<asp:Panel ID="pnl_campos" runat="server" CssClass="widget-box widget-color-green" Enabled="false">
		<div class="widget-header">
			<h5 class="widget-title"><asp:Label ID="lbl__Accion" runat="server"></asp:Label></h5>
		</div>
		<div class="widget-body">
			<div class="form-horizontal widget-main" role="form">
				<div class="form-group">
					<asp:Label ID="lbl_Id_Menu" runat="server" AssociatedControlID="nbx_Id_Menu" CssClass="col-xs-2 control-label">IdMenu:</asp:Label>
					<div class="col-xs-1">
						<ew:NumericBox ID="nbx_Id_Menu" runat="server" SkinID="skin_entero" Width="50px"></ew:NumericBox>
						<asp:RequiredFieldValidator ID="rfv_Id_Menu" runat="server" ErrorMessage="Requerido:<br /><b>Identificador de menu</b>" ControlToValidate="nbx_Id_Menu" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Id_Menu" runat="server" TargetControlID="rfv_Id_Menu" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
					</div>
					<asp:Label ID="lbl_Descripcion" runat="server" AssociatedControlID="txt_Descripcion" CssClass="col-xs-1 control-label">T&iacute;tulo:</asp:Label>
					<div class="col-xs-4">
						<asp:TextBox Id="txt_Descripcion" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="100"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_Descripcion" runat="server" ErrorMessage="Requerido:<br /><b>Descripcion del men&uacute;</b>" ControlToValidate="txt_Descripcion" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Descripcion" runat="server" TargetControlID="rfv_Descripcion" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
					</div>
					<%--<asp:Label ID="lbl_Icono" runat="server" AssociatedControlID="nbx_Icono" CssClass="col-xs-2 control-label">Orden:</asp:Label>
					<div class="col-xs-2">
						<ew:NumericBox ID="nbx_Icono" runat="server" SkinID="skin_entero" Width="50px"></ew:NumericBox>
						<asp:RequiredFieldValidator ID="rfv_Icono" runat="server" ErrorMessage="Requerido:<br /><b>Indice del Icono</b>" ControlToValidate="nbx_Icono" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Icono" runat="server" TargetControlID="rfv_Icono" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
					</div>--%>
					<asp:Label ID="lbl_Texto" runat="server" AssociatedControlID="wucIcono" CssClass="col-xs-1 control-label">Icono:</asp:Label>
					<div class="col-xs-3">
						<%--<asp:TextBox Id="txt_Texto" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="60"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_Texto" runat="server" ErrorMessage="Requerido:<br /><b>Texto del men&uacute;</b>" ControlToValidate="txt_Texto" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Texto" runat="server" TargetControlID="rfv_Texto" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>--%>
                        <wuc:wucIcono ID="wucIcono" runat="server" />
					</div>
				</div>

				<div class="form-group">
					<asp:Label ID="lbl_Id_Padre" runat="server" AssociatedControlID="wucPadre" CssClass="col-xs-2 control-label">Padre:</asp:Label>
					<div class="col-xs-10">
						<%--<asp:DropDownList ID="ddl_Id_Padre" runat="server" Visible="True" DataValueField="Id_Menu" DataTextField="Descripcion"  Width="100%" CssClass="form-control"></asp:DropDownList>
						<asp:RequiredFieldValidator ID="rfv_Id_Padre" runat="server" ErrorMessage="Requerido:<br /><b>Identificador de la jerarqu&iacute;a reflexiba</b>" ControlToValidate="ddl_Id_Padre" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Id_Padre" runat="server" TargetControlID="rfv_Id_Padre" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>--%>
                        <wuc:wucPadre runat="server" ID="wucPadre" />
					</div>
				</div>

				<div class="form-group">
					<asp:Label ID="lbl_Nombre_Forma" runat="server" AssociatedControlID="wucFormulario" CssClass="col-xs-2 control-label">Enlace:</asp:Label>
					<div class="col-xs-10">
						<%--<asp:TextBox Id="txt_Nombre_Forma" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="900"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_Nombre_Forma" runat="server" ErrorMessage="Requerido:<br /><b>nombre de la forma del sistema</b>" ControlToValidate="txt_Nombre_Forma" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Nombre_Forma" runat="server" TargetControlID="rfv_Nombre_Forma" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>--%>
                        <wuc:wucFormulario runat="server" id="wucFormulario" />
					</div>
				</div>

				<%--<div class="form-group">
					<asp:Label ID="lbl_Nivel" runat="server" AssociatedControlID="nbx_Nivel" CssClass="col-xs-2 control-label">Nivel:</asp:Label>
					<div class="col-xs-10">
						<ew:NumericBox ID="nbx_Nivel" runat="server" SkinID="skin_entero" Width="50px"></ew:NumericBox>
						<asp:RequiredFieldValidator ID="rfv_Nivel" runat="server" ErrorMessage="Requerido:<br /><b>nivel de jerarqu&iacute;a</b>" ControlToValidate="nbx_Nivel" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Nivel" runat="server" TargetControlID="rfv_Nivel" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
					</div>
				</div>

				<div class="form-group">
					<asp:Label ID="lbl_Jerarquia" runat="server" AssociatedControlID="txt_Jerarquia" CssClass="col-xs-2 control-label">Jerarquia:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_Jerarquia" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="90"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_Jerarquia" runat="server" ErrorMessage="Requerido:<br /><b>Jerarqu&iacute;a</b>" ControlToValidate="txt_Jerarquia" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Jerarquia" runat="server" TargetControlID="rfv_Jerarquia" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
					</div>
				</div>--%>

				<%--<div class="form-group">
					<asp:Label ID="lbl_Id_Modulo" runat="server" AssociatedControlID="txt_Id_Modulo" CssClass="col-xs-2 control-label">Id_Modulo:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_Id_Modulo" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="20"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_Id_Modulo" runat="server" ErrorMessage="Requerido:<br /><b></b>" ControlToValidate="txt_Id_Modulo" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Id_Modulo" runat="server" TargetControlID="rfv_Id_Modulo" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
					</div>
				</div>--%>

				<div class="form-group">
					<asp:Label ID="lbl_Url_Ayuda" runat="server" AssociatedControlID="wucManual" CssClass="col-xs-2 control-label">Manual en PDF:</asp:Label>
					<div class="col-xs-10">
						<%--<asp:TextBox Id="txt_Url_Ayuda" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="500"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_Url_Ayuda" runat="server" ErrorMessage="Requerido:<br /><b></b>" ControlToValidate="txt_Url_Ayuda" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Url_Ayuda" runat="server" TargetControlID="rfv_Url_Ayuda" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>--%>
                        <wuc:wucManual runat="server" ID="wucManual" />
					</div>
				</div>

				<div class="form-group">
					<asp:Label ID="lbl_Url_Ayuda_Video" runat="server" AssociatedControlID="wucVideo" CssClass="col-xs-2 control-label">Video:</asp:Label>
					<div class="col-xs-10">
						<%--<asp:TextBox Id="txt_Url_Ayuda_Video" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="500"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_Url_Ayuda_Video" runat="server" ErrorMessage="Requerido:<br /><b></b>" ControlToValidate="txt_Url_Ayuda_Video" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
						<ajax:ValidatorCalloutExtender ID="vce_Url_Ayuda_Video" runat="server" TargetControlID="rfv_Url_Ayuda_Video" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>--%>
                        <wuc:wucVideo runat="server" ID="wucVideo" />
					</div>
				</div>

			</div>
		</div>
	</asp:Panel>
	<div id="div_grilla" runat="server" class="widget-box widget-color-blue">
		<div class="widget-header">
			<h5 class="widget-title">Lista de registros</h5>
		</div>
		<div class="widget-body">

			<div class="widget-main">
                <div id="menu" class="row">
                    <div class="col-xs-8 col-xs-offset-2">
                        <div>
                            <asp:TreeView ID="tvw_Datos" runat="server" OnSelectedNodeChanged="tvw_Datos_SelectedNodeChanged" ShowLines="true">
                                <SelectedNodeStyle BackColor="#C3D9FF" />
                                <RootNodeStyle Font-Bold="True" />
                            </asp:TreeView>
                        </div>
                    </div>
                </div>
                			
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>
