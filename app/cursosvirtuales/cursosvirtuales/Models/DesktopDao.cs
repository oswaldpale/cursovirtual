using cursosvirtuales.Conection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace cursosvirtuales.Models
{
    public class DesktopDao
    {
        ConectionBD _conection = new ConectionBD();

        public DataTable logon(string usuario,string contrasena)
        {
            string sql = @"SELECT
                                r.ROLID
                            FROM
                                curso_menu.rol r
                            INNER JOIN curso_menu.usuario_rol ur
                            ON
                                r.ROLID = ur.ROLID
                            INNER JOIN curso_menu.usuario u
                            ON
                                ur.USUARIOID = u.CODIGO
                            WHERE
                                u.usuario = '" + usuario + @"'
                            AND u.CONTRASENA = AES_ENCRYPT('" + contrasena + "', '" + Global.key + @"')";

            return _conection.getDataMariaDB(sql).Tables[0]; ;
        }
        public DataTable login(string usuario,string contrasena)
        {
            string sql = @"SELECT
                                us.CODIGO,
                                us.USUARIO
                            FROM
                                curso_menu.usuario us
                            WHERE
                                us.USUARIO = '" + usuario + @"'
                            AND us.CONTRASENA = AES_ENCRYPT('" + contrasena + @"', '" + Global.key + "')";

            return _conection.getDataMariaDB(sql).Tables[0]; ;
        }

        public DataTable MenuForm(int codigomenu)
        {
            string sql = @"SELECT DISTINCT
                                m.IDMENU,
                                m.NOMBRE,
                                m.URL
                            FROM
                                curso_menu.rol_submenu rs
                            INNER JOIN curso_menu.submenu sm
                            ON
                                sm.SUBMENUID = rs.SUBMENUID
                            INNER JOIN curso_menu.menu m
                            ON
                                sm.MENUID = m.IDMENU
                            WHERE
                                rs.ROLID = '" + codigomenu + @"'
                            ORDER BY
                                nombre";

            return _conection.getDataMariaDB(sql).Tables[0]; ; 
        }
        public DataTable SubMenuForm(int menu, int rol)
        {

            string sql = @"SELECT
                                sm.SUBMENUID,
                                sm.ANCHO,
                                sm.ALTO,
                                sm.NOMBRE,
                                sm.URL
                            FROM
                                curso_menu.rol_submenu rs
                            INNER JOIN curso_menu.submenu sm
                            ON
                                sm.SUBMENUID = rs.SUBMENUID
                            INNER JOIN curso_menu.menu m
                            ON
                                sm.MENUID = m.IDMENU
                            WHERE
                                m.IDMENU = '" + menu + @"'
                            AND rs.ROLID = '" + rol  + @"'
                            ORDER BY
                                sm.NOMBRE";

            return _conection.getDataMariaDB(sql).Tables[0];
        }
    }
}