using BookNation.Data;
using BookNation.DTO;
using BookNation.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Controllers
{
    public class FieldController : BaseApiController
    {
        private readonly DataContext _context;

        public FieldController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ApplicableField>>> GetApplicableField()
        {
            var Fields = await _context.ApplicableFields.ToListAsync();
            return Fields;
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<ApplicableField>> GetApplicableField(int id)
        // {
        //     var ApplicableField = await _context.ApplicableFields.FindAsync(id);
        //     return ApplicableField;
        // }

        [HttpPost("add")]
        public async Task<ActionResult<ApplicableFieldDto>> Add(ApplicableFieldDto applicableFieldDto)
        {
            if (await FieldNameExists(applicableFieldDto.Name))
            {
                return BadRequest("Field with name already exists");
            }

            var applicableField = new ApplicableField
            {
                Name = applicableFieldDto.Name,
                Description = applicableFieldDto.Description
            };

            _context.ApplicableFields.Add(applicableField);
            await _context.SaveChangesAsync();

            return new ApplicableFieldDto
            {
                Name = applicableField.Name,
                Description = applicableField.Description
            };
        }


        [HttpDelete("remove")]
        public async Task<ActionResult<ApplicableFieldDto>> Remove(int id)
        {

            if (id == 0)
            {
                return BadRequest("Please enter a positive id");
            }

            var field = await _context.ApplicableFields.FirstOrDefaultAsync(x => x.Id == id);

            if (field == null)
            {
                return BadRequest("Field with provided id does not exist.");
            }

            _context.ApplicableFields.Remove(field);
            await _context.SaveChangesAsync();

            return new ApplicableFieldDto
            {
                Name = field.Name,
                Description = field.Description
            };
        }

        private async Task<bool> FieldNameExists(string name)
        {
            return await _context.ApplicableFields.AnyAsync(field => field.Name.ToLower() == name.ToLower());
        }

    }
}