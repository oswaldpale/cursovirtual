using cursosvirtuales.Conection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace cursosvirtuales.Models
{
    public class EstudianteDao
    {
        private ConectionBD _connection = new ConectionBD();

        public DataTable consultarEstudiantes()
        {
            string sql = "SELECT"
                        + "     U.PEGE_ID AS ID,"
                        + "     U.IDENTIFICACION AS IDENT,"
                        + "     U.NOMBRE AS NOMBRE,"
                        + "     U.APELLIDO AS APELLIDO,"
                        + "     U.TIPOUSUARIO"
                        + " FROM"
                        + "     USUARIO U";
            return _connection.getDataMariaDB(sql).Tables[0];
        }

        public DataTable consultarEstudiante(string identificacion)
        {
            string sql = "SELECT"
                        + "     U.PEGE_ID AS ID,"
                        + "     U.IDENTIFICACION AS IDENT,"
                        + "     U.NOMBRE AS NOMBRE,"
                        + "     U.APELLIDO AS APELLIDO,"
                        + "     U.TIPOUSUARIO"
                        + " FROM"
                        + "     USUARIO U";
            return _connection.getDataMariaDB(sql).Tables[0];
        }

        public string validarIdentificacion(string ident)
        {
            string sql = @"SELECT
                                IF(COUNT(*)  > 0, 'TRUE','FALSE') AS VALID
                            FROM
                                estudiante
                            WHERE IDENTIFICACION = '" + ident + "'";
            return _connection.getDataMariaDB(sql).Tables[0].Rows[0]["VALID"].ToString();
        }

        public bool registrarEstudiante(string tipodoc, string identificacion, string nombre, string apellido, string fechanac, string telefono, string direccion, string email,string usuario,string password)
        {
            string sql = @"INSERT
                            INTO
                                ESTUDIANTE
                                (
                                    CODIGO,
                                    TIPODOC,
                                    IDENTIFICACION,
                                    NOMBRE,
                                    APELLIDO,
                                    FECHANACIMIENTO,
                                    TELEFONO,
                                    DIRECCION,
                                    EMAIL,
                                    USUARIO,
                                    CONTRASENA
                                )
                                VALUES
                                (
                                    '" + identificacion + @"',
                                    '" + tipodoc + @"',
                                    '" + identificacion + @"',
                                    '" + nombre + @"',
                                    '" + apellido + @"',
                                    '" + fechanac + @"',
                                    '" + telefono + @"',
                                    '" + direccion + @"',
                                    '" + email + @"',
                                    '" + usuario + @"',
                                    AES_ENCRYPT('" + password + @"','" + Global.key + @"')
                                )";
            return _connection.sendSetDataMariaDB(sql);
        }


    }
}