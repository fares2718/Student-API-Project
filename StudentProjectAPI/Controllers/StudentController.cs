using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentProjectAPI.DataSemulation;
using StudentProjectAPI.Model;

namespace StudentProjectAPI.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        [HttpGet("GetAllStudents", Name = "GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return Ok(StudentDataSemulation.StudentsList);
        }

        [HttpGet("GetPassedStudents", Name = "GetPassedStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Student>> GetPassedStudents()
        {
            var passedStudents = StudentDataSemulation.StudentsList.Where(student => student.Grade >= 50).ToList();
            return Ok(passedStudents);
        }

        [HttpGet("GetStudentsGradesAvg", Name = "GetStudentsGradesAvg")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<double> GetStudentsGradesAvg()
        {
            if (StudentDataSemulation.StudentsList.Count == 0)
                return NotFound("No Students Found");
            var GradesAvg = StudentDataSemulation.StudentsList.Average(student => student.Grade);
            return Ok(GradesAvg);
        }

        [HttpGet("{id}", Name = "GetStudentByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Student> GetStudentByID(int id)
        {
            var student = StudentDataSemulation.StudentsList.FirstOrDefault(student => student.Id == id);

            if (id < 1)
                return BadRequest($"{id} is Not Accepted");

            if (student == null)
                return NotFound($"No Students With ID {id} Found");

            return Ok(student);

        }


        [HttpPost(Name = "AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<Student> AddStudent(Student student)
        {
            if (student == null || string.IsNullOrEmpty(student.Name) || student.Age < 4 || student.Grade < 0)
                return BadRequest("Invalid student data");
            student.Id = StudentDataSemulation.StudentsList.Count > 0 ? StudentDataSemulation.StudentsList.Max(s => s.Id + 1) : 1;
            StudentDataSemulation.StudentsList.Add(student);
            return CreatedAtRoute("AddStudent", new { id = student.Id }, student);
        }

        [HttpDelete("{id}",Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult DeleteStudent(int id)
        {
            if (id < 1)
                return BadRequest($"{id} is Not Accepted");
            var student = StudentDataSemulation.StudentsList.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound($"No Students With ID {id} Found");
            StudentDataSemulation.StudentsList.Remove(student);
            return Ok($"Students With ID {id} Deleted");
        }

        [HttpPut("{id}",Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult UpdateStudent(int id,Student updatedStudent)
        {
            if (id < 1 || updatedStudent == null || string.IsNullOrEmpty(updatedStudent.Name) 
                || updatedStudent.Age < 0 || updatedStudent.Grade < 0)
                    return BadRequest("Invalid Data");
            var student = StudentDataSemulation.StudentsList.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound($"No Students With ID {id} Found");
            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Grade = updatedStudent.Grade;

            return Ok(student);
        }

    }
}
