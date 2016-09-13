using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace UsuariosServices
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public string Dni { get; set; }

        [DataMember]
        public string Apellidos { get; set; }

        [DataMember]
        public string Nombres { get; set; }

        [DataMember]
        public DateTime FechaEmision { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public string Celular { get; set; }

        [DataMember]
        public string Mail { get; set; }

    }
}