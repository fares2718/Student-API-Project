using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProjectAPI.DataSemulation;
using StudentProjectAPI.Model;

namespace StudentProjectAPI.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        [HttpGet]

        public ActionResult<IEnumerable<Student>> GetAllStudents ()
        {
            return Ok(StudentDataSemulation.StudentsList);
        }

    }
}
