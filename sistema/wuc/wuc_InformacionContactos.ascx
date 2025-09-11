<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wuc_InformacionContactos.ascx.cs" Inherits="sistema_wuc_InformacionContactos" %>

                     <asp:Repeater ID="rep_InformacionContactos" runat="server" OnItemDataBound="rep_InformacionContactos_ItemDataBound">

    <ItemTemplate>
        <div class="profile-user-info profile-user-info-striped">
																<div class="profile-info-row">
																	<div class="profile-info-name"> Nombre </div>

																	<div class="profile-info-value">
																		<span><asp:Literal ID="lit_Nombre" runat="server"></asp:Literal></span>
																	</div>
																</div>

																<div class="profile-info-row">
																	<div class="profile-info-name"> Oficina </div>

																	<div class="profile-info-value">
																		<span><asp:Literal ID="lit_TelefonoOficina" runat="server"></asp:Literal></span>
																	</div>
																</div>

																<div class="profile-info-row">
																	<div class="profile-info-name"> Celular </div>

																	<div class="profile-info-value">
																		<span><asp:Literal ID="lit_TelefonoCelular" runat="server"></asp:Literal></span>
																	</div>
																</div>

																<div class="profile-info-row">
																	<div class="profile-info-name"> Correo electrónico </div>

																	<div class="profile-info-value">
																		<span><asp:HyperLink ID="hl_CorreoElectronico" runat="server"></asp:HyperLink></span>
																	</div>
																</div>

																<div class="profile-info-row">
																	<div class="profile-info-name"> Tipo </div>

																	<div class="profile-info-value">
																		<span><asp:Literal ID="lit_TipoConcesionario" runat="server"></asp:Literal></span>
																	</div>
																</div>
                                                                 <div class="profile-info-row">
																	<div class="profile-info-name"> Comentario </div>

																	<div class="profile-info-value">
																		<span><asp:Literal ID="lit_Comentario" runat="server"></asp:Literal></span>
																	</div>
																</div>
															</div>
         <div class="space"></div>
    </ItemTemplate>
                  
</asp:Repeater>
                     <div class="alert alert-warning" id="div_MensajeSinLineas" runat="server" visible="false">No hay contactos</div>