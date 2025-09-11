using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sistema_configuracion_wucVideo : System.Web.UI.UserControl
{

    public string Url
    {
        get { return this.txtVideo.Text; }
        set { this.txtVideo.Text = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            llebarArbol();
        }
    }
    protected void tvwVideo_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.hdfVideo.Value = this.tvwVideo.SelectedNode.Value;
        this.txtVideo.Text = this.tvwVideo.SelectedNode.ValuePath;
    }

    protected void llebarArbol()
    {
        string ruta = MapPath("/ayuda/videos");
        DirectoryInfo dir = new DirectoryInfo(ruta);

        this.tvwVideo.Nodes.Clear();
        TreeNode tnRaiz = new TreeNode();
        tnRaiz.Value = "/ayuda/videos";
        tnRaiz.Text = "Videos";//((master_ajax)(this.Page.Master)).NombreSistema;
        this.tvwVideo.Nodes.Add(tnRaiz);

        foreach (DirectoryInfo d in dir.GetDirectories())
        {
            TreeNode tn = new TreeNode(d.Name, d.Name);
            tn.ImageUrl = "http://estandar.mop.gob.sv/img/boton/dir.png";
            this.tvwVideo.Nodes[0].ChildNodes.Add(tn);

            this.llenarArbolHijos(ref tn, d.FullName);
        }

        foreach (FileInfo a in dir.GetFiles())
        {
            if (a.Extension == ".wmv")
            {
                TreeNode tn = new TreeNode("&nbsp;" + a.Name, a.Name);
                tn.ImageUrl = "http://estandar.mop.gob.sv/img/boton/aspx.png";
                tn.ImageToolTip = "wmv";
                this.tvwVideo.Nodes[0].ChildNodes.Add(tn);
            }
        }
    }

    protected void llenarArbolHijos(ref TreeNode tnPadre, string ruta)
    {
        DirectoryInfo dir = new DirectoryInfo(ruta);

        foreach (DirectoryInfo d in dir.GetDirectories())
        {
            TreeNode tn = new TreeNode(d.Name, d.Name);
            tn.ImageUrl = "http://estandar.mop.gob.sv/img/boton/dir.png";
            tnPadre.ChildNodes.Add(tn);

            this.llenarArbolHijos(ref tn, d.FullName);
        }

        foreach (FileInfo a in dir.GetFiles())
        {
            if (a.Extension == ".wmv")
            {
                TreeNode tn = new TreeNode("&nbsp;" + a.Name, a.Name);
                tn.ImageUrl = "http://estandar.mop.gob.sv/img/boton/aspx.png";
                tn.ImageToolTip = "wmv";
                tnPadre.ChildNodes.Add(tn);
            }
        }

    }
}