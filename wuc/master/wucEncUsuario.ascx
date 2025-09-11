<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucEncUsuario.ascx.cs" Inherits="wuc_master_wucEncUsuario" %>



<a data-toggle="dropdown" href="#" class="dropdown-toggle">
    <asp:Image ID="imgFoto" runat="server" class="nav-user-photo" ImageUrl="http://std.mop.gob.sv/ws/rh/foto/foto.aspx?" AlternateText="" />
    <span class="user-info">
        <small><asp:Literal ID="litUsuario" runat="server" OnInit="litUsuario_Init"></asp:Literal></small>
        <asp:Literal ID="litPerfil" runat="server"></asp:Literal>
    </span>

    <i class="ace-icon fa fa-caret-down"></i>
</a>

<ul class="user-menu dropdown-menu-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">
    <%--<li>
        <a href="javascript:void(0)">
            <i class="ace-icon fa fa-cog"></i>
            Configuraci&oacute;n
        </a>
    </li>--%>
    <li id="li_Manual" runat="server" visible="false">
        <a href="../../ayuda/manuales/Manual_Usuario_V2.pdf" target="_blank">
            <i class="ace-icon fa fa-file"></i>
            Manual de Usuario
        </a>
    </li>
    <li class="divider"></li>

    <li>
        <asp:LoginStatus ID="lbnCerrarSesion" runat="server" LogoutText='<i class="ace-icon fa fa-power-off"></i> Cerrar sesi&oacute;n' OnLoggedOut="lbnCerrarSesion_LoggedOut" >
        </asp:LoginStatus>

    </li>
</ul>
