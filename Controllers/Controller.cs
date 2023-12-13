using APIDemo.Controllers.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Controllers
{
	public class Controller : ControllerBase
	{
		private readonly MyDbContex _myDbContext;
        public Controller(MyDbContex myDbContex)
        {
			_myDbContext = myDbContex;
        }
		[HttpGet]
		[Route("api/[controller]")]
		public async Task<IActionResult> GetAsync()
		{
			var students= await _myDbContext.Students.ToListAsync();
			return Ok(students);

		}
		[HttpGet]
		[Route("api/getStudentById")]
		public async Task<ActionResult> getStudentByIdAsync(int id)
		{
			var student = await _myDbContext.Students.FindAsync(id);
			return Ok(student);

		}
		[HttpPost]
		[Route("api/getStudentByIdInsert")]
		public async Task<ActionResult>PostAsync(Students student)
		{
			try
			{
				_myDbContext.Students.Add(student);
				await _myDbContext.SaveChangesAsync();
				return Created($"getStudentById?id={student.Id}", student);

			}
			catch (Exception ex)
			{
				return BadRequest(new { ErrorMessage = ex.Message });
			}
		}
		///???
		[HttpPut]
		[Route("api/StudentUpdate")]
		public async Task<ActionResult> PutAsync(Students studentupdate)
		{
			_myDbContext.Students.Update(studentupdate);
			await _myDbContext.SaveChangesAsync();
			return NoContent();
		}

		[HttpDelete]
		[Route("api/StudentDeleteById")]
		public async Task<ActionResult> DeleteAsync(int id)
		{
			var studentDelete = await _myDbContext.Students.FindAsync(id);
			if (studentDelete == null)
			{
				return NotFound();
			}
			_myDbContext.Students.Remove(studentDelete);
			await _myDbContext.SaveChangesAsync();
			return NoContent();
		}
		

	}
}
