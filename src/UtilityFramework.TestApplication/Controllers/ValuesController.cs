using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UtilityFramework.Application;
using UtilityFramework.Application.ViewModels;
using UtilityFramework.TestApplication.Data;
using UtilityFramework.TestApplication.Data.Repository.Interface;

namespace UtilityFramework.TestApplication.Controllers
{
    [Route("api/v1/[controller]")]
    public class ValuesController : Controller
    {

        private readonly IUserRepository _userRepository;

        public ValuesController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        /// <summary>
        /// DESCRIPTION METHOD
        /// </summary>
        /// <response code="200">Returns success</response>
        /// <response code="400">Custom Error</response>
        /// <response code="401">Unauthorize Error</response>
        /// <response code="500">Exception Error</response>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ReturnViewModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                _userRepository.Create(new User()
                {
                    Login = "Fabricio",
                    Password = "123123412"
                });


                return Ok(Utilities.ReturnSuccess());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ReturnErro());
            }
        }

    }
}