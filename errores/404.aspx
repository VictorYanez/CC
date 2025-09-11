<%@ Page Title="" Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="errores_404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphEncabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <!-- PAGE CONTENT BEGINS -->

            <!-- #section:pages/error -->
            <div class="error-container">
                <div class="well">
                    <h1 class="grey lighter smaller">
                        <span class="blue bigger-125">
                            <i class="ace-icon fa fa-sitemap"></i>
                            404
                        </span>
                        P&aacute;gina no encontrada
                    </h1>

                    <hr>
                    <h3 class="lighter smaller"></h3>

                    <div>
                        

                        <div class="space"></div>
                        <h4 class="smaller"></h4>

                        <ul class="list-unstyled spaced inline bigger-110 margin-15">
                            <li>
                                <i class="ace-icon fa fa-hand-o-right blue"></i>
                                Por favor verifique que la dirección sea correcta.
                            </li>
                        </ul>
                    </div>

                    <hr />
                    <div class="space"></div>

                    <div class="center">
                        <a href="/" class="btn btn-primary">
                            <i class="ace-icon fa fa-tachometer"></i>
                            Ir a la p&aacute;gina principal
                        </a>
                    </div>
                </div>
            </div>

            <!-- /section:pages/error -->

            <!-- PAGE CONTENT ENDS -->
        </div>
        <!-- /.col -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

