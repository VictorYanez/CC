using Mop.Seg.BLL.BS3;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wuc_master_wucAyudaManual : System.Web.UI.UserControl
{
    public string UrlAyudaManual
    {
        get { return this.hdfUrlAyudaManual.Value; }
        set { this.hdfUrlAyudaManual.Value = value; }
    }
    

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbnAyudaManual_Click(object sender, EventArgs e)
    {
        int? ItemId = null;

        try
        {
            ItemId = Convert.ToInt32(Request.Params["ItemID"].ToString());
        }
        catch
        {
            ItemId = null;
            string url = Request.Url.AbsolutePath;
            if (url.ToLower() != "/default.aspx")
            {
                Response.Redirect("/");
            }

        }
        WcfSeguridadBS3Client seg = new WcfSeguridadBS3Client();
        string idSistema = ConfigurationManager.AppSettings["id_sistema"].ToString();
        Mop.Seg.BLL.BS3.Menu mnu = new Mop.Seg.BLL.BS3.Menu();
        mnu.Sistema = new Sistema();
        mnu.Sistema.Id_Sistema = idSistema;
        mnu.Id_Menu = ItemId;

        List<Mop.Seg.BLL.BS3.Menu> lstMenu = seg.BuscarMenu(mnu).ToList();
        try
        {
            this.UrlAyudaManual = lstMenu[0].Url_Ayuda;
            this.lblAyudaManualTitulo.Text = lstMenu[0].Descripcion;
            //this.UrlAyudaVideo = lstMenu[0].Url_Ayuda_Video;
        }
        catch
        {
            this.UrlAyudaManual = "";
            this.lblAyudaManualTitulo.Text = "";
            //this.UrlAyudaVideo = "";
        }


        this.litAyudaManualTexto.Text = String.Format("<iframe width='100%' height='450px' src='{0}' style='border: none;'></iframe>"
                                                        , this.UrlAyudaManual
                                                     );
        this.pnlAyudaManual.CssClass = "modal-dialog modal-form";
        this.mdlAyudaManual.Show();
    }
}