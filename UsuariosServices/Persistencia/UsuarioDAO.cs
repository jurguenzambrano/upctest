using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UsuariosServices.Persistencia
{
    public class UsuarioDAO
    {
        //private string cadenaConexion = "Data Source=(local); Initial Catalog = Money; Integrated Security = SSPI;";
        private string cadenaConexion = "Server=84f2f108-f1ef-481c-a84a-a67f016e94e3.sqlserver.sequelizer.com;Database=db84f2f108f1ef481ca84aa67f016e94e3;User ID=opjckhddqfloqdsl;Password=qJPpHN35stUAP4gNNhN6oZ8q5VFKSx3bj8Ue8ND4RzUfDQzSgU2DBUnyJysUhqk3;";


        public Usuario Crear(Usuario usuarioACrear)
        {
            Usuario usuarioCreado = null;
            string sql = "INSERT INTO TB_USUARIO VALUES (@Dni, @Apellidos, @Nombres, @FechaEmision, @Direccion, @Celular, @Mail)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Dni", usuarioACrear.Dni));
                    comando.Parameters.Add(new SqlParameter("@Apellidos", usuarioACrear.Apellidos));
                    comando.Parameters.Add(new SqlParameter("@Nombres", usuarioACrear.Nombres));
                    comando.Parameters.Add(new SqlParameter("@FechaEmision", usuarioACrear.FechaEmision));
                    comando.Parameters.Add(new SqlParameter("@Direccion", usuarioACrear.Direccion));
                    comando.Parameters.Add(new SqlParameter("@Celular", usuarioACrear.Celular));
                    comando.Parameters.Add(new SqlParameter("@Mail", usuarioACrear.Mail));
                    comando.ExecuteNonQuery();
                }
            }
            usuarioCreado = Obtener(usuarioACrear.Dni);
            return usuarioCreado;
        }

        public Usuario Obtener(string dni)
        {
            Usuario usuarioEncontrado = null;
            string sql = "SELECT * FROM TB_USUARIO WHERE DNI = @Dni";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Dni", dni));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            usuarioEncontrado = new Usuario(){
                                Dni = (string) resultado["dni"],
                                Apellidos = (string) resultado["apellidos"],
                                Nombres = (string) resultado["Nombres"],
                                FechaEmision = (DateTime) resultado["FechaEmision"],
                                Direccion = (string) resultado["Direccion"],
                                Celular = (string) resultado["Celular"],
                                Mail = (string) resultado["Mail"]
                            };

                        }
                    }
                }
            }

            return usuarioEncontrado;
        }
        public Usuario Modificar(Usuario usuarioAModificar)
        {
            Usuario usuarioModificado = null;
            string sql = "UPDATE TB_USUARIO set Apellidos = @Apellidos, Nombres = @Nombres, FechaEmision = @FechaEmision, Direccion = @Direccion, Celular = @Celular, Mail = @Mail WHERE dni = @Dni";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Dni", usuarioAModificar.Dni));
                    comando.Parameters.Add(new SqlParameter("@Apellidos", usuarioAModificar.Apellidos));
                    comando.Parameters.Add(new SqlParameter("@Nombres", usuarioAModificar.Nombres));
                    comando.Parameters.Add(new SqlParameter("@FechaEmision", usuarioAModificar.FechaEmision));
                    comando.Parameters.Add(new SqlParameter("@Direccion", usuarioAModificar.Direccion));
                    comando.Parameters.Add(new SqlParameter("@Celular", usuarioAModificar.Celular));
                    comando.Parameters.Add(new SqlParameter("@Mail", usuarioAModificar.Mail));
                    comando.ExecuteNonQuery();
                }
            }
            usuarioModificado = Obtener(usuarioAModificar.Dni);
            return usuarioModificado;
        }
        public void Eliminar(string dni)
        {
            string sql = "DELETE TB_USUARIO WHERE DNI = @Dni";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Dni", dni));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Usuario> Listar()
        {
            List<Usuario> usuariosEncontrados = new List<Usuario>();
            Usuario usuarioEncontrado = null;
            string sql = "SELECT * FROM TB_USUARIO";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            usuarioEncontrado = new Usuario()
                            {
                                Dni = (string)resultado["dni"],
                                Apellidos = (string)resultado["dni"],
                                Nombres = (string)resultado["Nombres"],
                                FechaEmision = (DateTime)resultado["FechaEmision"],
                                Direccion = (string)resultado["Direccion"],
                                Celular = (string)resultado["Celular"],
                                Mail = (string)resultado["Mail"]
                            };
                            usuariosEncontrados.Add(usuarioEncontrado);
                        }
                    }
                }
            }
            return usuariosEncontrados;
        }
    }
}