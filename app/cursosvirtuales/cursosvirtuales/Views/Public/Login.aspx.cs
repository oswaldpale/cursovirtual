using cursosvirtuales.Controllers;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cursosvirtuales.Views.Public
{
    public partial class Login : System.Web.UI.Page
    {
        Controller _controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [DirectMethod(ShowMask = true, Msg = "Verificando ...", Target = MaskTarget.Page)]
        public void ingresarUsuario(string usuario, string contrasena)
        {

            DataTable dt = _controller.login(usuario, contrasena);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][1].ToString() == usuario)
                {
                    DataTable drol = _controller.logon(usuario, contrasena);
                    Session["Usuario"] = usuario;
                    Session["id"] = dt.Rows[0][0].ToString();
                    Session["Rol"] = drol.Rows[0][0].ToString();
                    Session.Timeout = 5;
                    Response.Redirect("../Private/Escritorio.aspx");
                    return;
                }
            }
            X.AddScript("Ext.Msg.info({ui: 'danger', title: 'Notificación', html: 'Usuario o Contraseña incorrecta', iconCls: '#Exclamation'});");
        }
    }
}