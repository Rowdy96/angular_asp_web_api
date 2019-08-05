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
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class TestDetailsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public TestDetailsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/TestDetails/GetAllTestDetail/TestId
        [HttpGet("{id}")]
        public async Task<IEnumerable<TestDetail>> GetAllTestDetail(int id)
        {
            return await _unitOfWork.testDetailsRepo.GetAllTestDetails(id);
        }

        // GET: api/TestDetails/GetTestDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testDetail = await _unitOfWork.testDetailsRepo.GetTestDetails(id);

            if (testDetail == null)
            {
                return NotFound();
            }

            return Ok(testDetail);
        }

        // PUT: api/TestDetails/PutTestDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTestDetail([FromRoute] int id, [FromBody] TestDetail testDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testDetail.AthleteId)
            {
                return BadRequest();
            }

            _unitOfWork.testDetailsRepo.UpdateTest(testDetail);

            try
            {
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestDetailExists(id))
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

        // POST: api/TestDetails/CreateTestDetail/TestId
        [HttpPost("{id}")]
        public async Task<IActionResult> CreateTestDetail([FromBody] TestDetail testDetail,int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            testDetail.TestId = id;
            await _unitOfWork.testDetailsRepo.InsertTest(testDetail);
            await _unitOfWork.Save();
            return Ok(testDetail);
           //return CreatedAtAction("GetAllTestDetail", new { id = testDetail.TestId });
        }

        // DELETE: api/TestDetails/DeleteTestDetail/AthleteId
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testDetail = await _unitOfWork.testDetailsRepo.GetTestDetails(id);
            if (testDetail == null)
            {
                return NotFound();
            }

            await _unitOfWork.testDetailsRepo.DeleteTest(id);
            await _unitOfWork.Save();

            return Ok(testDetail);
        }

        private bool TestDetailExists(int id)
        {
            if (_unitOfWork.testDetailsRepo.GetTestDetails(id) != null)
            {
                return true;
            }

            return false;
        }
    }
    
}