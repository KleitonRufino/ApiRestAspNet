using ApiRestASPNET.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestASPNET.Business
{
    public interface IPessoaBusiness
    {
        PessoaVO Create(PessoaVO pessoaVO);
        PessoaVO FindById(long id);
        public PageSearchVO FindAll(String order, int page, int size);
        List<PessoaVO> FindByName(string fisrtName, string lastName);
        PessoaVO Update(PessoaVO person);
        void Delete(long id);
        public PessoaVO Disable(long id);

        //PagedSearchDTO<PessoaVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
