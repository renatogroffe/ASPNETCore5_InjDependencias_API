using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIExemploInjecao.Testes;

namespace APIExemploInjecao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestesController : ControllerBase
    {
        private readonly ILogger<TestesController> _logger;
        private ITesteA _testeA;
        private ITesteB _testeB;
        private TesteC _testeC;

        public TestesController(ILogger<TestesController> logger,
            ITesteA testeA,
            ITesteB testeB,
            TesteC testeC)
        {
            _logger = logger;
            _testeA = testeA;
            _testeB = testeB;
            _testeC = testeC;
        }

        [HttpGet]
        public ActionResult<ResultadoInjecao> Get(
            [FromServices]ITesteA testeA,
            [FromServices]ITesteB testeB,
            [FromServices]TesteC testeC)
        {
            var resultado = new ResultadoInjecao();

            resultado.ValoresA = new ()
            {
                Construtor = _testeA.IdReferencia,
                Action = testeA.IdReferencia
            };

            resultado.ValoresB = new ()
            {
                Construtor = _testeB.IdReferencia,
                Action = testeB.IdReferencia
            };

            resultado.ValoresC = new ()
            {
                Construtor = _testeC.IdReferencia,
                Action = testeC.IdReferencia
            };

            _logger.LogInformation(resultado.ValoresA.ToString());
            _logger.LogInformation(resultado.ValoresB.ToString());
            _logger.LogInformation(resultado.ValoresC.ToString());

            return resultado;
        }
    }
}