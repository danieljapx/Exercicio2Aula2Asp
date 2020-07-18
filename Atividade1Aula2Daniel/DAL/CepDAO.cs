using Atividade1Aula2Daniel.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Daniel Hideki Yoshioka - Matricula 1814976
//Atividade 1 - Exercício 01 – Aula presencial 02

namespace Atividade1Aula2Daniel.DAL
{
    public class CepDAO
    {
        private readonly Context _context;

        public CepDAO(Context context)
        {
            _context = context;
        }

        public void Cadastrar(Cep cep)
        {
            _context.Cep.Add(cep);
            _context.SaveChanges();
        }

        public List<Cep> Listar()
        {
            return _context.Cep.ToList();
        }


        public string ListarCep(string CEP)
        {


            CEP = CEP.Replace("-", "");
            CEP = CEP.Insert(5, "-");

            var c = JsonConvert.SerializeObject(_context.Cep.Where(x => x.CEP == CEP));

            return c;


        }


        public void Alterar(Cep cep)
        {
            _context.Cep.Update(cep);
            _context.SaveChanges();
        }

        public async Task DeletarAsync(int id)
        {
            var cep = await _context.Cep.FindAsync(id);
            _context.Cep.Remove(cep);
            await _context.SaveChangesAsync();

        }

    }
}
