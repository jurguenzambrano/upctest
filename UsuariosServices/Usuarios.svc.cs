using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UsuariosServices.Persistencia;
using UsuariosServices.Errores;

namespace UsuariosServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuarios" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Usuarios.svc or Usuarios.svc.cs at the Solution Explorer and start debugging.
    public class Usuarios : IUsuarios
    {
        private UsuarioDAO usuarioDAO = new UsuarioDAO();

        public Usuario CrearUsuario(Usuario usuarioACrear)
        {
            if (usuarioDAO.Obtener(usuarioACrear.Dni) != null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "Usuario Registrado"
                }, new FaultReason("Error al intentar crear usuario")
                );
            }

            return usuarioDAO.Crear(usuarioACrear);
        }

        public Usuario ObtenerUsuario(string dni)
        {
            return usuarioDAO.Obtener(dni);
        }

        public Usuario ModificarUsuario(Usuario usuarioAModificar)
        {
            return usuarioDAO.Modificar(usuarioAModificar);
        }

        public void EliminarUsuario(string dni)
        {
            if (usuarioDAO.Obtener(dni) == null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "102",
                        Descripcion = "Usuario No existe"
                    }, new FaultReason("Error al eliminar usuario")
                );
            }
            else
            {
                usuarioDAO.Eliminar(dni);
            }

            
            /*
            if (usuarioDAO.Obtener(dni) != null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "103",
                        Descripcion = "Error al eliminar usuario"
                    }, new FaultReason("Error al obtener usuario")
                );
            }
            */
        }

        public List<Usuario> ListarUsuarios()
        {
            return usuarioDAO.Listar();
        }
    }
}
