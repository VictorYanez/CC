using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sistema_configuracion_wucPadre : System.Web.UI.UserControl
{

    public short? Nivel
    {
        get 
        { 
            try
            {
                return Convert.ToInt16(this.tvwControl.SelectedNode.Depth);
            }
            catch
            {
                return 0;
            }
        }
    }
    public string Jerarquia
    {
        get
        {
            try
            {
                return this.tvwControl.SelectedNode.ValuePath + ".";
            }
            catch
            {
                return "";
            }
        }
    }




    public int? IdMenu
    {
        get
        {
            try
            {
                if((this.txtControl.Text == "Raiz de sistema") || (this.hdfControl.Value == "0"))
                    return null;
                else
                    return Convert.ToInt32(this.hdfControl.Value);
            }
            catch
            {
                return null;
            }
        }
        set
        {
            this.hdfControl.Value = value.ToString();
            this.CargarSeleccionado(value.ToString());
            try
            {
                this.txtControl.Text = this.tvwControl.SelectedNode.Text;

                //this.lit.Text = "";
                //for (int i = 1900; i >= 1800; i--)
                //{
                //    this.lit.Text += "<img src='http://std.mop.gob.sv/ws/rh/foto/foto.aspx?" + i.ToString() + "' width='50px' />";
                //}
            }
            catch
            {
                this.txtControl.Text = "";
            }
        }
    }


    protected void CargarSeleccionado(string id)
    {
        foreach (TreeNode tn in this.tvwControl.Nodes)
        {
            if (tn.Value == id)
            {
                tn.Selected = true;
                break;
            }
            CargarSeleccionadoHijos(id, tn);
        }
    }
    protected void CargarSeleccionadoHijos(string id, TreeNode tnP)
    {
        foreach(TreeNode tn in tnP.ChildNodes)
        {
            if (tn.Value == id)
            {
                tn.Selected = true;
                break;
            }
            CargarSeleccionadoHijos(id, tn);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void tvwControl_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.hdfControl.Value = this.tvwControl.SelectedNode.Value;
        this.txtControl.Text = this.tvwControl.SelectedNode.Text;
    }

    public void llenarArbol(List<Mop.Seg.BLL.WcfMaestra.Menu> lstMenu, int? exclusion)   
	{
		
        this.tvwControl.Nodes.Clear();
        TreeNode tnRaiz = new TreeNode();
        tnRaiz.Value = "";
        tnRaiz.Text = "Raiz de sistema";//((master_ajax)(this.Page.Master)).NombreSistema;
        this.tvwControl.Nodes.Add(tnRaiz);

        foreach(Mop.Seg.BLL.WcfMaestra.Menu mnu in lstMenu)
        {
            if((mnu.IdPadre == null) && (mnu.Id_Menu != exclusion))
            {
                TreeNode tn = new TreeNode();
                tn.Value = mnu.Id_Menu.ToString();
                tn.Text = mnu.Descripcion;

                this.tvwControl.Nodes[0].ChildNodes.Add(tn);
                this.Cargar_Datos_Hijos(ref tn, lstMenu, exclusion);
            }
        }

        this.tvwControl.ExpandAll();
	}
    protected void Cargar_Datos_Hijos(ref TreeNode tnPadre, List<Mop.Seg.BLL.WcfMaestra.Menu> lstMenu, int? exclusion)
    {
        foreach(Mop.Seg.BLL.WcfMaestra.Menu mnu in lstMenu)
        {
            if ((mnu.IdPadre.ToString() == tnPadre.Value) && (mnu.Id_Menu != exclusion))
            {
                TreeNode tn = new TreeNode();
                tn.Value = mnu.Id_Menu.ToString();
                tn.Text = mnu.Descripcion;

                tnPadre.ChildNodes.Add(tn);
                this.Cargar_Datos_Hijos(ref tn, lstMenu, exclusion);
            }
        }
    }

}