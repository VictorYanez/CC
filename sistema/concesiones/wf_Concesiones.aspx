<%@ Page Title="Administración de concesiones y garantías" Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_Concesiones.aspx.cs" Inherits="sistema_concesiones_wf_Concesiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphEncabezado" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" Runat="Server">
<div id="div_wucc" runat="server">
		<wuc:uc_mantenimiento
			ID="wuc_mantto" runat="server"
			MostrarBuscar="false"
			OnNuevo="Nuevo" OnEditar="Editar" OnEliminar="Eliminar"
			OnGuardar="Guardar" OnCancelar="Cancelar"
			OnFinalizar="Finalizar"
            OnAsignarLineas="AsignarLineas" OnNuevaModificativa="NuevaModificativa"
            OnBuscarPersonalizado="BuscarPersonalizado"
		/>
	</div>
	
    <asp:Panel ID="pnl_campos" runat="server" CssClass="widget-box widget-color-green" Enabled="false">
		<div class="widget-header">
			<h5 class="widget-title"><asp:Label ID="lbl_Accion" runat="server"></asp:Label></h5>
		</div>
		<div class="widget-body">
			<div class="form-horizontal widget-main" role="form">
				<div class="form-group hidden">
					<asp:Label ID="lbl_IdContrato" runat="server" AssociatedControlID="nb_IdContrato" CssClass="col-xs-2 control-label">IdContrato:</asp:Label>
					<div class="col-xs-10">
						<ew:NumericBox ID="nb_IdContrato" runat="server" SkinID="skin_entero" Width="50px"></ew:NumericBox>
					</div>
				</div>
						<asp:RequiredFieldValidator ID="rfv_IdContrato" runat="server" ErrorMessage="El campo IdContrato es requerido." ForeColor="Red" ControlToValidate="nb_IdContrato" ValidationGroup="vg_guardar" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
				<div class="form-group">
					<asp:Label ID="lbl_Numero" runat="server" AssociatedControlID="txt_Numero" CssClass="col-xs-2 control-label">N&uacute;mero:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_Numero" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_Numero" runat="server"  ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small" ControlToValidate="txt_Numero" ValidationGroup="vg_guardar" Display="Dynamic"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="lbl_FechaVigenciaInicial" runat="server" AssociatedControlID="txt_FechaVigenciaInicial" CssClass="col-xs-2 control-label">Fecha inicio:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_FechaVigenciaInicial" runat="server" CssClass="form-control" MaxLength="10" data-provide="datepicker" data-date-format="dd/mm/yyyy" onblur="agregarDiezAnios()"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_FechaVigenciaInicial" runat="server"  ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small" ControlToValidate="txt_FechaVigenciaInicial" ValidationGroup="vg_guardar" Display="Dynamic"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="lbl_FechaVigenciaFinal" runat="server" AssociatedControlID="txt_FechaVigenciaFinal" CssClass="col-xs-2 control-label">Fecha fin:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_FechaVigenciaFinal" runat="server" CssClass="form-control" MaxLength="10" data-provide="datepicker" data-date-format="dd/mm/yyyy"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_FechaVigenciaFinal" runat="server"  ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small" ControlToValidate="txt_FechaVigenciaFinal" ValidationGroup="vg_guardar" Display="Dynamic"></asp:RequiredFieldValidator>
					</div>
				</div>
                <div class="form-group">
					<asp:Label ID="lbl_Concesionario" runat="server" AssociatedControlID="ddl_Concesionarios" CssClass="col-xs-2 control-label">Concesionario:</asp:Label>
					<div class="col-xs-10">
						<asp:DropDownList ID="ddl_Concesionarios" runat="server" CssClass="form-control chzn-select" Width="100%"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_Concesionarios" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small" ControlToValidate="ddl_Concesionarios" ValidationGroup="vg_guardar" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
					</div>
				</div>
                  <div class="form-group">
                    <asp:Label ID="lbl_ComentarioContrato" runat="server" AssociatedControlID="txt_ComentarioContrato" CssClass="col-xs-2 control-label">Comentario:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_ComentarioContrato" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
					</div>
                </div>
				<div class="form-group">
					<asp:Label ID="lbl_Contratos" runat="server" AssociatedControlID="ddl_Contratos" CssClass="col-xs-2 control-label">Contrato dependiente:</asp:Label>
					<div class="col-xs-10">
						<asp:DropDownList ID="ddl_Contratos" runat="server" CssClass="form-control chzn-select" Width="100%" Enabled="false"></asp:DropDownList>
					</div>
				</div>
               <div class="form-group">
					<asp:Label ID="lbl_ModificativaContrato" runat="server" AssociatedControlID="txt_NumeroModificativa" CssClass="col-xs-2 control-label">No. Modificaci&oacute;n:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_NumeroModificativa" runat="server" CssClass="form-control" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txt_NumeroModificativa"></ajax:FilteredTextBoxExtender>
					</div>
				</div>
                 <div class="form-group">
					<asp:Label ID="lb_ResolucionContrato" runat="server" AssociatedControlID="txt_ResolucionContrato" CssClass="col-xs-2 control-label">Resoluci&oacute;n:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_ResolucionContrato" runat="server" CssClass="form-control" TextMode="SingleLine" ReadOnly="true" MaxLength="20"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfv_ResolucionContrato" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small" ControlToValidate="txt_ResolucionContrato" ValidationGroup="vg_guardar" Display="Dynamic"></asp:RequiredFieldValidator>
					</div>
				</div>
			</div>
		</div>
	</asp:Panel>
	
  <div id="div_grilla" runat="server" class="widget-box widget-color-blue">
		<div class="widget-header">
			<h5 class="widget-title">Contratos</h5>
		</div>
		<div class="widget-body">
			<div class="widget-main">
                <div class="col-xs-12">
                    <div class="pull-right">
                        <span class="label label-grey">
												MODIFICATIVA
											</span>
                         <span class="label label-success">
												LINEAS ACTIVAS
											</span>
                         <span class="label">
												LINEAS INACTIVAS
											</span>
                        &nbsp;&nbsp;
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
                  <div class="space"></div>
				<asp:GridView ID="gv_Datos_Contratos" runat="server" Width="100%" SkinID="skin_grilla_sin_paginacion"
					PageSize="10" AllowPaging="True" DataKeyNames="IdContrato, Numero, Finalizado, DiasAlertas, CodigoConcesionario,FechaVigenciaInicial,FechaVigenciaFinal, Modificativa"
					OnRowDataBound="gv_Datos_Contratos_RowDataBound" OnSelectedIndexChanged="gv_Datos_Contratos_SelectedIndexChanged"
					 OnPageIndexChanging="gv_Datos_Contratos_PageIndexChanging">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="&nbsp;" HeaderStyle-Width="1px" />
                         <asp:TemplateField HeaderText="N&Uacute;MERO" HeaderStyle-Width="13%">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                               <asp:Literal ID="lit_NumeroContrato" runat="server"> </asp:Literal>                       
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdConcesionario.Abreviatura" HeaderText="CONCESIONARIO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
						<asp:BoundField DataField="FechaVigenciaInicial" HeaderText="FECHA INICIO" DataFormatString = "{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" />
                          <asp:TemplateField HeaderText="FECHA FIN" HeaderStyle-Width="10%">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                               <asp:Literal ID="lit_FechaVigenciaFinalContrato" runat="server"> </asp:Literal>                       
                            </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="CONTRATO BASE" HeaderStyle-Width="9%">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                               <asp:Literal ID="lit_NumeroContratoDependiente" runat="server"> </asp:Literal>                       
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Resolucion" HeaderText="RESOLUCI&Oacute;N" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="9%" />
                        <asp:TemplateField HeaderText="COMENTARIO" HeaderStyle-Width="4%">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                 <asp:Literal ID="lit_ComentarioContrato" runat="server"> </asp:Literal>       
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="LINEAS" HeaderStyle-Width="6%">
                            <ItemStyle HorizontalAlign="Center" />
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                               <span class="badge badge-success" title="L&iacute;neas activas"><asp:Literal ID="lit_CantidadLineas" runat="server" Text="0"></asp:Literal></span>       
                                <span class="badge badge" title="L&iacute;neas inactivas"><asp:Literal ID="lit_CantidadLineasInactivas" runat="server" Text="0"></asp:Literal></span>                                                      
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="GARANTIAS" HeaderStyle-Width="6%">
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
    
    <div id="div_Mantenimiento" runat="server">
        <div class="hr hr-dotted hr-16"></div>
        <div class="row">
            <div class="col-xs-12">
                <div class="btn-toolbarr">
                    <div class="btn-groupp">
                        <asp:LinkButton ID="lb_NuevaGarantia" runat="server" SkinID="lbn_nuevo" OnClick="lb_NuevaGarantia_Click" Visible="false"></asp:LinkButton>
                        <asp:LinkButton ID="lb_EditarGarantia" runat="server" SkinID="lbn_editar" OnClick="lb_EditarGarantia_Click" Visible="false"></asp:LinkButton>
                        <asp:LinkButton ID="lb_EliminarGarantia" runat="server" SkinID="lbn_eliminar" OnClick="lb_EliminarGarantia_Click" Visible="false"></asp:LinkButton>
                        <ajax:ConfirmButtonExtender ID="cbe_EliminarGarantia" runat="server" TargetControlID="lb_EliminarGarantia" ConfirmText="&#191;Confirma que desea eliminar el registro?"></ajax:ConfirmButtonExtender>
                        <asp:HiddenField ID="hf_accion" runat="server" />
                        &nbsp;&nbsp;&nbsp;
                         <asp:LinkButton ID="lb_CambiarEstadoGarantia" runat="server" SkinID="lb_CambiarEstadoGarantia" OnClick="lb_CambiarEstadoGarantia_Click" Visible="false"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
         <div class="hr hr-dotted hr-16"></div>
    </div>

   <asp:HiddenField ID="hf_IdGarantia" runat="server" Value="0"/>
   <asp:HiddenField ID="hf_NumeroContratoModificativa" runat="server"/>
   <asp:HiddenField ID="hf_FechaVigenciaInicialModificativa" runat="server"/>
   <asp:HiddenField ID="hf_FechaVigenciaFinalModificativa" runat="server"/>
      <asp:HiddenField ID="hf_IdContratoDependiente" runat="server"/>
  <div id="div_grilla_garantia" runat="server" class="widget-box widget-color-blue2">
		<div class="widget-header">
			<h5 class="widget-title">Garant&iacute;as</h5>
		</div>
		<div class="widget-body">
			<div class="widget-main">
                <div class="col-xs-12">
                    <div class="pull-right">
                         <span class="label label-purple">
												PENDIENTE DE ENTREGA DE DOCUMENTOS
											</span>
                        &nbsp;&nbsp;
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
                <div class="space"></div>
				<asp:GridView ID="gv_Datos_Garantias" runat="server" Width="100%" SkinID="skin_grilla_sin_paginacion"
					PageSize="10" AllowPaging="True" DataKeyNames="IdGarantia, Final"
					OnRowDataBound="gv_Datos_Garantias_RowDataBound" OnSelectedIndexChanged="gv_Datos_Garantias_SelectedIndexChanged"
					 OnPageIndexChanging="gv_Datos_Garantias_PageIndexChanging">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="&nbsp;" HeaderStyle-Width="1px" />
                          <asp:TemplateField HeaderText="N&Uacute;MERO">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                               <asp:Literal ID="lit_NumeroGarantia" runat="server"> </asp:Literal>                       
                            </ItemTemplate>
                        </asp:TemplateField>
						
                        <asp:BoundField DataField="IdEstadoActual.Nombre" HeaderText="ESTADO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
						<asp:BoundField DataField="Monto" HeaderText="MONTO" DataFormatString="{0:C2}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="8%" />
						<asp:BoundField DataField="FechaEmision" HeaderText="FECHA EMISI&Oacute;N" DataFormatString = "{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="8%" />
						<asp:BoundField DataField="FechaVigenciaInicial" HeaderText="FECHA INICIO" DataFormatString = "{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="8%" />
                          <asp:TemplateField HeaderText="FECHA FIN" HeaderStyle-Width="8%">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                               <asp:Literal ID="lit_FechaVigenciaFinal" runat="server"> </asp:Literal>                       
                            </ItemTemplate>
                        </asp:TemplateField>
						<asp:BoundField DataField="IdEmisor.Nombre" HeaderText="EMISOR" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="14%" />
						<asp:BoundField DataField="IdForma.Nombre" HeaderText="FORMA" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" />
                        <asp:TemplateField HeaderText="COMENTARIO" HeaderStyle-Width="4%">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                 <asp:Literal ID="lit_ComentarioGarantia" runat="server"> </asp:Literal>       
                            </ItemTemplate>
                        </asp:TemplateField>
					</Columns>
				</asp:GridView>
				<div class="alert alert-info"><asp:Label ID="lbl_ContadorRegistrosGarantias" runat="server"></asp:Label></div>
			</div>
		</div>
	</div>

      <!--INICIO VENTANA MODAL DE CONTACTO-->
    <asp:Panel ID="pnl_Garantia" runat="server" CssClass="modal-dialog modalGarantia">
        <div class="modal-body">
            <div class="widget-main form-horizontal">
               <div class="form-group">
					<asp:Label ID="lbl_NumeroGarantia" runat="server" AssociatedControlID="txt_NumeroGarantia" CssClass="col-xs-2 control-label">N&uacute;mero:</asp:Label>
					<div class="col-xs-4">
						<asp:TextBox Id="txt_NumeroGarantia" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_NumeroGarantia" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small" ControlToValidate="txt_NumeroGarantia" ValidationGroup="vg_guardar_garantia" Display="Dynamic"></asp:RequiredFieldValidator>
					</div>
                   <asp:Label ID="lbl_Monto" runat="server" AssociatedControlID="nb_Monto" CssClass="col-xs-2 control-label">Monto:</asp:Label>
					<div class="col-xs-4">
						<ew:NumericBox ID="nb_Monto" runat="server" SkinID="skin_flotante" CssClass="form-control" TextAlign="Left"></ew:NumericBox>
						<asp:RequiredFieldValidator ID="rfv_Monto" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small" ControlToValidate="nb_Monto" ValidationGroup="vg_guardar_garantia" Display="Dynamic"></asp:RequiredFieldValidator>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="lbl_FechaEmisionGarantia" runat="server" AssociatedControlID="txt_FechaEmisionGarantia" CssClass="col-xs-2 control-label">Fecha emisi&oacute;n:</asp:Label>
					<div class="col-xs-2">
						<asp:TextBox Id="txt_FechaEmisionGarantia" runat="server" CssClass="form-control" MaxLength="10" data-provide="datepicker" data-date-format="dd/mm/yyyy"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_FechaEmisionGarantia" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small"  ControlToValidate="txt_FechaEmisionGarantia" ValidationGroup="vg_guardar_garantia" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_FechaEmisionGarantia" runat="server" ErrorMessage="Fecha incorrecta" ControlToValidate="txt_FechaEmisionGarantia" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/]\d{4}" ForeColor="Red" Font-Size="XX-Small" ValidationGroup="vg_guardar_garantia" Display="Dynamic" ValidateEmptyText="false"></asp:RegularExpressionValidator>
					</div>
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="txt_FechaVigenciaInicial" CssClass="col-xs-2 control-label">Fecha inicio:</asp:Label>
					<div class="col-xs-2">
						<asp:TextBox Id="txt_FechaVigenciaInicialGarantia" runat="server" CssClass="form-control" MaxLength="10" data-provide="datepicker" data-date-format="dd/mm/yyyy"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_FechaVigenciaInicialGarantia" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small"  ControlToValidate="txt_FechaVigenciaInicialGarantia" ValidationGroup="vg_guardar_garantia" Display="Dynamic"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="rev_FechaVigenciaInicialGarantia" runat="server" ErrorMessage="Fecha incorrecta" ControlToValidate="txt_FechaVigenciaInicialGarantia" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" ForeColor="Red" Font-Size="XX-Small" ValidationGroup="vg_guardar_garantia" Display="Dynamic"></asp:RegularExpressionValidator>
					</div>
                    <asp:Label ID="lbl_FechaVigenciaFinalGarantia" runat="server" AssociatedControlID="txt_FechaVigenciaFinalGarantia" CssClass="col-xs-2 control-label">Fecha fin:</asp:Label>
					<div class="col-xs-2">
						<asp:TextBox Id="txt_FechaVigenciaFinalGarantia" runat="server" CssClass="form-control" MaxLength="10" data-provide="datepicker" data-date-format="dd/mm/yyyy"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_FechaVigenciaFinalGarantia" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small"  ControlToValidate="txt_FechaVigenciaFinalGarantia" ValidationGroup="vg_guardar_garantia" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_FechaVigenciaFinalGarantia" runat="server" ErrorMessage="Fecha incorrecta" ControlToValidate="txt_FechaVigenciaFinalGarantia" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" ForeColor="Red" Font-Size="XX-Small" ValidationGroup="vg_guardar_garantia" Display="Dynamic"></asp:RegularExpressionValidator>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="lbl_Emisores" runat="server" AssociatedControlID="ddl_Emisores" CssClass="col-xs-2 control-label">Emisor:</asp:Label>
					<div class="col-xs-4">
						<asp:DropDownList ID="ddl_Emisores" runat="server" CssClass="form-control"></asp:DropDownList>
						<asp:RequiredFieldValidator ID="rfv_Emisores" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small"  ControlToValidate="ddl_Emisores" ValidationGroup="vg_guardar_garantia" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
					</div>
                    <asp:Label ID="lbl_FormasGarantias" runat="server" AssociatedControlID="ddl_FormasGarantias" CssClass="col-xs-2 control-label">Forma:</asp:Label>
					<div class="col-xs-4">
						<asp:DropDownList ID="ddl_FormasGarantias" runat="server" CssClass="form-control"></asp:DropDownList>
						<asp:RequiredFieldValidator ID="rfv_FormasGarantias" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small" ControlToValidate="ddl_FormasGarantias" ValidationGroup="vg_guardar_garantia" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
					</div>
				</div>
                <div class="form-group">
                    <asp:Label ID="lbl_ComentarioGarantia" runat="server" AssociatedControlID="txt_ComentarioGarantia" CssClass="col-xs-2 control-label">Comentario:</asp:Label>
					<div class="col-xs-10">
						<asp:TextBox Id="txt_ComentarioGarantia" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
					</div>
                </div>
                <div class="space"></div>
				<div class="form-group">
                    <asp:Label ID="lbl_DocumentacionPendiente" runat="server" AssociatedControlID="ddl_Emisores" CssClass="col-xs-2 control-label"></asp:Label>
					<div class="col-xs-10">
						<div class="checkbox">

													<label>
                                                        <asp:CheckBox ID="cb_DocumentacionPendiente" runat="server" CssClass="ace" />
														<span class="lbl"> &#191;Hay documentaci&oacute;n pendiente?</span>
													</label>
												</div>
					</div>
				</div>
            </div>
        </div>
        <div class="modal-footer">
             <asp:LinkButton ID="lb_GuardarGarantia" runat="server" ToolTip="Guardar contacto" ValidationGroup="vg_guardar_garantia" CssClass="btn btn-success" OnClick="lb_GuardarGarantia_Click"><i class="glyphicon glyphicon-ok-sign"></i>&nbsp;Guardar</asp:LinkButton>  
             <asp:LinkButton ID="lb_CerrarModalGarantia" runat="server" ToolTip="Cerrar ventana" CssClass="btn btn-warning"><i class="glyphicon glyphicon-remove-sign"></i>&nbsp;Cerrar</asp:LinkButton>             
        </div>
        <ajax:ModalPopupExtender ID="mpe_Garantia" runat="server" TargetControlID="hf_ModalGarantia" PopupControlID="pnl_Garantia"
            BackgroundCssClass="modal-backdrop" SkinID="mpe_animado" CancelControlID="lb_CerrarModalGarantia">
        </ajax:ModalPopupExtender>
    </asp:Panel>
     <asp:HiddenField ID="hf_ModalGarantia" runat="server" />
     <!--FIN VENTANA MODAL DE ENCABEZADO-->
    
       <!--INICIO VENTANA MODAL DE CAMBIAR ESTADO GARANTIA-->
    <asp:Panel ID="pnl_CambiarEstadoGarantia" runat="server" CssClass="modal-dialog modalCambiarEstado">
        <div class="modal-body">
            <div class="widget-main form-horizontal">
				<div class="form-group">
					<asp:Label ID="lbl_Estados" runat="server" AssociatedControlID="ddl_Estados" CssClass="col-xs-2 control-label">Estado:</asp:Label>
					<div class="col-xs-8">
						<asp:DropDownList ID="ddl_Estados" runat="server" CssClass="form-control"></asp:DropDownList>
						<asp:RequiredFieldValidator ID="rfv_Estados" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small"  ControlToValidate="ddl_Estados" ValidationGroup="AsignarLinea" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
					</div>
				</div>
            </div>
        </div>
        <div class="modal-footer">
             <asp:LinkButton ID="lb_GuardarCambiarEstadoGarantia" runat="server" ToolTip="Guardar selección" ValidationGroup="vg_cambiar_estado" CssClass="btn btn-success" OnClick="lb_GuardarCambiarEstadoGarantia_Click"><i class="glyphicon glyphicon-ok-sign"></i>&nbsp;Guardar</asp:LinkButton>  
             <asp:LinkButton ID="lb_CerarModalCambiarEstadoGarantia" runat="server" ToolTip="Cerrar ventana" CssClass="btn btn-warning"><i class="glyphicon glyphicon-remove-sign"></i>&nbsp;Cerrar</asp:LinkButton>             
        </div>
        <ajax:ModalPopupExtender ID="mpe_ModalCambiarEstadoGarantia" runat="server" TargetControlID="hf_ModalCambiarEstadoGarantia" PopupControlID="pnl_CambiarEstadoGarantia"
            BackgroundCssClass="modal-backdrop" SkinID="mpe_animado" CancelControlID="lb_CerarModalCambiarEstadoGarantia">
        </ajax:ModalPopupExtender>
    </asp:Panel>
     <asp:HiddenField ID="hf_ModalCambiarEstadoGarantia" runat="server" />
     <!--FIN VENTANA MODAL DE CAMBIAR ESTADO GARANTIA-->

      <!--INICIO VENTANA MODAL LÍNEAS-->
    <asp:Panel ID="pnl_Lineas" runat="server" CssClass="modal-dialog modalAsignarLinea">
        <div class="modal-body">
            <div class="widget-main form-horizontal">
				<div class="form-group">
					<asp:Label ID="lbl_LineasDisponibles" runat="server" AssociatedControlID="ddl_LineasDisponibles" CssClass="col-xs-2 control-label">L&iacute;neas:</asp:Label>
					<div class="col-xs-8">
						<asp:DropDownList ID="ddl_LineasDisponibles" runat="server" CssClass="chzn-select" Width="100%"></asp:DropDownList>

						<asp:RequiredFieldValidator ID="rfv_LineasDisponibles" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small"  ControlToValidate="ddl_LineasDisponibles" ValidationGroup="vg_guardar_linea" Display="Dynamic" InitialValue="-- SELECCIONE --"></asp:RequiredFieldValidator>
					</div>
                     <div class="col-xs-2">
                         <asp:LinkButton ID="lb_AsignarLinea" runat="server" ToolTip="Asignar l&iacute;nea" CssClass="btn btn-info btn-round btn-sm" ValidationGroup="vg_guardar_linea" OnClick="lb_AsignarLinea_Click"><i class="glyphicon glyphicon-arrow-down"></i>&nbsp;Asignar</asp:LinkButton>
                    </div>
				</div>
                <div class="space"></div>
                <hr />
                 <div style="height: 300px; width: 98%; overflow: auto;">
                     <asp:Repeater ID="rep_Asignaciones" runat="server" OnItemDataBound="rep_Asignaciones_ItemDataBound" OnItemCommand="rep_Asignaciones_ItemCommand">
    <HeaderTemplate>
        <div class="widget-main no-padding">
            <table class="table table-striped table-bordered table-hover" style="border: 1px solid #ddd; font-size: 10px">
                <thead>
                    <tr>
                        <th>L&iacute;nea
                        </th>
                        <th>Contrato
                        </th>
                        <th>Concesionario
                        </th>
                       <th>Estado</th>
                        <th>&nbsp;</th>
                    </tr>
                </thead>

                <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td class=""><asp:Literal ID="lit_NombreLinea" runat="server"></asp:Literal></td>
            <td class=""><asp:Literal ID="lit_NumeroContrato" runat="server"></asp:Literal></td>
            <td class=""><asp:Literal ID="lit_NombreConcesionario" runat="server"></asp:Literal></td>
            <td class="">
                <div class="center">                 
                    <asp:LinkButton ID="lb_CambiarEstadoAsignacion" runat="server" ToolTip="Cambiar estado" CommandName="CambiarEstadoAsignacion" OnClientClick="return confirm('&iquest;Confirma que cambiar&aacute; el estado de asignaci&oacute;n de la l&iacute;nea?');"><i style="font-size: 15px" class="glyphicon glyphicon-ok-sign green"></i></asp:LinkButton>
                    <i id="iconEstado" runat="server" style="font-size: 15px" class="glyphicon glyphicon-remove-sign red"></i>
                </div>
            </td>
            <td class="">
                <div class="center">                 
                    <asp:LinkButton ID="lb_QuitarLinea" runat="server" ToolTip="Quitar l&iacute;nea" CommandName="QuitarLinea" OnClientClick="return confirm('&iquest;Confirma que quitar&aacute; la l&iacute;nea del contrato?');"><i class="glyphicon glyphicon-trash red"></i></asp:LinkButton>
                </div>
            </td>
           
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
		</table>
		</div>
    </FooterTemplate>
                        
</asp:Repeater>
                     <div class="alert alert-warning" id="div_MensajeSinLineas" runat="server" visible="false">No hay l&iacute;neas asignadas</div>
                 </div>
            </div>
        </div>
        <div class="modal-footer">
             <asp:LinkButton ID="lb_CerrarModalLineas" runat="server" ToolTip="Cerrar ventana" CssClass="btn btn-warning"><i class="glyphicon glyphicon-remove-sign"></i>&nbsp;Cerrar</asp:LinkButton>             
        </div>
        <ajax:ModalPopupExtender ID="mpe_ModalLineas" runat="server" TargetControlID="hf_Lineas" PopupControlID="pnl_Lineas"
            BackgroundCssClass="modal-backdrop" SkinID="mpe_animado" CancelControlID="lb_CerrarModalLineas">
        </ajax:ModalPopupExtender>
    </asp:Panel>
     <asp:HiddenField ID="hf_Lineas" runat="server" />
     <!--FIN VENTANA MODAL  MODAL LÍNEAS-->

     <!--INICIO VENTANA MODAL FILTROS DE BÚSQUEDA-->
    <asp:Panel ID="pnl_ModalBusqueda" runat="server" CssClass="modal-dialog modalCambiarEstado">
        <div class="modal-body">
            <div class="widget-main form-horizontal">
                <div class="form-group">
					<asp:Label ID="lbl_NumeroContratoFiltro" runat="server" AssociatedControlID="txt_NumeroContratoFiltro" CssClass="col-xs-3 control-label">Contrato:</asp:Label>
					<div class="col-xs-9">
						<asp:TextBox Id="txt_NumeroContratoFiltro" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<asp:Label ID="lbl_ConcesionarioFiltro" runat="server" AssociatedControlID="ddl_ConcesionarioFiltro" CssClass="col-xs-3 control-label">Concesionario:</asp:Label>
					<div class="col-xs-9">
						<asp:DropDownList ID="ddl_ConcesionarioFiltro" runat="server" CssClass="form-control chzn-select" Width="100%"></asp:DropDownList>
					</div>
				</div>
                  <div class="form-group">
					<asp:Label ID="lbl_PalabraClaveFiltro" runat="server" AssociatedControlID="txt_PalabraClaveFiltro" CssClass="col-xs-3 control-label">Palabra clave:</asp:Label>
					<div class="col-xs-9">
						<asp:TextBox Id="txt_PalabraClaveFiltro" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
					</div>
				</div>
            </div>
        </div>
        <div class="modal-footer">
             <asp:LinkButton ID="lb_LimpiarBusqueda" runat="server" ToolTip="Limpiar b&uacute;squeda"  CssClass="btn btn-inverse" OnClick="lb_LimpiarBusqueda_Click"><i class="glyphicon glyphicon-refresh"></i>&nbsp;Limpiar</asp:LinkButton>  
             <asp:LinkButton ID="lb_EjecutarBusqueda" runat="server" ToolTip="Realizar b&uacute;"  CssClass="btn btn-info" OnClick="lb_EjecutarBusqueda_Click"><i class="glyphicon glyphicon-search"></i>&nbsp;Buscar</asp:LinkButton>  
             <asp:LinkButton ID="lb_CancelarModalBusqueda" runat="server" ToolTip="Cerrar ventana" CssClass="btn btn-warning"><i class="glyphicon glyphicon-remove-sign"></i>&nbsp;Cerrar</asp:LinkButton>             
        </div>
        <ajax:ModalPopupExtender ID="mpe_ModalBusqueda" runat="server" TargetControlID="hf_ModalBusqueda" PopupControlID="pnl_ModalBusqueda"
            BackgroundCssClass="modal-backdrop" SkinID="mpe_animado" CancelControlID="lb_CancelarModalBusqueda">
        </ajax:ModalPopupExtender>
    </asp:Panel>
     <asp:HiddenField ID="hf_ModalBusqueda" runat="server" />
     <!--FIN VENTANA MODAL FILTROS DE BÚSQUEDA-->
    
     <asp:HiddenField ID="hf_AccionGarantia" runat="server" />
   <asp:HiddenField ID="hf_IdConcesionario" runat="server" />
</asp:Content>
<asp:Content ID="cScripts" ContentPlaceHolderID="cphScripts" runat="Server">

    <style>
         .chosen-container { width: 99% !important; }
    </style>
     <script type="text/javascript">

         function pageLoad() {
             $(".chzn-select").chosen();
             $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
             $('[data-rel=popover]').popover({ container: 'body' });
         }
         function agregarDiezAnios() {
             var fechaI = $("#<%=txt_FechaVigenciaInicial.ClientID%>").val();
             var oFecha = new Date(fechaI);
             var nuevaFechaFin = agregarAnios(oFecha, 10);

             var dd = String(nuevaFechaFin.getDate()).padStart(2, '0');
             var mm = String(nuevaFechaFin.getMonth() + 1).padStart(2, '0'); //January is 0!
             var yyyy = nuevaFechaFin.getFullYear();

             if (dd != 'NaN') {
                 $("#<%=txt_FechaVigenciaFinal.ClientID%>").val((mm + '/' + dd + '/' + yyyy));
            }
        }

        function agregarAnios(dt, n) {
            return new Date(dt.setFullYear(dt.getFullYear() + n));
        }
    </script>

</asp:Content>

