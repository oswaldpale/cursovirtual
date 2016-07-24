using cursosvirtuales.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace cursosvirtuales.Controllers
{
    public class Controller
    {
        private EstudianteDao _estudiante = new EstudianteDao();
        private DesktopDao _manejador = new DesktopDao();

        #region GESTIONAR ESCRITORIO DINAMICO
        public DataTable logon(string usuario,string contrasena)
        {
            return _manejador.logon(usuario,contrasena);
        }

        public DataTable login(string usuario,string contrasena)
        {
            return _manejador.login(usuario, contrasena);
        }

        public DataTable MenuForm(int x)
        {

            return _manejador.MenuForm(x);
        }
        public DataTable SubMenuForm(int menu, int rol)
        {
            return _manejador.SubMenuForm(menu, rol);
        }
        #endregion

        #region GESTION DE ESTUDIANTE
        public DataTable consultarParticulares()
        {
            return null;
        }
        public bool registrarEstudiante(string tipodoc, string identificacion, string nombre, string apellido, string fechanac, string telefono, string direccion, string email,string usuario,string contrasena) {
            return _estudiante.registrarEstudiante(tipodoc,identificacion,nombre,apellido,fechanac,telefono,direccion,email,usuario, contrasena);
        }

        public string validarIdentificacion(string ident)
        {
            return _estudiante.validarIdentificacion(ident);
        }
        #endregion
    }
}