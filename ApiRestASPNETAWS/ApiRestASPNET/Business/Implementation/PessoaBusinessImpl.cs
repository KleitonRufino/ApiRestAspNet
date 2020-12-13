using ApiRestASPNET.Data.Converters;
using ApiRestASPNET.Data.VO;
using ApiRestASPNET.Model;
using ApiRestASPNET.Model.Context;
using ApiRestASPNET.Repository;
using ApiRestASPNET.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestASPNET.Business.Implementation
{
    public class PessoaBusinessImpl : IPessoaBusiness
    {

        private readonly IPessoaRepository _repository;
        private readonly PessoaConverter _converter;

        public PessoaBusinessImpl(IPessoaRepository repository) 
        {
            _converter = new PessoaConverter();
            _repository = repository;
        }
        
        public PessoaVO Create(PessoaVO pessoaVO)
        {
            var personEntity = _converter.Parse(pessoaVO);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PageSearchVO FindAll(String order, int page, int size)
        {
            if (size == 0) size = 3;
            order = string.IsNullOrEmpty(order) || (!string.IsNullOrEmpty(order) && !order.ToUpper().Equals("ASC") && !order.ToUpper().Equals("DESC")) ? "ASC" : order;
                    var result = _converter.ParseList(_repository.FindAll(order, page, size));
            var pageSearch = new PageSearchVO
            {
             page = page,
             ordem = order,
            itensPorPagina = size,
            Pessoas = result
        };
         return pageSearch;
       }

        public PessoaVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<PessoaVO> FindByName(string firstName, string lastName)
        {
               return _converter.ParseList(_repository.FindByName(firstName, lastName));
        }

        public PessoaVO Update(PessoaVO pessoaVO)
        {
            var personEntity = _converter.Parse(pessoaVO);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        // Method responsible for disable a person from an ID
        public PessoaVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }
    }
}
