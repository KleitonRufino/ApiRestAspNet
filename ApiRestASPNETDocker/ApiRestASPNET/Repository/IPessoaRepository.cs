using ApiRestASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestASPNET.Repository
{
    public interface IPessoaRepository
    {
        Pessoa Create(Pessoa pessoa);
        Pessoa FindById(long id);
        public List<Pessoa> FindAll(String order, int page, int size);
        Pessoa Update(Pessoa pessoa);
        void Delete(long id);
        bool Exists(long id);
        Pessoa Disable(long id);
        List<Pessoa> FindByName(string fristName, string lastName);
    }
}
