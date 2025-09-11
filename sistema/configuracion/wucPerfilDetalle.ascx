<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucPerfilDetalle.ascx.cs" Inherits="sistema_configuracion_wucPerfilDetalle" %>

<%@ Reference Control="~/master_ajax.master" %>

<asp:HiddenField ID="hfd_IdPerfil" runat="server" />


<style type="text/css">
    /*.act { background-color: #F5F5F5; color: #000000; }
    .sel { background-color: #428BCA; color: #ffffff; }
    .ins { background-color: #6FB3E0; color: #ffffff; }
    .edi { background-color: #FFB752; color: #ffffff; }
    .eli { background-color: #D15B47; color: #ffffff; }
    .imp { background-color: #87B87F; color: #ffffff; }*/

    .act { background-color: #ffffff; color: #000000; }
    .sel { background-color: #ffffff; color: #428BCA; }
    .ins { background-color: #ffffff; color: #6FB3E0; }
    .edi { background-color: #ffffff; color: #FFB752; }
    .eli { background-color: #ffffff; color: #D15B47; }
    .imp { background-color: #ffffff; color: #87B87F; }
    .btn-todo { width: 100% !important; text-align: left !important; margin-bottom: 2px !important; }
    #ctl00_cphContenido_wucPerfilDetalle_gv_Menu tr:hover { background-color: black !important;}
</style>

<div class="widget-box widget-color-blue">
    <div class="widget-header">
        <h5 class="widget-title">Opciones del menú</h5>
    </div>
    <div class="widget-body">

        <div class="widget-main">
            <div id="menu" class="row">
                
                <div class="col-xs-8 col-xs-offset-2">
                    <div>
                        <%--<asp:TreeView ID="tvw_Datos" runat="server" ShowLines="true" 
                            ShowCheckBoxes="All" OnSelectedNodeChanged="tvw_Datos_SelectedNodeChanged">
                            <SelectedNodeStyle BackColor="#C3D9FF" />
                            <RootNodeStyle Font-Bold="True" />
                        </asp:TreeView>--%>

                        <asp:GridView ID="gv_Menu" runat="server" SkinID="skin_grilla_sin_paginacion" DataKeyNames="Id_Menu" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="Sangria" HeaderText="Formulario" HeaderStyle-HorizontalAlign="Center" HtmlEncode="false" />

                                

                                <asp:TemplateField HeaderText="<div title='Activar todos los formularios'><input id='cbxAct' type='checkbox' /><label for='cbxAct'>&nbsp;<i class='glyphicon glyphicon-ok-sign'></i></label></div>" >
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="act" />
                                    <ItemTemplate>
                                        <div class='id_<%# Eval("Id_Menu") %>'>
                                            <asp:CheckBox ID="cbxAct" runat="server" Checked='<%# Eval("Activo") %>' Text="&nbsp;<i class='glyphicon glyphicon-ok-sign'></i>" ToolTip="Formulario" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<div title='Activar la selección para todos los formularios'><input id='cbxSel' type='checkbox' /><label for='cbxSel'>&nbsp;<i class='glyphicon glyphicon-search'></i></label></div>" >
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="sel" />
                                    <ItemTemplate>
                                        <div class='id_<%# Eval("Id_Menu") %>'>
                                            <asp:CheckBox ID="cbxSel" runat="server" Checked='<%# Eval("Seleccionar") %>' Text="&nbsp;<i class='glyphicon glyphicon-search'></i>" ToolTip="Seleccionar" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<div title='Activar la inserción para todos los formularios'><input id='cbxIns' type='checkbox' /><label for='cbxIns'>&nbsp;<i class='glyphicon glyphicon-plus-sign'></i></label></div>" >
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="ins" />
                                    <ItemTemplate>
                                        <div class='id_<%# Eval("Id_Menu") %>'>
                                            <asp:CheckBox ID="cbxIns" runat="server" Checked='<%# Eval("Insertar") %>' Text="&nbsp;<i class='glyphicon glyphicon-plus-sign'></i>" ToolTip="Insertar" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<div title='Activar la edición para todos los formularios'><input id='cbxEdi' type='checkbox' /><label for='cbxEdi'>&nbsp;<i class='glyphicon glyphicon-edit'></i></label></div>" >
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="edi" />
                                    <ItemTemplate>
                                        <div class='id_<%# Eval("Id_Menu") %>'>
                                            <asp:CheckBox ID="cbxEdi" runat="server" Checked='<%# Eval("Actualizar") %>' Text="&nbsp;<i class='glyphicon glyphicon-edit'></i>" ToolTip="Actualizar" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<div title='Activar la eliminación para todos los formularios'><input id='cbxEli' type='checkbox' /><label for='cbxEli'>&nbsp;<i class='glyphicon glyphicon-remove'></i></label></div>" >
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="eli" />
                                    <ItemTemplate>
                                        <div class='id_<%# Eval("Id_Menu") %>'>
                                            <asp:CheckBox ID="cbxEli" runat="server" Checked='<%# Eval("Eliminar") %>' Text="&nbsp;<i class='glyphicon glyphicon-remove'></i>" ToolTip="Eliminar" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<div title='Activar la impresión para todos los formularios'><input id='cbxImp' type='checkbox' /><label for='cbxImp'>&nbsp;<i class='glyphicon glyphicon-print'></i></label></div>" >
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="imp" />
                                    <ItemTemplate>
                                        <div class='id_<%# Eval("Id_Menu") %>'>
                                            <asp:CheckBox ID="cbxImp" runat="server" Checked='<%# Eval("Imprimir") %>' Text="&nbsp;<i class='glyphicon glyphicon-print'></i>" ToolTip="Imprimir" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="<div title='Activar la todos los permisos para todos los formularios'><input id='cbxTod' type='checkbox' /><label for='cbxTod'>&nbsp;<i class='glyphicon glyphicon-list'></i></label></div>" >
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" CssClass='tod' />
                                    <ItemTemplate>
                                        <div class='id_<%# Eval("Id_Menu") %>'>
                                            <asp:CheckBox ID="cbxTod" runat="server" Text="&nbsp;<i class='glyphicon glyphicon-list'></i>" ToolTip="Seleccionar toda la fila" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <%--<asp:CheckBoxField DataField="Activo"       HeaderText="ACT" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center" />
                                <asp:CheckBoxField DataField="Seleccionar"  HeaderText="SEL" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center" />
                                <asp:CheckBoxField DataField="Insertar"     HeaderText="INS" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center" />
                                <asp:CheckBoxField DataField="Actualizar"   HeaderText="ACT" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center" />
                                <asp:CheckBoxField DataField="Eliminar"     HeaderText="ELI" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center" />
                                <asp:CheckBoxField DataField="Imprimir"     HeaderText="IMP" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center" />--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <div class="col-xs-2">
                    
                    <%--<h5>Aplicar a todos</h5>
                    <div class="btn-group">
                        <span class="btn btn-todo btn-xs btn-default">   <input type="checkbox" id="cbxAct" /><label for="cbxAct">&nbsp;<i class="glyphicon glyphicon-ok-sign"></i>  Activo</label></span>
                        <span class="btn btn-todo btn-xs btn-primary">   <input type="checkbox" id="cbxSel" /><label for="cbxSel">&nbsp;<i class="glyphicon glyphicon-search"></i>   Seleccionar</label></span>
                        <span class="btn btn-todo btn-xs btn-info">      <input type="checkbox" id="cbxIns" /><label for="cbxIns">&nbsp;<i class="glyphicon glyphicon-plus-sign"></i> Insertar</label></span>
                        <span class="btn btn-todo btn-xs btn-warning">   <input type="checkbox" id="cbxEdi" /><label for="cbxEdi">&nbsp;<i class="glyphicon glyphicon-edit"></i>     Editar</label></span>
                        <span class="btn btn-todo btn-xs btn-danger">    <input type="checkbox" id="cbxEli" /><label for="cbxEli">&nbsp;<i class="glyphicon glyphicon-remove"></i>   Eliminar</label></span>
                        <span class="btn btn-todo btn-xs btn-success">   <input type="checkbox" id="cbxImp" /><label for="cbxImp">&nbsp;<i class="glyphicon glyphicon-print"></i>    Imprimir</label></span>
                    </div>--%>
                    

                </div>
            </div>

        </div>
    </div>
</div>
