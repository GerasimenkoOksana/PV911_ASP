using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUserAjax.Data;
using WebUserAjax.Data.Entities.School;
using WebUserAjax.Models.ViewModles;

namespace WebUserAjax.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Сформирую контейнер для передачи данных
        // используется сторонниками классического MVC
        private class StudentContainer
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Group Group { get; set; }
            public Teacher Teacher { get; set; }
        }

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // https://localhost:44370/Api/Students
        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MV_Student>>> GetStudents()
        {
            // return await _context.Students.Include(s => s.Group).ToListAsync();

            // var lstStudens = await _context.Students.Include(g => g.Group.Teacher).ToListAsync();

            //var lstStudens = await _context.Students.ToListAsync();

            /*
            SELECT * FROM Student AS s
                JOIN * FROM Group AS g ON g.Id = s.GroupId
                JOIN * FROM Teachers AS t On t.Id = g.TeacherId

            */

            var lstStudents = from s in _context.Students
                            join g in _context.Groups on s.GroupId equals g.Id
                            // join t in _context.Teachers on g.TeacherId equals t.Id
                            select new MV_Student 
                            { Id = s.Id, Name = s.Name, 
                                GroupName =g.Name,  Group = g,
                                TeacherName = g.Teacher.Name // , Teacher = g.Teacher
                            };


            // var lstStudents = await _context.Students.ToListAsync();

            return await lstStudents.ToListAsync();

            /*
            return await _context.Students
                .Include(g => g.Group.Teacher)
                .Select(s => new MV_Student(s))
                .ToListAsync();
            */


            // return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
