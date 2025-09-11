<%@ Page Title="" Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_GarantiasRecibidas.aspx.cs" Inherits="sistema_gfi_wf_GarantiasRecibidas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphEncabezado" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" Runat="Server">
         <div class="row-fluid"> 
         <div class="col-md-12">
                  <div class="widget-box transparent">
                                       <div class="row-fluid">
									<div class="widget-box">
										<div class="widget-header widget-header-small header-color-dark">
											<h6>CRITERIOS DE BÚSQUEDA</h6>
										</div>
										<div class="widget-body">
											<div class="widget-main">
											   <div class="row">
                        
                              <asp:Label ID="lbl_Periodo" runat="server" AssociatedControlID="txt_Numero" CssClass="col-xs-1 control-label">Número:</asp:Label>
                            <div class="col-xs-2">
                               <asp:TextBox Id="txt_Numero" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>
                            </div>
                                                   <div class="col-xs-3">
                                                         <asp:LinkButton ID="lb_Filtrar" runat="server" SkinID="lbn_buscar" OnClick="lb_Filtrar_Click"></asp:LinkButton>
                                                 <asp:LinkButton ID="lb_Reestablecer" runat="server" SkinID="lb_Reestablecer" OnClick="lb_Reestablecer_Click"></asp:LinkButton>
                                                        
                                                         
                                                   </div>
                        </div>
											</div>
										
									
										</div>
									</div>
	   </div>
                        <!--/widget-body-->
								</div><!--/widget-box-->
        </div>
    </div>
     <div class="row-fluid"> 
 <div class="col-md-12">
        <div class="widget-box transparent">
                                       <div class="row-fluid">
									<div class="widget-box">
										<div class="widget-header widget-header-small header-color-dark">
											<h6>ACCIONES</h6>
										</div>
										<div class="widget-body">
											<div class="widget-main">
											   <div class="row">
                                                   <div class="col-xs-2">
                                                         <asp:LinkButton ID="lb_CambiarEstado" runat="server" SkinID="lbn-info" OnClick="lb_CambiarEstado_Click">Cambiar estado</asp:LinkButton>
                                                         <ajax:ConfirmButtonExtender ID="cbe_CambiarEstado" runat="server" TargetControlID="lb_CambiarEstado" ConfirmText="¿Confirma que desea cambiar de estado todas las garantias seleccionadas?. Al confirmar las garantias pasarán a estado en RESGUARDO por parte de la GFI."></ajax:ConfirmButtonExtender>
                                                      &nbsp;
                                                   </div>
                                                   <div class="col-xs-5">
                                                          <div class="alert alert-danger" id="div_alerta" runat="server" visible="false">
											<button type="button" class="close" data-dismiss="alert">
												<i class="ace-icon fa fa-times"></i>
											</button>
											<strong>Notificación!</strong>

											La acción no se puede ejecutar por que no existen registros seleccionados.
											
										</div>
                                                   </div>
                        </div>
											</div>
										
									
										</div>
									</div>
	   </div>
                        <!--/widget-body-->
								</div><!--/widget-box-->
 </div>
     </div>
     <div class="row-fluid">
         <div class="col-md-12">
             <div id="div_grilla_garantia" runat="server" class="widget-box widget-color-blue">
		<div class="widget-header">
			<h5 class="widget-title">Garant&iacute;as</h5>
		</div>
		<div class="widget-body">
			<div class="widget-main">
               
				<asp:GridView ID="gv_Datos" runat="server" Width="100%" SkinID="skin_grilla_sin_paginacion"
					PageSize="25" AllowPaging="True" DataKeyNames="IdGarantia" Font-Size="10px"
					OnRowDataBound="gv_Datos_RowDataBound" OnSelectedIndexChanged="gv_Datos_SelectedIndexChanged"
					 OnPageIndexChanging="gv_Datos_PageIndexChanging">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="&nbsp;" HeaderStyle-Width="1px" />
                          <asp:TemplateField HeaderText="&nbsp;">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                <asp:CheckBox ID="cb_Todos" runat="server" AutoPostBack="true" OnCheckedChanged="cb_Todos_CheckedChanged" />    
                            </HeaderTemplate>
                               <ItemTemplate>
                                <asp:CheckBox ID="cb_Garantia" runat="server" />    
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                          <asp:TemplateField HeaderText="N&Uacute;MERO" HeaderStyle-Width="6%">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                               <asp:Literal ID="lit_NumeroGarantia" runat="server"> </asp:Literal>                       
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="NumeroContrato" HeaderText="CONTRATO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Bold="true" />
						<asp:BoundField DataField="Concesionario" HeaderText="CONCESIONARIO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Estado" HeaderText="ESTADO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
						<asp:BoundField DataField="Monto" HeaderText="MONTO" DataFormatString="{0:C2}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="8%" />
						<asp:BoundField DataField="FechaEmision" HeaderText="FECHA EMISI&Oacute;N" DataFormatString = "{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="8%" />
						<asp:BoundField DataField="FechaVigenciaInicial" HeaderText="FECHA INICIO" DataFormatString = "{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="8%" />
                        <asp:TemplateField HeaderText="FECHA FIN" HeaderStyle-Width="8%">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                               <asp:Literal ID="lit_FechaVigenciaFinal" runat="server"> </asp:Literal>                       
                            </ItemTemplate>
                        </asp:TemplateField>
						<asp:BoundField DataField="Emisor" HeaderText="EMISOR" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="14%" />
						<asp:BoundField DataField="Forma" HeaderText="FORMA" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" />
					</Columns>
				</asp:GridView>
				<div class="alert alert-info"><asp:Label ID="lbl_ContadorRegistrosGarantias" runat="server"></asp:Label></div>
			</div>
		</div>
	</div>
       </div>
     </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
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

