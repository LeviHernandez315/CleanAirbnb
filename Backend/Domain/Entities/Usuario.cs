using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Usuario:Entity
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Dni { get; set; }
        public int RolId { get; set; }
        public Persona? Persona { get; set; }
        public Rol? Rol { get; set; }

        //public Usuario(string? email, string? password, string? dni, int rolId)
        //{
        //    Email = email;
        //    Password = password;
        //    Dni = dni;
        //    RolId = rolId;
        //}
    }
}
