<%@ Page Title="" Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_ConsultaGarantias.aspx.cs" Inherits="sistema_consultas_wf_ConsultaGarantias" %>

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
                            <div class="col-xs-2">
                               <asp:TextBox Id="txt_Numero" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>
                            </div>
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="ddl_Alertas" CssClass="col-xs-1 control-label">Alerta:</asp:Label>
                                                    <div class="col-xs-2">
                               <asp:DropDownList ID="ddl_Alertas" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                                                     <asp:Label ID="Label2" runat="server" AssociatedControlID="ddl_Estados" CssClass="col-xs-1 control-label">Estados:</asp:Label>
                                                    <div class="col-xs-2">
                               <asp:DropDownList ID="ddl_Estados" runat="server" CssClass="form-control"></asp:DropDownList>
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
					OnRowDataBound="gv_Datos_RowDataBound" OnSelectedIndexChanged="gv_Datos_SelectedIndexChanged"
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
   
</asp:Content>

