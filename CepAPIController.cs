using Atividade1Aula2Daniel.DAL;
using Atividade1Aula2Daniel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Atividade1Aula2Daniel.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class CepAPIController : ControllerBase
    {
        private readonly CepDAO _cepDao;



        public CepAPIController(CepDAO cepDao)
        {
            _cepDao = cepDao;
        }

        //Inicio da Implementação dos Métodos

        //GET: /api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult ListarEnderecos()
        {
            return Ok(_cepDao.Listar());
        }

        

    }
}
