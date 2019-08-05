using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSportsApp.IRepositories;
using WebApiSportsApp.Models;

namespace WebApiSportsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public TestsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/Tests
        [HttpGet]
        public async Task<IEnumerable<Test>> GetTest()
        {
            var Tests = _unitOfWork.TestRepo.GetAllTests();
            return await Tests;
        }

        // GET: api/Tests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var test = await _unitOfWork.TestRepo.GetTestByID(id);

            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        // PUT: api/Tests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest([FromRoute] int id, [FromBody] Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test.TestId)
            {
                return BadRequest();
            }

           // _context.Entry(test).State = EntityState.Modified;
           
            try
            {
                //await _context.SaveChangesAsync();
                  _unitOfWork.TestRepo.UpdateTest(test);
                  await _unitOfWork.Save();
            }
           
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
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

        // POST: api/Tests
        [HttpPost]
        public async Task<IActionResult> PostTest([FromBody] Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_context.Test.Add(test);
            // await _context.SaveChangesAsync();
            await _unitOfWork.TestRepo.InsertTest(test);
            await _unitOfWork.Save();
            return CreatedAtAction("GetTest", new { id = test.TestId }, test);
        }

        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var test = await _unitOfWork.TestRepo.GetTestByID(id);
            if (test == null)
            {
                return NotFound();
            }

             _unitOfWork.TestRepo.DeleteTest(id);
            await _unitOfWork.Save();

            return Ok(test);
        }

        private bool TestExists(int id)
        {
            //return _context.Test.Any(e => e.TestId == id);
            if(_unitOfWork.TestRepo.GetTestByID(id)!= null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}