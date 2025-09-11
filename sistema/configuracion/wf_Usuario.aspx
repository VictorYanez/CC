<%@ Page Title="" Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_Usuario.aspx.cs" Inherits="sistema_configuracion_wf_Usuario" %>

<%@ MasterType VirtualPath="~/master_ajax.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphEncabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    <div id="div_wuc" runat="server">
        <wuc:uc_mantenimiento
            ID="wuc_mantto" runat="server"
            MostrarBuscar="false"
            OnNuevo="Nuevo" OnEditar="Editar" OnEliminar="Eliminar"
            OnGuardar="Guardar" OnCancelar="Cancelar"
            OnAplicarFiltro="AplicarFiltro" />
    </div>

    <asp:Panel ID="pnl_campos" runat="server" CssClass="widget-box widget-color-green" Enabled="false">
        <div class="widget-header">
            <h5 class="widget-title">
                <asp:Label ID="lbl__Accion" runat="server"></asp:Label></h5>
        </div>
        <div class="widget-body">
            <div class="form-horizontal widget-main" role="form">
                <div class="form-group">
                    <asp:Label ID="lbl_Id_Usuario" runat="server" AssociatedControlID="txt_Id_Usuario" CssClass="col-xs-2 control-label">ID:</asp:Label>
                    <div class="col-xs-3">
                        <asp:TextBox ID="txt_Id_Usuario" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Id_Usuario" runat="server" ErrorMessage="Requerido:<br /><b>Identificador del usuario</b>" ControlToValidate="txt_Id_Usuario" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vce_Id_Usuario" runat="server" TargetControlID="rfv_Id_Usuario" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
                    </div>
                    <asp:Label ID="lbl_Descripcion" runat="server" AssociatedControlID="txt_Descripcion" CssClass="col-xs-2 col-xs-offset-2 control-label">Inicio de sesi&oacute;n:</asp:Label>
                    <div class="col-xs-3">
                        <asp:TextBox ID="txt_Descripcion" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="60"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Descripcion" runat="server" ErrorMessage="Requerido:<br /><b>Login del Usuario</b>" ControlToValidate="txt_Descripcion" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vce_Descripcion" runat="server" TargetControlID="rfv_Descripcion" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Email" runat="server" AssociatedControlID="txt_Email" CssClass="col-xs-2 control-label">Email:</asp:Label>
                    <div class="col-xs-3">
                        <asp:TextBox ID="txt_Email" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Email" runat="server" ErrorMessage="Requerido:<br /><b></b>" ControlToValidate="txt_Email" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vce_Email" runat="server" TargetControlID="rfv_Email" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
                    </div>
                    <asp:Label ID="lbl_Nit" runat="server" AssociatedControlID="txt_Nit" CssClass="col-xs-2 col-xs-offset-2 control-label">NIT:</asp:Label>
                    <div class="col-xs-3">
                        <asp:TextBox ID="txt_Nit" runat="server" TextMode="SingleLine" Visible="True" CssClass="form-control" MaxLength="18"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Nit" runat="server" ErrorMessage="Requerido:<br /><b></b>" ControlToValidate="txt_Nit" ValidationGroup="vg_guardar" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="vce_Nit" runat="server" TargetControlID="rfv_Nit" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="lbl_Estatus" runat="server" AssociatedControlID="cbx_Estatus" CssClass="col-xs-2 control-label">Activo:</asp:Label>
                    <div class="col-xs-2">
                        <asp:CheckBox ID="cbx_Estatus" runat="server" CssClass="form-control" Text="" />
                    </div>
                    <asp:Label ID="lbl_Bloqueado" runat="server" AssociatedControlID="cbx_Bloqueado" CssClass="col-xs-2 control-label">Bloqueado:</asp:Label>
                    <div class="col-xs-2">
                        <asp:CheckBox ID="cbx_Bloqueado" runat="server" CssClass="form-control" Text="" />
                    </div>
                    <asp:Label ID="lbl_Fecha_Creacion_Usuario" runat="server" AssociatedControlID="cal_Fecha_Creacion_Usuario" CssClass="col-xs-2 control-label">Fecha de creación:</asp:Label>
                    <div class="col-xs-2">
                        <asp:TextBox ID="cal_Fecha_Creacion_Usuario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
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
                    PageSize="12" AllowPaging="True" DataKeyNames="Id_Usuario"
                    OnRowDataBound="gv_Datos_RowDataBound" OnSelectedIndexChanged="gv_Datos_SelectedIndexChanged"
                    OnPageIndexChanging="gv_Datos_PageIndexChanging">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="&nbsp;">
                            <HeaderStyle Width="1px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="Id_Usuario" HeaderText="ID">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Inicio de sesi&oacute;n">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Email" HeaderText="Correo electrónico">
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Nit" HeaderText="NIT">
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:CheckBoxField DataField="Estatus" HeaderText="Activo">
                            <HeaderStyle HorizontalAlign="Center" Width="10px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="Bloqueado" HeaderText="Bloqueado">
                            <HeaderStyle HorizontalAlign="Center" Width="10px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CheckBoxField>
                        <asp:BoundField DataField="Fecha_Creacion_Usuario" HeaderText="Fecha de creación" HtmlEncode="false" DataFormatString="{0:d}">
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Acciones">
                            <HeaderStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <span id='con_<%# Eval("Id_Usuario").ToString().Replace("NR  ", "NR__") %>' class="btn btn-xs btnCon btn-warning" title="Asignar contraseña"><i class="fa fa-key"></i></span>
                                <span id='per_<%# Eval("Id_Usuario").ToString().Replace("NR  ", "NR__") %>' class="btn btn-xs btnPer btn-info" title="Perfiles del usuario"><i class="fa fa-users"></i></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <input id="idSistema" type="hidden" value='<%# this.Master.IdSistema %>' />


    <div id="divOpciones" class="modal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="bootbox-close-button close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 id="mdlTitulo" class="modal-title"></h4>
                </div>
                <div class="modal-body">
                    <div class="bootbox-body">
                        <div class="bootbox-form">
                            <div id="mdlCuerpo"></div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <span class="btn btn-primary" onclick="$('#divOpciones').modal('hide');">OK</span>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {

            $(".btnCon").click(function () {
                var idUsuario = $(this).attr("id").substring(4).replace("NR__", "NR  ");
                $("#mdlTitulo").html("Actualizar la contraseña de: <strong>" + idUsuario + "</strong>");
                var f = "wf_ac.aspx?IdUsuario=" + idUsuario;
                $("#mdlCuerpo")
                    .html('<iframe src="' + f + '" style="width: 99%; height: 200px; border: none;"></iframe>');
                $("#divOpciones").modal("toggle");
            });

            $(".btnPer").click(function () {
                var idUsuario = $(this).attr("id").substring(4).replace("NR__", "NR  ");;
                $("#mdlTitulo").html("Perfiles de : <strong>" + idUsuario + "</strong>");
                var f = "wf_ap.aspx?IdUsuario=" + idUsuario;
                $("#mdlCuerpo")
                    .html('<iframe src="' + f + '" style="width: 99%; height: 100%; border: none;"></iframe>');
                $("#divOpciones").modal("toggle");

            });

        });

        
            
            function pageLoad()
            {


                $(".btnCon").click(function () {
                    var idUsuario = $(this).attr("id").substring(4).replace("NR__", "NR  ");
                    $("#mdlTitulo").html("Actualizar la contraseña de: <strong>" + idUsuario + "</strong>");
                    var f = "wf_ac.aspx?IdUsuario=" + idUsuario;
                    $("#mdlCuerpo")
                        .html('<iframe src="' + f + '" style="width: 99%; height: 200px; border: none;"></iframe>');
                    $("#divOpciones").modal("toggle");
                });

                $(".btnPer").click(function () {
                    var idUsuario = $(this).attr("id").substring(4).replace("NR__", "NR  ");;
                    $("#mdlTitulo").html("Perfiles de : <strong>" + idUsuario + "</strong>");
                    var f = "wf_ap.aspx?IdUsuario=" + idUsuario;
                    $("#mdlCuerpo")
                        .html('<iframe src="' + f + '" style="width: 99%; height: 100%; border: none;"></iframe>');
                    $("#divOpciones").modal("toggle");

                });



            }

        
    </script>
</asp:Content>

