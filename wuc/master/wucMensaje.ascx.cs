using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wuc_master_wucMensaje : System.Web.UI.UserControl
{
    public void Mostar(bool opcion)
    {
        if (opcion)
        {
            this.pnlMsg.CssClass = "modal-dialog progreso";
            this.modal.Show();
            this.lbnMsgCerrar.Focus();      
            this.Page.Form.DefaultButton = this.lbnMsgCerrar.UniqueID;
        }
        else
        {
            this.modal.Hide();
        }
    }

    public string Tipo
    {
        set
        {
            this.divFormato.Attributes["class"] = value;
        }
    }

    public Panel pnlMensaje
    {
        get { return this.pnlMsgCuerpo; }
        set { this.pnlMsgCuerpo = value; }
    }
    public string Mensaje
    {
        get { return this.litMsgTexto.Text; }
        set { this.litMsgTexto.Text = value; }
    }
    public string Icono
    {
        get { return this.i.Attributes["class"].ToString(); }
        set
        {
            this.i.Attributes["class"] = value + " icon-white";
            //this.i_tit.Attributes["class"] = value;
        }
    }
    public string MensajeTitulo
    {
        get { return this.lblMsgTitulo.Text; }
        set { this.lblMsgTitulo.Text = value; }
    }
    public string MensajeTexto
    {
        get { return this.litMsgTexto.Text; }
        set { this.litMsgTexto.Text = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbnMsgCerrar_Click(object sender, EventArgs e)
    {
        this.modal.Hide();
    }
}
