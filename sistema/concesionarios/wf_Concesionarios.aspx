<%@ Page Title="Tabla que almacena la información relevante de los concesionarios." Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_Concesionarios.aspx.cs" Inherits="wf_Concesionarios" %>

<%@ MasterType VirtualPath="~/master_ajax.master" %>

<asp:Content ID="cEncabezado" ContentPlaceHolderID="cphEncabezado" runat="Server"></asp:Content>

<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenido" runat="Server">
    <div id="div_wucc" runat="server">
        <wuc:uc_mantenimiento
            ID="wuc_mantto" runat="server"
            MostrarBuscar="false"
            OnNuevo="Nuevo" OnEditar="Editar" OnEliminar="Eliminar"
            OnGuardar="Guardar" OnCancelar="Cancelar"
            OnAplicarFiltro="AplicarFiltro" MostrarBuscarPersonalizado="false" />
    </div>

    <asp:Panel ID="pnl_campos" runat="server" CssClass="widget-box widget-color-green" Enabled="false">
        <div class="widget-header">
            <h5 class="widget-title">
                <asp:Label ID="lbl_Accion" runat="server"></asp:Label></h5>
        </div>
        <div class="widget-body">
            <div class="form-horizontal widget-main" role="form">
                <div class="form-group hidden">
                    <asp:Label ID="lbl_IdConcesionario" runat="server" AssociatedControlID="nb_IdConcesionario" CssClass="col-xs-2 control-label">IdConcesionario:</asp:Label>
                    <div class="col-xs-10">
                        <ew:NumericBox ID="nb_IdConcesionario" runat="server" SkinID="skin_entero" Width="50px"></ew:NumericBox>
                    </div>
                </div>
                <asp:RequiredFieldValidator ID="rfv_IdConcesionario" runat="server" ErrorMessage="El campo IdConcesionario es requerido." ForeColor="Red" ControlToValidate="nb_IdConcesionario" ValidationGroup="vg_guardar" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                <div class="form-group">
                    <asp:Label ID="lbl_Nombre" runat="server" AssociatedControlID="txt_Nombre" CssClass="col-xs-2 control-label">Nombre:</asp:Label>
                    <div class="col-xs-10">
                        <asp:TextBox ID="txt_Nombre" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Nombre" runat="server" ErrorMessage="El campo Nombre es requerido." ForeColor="Red" ControlToValidate="txt_Nombre" ValidationGroup="vg_guardar" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lbl_Abreviatura" runat="server" AssociatedControlID="txt_Abreviatura" CssClass="col-xs-2 control-label">Abreviatura:</asp:Label>
                    <div class="col-xs-10">
                        <asp:TextBox ID="txt_Abreviatura" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <!---------------  Cambios en campos del formulario DUI/NIT como documento ------------->
                <div class="form-group">
                    <asp:Label ID="lbl_TiposConcesionarios" runat="server" AssociatedControlID="ddl_TiposConcesionarios" CssClass="col-xs-2 control-label">Tipo Concesionario:</asp:Label>
                    <div class="col-xs-10">
                        <asp:DropDownList ID="ddl_TiposConcesionarios" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_TiposConcesionarios_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_TiposConcesionarios" runat="server" ErrorMessage="El campo Tipo Concesionario es requerido." ForeColor="Red" ControlToValidate="ddl_TiposConcesionarios" ValidationGroup="vg_guardar" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!---------------  DUI/NIT  ------------->
                <div class="form-group" id="divNitDui" runat="server" visible="false">
                    <asp:Label ID="lbl_Nit" runat="server" AssociatedControlID="txt_Nit" CssClass="col-xs-2 control-label">NIT/DUI:</asp:Label>
                    <div class="col-xs-10">
                        <asp:TextBox ID="txt_Nit" runat="server" CssClass="form-control" MaxLength="17"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Nit" runat="server" ErrorMessage="El campo NIT/DUI es requerido." ForeColor="Red" ControlToValidate="txt_Nit" ValidationGroup="vg_guardar" Display="Dynamic"></asp:RequiredFieldValidator>
                        <ajax:MaskedEditExtender ID="mee_Nit" runat="server" TargetControlID="txt_Nit" Mask="" Enabled="true" />
                        <asp:RegularExpressionValidator ID="rev_Nit" runat="server" ErrorMessage="" ValidationGroup="vg_guardar" ControlToValidate="txt_Nit"
                            ForeColor="Red" Font-Size="XX-Small" ValidateEmptyText="false" ValidationExpression=""></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Error" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                </div>
                <!---------------  Fin cambio en el orden campos del formulario  ------------->
            </div>
        </div>
    </asp:Panel>

    <div id="div_grilla" runat="server" class="widget-box widget-color-green">
        <div class="widget-header">
            <h5 class="widget-title">Concesionarios</h5>
        </div>
        <div class="widget-body">
            <div class="widget-main">
                <asp:GridView ID="gv_Datos" runat="server" Width="100%" SkinID="skin_grilla_sin_paginacion"
                    PageSize="10" AllowPaging="True" DataKeyNames="IdConcesionario"
                    OnRowDataBound="gv_Datos_RowDataBound" OnSelectedIndexChanged="gv_Datos_SelectedIndexChanged"
                    OnPageIndexChanging="gv_Datos_PageIndexChanging">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="&nbsp;" HeaderStyle-Width="1px" />
                        <asp:BoundField DataField="Nombre" HeaderText="NOMBRE" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Abreviatura" HeaderText="ABREVIATURA" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" />
                        <asp:BoundField DataField="Nit" HeaderText="NIT/DUI" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" />
                        <asp:BoundField DataField="IdTipoConcesionario.Nombre" HeaderText="TIPO DE CONCESIONARIO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="12%" />
                        <asp:TemplateField HeaderText="CONTACTOS" HeaderStyle-Width="13%">
                            <ItemStyle HorizontalAlign="Center" />
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <div class="infobox infobox-green">
                                    <div class="infobox-icon">
                                        <i class="ace-icon fa fa-users"></i>
                                    </div>
                                    <div class="infobox-data">
                                        <span class="infobox-data-number">
                                            <asp:Literal ID="lit_CantidadContactos" runat="server" Text="0"></asp:Literal></span>
                                        <div class="infobox-content">contactos</div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="alert alert-info">
                    <asp:Label ID="lbl_ContadorRegistros" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div id="div_Mantenimiento" runat="server">
        <div class="hr hr-dotted hr-16"></div>
        <div class="row">
            <div class="col-xs-12">
                <div class="btn-toolbarr">
                    <div class="btn-groupp">
                        <asp:LinkButton ID="lb_NuevoContacto" runat="server" SkinID="lbn_nuevo" OnClick="lb_NuevoContacto_Click" Visible="false"></asp:LinkButton>
                        <asp:LinkButton ID="lb_EditarContacto" runat="server" SkinID="lbn_editar" OnClick="lb_EditarContacto_Click" Visible="false"></asp:LinkButton>
                        <asp:LinkButton ID="lb_EliminarContacto" runat="server" SkinID="lbn_eliminar" OnClick="lb_EliminarContacto_Click" Visible="false"></asp:LinkButton>
                        <ajax:ConfirmButtonExtender ID="cbe_EliminarContacto" runat="server" TargetControlID="lb_EliminarContacto" ConfirmText="&#191;Confirma que desea eliminar el registro?"></ajax:ConfirmButtonExtender>
                        <asp:HiddenField ID="hf_accion" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="hr hr-dotted hr-16"></div>
    </div>

    <asp:HiddenField ID="hf_IdContacto" runat="server" Value="0" />

    <div id="div_grilla_contactos" runat="server" class="widget-box widget-color-green">
        <div class="widget-header">
            <h5 class="widget-title">Contactos</h5>
        </div>
        <div class="widget-body">
            <div class="widget-main">
                <asp:GridView ID="gv_DatosContactos" runat="server" Width="100%" SkinID="skin_grilla_contactos_paginacion"
                    PageSize="10" AllowPaging="False" DataKeyNames="IdContacto"
                    OnRowDataBound="gv_DatosContactos_RowDataBound" OnSelectedIndexChanged="gv_DatosContactos_SelectedIndexChanged"
                    OnPageIndexChanging="gv_DatosContactos_PageIndexChanging">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="&nbsp;" HeaderStyle-Width="1px" />
                        <asp:TemplateField HeaderText="NOMBRE / NIT" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <strong>NOMBRE:</strong>&nbsp;&nbsp; <%#Eval("Nombres")%>&nbsp;<%#Eval("Apellidos")%><br />
                                <strong>NIT*:&nbsp;&nbsp;</strong> <%#Eval("Nit")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TEL&Eacute;FONOS" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="12%">
                            <ItemTemplate>
                                <strong>OFICINA:</strong>&nbsp;&nbsp;<%#Eval("TelefonoOficina")%><br />
                                <strong>CELULAR:</strong>&nbsp;&nbsp;<%#Eval("NumeroCelular")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CORREO ELECTR&Oacute;NICO" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="18%">
                            <ItemTemplate>
                                <asp:HyperLink ID="linkEmail" runat="server" Text='<%#Eval("CorreoElectronico") %>' NavigateUrl='<%#Eval("CorreoElectronico","mailto:{0}") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdTipoContacto.Nombre" HeaderText="TIPO DE CONTACTO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="11%" />
                        <asp:TemplateField HeaderText="COMENTARIO" HeaderStyle-Width="4%">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Literal ID="lit_ComentarioContacto" runat="server"> </asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <!--INICIO VENTANA MODAL DE CONTACTO-->
    <asp:Panel ID="pnl_Contacto" runat="server" CssClass="modal-dialog modalContacto">

        <div class="modal-body">
            <div class="widget-main form-horizontal">
                <div class="form-group">
                    <asp:Label ID="lbl_Nombres" runat="server" AssociatedControlID="txt_Nombres" CssClass="col-xs-2 control-label">Nombres:</asp:Label>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txt_Nombres" runat="server" CssClass="form-control may" MaxLength="60"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Nombres" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small" ControlToValidate="txt_Nombres" ValidationGroup="vg_guardar_contacto" Display="Dynamic"></asp:RequiredFieldValidator>

                    </div>

                    <asp:Label ID="lbl_Apellidos" runat="server" AssociatedControlID="txt_Apellidos" CssClass="col-xs-2 control-label">Apellidos:</asp:Label>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txt_Apellidos" runat="server" CssClass="form-control may" MaxLength="60"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Apellidos" runat="server" ErrorMessage="Requerido." ForeColor="Red" Font-Size="XX-Small" ControlToValidate="txt_Apellidos" ValidationGroup="vg_guardar_contacto" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="form-group">
                    <asp:Label ID="lbl_TelefonoOficina" runat="server" AssociatedControlID="txt_TelefonoOficina" CssClass="col-xs-2 control-label">Tel&eacute;fono oficina:</asp:Label>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txt_TelefonoOficina" runat="server" CssClass="form-control" MaxLength="9" onblur="quitarMascara()"></asp:TextBox>
                        <ajax:MaskedEditExtender ID="mee_TelefonoOficina" runat="server" ClearMaskOnLostFocus="True" Mask="9999-9999" TargetControlID="txt_TelefonoOficina" AutoComplete="false"></ajax:MaskedEditExtender>
                        <asp:RegularExpressionValidator ID="rev_TelefonoOficina" runat="server" ErrorMessage="Formato incorrecto." ValidationExpression="([0-9]{8})|[0-9]{4}[-]{1}[0-9]{4}" ForeColor="Red" Font-Size="XX-Small" ControlToValidate="txt_TelefonoOficina" Display="Dynamic" ValidationGroup="vg_guardar_contacto" ValidateEmptyText="false"></asp:RegularExpressionValidator>
                    </div>
                    <asp:Label ID="lbl_NumeroCelular" runat="server" AssociatedControlID="txt_NumeroCelular" CssClass="col-xs-2 control-label">Tel&eacute;fono celular:</asp:Label>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txt_NumeroCelular" runat="server" CssClass="form-control" MaxLength="9" onblur="quitarMascara()"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_NumeroCelular" runat="server" ErrorMessage="Formato incorrecto." ValidationExpression="([0-9]{8})|[0-9]{4}[-]{1}[0-9]{4}" ForeColor="Red" Font-Size="XX-Small" ControlToValidate="txt_NumeroCelular" Display="Dynamic" ValidationGroup="vg_guardar_contacto" ValidateEmptyText="false"></asp:RegularExpressionValidator>
                        <ajax:MaskedEditExtender ID="mee_NumeroCelular" runat="server" ClearMaskOnLostFocus="True" Mask="9999-9999" TargetControlID="txt_NumeroCelular" AutoComplete="false"></ajax:MaskedEditExtender>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lbl_CorreoElectronico" runat="server" AssociatedControlID="txt_CorreoElectronico" CssClass="col-xs-2 control-label">Correo:</asp:Label>
                    <div class="col-xs-10">
                        <asp:TextBox ID="txt_CorreoElectronico" runat="server" CssClass="form-control" MaxLength="120"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_Email" runat="server" ErrorMessage="Formato de correo incorrecto." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Font-Size="XX-Small" ControlToValidate="txt_CorreoElectronico" ValidationGroup="vg_guardar_contacto" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lbl_NitContacto" runat="server" AssociatedControlID="txt_NitContacto" CssClass="col-xs-2 control-label">Nit:</asp:Label>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txt_NitContacto" runat="server" CssClass="form-control" MaxLength="17" onblur="quitarMascara()"></asp:TextBox>
                        <ajax:MaskedEditExtender ID="mee_NitContacto" runat="server" Mask="9999-999999-999-9" TargetControlID="txt_NitContacto"></ajax:MaskedEditExtender>
                        <asp:RegularExpressionValidator ID="rev_NitContacto" runat="server" ErrorMessage="Nit incorrecto"
                            ValidationGroup="vg_guardar_contacto" ControlToValidate="txt_NitContacto" ForeColor="Red" Font-Size="XX-Small"
                            ValidateEmptyText="false" ValidationExpression="([0-9]{14})|[0-9]{4}[-]{1}[0-9]{6}[-]{1}[0-9]{3}[-]{1}[0-9]{1}">
                        </asp:RegularExpressionValidator>
                    </div>
                    <asp:Label ID="lbl_TiposContactos" runat="server" AssociatedControlID="ddl_TiposContactos" CssClass="col-xs-2 control-label">Tipo:</asp:Label>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="ddl_TiposContactos" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_TiposContactos" runat="server" ErrorMessage="Requerido.." ForeColor="Red" Font-Size="XX-Small" ControlToValidate="ddl_TiposContactos" ValidationGroup="vg_guardar_contacto" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lbl_Comentarios" runat="server" AssociatedControlID="txt_Comentarios" CssClass="col-xs-2 control-label">Comentarios:</asp:Label>
                    <div class="col-xs-10">
                        <asp:TextBox ID="txt_Comentarios" runat="server" CssClass="form-control may" MaxLength="200" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <asp:LinkButton ID="lb_GuardarContacto" runat="server" ToolTip="Guardar contacto" ValidationGroup="vg_guardar_contacto" CssClass="btn btn-success" OnClick="lb_GuardarContacto_Click"><i class="glyphicon glyphicon-ok-sign"></i>&nbsp;Guardar</asp:LinkButton>
            <asp:LinkButton ID="lb_CerrarModalContacto" runat="server" ToolTip="Cerrar ventana" CssClass="btn btn-warning"><i class="glyphicon glyphicon-remove-sign"></i>&nbsp;Cerrar</asp:LinkButton>
        </div>
        <ajax:ModalPopupExtender ID="mpe_Contacto" runat="server" TargetControlID="hf_ModalContacto" PopupControlID="pnl_Contacto"
            BackgroundCssClass="modal-backdrop" SkinID="mpe_animado" CancelControlID="lb_CerrarModalContacto">
        </ajax:ModalPopupExtender>
    </asp:Panel>
    <asp:HiddenField ID="hf_ModalContacto" runat="server" />
    <asp:HiddenField ID="hf_AccionContacto" runat="server" />
    <!--FIN VENTANA MODAL DE ENCABEZADO-->
</asp:Content>
<asp:Content ID="cScripts" ContentPlaceHolderID="cphScripts" runat="Server">
    <script type="text/javascript">

        // Función de carga de la página
        function pageLoad() {
            $('[data-rel=popover]').popover({ container: 'body' });
        }

        // Función para quitar la máscara si está vacía
        function quitarMascara() {
            var mascaraNitContacto = $("#<%=txt_NitContacto.ClientID%>").val();
            var telefonoContacto = $("#<%=txt_TelefonoOficina.ClientID%>").val();
            var telefonoCelular = $("#<%=txt_NumeroCelular.ClientID%>").val();

            // Evaluar si el campo tiene la máscara de NIT o DUI y eliminarla si está vacía
            if (mascaraNitContacto === '____-______-___-_' || mascaraNitContacto === '________-_') {
                $("#<%=txt_NitContacto.ClientID%>").val('');
            }
            if (telefonoContacto == '____-____') {
                $("#<%=txt_TelefonoOficina.ClientID%>").val('');
            }
            if (telefonoCelular == '____-____') {
                $("#<%=txt_NumeroCelular.ClientID%>").val('');
            }
        }

        // Función para inicializar la máscara al cargar el formulario
        function inicializarMascara() {
            var maskedNit = $find("<%= mee_Nit.ClientID %>");
            if (maskedNit) {
                maskedNit.initialize();
            }
        }

        // Script para aplicar la máscara dinámica en el campo NIT/DUI
        $(document).ready(function () {
            // Función para mostrar/ocultar el campo NIT/DUI y aplicar la máscara según el tipo de concesionario
            function gestionarNitDui() {
                var tipoConcesionario = $("#<%= ddl_TiposConcesionarios.ClientID %>").val();
                if (tipoConcesionario === "1" || tipoConcesionario === "2") {
                    $("#divNitDui").show(); // Mostrar el campo
                    aplicarMascara();
                } else {
                    $("#divNitDui").hide(); // Ocultar el campo si no hay un tipo válido
                    $("#<%= txt_Nit.ClientID %>").val(""); // Limpiar el valor
                }
            }

            // Aplica la máscara dinámica en el campo NIT/DUI
            function aplicarMascara() {
                var tipoConcesionario = $("#<%= ddl_TiposConcesionarios.ClientID %>").val();
        if (tipoConcesionario === "1") { // NATURAL (DUI)
            $("#<%= txt_Nit.ClientID %>").mask("99999999-9");
        } else if (tipoConcesionario === "2") { // JURÍDICO (NIT)
            $("#<%= txt_Nit.ClientID %>").mask("9999-999999-999-9");
                }
            }

            // Inicializar el comportamiento al cargar la página
            gestionarNitDui();

            // Detecta cambios en el dropdown de tipos de concesionarios
            $("#<%= ddl_TiposConcesionarios.ClientID %>").on("change", function () {
                gestionarNitDui();
            });

            // Eliminar máscara si el campo está vacío
            $("#<%= txt_Nit.ClientID %>").on("blur", function () {
                if ($(this).val().trim() === "") {
                    $(this).unmask();
                }
            });
        });

    </script>
</asp:Content>
