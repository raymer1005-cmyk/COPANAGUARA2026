using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamNaGuara.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Representative { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Category { get; set; }

        public string? LogoPath { get; set; }

        // Inicializar con un valor por defecto válido
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Lista de jugadores inicializada correctamente
        public List<Player> Players { get; set; } = new();
    }
}
