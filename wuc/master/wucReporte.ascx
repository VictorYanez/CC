<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucReporte.ascx.cs" Inherits="wuc_master_wucReporte" %>

<asp:HiddenField ID="hdfIdReporte" runat="server" />
<asp:HiddenField ID="hdfSqlPrincipal" runat="server" />

<asp:UpdatePanel ID="udpReporte" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlReporte" runat="server" CssClass="modal-dialog modal-ayuda hidden" Width="90%">
            <div class="modal-content">
                <asp:Panel ID="pnlReporteTitulo" runat="server" CssClass="modal-header">
                    <asp:LinkButton runat="server" ID="btnReporteOculto2" CssClass="bootbox-close-button close" data-dismiss="modal" aria-hidden="true" Text="x" />
                    <h4><i id="i_tit" runat="server"></i>&nbsp;<asp:Label ID="lblReporteTitulo" runat="server" Text=""></asp:Label></h4>
                </asp:Panel>
                <asp:Panel ID="pnlReporteCuerpo" runat="server" CssClass="modal-body">
                    <i id="i" runat="server" class="icon-ok-sign icon-white"></i>
                    <%--<asp:Literal ID="litReporteTexto" runat="server"></asp:Literal>--%>
                    <iframe id="ifmReporte" runat="server" frameborder="0" scrolling="auto" width="100%" height="100%"></iframe>                    
                </asp:Panel>
                <div class="modal-footer">
                    <div class="text-right">
                        <%--<asp:LinkButton ID="lbnReporteCerrar" runat="server" ToolTip="Cerrar" CssClass="btn btn-danger cerrar_msj">
                            <i class="glyphicon glyphicon-ok-sign"></i>
                            Cerrar
                        </asp:LinkButton>--%>
                        <asp:HyperLink ID="lb_pdf" runat="server" SkinID="lnk_imprimir_pdf" Target="_blank"></asp:HyperLink>
                        <asp:HyperLink ID="lb_doc" runat="server" SkinID="lnk_imprimir_doc" ></asp:HyperLink>
                        <asp:HyperLink ID="lb_xls" runat="server" SkinID="lnk_imprimir_xls" ></asp:HyperLink>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <ajax:ModalPopupExtender ID="mdlReporte" runat="server" TargetControlID="hidForModalLocal" PopupControlID="pnlReporte"
            BackgroundCssClass="modal-backdrop" SkinID="mpe_animado" CancelControlID="btnReporteOculto2">
        </ajax:ModalPopupExtender>
       <asp:HiddenField ID="hidForModalLocal" runat="server" />
   </ContentTemplate>
</asp:UpdatePanel>