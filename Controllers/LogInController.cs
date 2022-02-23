using Microsoft.AspNetCore.Mvc;
using TestProject.DBModels;
using TestProject.Models;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogInController : ControllerBase
    {
        TestDBContext testDB = new TestDBContext();

        private readonly ILogger<LogInController> _logger;

        public LogInController(ILogger<LogInController> logger)
        {
            _logger = logger;
        }


        [HttpPost(Name = "VarifyLogin")]
        public IActionResult VarifyLogin(LogInModel model)
        {
            CommonResponseModel responseModel = new CommonResponseModel();
            try
            {
                if (!string.IsNullOrWhiteSpace(model.UserName) && !string.IsNullOrWhiteSpace(model.Password))
                {
                    var IsRegistred = testDB.RegistrationDetails.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
                    if (IsRegistred != null)
                    {
                        responseModel.Status = true;
                        responseModel.Message = "Logged In SuccessFully.";
                    }
                    else
                    {
                        responseModel.Message = "Logged In Fail ! UserName Or Password InCorrect.";
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
            }
            return Ok(responseModel);
        }
    }
}
