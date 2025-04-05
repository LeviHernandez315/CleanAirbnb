using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Direccion:Entity
    {
        public string NumCasa { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public int IdCiudad { get; set; }

        public Ciudad? Ciudad { get; set; }


    }


}
