using Microsoft.AspNetCore.Mvc;
using TestProject.DBModels;
using TestProject.Models;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        TestDBContext testDB = new TestDBContext();

        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "SaveRegistrationDetails")]
        public IActionResult SaveRegistrationDetails(RegistrationDetail model)
        {
            CommonResponseModel responseModel = new CommonResponseModel();
            try
            {
                RegistrationDetail registration = new RegistrationDetail();
                registration.Id = Guid.NewGuid();
                registration.UserName = model.UserName;
                registration.FullName = model.FullName;
                registration.Email = model.Email;
                registration.Mobile = model.Mobile;
                registration.Password = model.Password;

                testDB.Add(registration);
                testDB.SaveChanges();
                responseModel.Status = true;
                responseModel.Message = "Registration Detail Saved Succesfully.";
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
            }

            return Ok(responseModel);
        }

    }
}
