using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using System.Collections.Generic;

namespace UsuariosServicesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCrearUsuario()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            UsuariosWS.Usuario usuarioCreado = proxy.CrearUsuario(new UsuariosWS.Usuario()
            {
                Dni = "99999999",
                Apellidos = "DE LOS PALOTES",
                Nombres = "PERICO",
                FechaEmision = Convert.ToDateTime("01/01/2000"),
                Direccion = "CALLE",
                Celular = "99999999",
                Mail = "perico@gmail.com"
            });

            Assert.AreEqual("99999999",usuarioCreado.Dni);
            Assert.AreEqual("PERICO", usuarioCreado.Nombres);
            Assert.AreEqual("DE LOS PALOTES", usuarioCreado.Apellidos);
        }

        [TestMethod]
        public void TestUsuarioRepetido()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            try { 
            UsuariosWS.Usuario usuarioCreado = proxy.CrearUsuario(new UsuariosWS.Usuario()
            {
                Dni = "99999999",
                Apellidos = "DE LOS PALOTES",
                Nombres = "PERICO",
                FechaEmision = Convert.ToDateTime("01/01/2000"),
                Direccion = "CALLE",
                Celular = "99999999",
                Mail = "perico@gmail.com"
            });
                }
            catch(FaultException<UsuariosWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar crear usuario", error.Reason.ToString());
                Assert.AreEqual("101", error.Detail.Codigo);
                Assert.AreEqual("Usuario Registrado", error.Detail.Descripcion);
            }
                        
        }

        [TestMethod]
        public void TestModificarUsuario()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            UsuariosWS.Usuario usuarioModificado = proxy.ModificarUsuario(new UsuariosWS.Usuario()
            {
                Dni = "99999999",
                Apellidos = "DE LOS PALOTES",
                Nombres = "PERICOSs",
                FechaEmision = Convert.ToDateTime("01/01/2000"),
                Direccion = "CALLE",
                Celular = "99999999",
                Mail = "perico@gmail.com"
            });
            Assert.AreEqual("PERICOSs", usuarioModificado.Nombres);
        }

        [TestMethod]
        public void TestEliminarUsuario()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            try
            {
                proxy.EliminarUsuario("99999999");
            }
            catch (FaultException<UsuariosWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al eliminar usuario", error.Reason.ToString());
                Assert.AreEqual("102", error.Detail.Codigo);
                Assert.AreEqual("Usuario No existe", error.Detail.Descripcion);
            }

        }

        [TestMethod]
        public void TestListarUsuarios()
        {
            UsuariosWS.UsuariosClient proxy = new UsuariosWS.UsuariosClient();
            UsuariosWS.Usuario[] usuarios = proxy.ListarUsuarios();
            Assert.AreEqual(usuarios.Length, 1);
        }
    }
}
