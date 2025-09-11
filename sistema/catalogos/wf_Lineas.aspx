<%@   Page Title="Tabla que almacena las lineas emitidas para concesiones." Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_Lineas.aspx.cs" Inherits="wf_Lineas"%>
<%@ MasterType VirtualPath="~/master_ajax.master" %>

<asp:Content ID="cEncabezado" ContentPlaceHolderID="cphEncabezado" runat="Server">

</asp:Content>

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
					<asp:Label ID="lbl_IdLinea" runat="server" AssociatedControlID="nb_IdLinea" CssClass="col-xs-2 control-label">IdLinea:</asp:Label>
					<div class="col-xs-10">
						<ew:NumericBox ID="nb_IdLinea" runat="server" SkinID="skin_entero" Width="50px"></ew:NumericBox>
					</div>
				</div>
						<asp:RequiredFieldValidator ID="rfv_IdLinea" runat="server" ErrorMessage="El campo IdLinea es requerido." ForeColor="Red" ControlToValidate="nb_IdLinea" ValidationGroup="vg_guardar" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
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
					PageSize="25" AllowPaging="True" DataKeyNames="IdLinea"
					OnRowDataBound="gv_Datos_RowDataBound" OnSelectedIndexChanged="gv_Datos_SelectedIndexChanged"
					 OnPageIndexChanging="gv_Datos_PageIndexChanging">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="&nbsp;" HeaderStyle-Width="1px" />
						<asp:BoundField DataField="Nombre" HeaderText="NOMBRE" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Numero" HeaderText="CONTRATO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="NombreConcesionario" HeaderText="CONCESIONARIO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                          <asp:TemplateField HeaderText="ESTADO">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                               <asp:Literal ID="lit_EstadoLinea" runat="server"> </asp:Literal>                       
                            </ItemTemplate>
                        </asp:TemplateField>
					</Columns>
				</asp:GridView>
				<div class="alert alert-info"><asp:Label ID="lbl_ContadorRegistros" runat="server"></asp:Label></div>
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="cScripts" ContentPlaceHolderID="cphScripts" runat="Server">
     <script src="../../assets/js/sweetalert.min.js"></script>
    <script type="text/javascript">
        function Notificacion(titulo, texto, icono, textoButon) {
            titulo = decode_utf8(titulo);
            texto = decode_utf8(texto);
            swal({
                title: titulo,
                text: texto,
                icon: icono,
                button: textoButon
            });
        }

        function decode_utf8(s) {
            return decodeURIComponent(escape(s));
        }
    </script>
</asp:Content>
