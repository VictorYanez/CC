using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class sistema_configuracion_wucIcono : System.Web.UI.UserControl
{

    public string Clase
    {
        get { return this.hdfControl.Value;  }
        set
        {
            try
            {
                int i = 0;
                foreach(ListItem item in this.rblIconos.Items)
                {
                    if(item.Value == value)
                    {
                        item.Selected = true;
                        i++;
                        break;
                    }
                }

                //this.rblIconos.SelectedIndex  = value;
                this.lblControl.Text = String.Format("<i class='fa {0}'></i> {0}", value);
                this.hdfControl.Value = value;

                if (i == 0)
                    this.rblIconos.SelectedIndex = -1;
            }
            catch
            {
                this.rblIconos.SelectedIndex = -1;
                this.lblControl.Text = "";
                this.hdfControl.Value = "";
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            this.CargarIconos();
        }
    }

    protected void CargarIconos()
    {
        //Create the XmlDocument.
        XmlDocument doc = new XmlDocument();
        doc.Load(MapPath("iconos.xml"));

        //Display all the book titles.
        XmlNodeList elemList = doc.GetElementsByTagName("icono");
        List<Elementos> lstElementos = new List<Elementos>();

        for (int i = 0; i < elemList.Count; i++)
        {
            Elementos elementos = new Elementos();
            elementos.Nombre = elemList[i].Attributes["nombre"].InnerText;
            elementos.Texto = elemList[i].Attributes["texto"].InnerText;
            lstElementos.Add(elementos);
        }

        this.rblIconos.DataValueField = "Nombre";
        this.rblIconos.DataTextField = "Texto";
        this.rblIconos.DataSource = lstElementos
                                        .OrderBy(a => a.Nombre)
                                        .ToList();
        this.rblIconos.DataBind();


    }
    protected void rblIconos_SelectedIndexChanged(object sender, EventArgs e)
    {
        string v = this.rblIconos.SelectedItem.Value;
        this.lblControl.Text = String.Format("<i class='fa {0}'></i> {0}", v);
        this.hdfControl.Value = v;
    }
}

public class Elementos
{
    public string Nombre { get; set; }
    public string Texto { get; set; }
}