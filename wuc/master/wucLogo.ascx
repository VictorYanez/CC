<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucLogo.ascx.cs" Inherits="wuc_wucLogo" %>

<div class="navbar-header pull-left">
    <!-- #section:basics/navbar.layout.brand -->
    <div class="pull-left">
        <a href="/">
            <img alt="Logo institucional" src="../../assets/img/mopt/vmt.jpg" height="45px" width="93px" />
        </a>
    </div>


    <a href="/" class="navbar-brand">
        <small>
            <i class="fa fa-home"></i>
            <%= ConfigurationManager.AppSettings["nombre_sistema"].ToString() %>
        </small>
    </a>
    <!-- /section:basics/navbar.layout.brand -->    

    


</div>
