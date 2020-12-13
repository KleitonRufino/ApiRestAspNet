
using ApiRestASPNET.Hypermedia;

namespace ApiRestASPNET.Data.VO
{
    public class PessoaVO : Recurso
    {

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool Enabled { get; set; }
    }
}
