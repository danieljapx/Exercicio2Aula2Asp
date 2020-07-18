using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atividade1Aula2Daniel.Models;
using Newtonsoft.Json;
using Atividade1Aula2Daniel.DAL;


//Daniel Hideki Yoshioka - Matricula 1814976
//Atividade 1 - Exercício 01 – Aula presencial 02

namespace Atividade1Aula2Daniel.Controllers
{
    public class CepController : Controller
    {
        private readonly CepDAO _cepDao;

        public CepController(CepDAO cepDao)
        {
            _cepDao = cepDao;
        }

        public IActionResult Index()
        {
            if (TempData["CEP"] != null)
            {
                //Newtonsoft.Json
                string resultado = TempData["CEP"].ToString();
                Cep cep = JsonConvert.DeserializeObject<Cep>(resultado);

                _cepDao.Cadastrar(cep);

            }

            return View(_cepDao.Listar());
        }


        [HttpPost]
        public IActionResult CadastrarCEP(string txtCep)
        {
            string url = $@"http://viacep.com.br/ws/{txtCep}/json";

            WebClient cliente = new WebClient();
            TempData["CEP"] = cliente.DownloadString(url);

            return RedirectToAction("Index");
        }

    }
}
