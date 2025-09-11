<%@ Page Title="" Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="wf_ac.aspx.cs" Inherits="sistema_configuracion_wf_ac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphEncabezado" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" Runat="Server">
 <asp:Panel ID="pnl_campos" runat="server" CssClass="box box-warning" Enabled="true" DefaultButton="lbn_CambiarContrasena">
     <div class="row-fluid">
     <div class="widget-box">
         <div class="widget-header widget-header-small header-color-dark">
                    <h5>Actualización de contraseña</h5>
                </div>
          <div class="widget-body">
          <div class="widget-main form-horizontal">

             <div id="divCampos" runat="server">

                 <div class="form-group">
                     <asp:Label ID="lbl_ContrasenaNueva" runat="server"
                         AssociatedControlID="txt_ContrasenaNueva"
                         CssClass="col-xs-2 control-label">Nueva contrase&ntilde;a:</asp:Label>
                     <div class="col-xs-4">
                         <asp:TextBox ID="txt_ContrasenaNueva" runat="server" TextMode="Password" Visible="True" CssClass="form-control" MaxLength="100"></asp:TextBox>
                         <div id="val_ContrasenaNueva" class="validador"></div>
                         <asp:RequiredFieldValidator ID="rfv_ContrasenaNueva" runat="server" ErrorMessage="Requerido:<br /><b>Nueva contrase&ntilde;a del usuario.</b>" ControlToValidate="txt_ContrasenaNueva" ValidationGroup="vg_clave" Display="None"></asp:RequiredFieldValidator>
                         <ajax:ValidatorCalloutExtender ID="vce_ContrasenaNueva" runat="server" TargetControlID="rfv_ContrasenaNueva" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
                     </div>
                 </div>

                 <div class="form-group">
                     <asp:Label ID="lbl_ContrasenaConfirmada" runat="server"
                         AssociatedControlID="txt_ContrasenaConfirmada"
                         CssClass="col-xs-2 control-label">Confirme la contrase&ntilde;a:</asp:Label>
                     <div class="col-xs-4">
                         <asp:TextBox ID="txt_ContrasenaConfirmada" runat="server" TextMode="Password" Visible="True" CssClass="form-control" MaxLength="100"></asp:TextBox>
                         <div id="val_ContrasenaConfirmada" class="validador"></div>

                         <asp:RequiredFieldValidator ID="rfv_ContrasenaConfirmada" runat="server" ErrorMessage="Requerido:<br /><b>Confirme la contrase&ntilde;a del usuario.</b>" ControlToValidate="txt_ContrasenaConfirmada" ValidationGroup="vg_clave" Display="None"></asp:RequiredFieldValidator>
                         <ajax:ValidatorCalloutExtender ID="vce_ContrasenaConfirmada" runat="server" TargetControlID="rfv_ContrasenaConfirmada" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>


                         <asp:CompareValidator runat="server" ID="cv_ContrasenaConfirmada" ControlToValidate="txt_ContrasenaConfirmada" ControlToCompare="txt_ContrasenaNueva"
                             ErrorMessage="No coinciden las contraseñas" CssClass="error" ValidationGroup="vg_clave" Display="None"></asp:CompareValidator>
                         <ajax:ValidatorCalloutExtender ID="vce2_ContrasenaConfirmada" runat="server" TargetControlID="cv_ContrasenaConfirmada" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>


                         <asp:RegularExpressionValidator runat="server" ID="rev_ContrasenaConfirmada" ControlToValidate="txt_ContrasenaConfirmada"
                             ValidationExpression="^[a-zA-Z0-9'@&#.\s]{8,20}$" ErrorMessage="Debe tener al menos 8 caracteres" ValidationGroup="vg_clave" Display="None"></asp:RegularExpressionValidator>
                         <ajax:ValidatorCalloutExtender ID="vce3_ContrasenaConfirmada" runat="server" TargetControlID="rev_ContrasenaConfirmada" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>



                     </div>
                 </div>


                 <div class="form-group">
                     <div class="col-xs-6">
                         <div class="pull-right">
                             <asp:LinkButton ID="lbn_CambiarContrasena" runat="server" CssClass="btn btn-default" ValidationGroup="vg_clave" OnClick="lbn_CambiarContrasena_Click">
                            <i class="fa fa-key"></i>
                            Actualizar contrase&ntilde;a
                             </asp:LinkButton>
                         </div>
                     </div>
                 </div>

             </div>

              <div id="divMensaje" runat="server" class="alert alert-warning">
                             <h3>
                                 <asp:Literal ID="lit_Mensaje" runat="server"></asp:Literal></h3>
                         </div>


         </div>
          </div>
     </div>
     </div>
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

