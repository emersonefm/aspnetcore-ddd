using Aplicacao.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class VendaViewModel
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Informe a Data da Venda")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Data { get; set; }

        [Required(ErrorMessage = "Informe o Cliente")]
        public int? CodigoCliente { get; set; }

        [Required(ErrorMessage = "Informe o Valor Unitário do Produto")]
        public decimal Total { get; set; }

        public IEnumerable<SelectListItem> ListaClientes { get; set; }
        public IEnumerable<SelectListItem> ListaProdutos { get; set; }

        public string JsonProdutos { get; set; }
        public ICollection<VendaProdutoViewModel> Produtos { get; set; }

        public string NomeCliente { get; set; }
    }
}
