<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucRegistrar.ascx.cs" Inherits="wuc_login_wucRegistrar" %>

<div id="signup-box" class="signup-box widget-box no-border">
    <div class="widget-body">
        <div class="widget-main">
            <h4 class="header green lighter bigger">
                <i class="ace-icon fa fa-users blue"></i>
                Registro para nuevo usuario
            </h4>

            <div class="space-6"></div>
            <p>Ingrese los datos que se le solicitan a continuaci&oacute;n: </p>

            <%--<form>--%>
            <fieldset>
                <label class="block clearfix">
                    <span class="block input-icon input-icon-right">
                        <asp:TextBox ID="txtNuevoEmail" runat="server" class="form-control" placeholder="Correo electr&oacute;nico" />
                        <i class="ace-icon fa fa-envelope"></i>
                    </span>
                </label>

                <label class="block clearfix">
                    <span class="block input-icon input-icon-right">
                        <asp:TextBox ID="txtNuevoUsuario" runat="server" class="form-control" placeholder="Nombre de usuario:  nombre.apellido" />
                        <i class="ace-icon fa fa-user"></i>
                    </span>
                </label>

                <label class="block clearfix">
                    <span class="block input-icon input-icon-right">
                        <asp:TextBox ID="txtNuevoContrasenia" runat="server" class="form-control" placeholder="Contrase&ntilde;a" />
                        <i class="ace-icon fa fa-lock"></i>
                    </span>
                </label>

                <label class="block clearfix">
                    <span class="block input-icon input-icon-right">
                        <asp:TextBox ID="txtNuevoConfirmar" runat="server" class="form-control" placeholder="Confirmar la contrase&ntilde;a" />
                        <i class="ace-icon fa fa-retweet"></i>
                    </span>
                </label>

                <label class="block">
                    <input type="checkbox" class="ace" />
                    <span class="lbl">Acepto los 
															<a href="#">t&eacute;rminos del usuario</a>
                    </span>
                </label>

                <div class="space-24"></div>

                <div class="clearfix">
                    <button type="reset" class="width-30 pull-left btn btn-sm">
                        <i class="ace-icon fa fa-refresh"></i>
                        <span class="bigger-110">Limpiar</span>
                    </button>

                    <asp:LinkButton ID="lbnRegistrar" runat="server" runat="server" class="width-65 pull-right btn btn-sm btn-success">
															<span class="bigger-110">Registrar</span>

															<i class="ace-icon fa fa-arrow-right icon-on-right"></i>
                    </asp:LinkButton>
                </div>
            </fieldset>
            <%--</form>--%>
        </div>

        <div class="toolbar center">
            <a href="#" data-target="#login-box" class="back-to-login-link">
                <i class="ace-icon fa fa-arrow-left"></i>
                Regresar
            </a>
        </div>
    </div>
    <!-- /.widget-body -->
</div>
