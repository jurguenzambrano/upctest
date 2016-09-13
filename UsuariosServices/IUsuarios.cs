using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UsuariosServices.Errores;

namespace UsuariosServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuarios" in both code and config file together.
    [ServiceContract]
    public interface IUsuarios
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Usuario CrearUsuario(Usuario usuarioACrear);
        
        [OperationContract]
        Usuario ObtenerUsuario(string dni);
        
        [OperationContract]
        Usuario ModificarUsuario(Usuario usuarioAModificar);
        
        [OperationContract]
        void EliminarUsuario(string dni);
        
        [OperationContract]
        List<Usuario> ListarUsuarios();
    }
}
