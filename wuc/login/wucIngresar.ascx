<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucIngresar.ascx.cs" Inherits="wuc_login_wucIngresar" %>

<div id="login-box" class="login-box visible widget-box no-border">
    <div class="widget-body">
        <div class="widget-main">
            <h4 class="header blue lighter bigger">
                <i class="ace-icon fa fa-coffee green"></i>
                Ingrese sus datos
            </h4>

            <div class="space-6"></div>

            <%--<form>--%>
            <fieldset>

                <div id="divCampos" runat="server" class="">
                    <label class="block clearfix">
                        <span class="block input-icon input-icon-right">

                            <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Usuario"></asp:TextBox>
                            <i class="ace-icon fa fa-user"></i>
                        </span>
                    </label>

                    <label class="block clearfix">
                        <span class="block input-icon input-icon-right">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" placeholder="Contrase&ntilde;a" />
                            <i class="ace-icon fa fa-lock"></i>
                        </span>
                    </label>
                    <div class="space"></div>



                </div>





                <div id="divIngresar" runat="server" class="clearfix">
                    <label class="block clearfix">
                        <%--<label class="inline">
                                                        <input type="checkbox" class="ace" />
                                                        <span class="lbl">Recordar datos</span>
                                                    </label>--%>

                        <asp:LinkButton ID="btnIngresar" runat="server" class="width-35 pull-right btn btn-sm btn-primary" OnClick="btnIngresar_Click">
															<i class="ace-icon fa fa-key"></i>
															<span class="bigger-110">Ingresar</span>
                        </asp:LinkButton>
                    </label>

                    <label class="block clearfix">
                        <span class="block text-center alert-danger">
                            <h5>
                                <asp:Label ID="lblMensaje" runat="server" Text="" /></h5>
                        </span>
                    </label>
                </div>


                <div id="divPerfil" runat="server" class="hidden">
                    <label class="block clearfix">
                        <span class="block input-icon input-icon-right">
                            <h4 class="text-center text-danger">Seleccione el perfil:</h4>
                        </span>
                        <span class="block input-icon input-icon-right">
                            <asp:DropDownList ID="ddlPerfil" runat="server" class="form-control" placeholder="Perfil del usuario" DataValueField="IdPerfil" DataTextField="IdPerfil" OnSelectedIndexChanged="ddlPerfil_SelectedIndexChanged" AutoPostBack="true" />
                            <%--<i class="ace-icon fa fa-user"></i>--%>
                        </span>
                    </label>
                </div>

                <%--<div class="space-12"></div>--%>
            </fieldset>
            <%--</form>--%>
        </div>
        <!-- /.widget-main -->

      <%--  <div id="divNavegacion" runat="server" class="toolbar clearfix">
           <div>
              -  <a href="#" data-target="#forgot-box" class="forgot-password-link">
                    <i class="ace-icon fa fa-arrow-left"></i>
                    Restablecer contrase&ntilde;a
                </a>
            </div>
            <%-- 
            <div>
                <a href="#" data-target="#signup-box" class="user-signup-link">Registrarse
													<i class="ace-icon fa fa-arrow-right"></i>
                </a>
            </div>
        </div>--%>
    </div>
    <!-- /.widget-body -->
</div>
<!-- /.login-box -->
