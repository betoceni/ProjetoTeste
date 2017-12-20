using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Models
{
    public class Ingredientes
    {
        public int Codigo_Ingrediente { get; set; }
        public string Ingrediente { get; set; }
        public string Valor_Ingrediente { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Somente valores positivos")]
        public int Qtde_Ingrediente { get; set; }
    }
}