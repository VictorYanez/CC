<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucRestablecer.ascx.cs" Inherits="wuc_login_wucRestablecer" %>
<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="BotDetect" %>

<div id="forgot-box" class="forgot-box widget-box no-border">
    <div class="widget-body">
        <div class="widget-main">
            <h4 class="header red lighter bigger">
                <i class="ace-icon fa fa-key"></i>
                Restablecer contrase&ntilde;a
            </h4>

            <div class="space-6"></div>
            <p class="jus">
                Ingrese su direcci&oacute;n de correo electr&oacute;nico institucional y 
                haga clic en el bot&oacute;n enviar, luego recibir&aacute; un mensaje con 
                las instrucciones para finalizar el proceso.
            </p>

            <asp:Panel ID="pnlRestablecer" runat="server" DefaultButton="lbnSolicitarCambioContrasenia">
                <fieldset>
                    <label class="block clearfix">
                        <span class="block input-icon input-icon-right">
                            <asp:TextBox ID="txt_Correo" runat="server" TextMode="SingleLine" CssClass="form-control minuss" placeholder="Dirección de correo electrónico" />
                            <asp:RequiredFieldValidator ID="rfv_Correo" runat="server" ErrorMessage="Requerido:<br /><b>Direcci&oacute;n de correo electronico del estudiante</b>" ControlToValidate="txt_Correo" ValidationGroup="vg_Restablecer" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vce_Correo" runat="server" TargetControlID="rfv_Correo" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
                            <i class="ace-icon fa fa-envelope"></i>
                        </span>
                    </label>
                    <br />
                    <div class="block clearfix cen">
                        <BotDetect:Captcha ID="cap_Restablecer" runat="server" CustomCharacterSetName="1234567890" CodeLength="3" CustomDarkColor="Black" CustomLightColor="White" />
                    </div>
                    <br />
                    <label class="block clearfix">
                        <span class="block input-icon input-icon-right">
                            <asp:TextBox ID="txt_CapRestablecer" runat="server" TextMode="SingleLine" class="form-control mayus" MaxLength="3" placeholder="Ingrese el código de arriba" />
                            <asp:RequiredFieldValidator ID="rfv_CapRestablecer" runat="server" ErrorMessage="Requerido:<br /><b>C&oacute;digo de seguridad que se encuentra arriba de este mensaje.</b>" ControlToValidate="txt_CapRestablecer" ValidationGroup="vg_Restablecer" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="vce_CapRestablecer" runat="server" TargetControlID="rfv_CapRestablecer" SkinID="vce_animado"></ajax:ValidatorCalloutExtender>
                            <i class="ace-icon fa fa-key"></i>
                        </span>
                    </label>
                   
                    <br />
                    <div class="clearfix">
                        <asp:Literal ID="lit_Mensaje" runat="server"></asp:Literal>
                        <asp:LinkButton ID="lbnSolicitarCambioContrasenia" runat="server"
                            class="width-35 pull-right btn btn-sm btn-danger"
                            ValidationGroup="vg_Restablecer" OnClick="lbnSolicitarCambioContrasenia_Click">
						<i class="ace-icon fa fa-lightbulb-o"></i>
						<span class="bigger-110">Enviar</span>
                        </asp:LinkButton>
                    </div>
                </fieldset>
            </asp:Panel>
        </div>
        <!-- /.widget-main -->

        <div class="toolbar center">
            <a href="#" data-target="#login-box" class="back-to-login-link">Regresar
                <i class="ace-icon fa fa-arrow-right"></i>
            </a>
        </div>
    </div>
    <!-- /.widget-body -->
</div>
<!-- /.forgot-box -->


