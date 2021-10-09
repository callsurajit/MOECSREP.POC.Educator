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
    public class EducatorController : ControllerBase
    {
        private readonly MDEDBContext _context;
        public EducatorController(MDEDBContext context)
        {
            _context = context;
        }

        // GET: api/educator
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<MOECSREP.POC.Educator.Models.Educator>>> GetEducators()
        {
            // get the list of educators from the service.
            var educatorList = _context.Educators.ToList();

            if (educatorList.Count > 0)
            {
                return educatorList;
            }

            return NotFound();
        }

        // GET: api/educator/5
        [HttpGet("{id}", Name = "EducatorById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MOECSREP.POC.Educator.Models.Educator>> GetEducatorById(int id)
        {
            var educatorList = GetEducators().Result.Value;
            // the list should not be empty
            if (educatorList != null)
            {
                // find the match if present
                var educator = educatorList.FirstOrDefault(edu => edu.EducatorID == id);
                // yayyy..record found...
                if (educator != null)
                {
                    return educator;
                }
            }

            return NotFound();
        }
    }
}
