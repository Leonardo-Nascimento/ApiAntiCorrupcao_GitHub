using ApiAntiCorrupcao.Domain.Dtos;
using ApiAntiCorrupcao.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAntiCorrupcao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {

        private readonly IGitHubServices _gitHubServices;

        public GitHubController(IGitHubServices gitHubServices)
        {
            _gitHubServices = gitHubServices;
        }

        [HttpGet("GetTotalInfos")]
        public IActionResult GetTotalInfo([FromQuery] string UserName)
        {
            return Ok(_gitHubServices.GetTotalInfo(UserName));
        }

        [HttpGet("ListBranchesByProjectName")]
        public IActionResult ListBranchesByProjectName([FromQuery] string UserName, string projectName)
        {
            return Ok(_gitHubServices.ListBranchesByProjectName(UserName, projectName));
        }


        [HttpGet("GetAllWebhooksByRepository")]
        public IActionResult GetAllWebhooksByRepository([FromQuery] string UserName, [FromQuery] string projectName, [FromHeaderAttribute] string token )
        {
            var result = _gitHubServices.GetAllWebhooksByRepository(UserName, projectName, token);
            return Ok(result);
        }


        [HttpPost("CreateNewRepository")]
        public IActionResult CreateNewRepository([FromBody] LoginDto login)
        {
            _gitHubServices.CreateNewRepository(login.userName, login.Senha, login.Token);
            return Ok("Repository criado com sucesso");
        }

        [HttpPost("CreateWebhookForRepository")]
        public IActionResult CreateWebhookForRepository([FromQuery] string urlWebhook, [FromQuery] string projectName, [FromBody] LoginDto login)
        {
           var result =  _gitHubServices.CreateWebhookForRepository(urlWebhook , login.userName, projectName, login.Token);
            return Ok(result);
        }



    }
}
