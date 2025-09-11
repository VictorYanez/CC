<%@ Page Title="" Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_InformeGarantias.aspx.cs" Inherits="sistema_reportes_wf_InformeGarantias" %>
<%@ MasterType VirtualPath="~/master_ajax.master" %>
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
                                    <asp:Label ID="lbl_Periodo" runat="server" AssociatedControlID="lb_Contratos" CssClass="col-xs-1 control-label">Contrato:</asp:Label>
                                    <div class="col-xs-3">
                                         <asp:ListBox ID="lb_Contratos" runat="server" SelectionMode="Multiple" CssClass="form-control chzn-select" Width="100%" data-placeholder="Seleccione un contrato"></asp:ListBox>
                                    </div>
                                    <asp:Label ID="lbl_Alertas" runat="server" AssociatedControlID="ddl_Alertas" CssClass="col-xs-1 control-label">Alerta:</asp:Label>
                                     <div class="col-xs-3">
                                        <asp:DropDownList ID="ddl_Alertas" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="space"></div>
                                 <div class="row">
                                      <asp:Label ID="lbl_Concesionario" runat="server" AssociatedControlID="lb_Concesionarios" CssClass="col-xs-1 control-label">Concesionario:</asp:Label>
                                    <div class="col-xs-3">
                                        <asp:ListBox ID="lb_Concesionarios" SelectionMode="Multiple" runat="server" CssClass="form-control chzn-select" Width="100%" data-placeholder="Seleccione un concesionario"></asp:ListBox>
                                    </div>
                                   <asp:Label ID="lbl_estadoFlujo" runat="server" AssociatedControlID="lb_FlujosEstados" CssClass="col-xs-1 control-label">Flujo garantia:</asp:Label>
                                    <div class="col-xs-3">
                                        <asp:ListBox ID="lb_FlujosEstados" SelectionMode="Multiple" runat="server" CssClass="form-control chzn-select" Width="100%" data-placeholder="Seleccione un estado"></asp:ListBox>
                                    </div>
                                 </div>
                            <div class="space"></div>
                                  <div class="row">
                                       <asp:Label ID="Label1" runat="server" AssociatedControlID="txt_NumeroGarantia" CssClass="col-xs-1 control-label">Garantía:</asp:Label>
                                    <div class="col-xs-3">
                                    <asp:TextBox Id="txt_NumeroGarantia" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>
                                    </div>
                                       <asp:Label ID="Label2" runat="server" AssociatedControlID="txt_FechaIngresoInicial" CssClass="col-xs-1 control-label">F. Ingreso:</asp:Label>
                                    <div class="col-xs-1">
                                   <asp:TextBox Id="txt_FechaIngresoInicial" runat="server" CssClass="form-control" MaxLength="10" data-provide="datepicker" data-date-format="dd/mm/yyyy"></asp:TextBox>
                                    </div>
                                       <div class="col-xs-1">
                                            <asp:TextBox Id="txt_FechaIngresoFinal" runat="server" CssClass="form-control" MaxLength="10" data-provide="datepicker" data-date-format="dd/mm/yyyy"></asp:TextBox>
                                       </div>
                                  </div>
                                 <div class="space"></div>
                                 <div class="row">
                                     <div class="col-xs-4"></div>
                                       <div class="col-xs-1"></div>
                                        <div class="col-xs-3 text-right">
                                        <asp:LinkButton ID="lb_Filtrar" runat="server" SkinID="lbn_buscar" OnClick="lb_Filtrar_Click"></asp:LinkButton>
                                               <asp:LinkButton ID="lb_Imprimir" runat="server" ToolTip="Muestra la vista previa de impresi&oacute;n de informes"  CssClass="btn btn-success btn-xs" ValidationGroup="Reporte" OnClick="lb_Imprimir_Click"><i class="glyphicon glyphicon-print"></i> Imprimir</asp:LinkButton>
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
                  <div class="col-xs-12">
            <div class="space"></div>
                    <div class="pull-right">
                         <span class="label label-purple">
												PENDIENTE DE ENTREGA DE DOCUMENTOS
											</span>
                       
                         <span class="label label-warning">
												<i class="ace-icon fa fa-exclamation-triangle bigger-120"></i>
												POR VENCER
											</span>
                          <span class="label label-danger">
												<i class="ace-icon fa fa-minus-circle bigger-120"></i>
												VENCIDA
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
					PageSize="25" AllowPaging="True" DataKeyNames="IdGarantia" Font-Size="10px"
					OnRowDataBound="gv_Datos_RowDataBound" 
					 OnPageIndexChanging="gv_Datos_PageIndexChanging">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="&nbsp;" HeaderStyle-Width="1px" />
                          <asp:TemplateField HeaderText="N&Uacute;MERO" HeaderStyle-Width="6%">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                               <asp:Literal ID="lit_NumeroGarantia" runat="server"> </asp:Literal>                       
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="NumeroContrato" HeaderText="CONTRATO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Bold="true" />
                        <asp:BoundField DataField="Estado" HeaderText="ESTADO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
						<asp:BoundField DataField="Monto" HeaderText="MONTO" DataFormatString="{0:C2}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="8%" />
						<asp:BoundField DataField="FechaEmision" HeaderText="FECHA EMISI&Oacute;N" DataFormatString = "{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="8%" />
						<asp:BoundField DataField="FechaInicio" HeaderText="FECHA INICIO" DataFormatString = "{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="8%" />
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
      <script type="text/javascript">
          function pageLoad() {
              $(".chzn-select").chosen();
              $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
          }
  </script>
</asp:Content>

