<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucProcesando.ascx.cs" Inherits="wuc_master_wucProcesando" %>

<asp:UpdateProgress ID="upp_progreso" runat="server" >
    <ProgressTemplate>       
   
        <asp:Panel ID="pnl_progreso" runat="server" CssClass="myModal progreso">           
            <div class="modal-body">
                <asp:Panel id="pnl_progreso_cuerpo" runat="server" CssClass="modal-body alert alert-warning">
                    <div class="progreso_texto text-center">
                        <i id="i" runat="server" class="icon-ok-sign icon-white"></i>
                        <asp:Literal ID="lit_mensaje" runat="server">Procesando datos...</asp:Literal>
                    </div>
                    <div class="cen">                                                            
                        <div class="progress progress-striped active">
                          <div class="progress-bar progress-bar-warning" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%;">
                            <span class="sr-only"></span>
                          </div>
                        </div>
                    </div>    
                </asp:Panel>                 
            </div>                            
        </asp:Panel>           
        <ajax:AnimationExtender ID="ane_progreso" runat="server" Enabled="True" TargetControlID="pnl_progreso_cuerpo">
            <Animations>
              
            </Animations>
        </ajax:AnimationExtender>
        <div id="cargando"></div>       
    </ProgressTemplate>    
</asp:UpdateProgress>
