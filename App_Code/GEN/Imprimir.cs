using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrystalDecisions.Shared;


/// <summary>
/// Descripción breve de Imprimir
/// </summary>
public class Imprimir
{

    public string Titulo { get; set; }
    public string IdReporte { get; set; }
    public string SqlPrincipal { get; set; }
    public List<string> SqlSubReportes { get; set; }
    public bool SubReporte { get; set; }
    public PaperSize TamanoPapel { get; set; }
    public PaperOrientation Orientacion { get; set; }
    public List<ParametrosReporte> ColeccionParametros { get; set; }
    public string NombreArchivoDescarga { get; set; }
   
	public Imprimir()
	{
        SubReporte = false;
        TamanoPapel = PaperSize.DefaultPaperSize;
        Orientacion = PaperOrientation.DefaultPaperOrientation;
	}

 
}

public class ParametrosReporte
{
    public string NombreParametro { get; set; }
    public string ValorParametro { get; set; }

    public ParametrosReporte() { }
}