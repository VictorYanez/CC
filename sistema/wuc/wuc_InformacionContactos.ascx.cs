using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sistema_wuc_InformacionContactos : System.Web.UI.UserControl
{
   
    public void CargarContactos(int idGarantia, int idContrato)
    {
        rep_InformacionContactos.DataSource = new BllContactos().ListaContactosConsulta(idGarantia, idContrato);
        rep_InformacionContactos.DataBind();
    }

    protected void rep_InformacionContactos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal lit_Nombre = (Literal)e.Item.FindControl("lit_Nombre");
            Literal lit_TelefonoOficina = (Literal)e.Item.FindControl("lit_TelefonoOficina");
            Literal lit_TelefonoCelular = (Literal)e.Item.FindControl("lit_TelefonoCelular");
            HyperLink hl_CorreoElectronico = (HyperLink)e.Item.FindControl("hl_CorreoElectronico");
            Literal lit_TipoConcesionario = (Literal)e.Item.FindControl("lit_TipoConcesionario");
            Literal lit_Comentario = (Literal)e.Item.FindControl("lit_Comentario");

            lit_Nombre.Text = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Nombre"));
            lit_TelefonoOficina.Text = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Oficina"));
            lit_TelefonoCelular.Text = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Celular"));
            hl_CorreoElectronico.Text = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "CorreoElectronico"));
            hl_CorreoElectronico.NavigateUrl = "mailto:" + hl_CorreoElectronico.Text;
            lit_TipoConcesionario.Text = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "TipoContacto"));
            lit_Comentario.Text = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Comentarios"));

        }
    }
}