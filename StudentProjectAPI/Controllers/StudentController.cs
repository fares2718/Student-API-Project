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

        [HttpGet ("GetAllStudents",Name = "GetAllStudents")]

        public ActionResult<IEnumerable<Student>> GetAllStudents ()
        {
            return Ok(StudentDataSemulation.StudentsList);
        }

        [HttpGet ("GetPassedStudents",Name = "GetPassedStudents")]
        
        public ActionResult<IEnumerable<Student>> GetPassedStudents()
        {
            var passedStudents = StudentDataSemulation.StudentsList.Where(student => student.Grade >= 50).ToList();
            return Ok(passedStudents);
        }

    }
}
