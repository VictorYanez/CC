<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucAyudaManual.ascx.cs" Inherits="wuc_master_wucAyudaManual" %>
<asp:HiddenField ID="hdfUrlAyudaManual" runat="server" />
<!-- #section:basics/sidebar.layout.shortcuts -->
<asp:LinkButton ID="lbnAyudaManual" runat="server" CssClass="btn btn-warning" OnClick="lbnAyudaManual_Click">
            <i class="ace-icon fa fa-question"></i>
</asp:LinkButton>
<%--<asp:UpdatePanel ID="udpAyudaManual" runat="server">
    <ContentTemplate>--%>
        <asp:Panel ID="pnlAyudaManual" runat="server" CssClass="modal-dialog modal-ayuda hidden" Width="80%">
            <div class="modal-content">
                <asp:Panel ID="pnlAyudaManualTitulo" runat="server" CssClass="modal-header">
                    <asp:LinkButton runat="server" ID="btnAyudaManualOculto2" CssClass="bootbox-close-button close" data-dismiss="modal" aria-hidden="true" Text="x" />
                    <h4><i id="i_tit" runat="server"></i>&nbsp;<asp:Label ID="lblAyudaManualTitulo" runat="server" Text=""></asp:Label></h4>
                </asp:Panel>
                <asp:Panel ID="pnlAyudaManualCuerpo" runat="server" CssClass="modal-body">
                    <i id="i" runat="server" class="icon-ok-sign icon-white"></i>
                    <asp:Literal ID="litAyudaManualTexto" runat="server"></asp:Literal>
                </asp:Panel>
                <div class="modal-footer">
                    <div class="text-right">
                        <asp:LinkButton ID="lbnAyudaManualCerrar" runat="server" ToolTip="Cerrar" CssClass="btn btn-danger cerrar_msj">
                            <i class="glyphicon glyphicon-ok-sign"></i>
                            Cerrar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <ajax:ModalPopupExtender ID="mdlAyudaManual" runat="server" TargetControlID="btnAyudaManualOculto" PopupControlID="pnlAyudaManual"
            BackgroundCssClass="modal-backdrop" SkinID="mpe_animado">
        </ajax:ModalPopupExtender>
        <asp:Button runat="server" ID="btnAyudaManualOculto" Style="display: none;" Enabled="false" />
   <%-- </ContentTemplate>
</asp:UpdatePanel>--%>