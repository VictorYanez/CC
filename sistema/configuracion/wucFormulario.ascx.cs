using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sistema_configuracion_wucFormulario : System.Web.UI.UserControl
{

    public string Url
    {
        get { return this.txtFormulario.Text; }
        set { this.txtFormulario.Text = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            llebarArbol();
        }
    }
    protected void tvwFormulario_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.hdfFormulario.Value = this.tvwFormulario.SelectedNode.Value;
        this.txtFormulario.Text = this.tvwFormulario.SelectedNode.ValuePath;
    }

    protected void llebarArbol()
    {
        string ruta = MapPath("/sistema");
        DirectoryInfo dir = new DirectoryInfo(ruta);

        this.tvwFormulario.Nodes.Clear();
        TreeNode tnRaiz = new TreeNode();
        tnRaiz.Value = "/sistema";
        tnRaiz.Text = "Sistema";//((master_ajax)(this.Page.Master)).NombreSistema;
        this.tvwFormulario.Nodes.Add(tnRaiz);

        foreach(DirectoryInfo d in dir.GetDirectories())
        {
            TreeNode tn = new TreeNode(d.Name, d.Name);
            tn.ImageUrl = "http://estandar.mop.gob.sv/img/boton/dir.png";
            this.tvwFormulario.Nodes[0].ChildNodes.Add(tn);
            
            this.llenarArbolHijos(ref tn, d.FullName);
        }

        foreach (FileInfo a in dir.GetFiles())
        {
            if (a.Extension == ".aspx")
            {               
                TreeNode tn = new TreeNode("&nbsp;" + a.Name, a.Name);
                tn.ImageUrl = "http://estandar.mop.gob.sv/img/boton/aspx.png";
                tn.ImageToolTip = "aspx";
                this.tvwFormulario.Nodes[0].ChildNodes.Add(tn);
            }
        }
    }

    protected void llenarArbolHijos(ref TreeNode tnPadre, string ruta)
    {
        DirectoryInfo dir = new DirectoryInfo(ruta);

        foreach(DirectoryInfo d in dir.GetDirectories())
        {
            TreeNode tn = new TreeNode(d.Name, d.Name);
            tn.ImageUrl = "http://estandar.mop.gob.sv/img/boton/dir.png";
            tnPadre.ChildNodes.Add(tn);
            
            this.llenarArbolHijos(ref tn, d.FullName);
        }

        foreach (FileInfo a in dir.GetFiles())
        {
            if (a.Extension == ".aspx")
            {
                TreeNode tn = new TreeNode("&nbsp;" + a.Name, a.Name);
                tn.ImageUrl = "http://estandar.mop.gob.sv/img/boton/aspx.png";
                tn.ImageToolTip = "aspx";
                tnPadre.ChildNodes.Add(tn);
            }
        }
          
    }
}