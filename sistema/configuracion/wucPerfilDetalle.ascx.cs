using Mop.Seg.BLL.WcfMaestra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sistema_configuracion_wucPerfilDetalle : System.Web.UI.UserControl
{

    #region PROPIEDADES
    //Entidad a la que corresponde el formulario
    WcfMaestraClient bllMenu = new WcfMaestraClient();

    public string IdPerfil
    {
        get { return this.hfd_IdPerfil.Value; }
        set { this.hfd_IdPerfil.Value = value; }
    }
    #endregion

    #region CARGA DEL WUC

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            //this.Cargar_Datos();
        }
    }
    #endregion

    #region CARGA DE DATOS

    public void Cargar_Datos()
    {
        Mop.Seg.BLL.WcfMaestra.WcfMaestraClient wcf = new WcfMaestraClient();
        ParSeguridad parSeguridad = new ParSeguridad();
        parSeguridad.Id_Perfil = this.IdPerfil;
        parSeguridad.Id_Sistema = ((master_ajax)(this.Page.Master)).IdSistema;

        List<DetallePerfil> lst = wcf.DetallePerfil(parSeguridad).ToList();
        List<DetallePerfil> lstDetallePerfil = new List<DetallePerfil>();

        foreach(DetallePerfil dp in lst)
        {
            if(dp.IdPadre == null)
            {
                lstDetallePerfil.Add(dp);
                this.agregarHijos(dp, lst, ref lstDetallePerfil);
            }
        }

        this.gv_Menu.DataSource = lstDetallePerfil;
        this.gv_Menu.DataBind();
    }

    protected void agregarHijos(DetallePerfil dpP, List<DetallePerfil> lst, ref List<DetallePerfil> lstDetallePerfil)
    {
        foreach(DetallePerfil dp in lst)
        {
            if((dp.IdPadre != null) && (dp.IdPadre == dpP.Id_Menu))
            {
                lstDetallePerfil.Add(dp);
                this.agregarHijos(dp, lst, ref lstDetallePerfil);
            }
        }
    }

    

    #endregion


    #region GUARDAR DATOS
    public void Guardar_Datos()
    {

        string idPerfil = this.IdPerfil;
        string idSistema = ((master_ajax)(this.Page.Master)).IdSistema;

        List<Detalle_Perfil> lstInsertar = new List<Detalle_Perfil>();
        List<Detalle_Perfil> lstEliminar = new List<Detalle_Perfil>();

        
        foreach(GridViewRow dr in this.gv_Menu.Rows)
        {
            if(dr.RowType == DataControlRowType.DataRow)
            {
                Detalle_Perfil detalle = new Detalle_Perfil();
                detalle.Perfil = new Perfil();
                detalle.Sistema = new Sistema();
                detalle.Menu = new Mop.Seg.BLL.WcfMaestra.Menu();
                detalle.Perfil.Id_Perfil = idPerfil;
                detalle.Sistema.Id_Sistema = idSistema;

                bool Activo = ((CheckBox)(dr.FindControl("cbxAct"))).Checked;
                detalle.Seleccionar = ((CheckBox)(dr.FindControl("cbxSel"))).Checked;
                detalle.Insertar = ((CheckBox)(dr.FindControl("cbxIns"))).Checked;
                detalle.Actualizar = ((CheckBox)(dr.FindControl("cbxEdi"))).Checked;
                detalle.Eliminar = ((CheckBox)(dr.FindControl("cbxEli"))).Checked;
                detalle.Imprimir = ((CheckBox)(dr.FindControl("cbxImp"))).Checked;
                detalle.Menu.Id_Menu = Convert.ToInt32(this.gv_Menu.DataKeys[dr.RowIndex]["Id_Menu"].ToString());
                if (Activo)
                    lstInsertar.Add(detalle);
                else
                    lstEliminar.Add(detalle);
            }
        }


        bllMenu.Detalle_Perfil_IL(lstInsertar.ToArray());
        bllMenu.Detalle_Perfil_EL(lstEliminar.ToArray());

    }

    
    #endregion


}