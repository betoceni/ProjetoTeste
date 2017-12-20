using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Models 
{
    public class Lanches : Ingredientes
    {
        public int Codigo_Lanche { get; set; }
        public string Lanche { get; set; }
        public string Conteudo { get; set; }
        public string Valor_Lanche { get; set; }
    }
}