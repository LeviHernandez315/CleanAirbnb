﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entidades.TipoVehiculoDTOs
{
    public class TipoVehiculoResponseDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
