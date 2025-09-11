using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mop.Seg.BLL.BS3;
using System.Configuration;

public partial class wuc_master_wucPistaNavegacion : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            CargarPista();
        }
    }
    protected void CargarPista()
    {
        int? ItemId;
        try
        {
            ItemId = Convert.ToInt32(Request.Params["ItemID"].ToString());            
        }
        catch
        {
            ItemId = 0;
        }

        WcfSeguridadBS3Client seg = new WcfSeguridadBS3Client();
        ParSeguridad parSeguridad = new ParSeguridad();
        parSeguridad.Id_Menu = ItemId;
        parSeguridad.Id_Sistema = ConfigurationManager.AppSettings["id_sistema"].ToString();
        this.litPistaNavegacion.Text = seg.PistaNavegacion(parSeguridad);

    }
}