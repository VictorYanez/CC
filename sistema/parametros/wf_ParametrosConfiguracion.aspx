<%@   Page Title="" Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_Parametrosconfiguracion.aspx.cs" Inherits="wf_Parametrosconfiguracion"%>
<%@ MasterType VirtualPath="~/master_ajax.master" %>

<asp:Content ID="cEncabezado" ContentPlaceHolderID="cphEncabezado" runat="Server"></asp:Content>

<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenido" runat="Server">
	<div id="div_wuc" runat="server">
		<wuc:uc_mantenimiento
			ID="wuc_mantto" runat="server"
			MostrarBuscar="false"
			OnEditar="Editar"
			OnGuardar="Guardar" OnCancelar="Cancelar"
			OnAplicarFiltro="AplicarFiltro" MostrarNuevo="false"
            MostrarBuscarPersonalizado="false"
		/>
	</div>

	<asp:Panel ID="pnl_campos" runat="server" CssClass="widget-box widget-color-green" Enabled="false">
		<div class="widget-header">
			<h5 class="widget-title"><asp:Label ID="lbl_Accion" runat="server"></asp:Label></h5>
		</div>
		<div class="widget-body">
			<div class="form-horizontal widget-main" role="form">
                <div class="form-group">
					<asp:Label ID="lbl_IdParametro" runat="server" AssociatedControlID="txt_IdParametro" CssClass="col-xs-2 control-label">Parametro:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_IdParametro" runat="server" CssClass="form-control" MaxLength="3"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_IdParametro" runat="server" ErrorMessage="El campo IdParametro es requerido." ForeColor="Red" ControlToValidate="txt_IdParametro" ValidationGroup="vg_guardar" Display="Dynamic"></asp:RequiredFieldValidator>
					</div>
                    </div>
				<div class="form-group">
					<asp:Label ID="lbl_Nombre" runat="server" AssociatedControlID="txt_Nombre" CssClass="col-xs-2 control-label">Nombre:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_Nombre" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_Nombre" runat="server" ErrorMessage="El campo Nombre es requerido." ForeColor="Red" ControlToValidate="txt_Nombre" ValidationGroup="vg_guardar" Display="Dynamic"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="lbl_ValorNumerico" runat="server" AssociatedControlID="nb_ValorNumerico" CssClass="col-xs-2 control-label">Valor num&eacute;rico:</asp:Label>
					<div class="col-xs-10">
						<ew:NumericBox ID="nb_ValorNumerico" runat="server" SkinID="skin_entero" CssClass="form-control"></ew:NumericBox>
                        <asp:RequiredFieldValidator ID="rfv_ValorNumerico" runat="server" ErrorMessage="El campo valor numérico es requerido." ForeColor="Red" ControlToValidate="nb_ValorNumerico" ValidationGroup="vg_guardar" Display="Dynamic"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="lbl_ValorCadena" runat="server" AssociatedControlID="txt_ValorCadena" CssClass="col-xs-2 control-label">Valor cadena:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_ValorCadena" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
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
					PageSize="10" AllowPaging="false" DataKeyNames="IdParametro"
					OnRowDataBound="gv_Datos_RowDataBound" OnSelectedIndexChanged="gv_Datos_SelectedIndexChanged"
					 >
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="&nbsp;" HeaderStyle-Width="1px" />
						<asp:BoundField DataField="IdParametro" HeaderText="PARAMETRO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
						<asp:BoundField DataField="Nombre" HeaderText="NOMBRE" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
						<asp:BoundField DataField="ValorNumerico" HeaderText="VALOR NUMERICO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
						<asp:BoundField DataField="ValorCadena" HeaderText="VALOR CADENA" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
					</Columns>
				</asp:GridView>
				
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="cScripts" ContentPlaceHolderID="cphScripts" runat="Server"></asp:Content>
