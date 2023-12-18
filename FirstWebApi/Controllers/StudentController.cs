using FirstWebApi.Data;
using FirstWebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [ApiController]
    // [Route("api/[controller]")]
    [Route("api/Student")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Student>> GetStudent()
        {
            return Ok(StudentStore.studentList);
        }

        [HttpGet("id:int" , Name = "GetStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Student> GetStudent(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var student = StudentStore.studentList.FirstOrDefault(x => x.Id == id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("name:alpha", Name = "GetStudentByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Student> GetStudentByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            var student = StudentStore.studentList.FirstOrDefault(x => x.Name == name);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Student> CreateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest(student);
            }
            if (student.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            student.Id = StudentStore.studentList.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            StudentStore.studentList.Add(student);

            return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Student> DeleteStudent(int id)
        {
            var student = StudentStore.studentList.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound(student);
            }
            StudentStore.studentList.Remove(student);
            return Ok(student);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var existingStudent = StudentStore.studentList.FirstOrDefault(s => s.Id == id);

            if (existingStudent == null)
            {
                return NotFound();
            }

            // Update the existing student's properties
            existingStudent.Id = updatedStudent.Id;
            existingStudent.Name = updatedStudent.Name;
            existingStudent.PhoneNo = updatedStudent.PhoneNo;

            return Ok(existingStudent);
        }

    }
}
