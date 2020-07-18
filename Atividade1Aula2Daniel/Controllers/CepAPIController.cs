using Atividade1Aula2Daniel.DAL;
using Atividade1Aula2Daniel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


//Daniel Hideki Yoshioka - Matricula 1814976
//Atividade 1 - Exercício 01 – Aula presencial 02


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

        
        //GET: /api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult ListarEnderecos()
        {
            return Ok(_cepDao.Listar());
        }

        //GET:/api/Endereco/ListarEndereco/81730000
        [HttpGet("/api/Endereco/ListarEndereco/{CEP}")]
        [Route("ListarEndereco")]
        public string ListarEndereco(string CEP)
        {
            return _cepDao.ListarCep(CEP);
        }


        //POST:/api/Endereco/CadastrarEndereco
        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult CadastrarEndereco(Cep cep)
        {
            _cepDao.Cadastrar(cep);
            return Created("ListarEnderecos", cep);
        }

        //PUT:/api/Endereco/AlterarEndereco
        [HttpPut]
        [Route("AlterarEndereco")]
        public IActionResult AlterarEndereco(Cep cep)
        {
            _cepDao.Alterar(cep);
            return Created("ListarEnderecos", cep);
        }

        //DELETE:/api/Endereco/DeletarEndereco/2
        [HttpDelete("/api/Endereco/DeletarEndereco/{id}")]
        [Route("DeletarEndereco")]
        public async Task<IActionResult> DeletarEndereco(int id)
        {
            await _cepDao.DeletarAsync(id);
            return Ok();
        }


    }
}
