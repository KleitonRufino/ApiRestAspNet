using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestASPNET.Hypermedia
{
    public class Recurso
    {
        public List<LinkDTO> Links { get; set; } = new List<LinkDTO>();
    }
}
