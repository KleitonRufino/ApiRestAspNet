using ApiRestASPNET.Data.Converter;
using ApiRestASPNET.Data.VO;
using ApiRestASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestASPNET.Data.Converters
{
    public class PessoaConverter : IParser<PessoaVO, Pessoa>, IParser<Pessoa, PessoaVO>
    {
        public Pessoa Parse(PessoaVO origin)
        {
            if (origin == null) return new Pessoa();
            return new Pessoa
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
                Enabled = origin.Enabled
            };
        }

        public PessoaVO Parse(Pessoa origin)
        {
            if (origin == null) return new PessoaVO();
            return new PessoaVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
                Enabled = origin.Enabled
            };
        }

        public List<Pessoa> ParseList(List<PessoaVO> origin)
        {
            if (origin == null) return new List<Pessoa>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PessoaVO> ParseList(List<Pessoa> origin)
        {
            if (origin == null) return new List<PessoaVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
