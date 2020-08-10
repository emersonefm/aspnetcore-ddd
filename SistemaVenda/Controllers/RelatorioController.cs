using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Servico.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers
{
    public class RelatorioController : Controller
    {
        readonly IServicoAplicacaoVenda _servicoServicoAplicacaoVenda;
        public RelatorioController(IServicoAplicacaoVenda servicoServicoAplicacaoVenda)
        {
            _servicoServicoAplicacaoVenda = servicoServicoAplicacaoVenda;
        }

        public IActionResult Grafico()
        {
            var lista = _servicoServicoAplicacaoVenda.ListaGrafico().ToList();

            string valores = string.Empty;
            string labels = string.Empty;
            string cores = string.Empty;

            var random = new Random();
            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].TotalVendido.ToString() + ","; 
                labels += "'" + lista[i].Descricao.ToString() + "',"; 
                cores += "'" + string.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }

            ViewBag.Valores = valores;
            ViewBag.Cores = cores;
            ViewBag.Labels = labels;
            return View();
        }
    }
}