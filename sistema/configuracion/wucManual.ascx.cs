using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sistema_configuracion_wucManual : System.Web.UI.UserControl
{
    public string Url
    {
        get { return this.txtManual.Text; }
        set { this.txtManual.Text = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            llebarArbol();
        }
    }
    protected void tvwManual_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.hdfManual.Value = this.tvwManual.SelectedNode.Value;
        this.txtManual.Text = this.tvwManual.SelectedNode.ValuePath;
    }

    protected void llebarArbol()
    {
        string ruta = MapPath("/ayuda/manuales");
        DirectoryInfo dir = new DirectoryInfo(ruta);

        this.tvwManual.Nodes.Clear();
        TreeNode tnRaiz = new TreeNode();
        tnRaiz.Value = "/ayuda/manuales";
        tnRaiz.Text = "Manuales";//((master_ajax)(this.Page.Master)).NombreSistema;
        this.tvwManual.Nodes.Add(tnRaiz);

        foreach (DirectoryInfo d in dir.GetDirectories())
        {
            TreeNode tn = new TreeNode(d.Name, d.Name);
            tn.ImageUrl = "http://estandar.mop.gob.sv/img/boton/dir.png";
            this.tvwManual.Nodes[0].ChildNodes.Add(tn);

            this.llenarArbolHijos(ref tn, d.FullName);
        }

        foreach (FileInfo a in dir.GetFiles())
        {
            if (a.Extension == ".pdf")
            {
                TreeNode tn = new TreeNode("&nbsp;" + a.Name, a.Name);
                tn.ImageUrl = "http://estandar.mop.gob.sv/img/boton/aspx.png";
                tn.ImageToolTip = "pdf";
                this.tvwManual.Nodes[0].ChildNodes.Add(tn);
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
            if (a.Extension == ".pdf")
            {
                TreeNode tn = new TreeNode("&nbsp;" + a.Name, a.Name);
                tn.ImageUrl = "http://estandar.mop.gob.sv/img/boton/aspx.png";
                tn.ImageToolTip = "pdf";
                tnPadre.ChildNodes.Add(tn);
            }
        }

    }
}