using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI.WebControls;
/// <summary>
/// Descripción breve de Utilidades
/// </summary>
public class Utilidades
{
	public Utilidades()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public static string GetIPAddress()
    {
       string ip = null;
        if (HttpContext.Current != null)
        { 
            ip = string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"])
                ? HttpContext.Current.Request.UserHostAddress
                : HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        }
        if (string.IsNullOrEmpty(ip) || ip.Trim() == "::1")
        { 
            var lan = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(r => r.AddressFamily == AddressFamily.InterNetwork);
            ip = lan == null ? string.Empty : lan.ToString();
        }
        return ip;
    }

    public static string GetUserApp() {
        return HttpContext.Current.Session["usuario"].ToString();
    }
	
	 public string ContadorRegistrosGrid(int NumeroRegistros, int RegistrosPorPagina, GridView gv_Datos) {

        string resultado = "";

        if (NumeroRegistros > 0)
        {
            int cantidad_paginas = gv_Datos.PageCount;
            int cantida_por_pagina = gv_Datos.PageSize;
            int pagina = gv_Datos.PageIndex + 1;
            string pagina_estado = "P&aacute;gina " + (NumeroRegistros == 0 ? 0 : pagina).ToString() + " de " + cantidad_paginas.ToString() + " - ";
            resultado = pagina_estado + string.Format("Mostrando registro del {0} - {1} de {2}", ((pagina * cantida_por_pagina) + 1) - cantida_por_pagina, (cantida_por_pagina * (pagina)) - (cantida_por_pagina - RegistrosPorPagina), NumeroRegistros);
        }
        else
        {
            resultado = "No se han encontrado coincidencias con el criterio de b&uacute;squeda.";
        }
        return resultado;
    }
}