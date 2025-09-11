<%@   Page Title="Tabla que almacena los diferentes tipos de contactos del concesionario." Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_Tiposcontactos.aspx.cs" Inherits="wf_Tiposcontactos"%>
<%@ MasterType VirtualPath="~/master_ajax.master" %>

<asp:Content ID="cEncabezado" ContentPlaceHolderID="cphEncabezado" runat="Server"></asp:Content>

<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenido" runat="Server">
	<div id="div_wuc" runat="server">
		<wuc:uc_mantenimiento
			ID="wuc_mantto" runat="server"
			MostrarBuscar="false"
			OnNuevo="Nuevo" OnEditar="Editar" OnEliminar="Eliminar"
			OnGuardar="Guardar" OnCancelar="Cancelar"
			OnAplicarFiltro="AplicarFiltro" MostrarBuscarPersonalizado="false"
		/>
	</div>

	<asp:Panel ID="pnl_campos" runat="server" CssClass="widget-box widget-color-green" Enabled="false">
		<div class="widget-header">
			<h5 class="widget-title"><asp:Label ID="lbl_Accion" runat="server"></asp:Label></h5>
		</div>
		<div class="widget-body">
			<div class="form-horizontal widget-main" role="form">
				<div class="form-group hidden">
					<asp:Label ID="lbl_IdTipoContacto" runat="server" AssociatedControlID="nb_IdTipoContacto" CssClass="col-xs-2 control-label">IdTipoContacto:</asp:Label>
					<div class="col-xs-10">
						<ew:NumericBox ID="nb_IdTipoContacto" runat="server" SkinID="skin_entero" Width="50px"></ew:NumericBox>
					</div>
				</div>
						<asp:RequiredFieldValidator ID="rfv_IdTipoContacto" runat="server" ErrorMessage="El campo IdTipoContacto es requerido." ForeColor="Red" ControlToValidate="nb_IdTipoContacto" ValidationGroup="vg_guardar" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
				<div class="form-group">
					<asp:Label ID="lbl_Nombre" runat="server" AssociatedControlID="txt_Nombre" CssClass="col-xs-2 control-label">Nombre:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_Nombre" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_Nombre" runat="server" ErrorMessage="El campo Nombre es requerido." ForeColor="Red" ControlToValidate="txt_Nombre" ValidationGroup="vg_guardar" Display="Dynamic"></asp:RequiredFieldValidator>
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
				<asp:GridView ID="gv_Datos" runat="server" Width="100%" SkinID="skin_grilla_sin_paginacion"
					PageSize="10" AllowPaging="True" DataKeyNames="IdTipoContacto"
					OnRowDataBound="gv_Datos_RowDataBound" OnSelectedIndexChanged="gv_Datos_SelectedIndexChanged"
					 OnPageIndexChanging="gv_Datos_PageIndexChanging">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="&nbsp;" HeaderStyle-Width="1px" />
						<asp:BoundField DataField="Nombre" HeaderText="NOMBRE" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
					</Columns>
				</asp:GridView>
				<div class="alert alert-info"><asp:Label ID="lbl_ContadorRegistros" runat="server"></asp:Label></div>
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="cScripts" ContentPlaceHolderID="cphScripts" runat="Server"></asp:Content>
