<%@ Page Title="" Language="C#" MasterPageFile="~/master_ajax.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ MasterType VirtualPath="~/master_ajax.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphEncabezado" runat="Server">
    <link href="assets/dashboard/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">

     	<div class="row" runat="server" id="div_alertas_direccion_legal">
             <div class="col-md-3">
			<div class="dbox dbox--color-2">
				<div class="dbox__icon">
					<i class="glyphicon glyphicon-warning-sign"></i>
				</div>
				<div class="dbox__body">
					<span class="dbox__count">
                 <asp:Literal ID="lit_GarantiasPorVencer" runat="server">0</asp:Literal></span>
					<span class="dbox__title">GARANTÍAS POR VENCER</span>
				</div>
				
				<div class="dbox__action">
					 <asp:HyperLink ID="hl_GarantiasPorVencer" CssClass="dbox__action__btn" runat="server" NavigateUrl="~/sistema/consultas/wf_ConsultaGarantias.aspx?ItemID=50&estado=GPV">Ver más</asp:HyperLink>
				</div>				
			</div>
		</div>
              <div class="col-md-3">
			<div class="dbox dbox--color-2">
				<div class="dbox__icon">
					<i class="glyphicon glyphicon-warning-sign"></i>
				</div>
				<div class="dbox__body">
					<span class="dbox__count"> <asp:Literal ID="lit_ContratosPorVencer" runat="server">0</asp:Literal></span>
					<span class="dbox__title">CONTRATOS POR VENCER</span>
				</div>
				
				<div class="dbox__action">
					<asp:HyperLink ID="hl_ContratosPorVencer" CssClass="dbox__action__btn" runat="server" NavigateUrl="~/sistema/consultas/wf_ConsultaContratos.aspx?ItemID=53&estado=CPV">Ver más</asp:HyperLink>
				</div>				
			</div>
		</div>
		<div class="col-md-3">
			<div class="dbox dbox--color-1">
				<div class="dbox__icon">
					<i class="glyphicon glyphicon-minus-sign"></i>
				</div>
				<div class="dbox__body">
					<span class="dbox__count"> <asp:Literal ID="lit_GarantiasVencidas" runat="server">0</asp:Literal></span>
					<span class="dbox__title">GARANTÍAS VENCIDAS</span>
				</div>
				
				<div class="dbox__action">
                    <asp:HyperLink ID="hl_GarantiasVencidas" CssClass="dbox__action__btn" runat="server" NavigateUrl="~/sistema/consultas/wf_ConsultaGarantias.aspx?ItemID=50&estado=GVE">Ver más</asp:HyperLink>
					
				</div>				
			</div>
		</div>
	<div class="col-md-3">
			<div class="dbox dbox--color-1">
				<div class="dbox__icon">
					<i class="glyphicon glyphicon-minus-sign"></i>
				</div>
				<div class="dbox__body">
					<span class="dbox__count"> <asp:Literal ID="lit_ContratosVencidos" runat="server">0</asp:Literal></span>
					<span class="dbox__title">CONTRATOS VENCIDOS</span>
				</div>
				
				<div class="dbox__action">
				 <asp:HyperLink ID="hl_ContratosVencidos" CssClass="dbox__action__btn" runat="server" NavigateUrl="~/sistema/consultas/wf_ConsultaContratos.aspx?ItemID=53&estado=CVE">Ver más</asp:HyperLink>
				</div>				
			</div>
		</div>
	</div>
    
    <div class="row" id="div_alerta_documento_direccion_legal" runat="server">
        	
		<div class="col-md-3">
			<div class="dbox dbox--color-3">
				<div class="dbox__icon">
					<i class="glyphicon glyphicon-cog"></i>
				</div>
				<div class="dbox__body">
					<span class="dbox__count"> <asp:Literal ID="lit_GarantiasConDocumentosPendientes" runat="server">0</asp:Literal></span>
					<span class="dbox__title">GARANTÍAS CON DOCUMENTOS PENDIENTES</span>
				</div>
				
				<div class="dbox__action">
					 <asp:HyperLink ID="hl_GarantiasPendientesDocumentos" CssClass="dbox__action__btn" runat="server"  NavigateUrl="~/sistema/consultas/wf_ConsultaGarantias.aspx?ItemID=50&estado=GDP">Ver más</asp:HyperLink>
				</div>				
			</div>
		</div>
    </div>

    <div class="row" runat="server" id="div_gerencia_financiera">
             <div class="col-md-3">
			<div class="dbox dbox--color-2">
				<div class="dbox__icon">
					<i class="glyphicon glyphicon-warning-sign"></i>
				</div>
				<div class="dbox__body">
					<span class="dbox__count">
                 <asp:Literal ID="lit_PendientesProcesarGfi" runat="server">0</asp:Literal></span>
					<span class="dbox__title">GARANTÍAS PENDIENTES DE PROCESAR</span>
				</div>
				
				<div class="dbox__action">
					 <asp:HyperLink ID="hl_GarantiasPendientesProcesar" CssClass="dbox__action__btn" runat="server" NavigateUrl="~/sistema/gfi/wf_GarantiasRecibidas.aspx?ItemID=80">Ver más</asp:HyperLink>
				</div>				
			</div>
		</div>

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

