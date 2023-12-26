using FirstWebApi.Data;
using FirstWebApi.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [ApiController]
    // [Route("api/[controller]")]
    [Route("api/Student")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Student>> GetStudent()
        {
            _logger.LogInformation("Get all Students");
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
            if(StudentStore.studentList.Where(x => x.Id == id).Any())
            {
                var student = StudentStore.studentList.Where(x => x.Id == id).FirstOrDefault();
                if(student == null)
                {
                   
                    return NotFound();
                }
                var studentData = new StudentData
                {
                    Name = student.Name,
                    Age = student.Age,
                    PhoneNumber = student.PhoneNo
                };
                return Ok(studentData);
            }
            else
            {
                return NotFound();
            }
            
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
            
            if (StudentStore.studentList.Where(x => x.Name.ToLower() == name.ToLower()).Any())
            {
                var student = StudentStore.studentList.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
                if (student == null)
                {
                    return NotFound();
                }
                var studentData = new StudentData
                {
                    Name = student.Name,
                    Age = student.Age,
                    PhoneNumber = student.PhoneNo
                };
                return Ok(studentData);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Student> CreateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                _logger.LogInformation("Student is null");
                return BadRequest(student);
            }
            if (student.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if(student.Age == 15 || student.Age == 16)
            {
                ModelState.AddModelError("Not Accepted", "We don't accept this age");
                return BadRequest(ModelState);
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
