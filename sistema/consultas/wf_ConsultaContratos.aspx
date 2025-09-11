<%@ Page Title="" Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_ConsultaContratos.aspx.cs" Inherits="sistema_consultas_wf_ConsultaContratos" %>

<%@ Register Src="~/sistema/wuc/wuc_InformacionContactos.ascx" TagPrefix="wuc" TagName="wuc_InformacionContactos" %>


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
                                    <div class="col-xs-1">
                                        <asp:TextBox ID="txt_Numero" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>
                                    </div>
                                    <asp:Label ID="lbl_Alertas" runat="server" AssociatedControlID="ddl_Alertas" CssClass="col-xs-1 control-label">Alerta:</asp:Label>
                                     <div class="col-xs-2">
                                        <asp:DropDownList ID="ddl_Alertas" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <asp:Label ID="lbl_Concesionario" runat="server" AssociatedControlID="ddl_Concesionarios" CssClass="col-xs-1 control-label">Concesionario:</asp:Label>
                                    <div class="col-xs-2">
                                        <asp:DropDownList ID="ddl_Concesionarios" runat="server" CssClass="form-control chzn-select" Width="100%"></asp:DropDownList>
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
            </div>
            <!--/widget-box-->
        </div>
    </div>
     <div class="row-fluid">
           <div class="col-xs-12">
            <div class="space"></div>
                    <div class="pull-right">
                       
                         <span class="label label-warning">
												<i class="ace-icon fa fa-exclamation-triangle bigger-120"></i>
												POR VENCER
											</span>
                          <span class="label label-danger">
												<i class="ace-icon fa fa-minus-circle bigger-120"></i>
												VENCIDO
											</span>
                    </div>
                </div>
    <div class="col-md-12">
             <div id="div_grilla_garantia" runat="server" class="widget-box widget-color-blue">
		<div class="widget-header">
			<h5 class="widget-title">Garant&iacute;as</h5>
		</div>
		<div class="widget-body">
			<div class="widget-main">
      <asp:GridView ID="gv_Datos" runat="server" Width="100%" SkinID="skin_grilla_sin_paginacion"
					PageSize="25" AllowPaging="True" DataKeyNames="IdContrato" Font-Size="10px"
					OnRowDataBound="gv_Datos_RowDataBound" 
					 OnPageIndexChanging="gv_Datos_PageIndexChanging" OnSelectedIndexChanged="gv_Datos_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="&nbsp;" HeaderStyle-Width="1px" />
                         <asp:TemplateField HeaderText="N&Uacute;MERO">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                               <asp:Literal ID="lit_NumeroContrato" runat="server"> </asp:Literal>                       
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Concesionario" HeaderText="CONCESIONARIO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" />
						<asp:BoundField DataField="FechaVigenciaInicial" HeaderText="FECHA INICIO" DataFormatString = "{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="12%" />
                          <asp:TemplateField HeaderText="FECHA FIN" HeaderStyle-Width="12%">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                               <asp:Literal ID="lit_FechaVigenciaFinalContrato" runat="server"> </asp:Literal>                       
                            </ItemTemplate>
                        </asp:TemplateField>
						<asp:BoundField DataField="NumeroContratoDependiente" HeaderText="CONTRATO DEPENDIENTE" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="16%" />
                          <asp:TemplateField HeaderText="LINEAS" HeaderStyle-Width="8%">
                            <ItemStyle HorizontalAlign="Center" />
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                               <span class="badge badge-success" title="L&iacute;neas activas"><asp:Literal ID="lit_CantidadLineas" runat="server" Text="0"></asp:Literal></span>       
                                <span class="badge badge" title="L&iacute;neas inactivas"><asp:Literal ID="lit_CantidadLineasInactivas" runat="server" Text="0"></asp:Literal></span>                                                      
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="GARANTIAS" HeaderStyle-Width="8%">
                            <ItemStyle HorizontalAlign="Center" />
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                               <span class="badge badge-primary" title="Garant&iacute;as del contrato"><asp:Literal ID="lit_CantidadGarantias" runat="server" Text="0"></asp:Literal></span>
                            </ItemTemplate>
                        </asp:TemplateField>
					</Columns>
				</asp:GridView>
				<div class="alert alert-info"><asp:Label ID="lbl_ContadorRegistros" runat="server"></asp:Label></div> 
                	</div>
		</div>
	</div>
       </div>
   </div>
      <!--INICIO VENTANA MODAL INFORMACIÓN CONTACTOS-->
    <asp:Panel ID="pnl_InformacionContactos" runat="server" CssClass="modal-dialog modalAsignarLinea">
        <div class="modal-body">
            <div class="widget-main form-horizontal">
                 <div style="height: 300px; width: 98%; overflow: auto;">
                     <wuc:wuc_InformacionContactos runat="server" ID="wuc_InformacionContactos" />
                 </div>
            </div>
        </div>
        <div class="modal-footer">
             <asp:LinkButton ID="lb_CerrarModalInformacionContacto" runat="server" ToolTip="Cerrar ventana" CssClass="btn btn-warning"><i class="glyphicon glyphicon-remove-sign"></i>&nbsp;Cerrar</asp:LinkButton>             
        </div>
        <ajax:ModalPopupExtender ID="mpe_ModalInformacionContactos" runat="server" TargetControlID="hf_ModalInformacionContactos" PopupControlID="pnl_InformacionContactos"
            BackgroundCssClass="modal-backdrop" SkinID="mpe_animado" CancelControlID="lb_CerrarModalInformacionContacto">
        </ajax:ModalPopupExtender>
    </asp:Panel>
     <asp:HiddenField ID="hf_ModalInformacionContactos" runat="server" />
     <!--FIN VENTANA MODAL INFORMACIÓN CONTACTOS-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
  <script type="text/javascript">
     function pageLoad() {
             $(".chzn-select").chosen();
             $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
             $('[data-rel=popover]').popover({ container: 'body' });
     }
  </script>
</asp:Content>

