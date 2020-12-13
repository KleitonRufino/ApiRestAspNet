using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestASPNET.Data.VO
{
    public class PageSearchVO
    {
        public int page { get; set; }

        public String ordem { get; set; }
        public int itensPorPagina { get; set; }
        public List<PessoaVO> Pessoas { get; set; }
    }
}
