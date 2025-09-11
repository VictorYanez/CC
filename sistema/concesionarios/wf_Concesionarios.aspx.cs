/*
============================================================================================
tbl_Concesionarios:	Tabla que almacena la información relevante de los concesionarios.
Creada por:	VMT\marvin.ruiz
Fecha generación:	jueves, 08 de julio de 2021 10:42:57
============================================================================================
*/
using BLL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wf_Concesionarios : System.Web.UI.Page
{

    BllConcesionarios bllConcesionarios = new BllConcesionarios();
    BllContactos bllContactos = new BllContactos();

    int registros_por_pagina = 0;

    #region "CARGA DEL FORMULARIO"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.wuc_mantto.Filtro_Criterio.Items.Add("Nombre");
            this.wuc_mantto.Filtro_Criterio.Items.Add("Nit/Dui");
            this.CargarTiposConcesionarios();

            this.HabilitarEdicion(false);
            this.div_grilla_contactos.Style["display"] = "none";
            this.div_Mantenimiento.Style["display"] = "none";

            this.LimpiarCampos();
            this.CargarDatos();
            this.CargarTiposContactos();

            // Coloca el campo DUI/NIT oculto inicialmente
            this.divNitDui.Visible = false;
            this.rfv_Nit.Enabled = false;
            this.rev_Nit.Enabled = false;
        }
    }
    #endregion //"CARGA DEL FORMULARIO"

    #region "EVENTOS DE LOS BOTONES"

    protected void Nuevo(object sender, EventArgs e)
    {
        this.HabilitarEdicion(true);
        this.LimpiarCampos();
        this.lbl_Accion.Text = "Insertar registro:";
        this.nb_IdConcesionario.Enabled = false;
        this.div_grilla_contactos.Style["display"] = "none";
        this.div_Mantenimiento.Style["display"] = "none";
    }
    protected void Editar(object sender, EventArgs e)
    {
        this.CargarRegistro();
        this.HabilitarEdicion(true);
        this.lbl_Accion.Text = "Actualizar registro:";
        this.nb_IdConcesionario.Enabled = false;
        this.div_grilla_contactos.Style["display"] = "none";
        this.div_Mantenimiento.Style["display"] = "none";
    }
    protected void Eliminar(object sender, EventArgs e)
    {
        this.EliminarRegistro();
        this.HabilitarEdicion(false);
        this.LimpiarCampos();
        this.CargarDatos();
    }
    protected void Guardar(object sender, EventArgs e)
    {
        this.GuardarRegistro();
        this.HabilitarEdicion(false);
        this.LimpiarCampos();
        this.CargarDatos();
        this.wuc_mantto.MostrarBuscar = true;
    }
    protected void Cancelar(object sender, EventArgs e)
    {
        this.HabilitarEdicion(false);
        this.LimpiarCampos();
        this.CargarDatos();
    }
    protected void Imprimir(object sender, EventArgs e)
    {
        /*
			this.Master.Reporte.Titulo = "Modulo";
			this.Master.Reporte.ID_Reporte = "rpt_modulo";
			this.Master.Reporte.SQL_Principal = "pa_br_Modulo @_accion='buscar'";
			//this.Master.Reporte.SQL_SubReportes = new string[] { "sql uno", "sql dos", "sql n" };
			this.Master.Reporte.TamanoPapel = CrystalDecisions.Shared.PaperSize.PaperLetter;
			this.Master.Reporte.Orientacion = CrystalDecisions.Shared.PaperOrientation.Portrait;
			this.Master.Reporte.Mostar(true);
		*/
    }
    protected void AplicarFiltro(object sender, EventArgs e)
    {
        this.wuc_mantto.MostrarImprimir = false;
        this.CargarDatos();
    }

    protected void lb_NuevoContacto_Click(object sender, EventArgs e)
    {
        LimpiarCamposContacto();
        hf_AccionContacto.Value = "I";
        mpe_Contacto.Show();
    }
    protected void lb_EditarContacto_Click(object sender, EventArgs e)
    {
        CargarRegistroContacto();
        hf_AccionContacto.Value = "U";
        mpe_Contacto.Show();
    }

    protected void lb_GuardarContacto_Click(object sender, EventArgs e)
    {
        this.GuardarRegistroContacto();
        this.CargarDatosContactos(Convert.ToInt32(nb_IdConcesionario.Text));
        this.CargarDatos();
        this.HabilitarEdicionContactos(false);
        hf_AccionContacto.Value = "";
        this.lb_GuardarContacto.Visible = true;
        LimpiarCamposContacto();
    }

    protected void lb_EliminarContacto_Click(object sender, EventArgs e)
    {
        EliminarRegistroContacto();
        this.CargarDatosContactos(Convert.ToInt32(nb_IdConcesionario.Text));
        this.CargarDatos();
        this.HabilitarEdicionContactos(false);
    }
    #endregion //"EVENTOS DE LOS BOTONES"

    #region "GESTION DEL COMPORTAMIENTO DE EDICION"

    protected void LimpiarCampos()
    {
        this.nb_IdConcesionario.Text = String.Empty;
        this.txt_Nombre.Text = String.Empty;
        this.txt_Abreviatura.Text = String.Empty;
        this.txt_Nit.Text = String.Empty;
        this.ddl_TiposConcesionarios.SelectedIndex = 0;

        // Ocultar el campo DUI/NIT y restablecer máscaras y validaciones
        divNitDui.Visible = false;
        mee_Nit.Mask = string.Empty;
        rev_Nit.ValidationExpression = string.Empty;
        rev_Nit.ErrorMessage = string.Empty;
    }

    protected void LimpiarCamposContacto()
    {
        this.hf_IdContacto.Value = "0";
        this.txt_Nombres.Text = String.Empty;
        this.txt_Apellidos.Text = String.Empty;
        this.txt_NitContacto.Text = String.Empty;
        this.txt_TelefonoOficina.Text = String.Empty;
        this.txt_NumeroCelular.Text = String.Empty;
        this.txt_CorreoElectronico.Text = String.Empty;
        this.ddl_TiposContactos.SelectedIndex = 0;
        this.txt_Comentarios.Text = String.Empty;
    }
    protected void HabilitarEdicion(bool opcion)
    {

        this.pnl_campos.Enabled = opcion;
        this.gv_Datos.Enabled = !opcion;

        this.wuc_mantto.Limpiar_Filtro();

        this.wuc_mantto.MostrarNuevo = !opcion;
        this.wuc_mantto.MostrarGuardar = opcion;
        this.wuc_mantto.MostrarCancelar = opcion;

        this.wuc_mantto.MostrarEditar = false;
        this.wuc_mantto.MostrarEliminar = false;
        this.wuc_mantto.MostrarBuscar = !opcion;
        //this.wuc_mantto.MostrarImprimir = !opcion;
        this.wuc_mantto.MostrarImprimir = false;

        if (opcion)
        {
            this.pnl_campos.Style["display"] = "block";
            this.div_grilla.Style["display"] = "none";
        }
        else
        {
            this.pnl_campos.Style["display"] = "none";
            this.div_grilla.Style["display"] = "block";
        }
    }

    protected void HabilitarEdicionContactos(bool opcion)
    {

        this.gv_DatosContactos.Enabled = !opcion;

        this.lb_NuevoContacto.Visible = !opcion;
        this.lb_GuardarContacto.Visible = opcion;

        this.lb_EditarContacto.Visible = false;
        this.lb_EliminarContacto.Visible = false;
    }

    // Para validacion de NIT o DUI según corresponda
    protected void ddl_TiposConcesionarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int tipoConcesionario;
            if (int.TryParse(ddl_TiposConcesionarios.SelectedValue, out tipoConcesionario))
            {
                divNitDui.Visible = true;
                rev_Nit.ErrorMessage = "";

                switch (tipoConcesionario)
                {
                    case 1: // NATURAL (DUI)
                        mee_Nit.Mask = "99999999-9";
                        rev_Nit.ValidationExpression = @"^\d{8}-\d$";
                        //rev_Nit.ErrorMessage = "Formato de DUI inválido. Ejemplo: 12345678-9";
                        rfv_Nit.Enabled = true; // Habilitar validador
                        break;

                    case 2: // JURÍDICO (NIT)
                        mee_Nit.Mask = "9999-999999-999-9";
                        rev_Nit.ValidationExpression = @"^\d{4}-\d{6}-\d{3}-\d$";
                        //rev_Nit.ErrorMessage = "Formato de NIT inválido. Ejemplo: 1234-567890-123-1";
                        rfv_Nit.Enabled = true; // Habilitar validador
                        break;

                    default:
                        divNitDui.Visible = false; // Ocultar el campo
                        mee_Nit.Mask = string.Empty;
                        rev_Nit.ValidationExpression = string.Empty;
                        rev_Nit.ErrorMessage = string.Empty;
                        rfv_Nit.Enabled = false; // Deshabilitar validador
                        break;
                }
                // Forzar la actualización del MaskedEditExtender
                mee_Nit.DataBind();
            }
            else
            {
                throw new Exception("El valor seleccionado no es válido.");
            }
        }
        catch (Exception ex)
        {
            MostrarError("Error en la selección: " + ex.Message);
        }
    }

    // Método para mostrar errores
    private void MostrarError(string mensaje)
    {
        lbl_Error.Text = mensaje;
        lbl_Error.Visible = true;
    }

    #endregion //"GESTION DEL COMPORTAMIENTO DE EDICION"

    #region "GESTION DEL COMPORTAMIENTO DE LA GRID"
    protected void gv_Datos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gv_Datos, "Select$" + e.Row.RowIndex);

            Literal lit_CantidadContactos = (Literal)e.Row.FindControl("lit_CantidadContactos");

            int IdConcesionario = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdConcesionario"));
            lit_CantidadContactos.Text = new BllConcesionarios().CantidadContactosConcesionario(IdConcesionario).ToString();

            registros_por_pagina = e.Row.RowIndex + 1;
        }
    }
    protected void gv_Datos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv_Datos.PageIndex = e.NewPageIndex;
        this.CargarDatos();
    }
    protected void gv_Datos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.gv_Datos.SelectedIndex >= 0)
        {
            this.wuc_mantto.MostrarEditar = true;
            this.wuc_mantto.MostrarEliminar = true;

            this.nb_IdConcesionario.Text = this.gv_Datos.SelectedDataKey["IdConcesionario"].ToString();
            this.div_grilla_contactos.Style["display"] = "block";
            this.div_Mantenimiento.Style["display"] = "block";

            this.lb_NuevoContacto.Visible = true;
            CargarDatosContactos(Convert.ToInt32(this.nb_IdConcesionario.Text));
        }
    }
    protected void gv_DatosContactos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gv_DatosContactos, "Select$" + e.Row.RowIndex);
            Literal lit_ComentarioContacto = (Literal)e.Row.FindControl("lit_ComentarioContacto");

            string comentarios = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Comentarios"));

            if (comentarios.Length > 0)
                lit_ComentarioContacto.Text = "<span class='help-button' data-rel='popover' data-placement='left' data-trigger='hover' data-content='" + comentarios + "' title='COMENTARIO'><i class='ace-icon fa fa-comment icon-only bigger-120'></i></span>";
            registros_por_pagina = e.Row.RowIndex + 1;
        }
    }
    protected void gv_DatosContactos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv_DatosContactos.PageIndex = e.NewPageIndex;
        this.CargarDatos();
    }
    protected void gv_DatosContactos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.gv_DatosContactos.SelectedIndex >= 0)
        {
            this.lb_EditarContacto.Visible = true;
            this.lb_EliminarContacto.Visible = true;
            this.hf_IdContacto.Value = this.gv_DatosContactos.SelectedDataKey["IdContacto"].ToString();
        }
    }

    #endregion //"GESTION DEL COMPORTAMIENTO DE LA GRID"

    #region "GESTION DEL ACCESO A DATOS"

    //Métodos para cargar lista de selección.
    protected void CargarTiposConcesionarios()
    {
        TiposConcesionarios tiposconcesionarios = new TiposConcesionarios();
        BllTiposConcesionarios blltiposconcesionarios = new BllTiposConcesionarios();

        this.ddl_TiposConcesionarios.DataSource = blltiposconcesionarios.buscar(tiposconcesionarios);
        this.ddl_TiposConcesionarios.DataTextField = "Nombre";
        this.ddl_TiposConcesionarios.DataValueField = "IdTipoConcesionario";
        this.ddl_TiposConcesionarios.DataBind();
        this.ddl_TiposConcesionarios.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));
        this.ddl_TiposConcesionarios.SelectedIndex = 0;
    }
    protected void CargarDatos()
    {
        Concesionarios concesionarios = new Concesionarios();
        concesionarios.IdTipoConcesionario = new TiposConcesionarios();

        if (this.wuc_mantto.Filtro_Criterio.SelectedValue == "Nombre")
        {
            try
            {
                concesionarios.Nombre = Convert.ToString(this.wuc_mantto.Filtro_Valor_TXT);
            }
            catch
            {
                concesionarios.Nombre = null;
            }
        }

        if (this.wuc_mantto.Filtro_Criterio.SelectedValue == "Nit/Dui")
        {
            try
            {
                concesionarios.Nit = Convert.ToString(this.wuc_mantto.Filtro_Valor_TXT);
            }
            catch
            {
                concesionarios.Nit = null;
            }
        }

        List<Concesionarios> lstConcesionarios = bllConcesionarios.buscar(concesionarios).OrderByDescending(x => x.FechaIngreso).ToList();
        this.gv_Datos.DataSource = lstConcesionarios;
        this.gv_Datos.DataBind();

        int cantidad_registros = lstConcesionarios.Count;
        lbl_ContadorRegistros.Text = new Utilidades().ContadorRegistrosGrid(cantidad_registros, registros_por_pagina, gv_Datos);
    }

    // Modificaciones al Metodo CargarRegistro
    protected void CargarRegistro()
    {
        // Instancia y búsqueda del concesionario
        Concesionarios concesionarios = new Concesionarios();
        concesionarios.IdTipoConcesionario = new TiposConcesionarios();

        concesionarios.IdConcesionario = Convert.ToInt32(nb_IdConcesionario.Text);
        concesionarios = bllConcesionarios.buscar(concesionarios)[0];

        // Asignar valores al formulario
        this.txt_Nombre.Text = concesionarios.Nombre;
        this.txt_Abreviatura.Text = concesionarios.Abreviatura;
        this.txt_Nit.Text = concesionarios.Nit; // Mostrar el valor puro desde la base

        try
        {
            this.ddl_TiposConcesionarios.SelectedValue = concesionarios.IdTipoConcesionario.IdTipoConcesionario.ToString();
            // Mostrar/ocultar el div del campo NIT/DUI
            divNitDui.Visible = true;

            // Configurar máscara solo para edición
            if (concesionarios.IdTipoConcesionario.IdTipoConcesionario == 1) // NATURAL (DUI)
            {
                mee_Nit.Mask = "99999999-9";
                rev_Nit.ValidationExpression = @"^\d{8}-\d$";
            }
            else if (concesionarios.IdTipoConcesionario.IdTipoConcesionario == 2) // JURÍDICO (NIT)
            {
                mee_Nit.Mask = "9999-999999-999-9";
                rev_Nit.ValidationExpression = @"^\d{4}-\d{6}-\d{3}-\d$";
            }
            // Poner en firme la aplicacion de la máscara.
            mee_Nit.DataBind();
        }
        catch { }
    }

    protected void CargarRegistroContacto()
    {
        Contactos contactos = new Contactos();
        contactos.IdConcesionario = new Concesionarios();
        contactos.IdTipoContacto = new TiposContactos();

        contactos.IdContacto = Convert.ToInt32(hf_IdContacto.Value);

        contactos = bllContactos.buscar(contactos)[0];

        this.txt_Nombres.Text = contactos.Nombres.ToString();
        this.txt_Apellidos.Text = contactos.Apellidos.ToString();
        this.divNitDui.Visible = true;
        this.txt_NitContacto.Text = contactos.Nit.ToString();
        this.txt_TelefonoOficina.Text = contactos.TelefonoOficina.ToString();
        this.txt_NumeroCelular.Text = contactos.NumeroCelular.ToString();
        this.txt_CorreoElectronico.Text = contactos.CorreoElectronico.ToString();

        try { this.ddl_TiposContactos.SelectedValue = contactos.IdTipoContacto.IdTipoContacto.ToString(); }
        catch { }
        this.txt_Comentarios.Text = contactos.Comentarios.ToString();


    }
    protected void GuardarRegistro()
    {
        Concesionarios concesionarios = new Concesionarios();
        concesionarios.IdTipoConcesionario = new TiposConcesionarios();

        concesionarios.Nombre = Convert.ToString(txt_Nombre.Text.ToUpper());
        concesionarios.Abreviatura = Convert.ToString(txt_Abreviatura.Text.ToUpper());
        concesionarios.Nit = Convert.ToString(txt_Nit.Text);
        concesionarios.IdTipoConcesionario.IdTipoConcesionario = Convert.ToInt32(ddl_TiposConcesionarios.SelectedValue);

        int r;
        if (this.wuc_mantto.Accion == "I")
        {
            concesionarios.UsuarioIngreso = Utilidades.GetUserApp();
            concesionarios.IpEquipoUsuarioIngreso = Utilidades.GetIPAddress();
            r = bllConcesionarios.insertar(concesionarios);
        }
        else
        {
            concesionarios.IdConcesionario = Convert.ToInt32(nb_IdConcesionario.Text);
            concesionarios.UsuarioActualizacion = Utilidades.GetUserApp();
            concesionarios.IpEquipoActualizacion = Utilidades.GetIPAddress();
            r = bllConcesionarios.actualizar(concesionarios);
        }
    }
    protected void GuardarRegistroContacto()
    {

        Contactos contactos = new Contactos();
        contactos.IdConcesionario = new Concesionarios();
        contactos.IdTipoContacto = new TiposContactos();

        contactos.Nombres = Convert.ToString(txt_Nombres.Text.ToUpper());
        contactos.Apellidos = Convert.ToString(txt_Apellidos.Text.ToUpper());
        contactos.Nit = Convert.ToString(txt_NitContacto.Text);
        contactos.TelefonoOficina = Convert.ToString(txt_TelefonoOficina.Text);
        contactos.NumeroCelular = Convert.ToString(txt_NumeroCelular.Text);
        contactos.CorreoElectronico = Convert.ToString(txt_CorreoElectronico.Text);
        contactos.IdTipoContacto.IdTipoContacto = Convert.ToInt32(ddl_TiposContactos.SelectedValue);
        contactos.IdConcesionario.IdConcesionario = Convert.ToInt32(nb_IdConcesionario.Text);
        contactos.Comentarios = Convert.ToString(txt_Comentarios.Text.ToUpper());

        int r;
        if (this.hf_AccionContacto.Value == "I")
        {
            contactos.UsuarioIngreso = Utilidades.GetUserApp();
            contactos.IpEquipoUsuarioIngreso = Utilidades.GetIPAddress();
            r = bllContactos.insertar(contactos);
        }
        else
        {
            contactos.IdContacto = Convert.ToInt32(hf_IdContacto.Value);
            contactos.UsuarioActualizacion = Utilidades.GetUserApp();
            contactos.IpEquipoActualizacion = Utilidades.GetIPAddress();
            r = bllContactos.actualizar(contactos);
        }
    }
    protected void EliminarRegistro()
    {
        Concesionarios concesionarios = new Concesionarios();
        concesionarios.IdTipoConcesionario = new TiposConcesionarios();

        concesionarios.IdConcesionario = Convert.ToInt32(nb_IdConcesionario.Text);
        int r = bllConcesionarios.eliminar(concesionarios);
    }
    protected void EliminarRegistroContacto()
    {
        Contactos contactos = new Contactos();
        contactos.IdConcesionario = new Concesionarios();
        contactos.IdTipoContacto = new TiposContactos();

        contactos.IdContacto = Convert.ToInt32(hf_IdContacto.Value);
        int r = bllContactos.eliminar(contactos);
    }

    //Métodos para cargar la lista de contactos
    protected void CargarTiposContactos()
    {
        TiposContactos tiposcontactos = new TiposContactos();
        BllTiposContactos blltiposcontactos = new BllTiposContactos();

        this.ddl_TiposContactos.DataSource = blltiposcontactos.buscar(tiposcontactos, "Nombre ASC");
        this.ddl_TiposContactos.DataTextField = "Nombre";
        this.ddl_TiposContactos.DataValueField = "IdTipoContacto";
        this.ddl_TiposContactos.DataBind();
        this.ddl_TiposContactos.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));
        this.ddl_TiposContactos.SelectedIndex = 0;
    }

    protected void CargarDatosContactos(int IdConcesionario)
    {
        Contactos contactos = new Contactos();
        contactos.IdTipoContacto = new TiposContactos();
        contactos.IdConcesionario = new Concesionarios();

        contactos.IdConcesionario.IdConcesionario = IdConcesionario;

        List<Contactos> lstContactos = bllContactos.buscar(contactos).ToList();
        this.gv_DatosContactos.DataSource = lstContactos;
        this.gv_DatosContactos.DataBind();
    }
    #endregion //"GESTION DEL ACCESO A DATOS"

} // Fin Clase
