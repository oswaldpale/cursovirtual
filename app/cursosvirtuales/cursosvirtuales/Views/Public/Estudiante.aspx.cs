using cursosvirtuales.Controllers;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cursosvirtuales.Views.Public
{
    public partial class Estudiante : System.Web.UI.Page
    {
        Controller _controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [DirectMethod]
        public void registrarEstudiante(string fechan)
        {

            string ident = TIDENTIFICACION.Text;
            string tipodoc = CTIPDOC.SelectedItem.Value;
            string nombres = TNOMBRE.Text.Trim();
            string apellidos = TAPELLIDO.Text.Trim();
            var fecha = this.DFECHA.RawText;
            string fechanac = Convert.ToDateTime(fechan).ToString("yyyy-MM-dd");
            string telefono = TTELEFONO.Text;
            string direccion = TDIRECCION.Text.ToUpper().Trim();
            string correo = TCORREO.Text.Trim();
            string usuario = TUSUARIO.Text;
            string contrasena = TCONTRASENA.Text;

            if (_controller.registrarEstudiante(tipodoc, ident, nombres, apellidos, fechanac, telefono, direccion, correo,usuario,contrasena))
            {
                X.Msg.Notify("Notificación", "Guardado exitosamente!").Show();

            }
            else
            {
                X.Msg.Notify("Notificación", "Ha ocurrido un error..").Show();
            }
        }

        [DirectMethod]
        public object validarIdent(string value)
        {
            string data = _controller.validarIdentificacion(value);
            if (data.Equals("FALSE"))
            {
                return true;
            }
            else
            {
                return "'Valid' is valid value only";
            }
        }

    }
}