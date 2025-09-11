<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucMensaje.ascx.cs" Inherits="wuc_master_wucMensaje" %>

<asp:UpdatePanel ID="udp_mensaje" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlMsg" runat="server" CssClass="modal-dialog progreso hidden">
            <div class="modal-content">
                <asp:Panel ID="pnlMsgTitulo" runat="server" CssClass="modal-header">
                    <asp:LinkButton runat="server" ID="btnMsgOculto2" CssClass="bootbox-close-button close" data-dismiss="modal" aria-hidden="true" Text="x" OnClick="lbnMsgCerrar_Click" />
                    <h4><i id="i_tit" runat="server"></i>&nbsp;<asp:Label ID="lblMsgTitulo" runat="server" Text=""></asp:Label></h4>
                </asp:Panel>
                <div id="divFormato" runat="server">
                    <asp:Panel ID="pnlMsgCuerpo" runat="server" CssClass="modal-body">
                        <i id="i" runat="server" class="icon-ok-sign icon-white"></i>
                        <asp:Literal ID="litMsgTexto" runat="server"></asp:Literal>
                    </asp:Panel>
                </div>
                <div class="modal-footer">
                    <div class="text-center">
                        <asp:LinkButton ID="lbnMsgCerrar" runat="server" OnClick="lbnMsgCerrar_Click" ToolTip="Cerrar" CssClass="btn btn-info cerrar_msj">
                            <i class="glyphicon glyphicon-ok-sign"></i>
                            Aceptar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <ajax:ModalPopupExtender ID="modal" runat="server" TargetControlID="btnMsgOculto" PopupControlID="pnlMsg"
            BackgroundCssClass="modal-backdrop" SkinID="mpe_animado">
        </ajax:ModalPopupExtender>
        <asp:Button runat="server" ID="btnMsgOculto" Style="display: none;" Enabled="false" />
    </ContentTemplate>
</asp:UpdatePanel>
