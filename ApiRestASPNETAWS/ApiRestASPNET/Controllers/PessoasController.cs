using ApiRestASPNET.Business;
using ApiRestASPNET.Business.Implementation;
using ApiRestASPNET.Data.VO;
using ApiRestASPNET.Hypermedia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PessoasController : Controller
    {
        private readonly ILogger<PessoasController> _logger;

        // Declaration of the service used
        private IPessoaBusiness _business;
        private readonly IUrlHelper _urlHelper;

        // Injection of an instance of IPersonService
        // when creating an instance of PersonController
        public PessoasController(ILogger<PessoasController> logger, IPessoaBusiness business, IUrlHelper urlHelper)
        {
            _logger = logger;
            _business = business;
            _urlHelper = urlHelper;
        }


        private void GerarLinks(PessoaVO pessoa)
        {
            pessoa.Links.Add(new LinkDTO(_urlHelper.Link(nameof(GetPessoa), new { id = pessoa.Id }), rel: "self", metodo: "GET"));
            pessoa.Links.Add(new LinkDTO(_urlHelper.Link(nameof(PostPessoa), new { }), rel: "create-pessoa", metodo: "POST"));
            pessoa.Links.Add(new LinkDTO(_urlHelper.Link(nameof(PutPessoa), new { }), rel: "update-pessoa", metodo: "PUT"));
            pessoa.Links.Add(new LinkDTO(_urlHelper.Link(nameof(DeletePessoa), new { id = pessoa.Id }), rel: "delete-pessoa", metodo: "DELETE"));
        }

        // Maps GET requests to https://localhost:{port}/api/person
        // Get no parameters for FindAll -> Search All
        [HttpGet(Name = nameof(GetAll))]
        [ProducesResponseType((200), Type = typeof(List<PessoaVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetAll([FromQuery]string ordem, [FromQuery] int page, [FromQuery] int size)
        {
            var result = _business.FindAll(ordem, page, size);
            if (result != null && result.Pessoas != null) result.Pessoas.ForEach(p => GerarLinks(p));
            //var resultado = new ColecaoRecursos<PessoaVO>(result.Pessoas);
            //resultado.Links.Add(new LinkDTO(_urlHelper.Link(nameof(GetAll), new { }), rel: "self", metodo: "GET"));
            //resultado.Links.Add(new LinkDTO(_urlHelper.Link(nameof(PostPessoa), new { }), rel: "create-pessoa", metodo: "POST"));
            //resultado.Links.Add(new LinkDTO(_urlHelper.Link(nameof(PutPessoa), new { }), rel: "update-pessoa", metodo: "PUT"));
            //resultado.Links.Add(new LinkDTO(_urlHelper.Link(nameof(GetAll), new {}), rel: "delete-pessoa", metodo: "DELETE"));

            return Ok(result);
        }

        // Maps GET requests to https://localhost:{port}/api/person/{id}
        // receiving an ID as in the Request Path
        // Get with parameters for FindById -> Search by ID
        [HttpGet("{id}", Name = nameof(GetPessoa))]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetPessoa(long id)
        {
            var pessoaVO = _business.FindById(id);
            if (pessoaVO == null) return NotFound();
            GerarLinks(pessoaVO);
            return Ok(pessoaVO);
        }

        [HttpGet("findByName" ,Name = nameof(GetPessoaByName))]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetPessoaByName([FromQuery]String firstname,[FromQuery] string lastname)
        {
            var result = _business.FindByName(firstname, lastname);
            if (result == null || (result!=null && result.Count == 0)) return NotFound();
            result.ForEach(r => GerarLinks(r));
            return Ok(result);
        }


        // Maps POST requests to https://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object sent in the request body
        [HttpPost(Name = nameof(PostPessoa))]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult PostPessoa([FromBody] PessoaVO pessoaVO)
        {
            if (pessoaVO == null) return BadRequest();
            var result =  _business.Create(pessoaVO);
            if (result == null) return BadRequest();
            GerarLinks(result);
            return Ok(result);
        }

        // Maps PUT requests to https://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object sent in the request body
        [HttpPut(Name = nameof(PutPessoa))]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult PutPessoa([FromBody] PessoaVO pessoaVO)
        {
            if (pessoaVO == null) return BadRequest();
            var result = _business.Update(pessoaVO);
            if (result == null) return BadRequest();
            GerarLinks(result);
            return Ok(result);
        }

        // Maps DELETE requests to https://localhost:{port}/api/person/{id}
        // receiving an ID as in the Request Path
        [HttpDelete("{id}", Name = nameof(DeletePessoa))]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult DeletePessoa(long id)
        {
            _business.Delete(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((200), Type = typeof(PessoaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Patch(long id)
        {
            var person = _business.Disable(id);
            return Ok(person);
        }
    }
}
