using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Models
{
    public class VendaProdutoViewModel
    {
        public int CodigoVenda { get; set; }
        public int CodigoProduto { get; set; }
        public double Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public string NomeProduto { get; set; }
    }
}
