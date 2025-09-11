<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucAyudaVideo.ascx.cs" Inherits="wuc_master_wucAyudaVideo" %>
<asp:HiddenField ID="hdfUrlAyudaVideo" runat="server" />
<asp:LinkButton ID="lbnAyudaVideo" runat="server" CssClass="btn btn-danger" OnClick="lbnAyudaVideo_Click">
    <i class="ace-icon fa fa-play"></i>
</asp:LinkButton>
<%--<asp:UpdatePanel ID="udpAyudaVideo" runat="server">
    <ContentTemplate>--%>
        <asp:Panel ID="pnlAyudaVideo" runat="server" CssClass="modal-dialog modal-form hidden" Width="80%">
            <div class="modal-content">
                <asp:Panel ID="pnlAyudaVideoTitulo" runat="server" CssClass="modal-header">
                    <asp:LinkButton runat="server" ID="btnAyudaVideoOculto2" CssClass="bootbox-close-button close" data-dismiss="modal" aria-hidden="true" Text="x" />
                    <h4><i id="i_tit" runat="server"></i>&nbsp;<asp:Label ID="lblAyudaVideoTitulo" runat="server" Text=""></asp:Label></h4>
                </asp:Panel>
                <asp:Panel ID="pnlAyudaVideoCuerpo" runat="server" CssClass="modal-body">
                    <i id="i" runat="server" class="icon-ok-sign icon-white"></i>
                    <asp:Literal ID="litAyudaVideoTexto" runat="server"></asp:Literal>
                </asp:Panel>
                <div class="modal-footer">
                    <div class="text-right">
                        <asp:LinkButton ID="lbnAyudaVideoCerrar" runat="server" ToolTip="Cerrar" CssClass="btn btn-danger cerrar_msj">
                            <i class="glyphicon glyphicon-ok-sign"></i>
                            Cerrar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <ajax:ModalPopupExtender ID="mdlAyudaVideo" runat="server" TargetControlID="btnAyudaVideoOculto" PopupControlID="pnlAyudaVideo"
            BackgroundCssClass="modal-backdrop" SkinID="mpe_animado">
        </ajax:ModalPopupExtender>
        <asp:Button runat="server" ID="btnAyudaVideoOculto" Style="display: none;" Enabled="false" />
    <%--</ContentTemplate>
</asp:UpdatePanel>--%>
