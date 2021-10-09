using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOECSREP.POC.Educator.Data;
using MOECSREP.POC.Educator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOECSREP.POC.Educator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly MDEDBContext _context;
        public EducationController(MDEDBContext context)
        {
            _context = context;
        }
               
        // GET: api/educator/education/5
        [HttpGet("{id}", Name = "EducationById")]       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<MOECSREP.POC.Educator.Models.Education>>> GetEducationById(int id)
        {
            // get the list of education for a particular educator.
            var educationList = _context.Educations.Where(edu => edu.EducatorID == id).ToList();    
            // the list should not be empty
            if (educationList != null)
            {
                return educationList;               
            }

            return NotFound();
        }
    }
}
