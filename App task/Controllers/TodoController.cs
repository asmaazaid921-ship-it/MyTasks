using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App_task.Models;
using App_task.Data;

namespace App_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TodoController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        
        [HttpPost("AddWithFile")]
        public async Task<IActionResult> Create([FromForm] TodoCreateDto dto)
        {
            if (string.IsNullOrEmpty(dto.Title))
                return BadRequest("عنوان المهمة مطلوب.");

            string? filePath = null;

            if (dto.File != null)
            {
               
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.File.FileName);
                var fullPath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await dto.File.CopyToAsync(stream);
                }

                filePath = Path.Combine("uploads", fileName);
            }

            var newItem = new TodoItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Deadline = dto.Deadline,
                AttachmentPath = filePath,
                CreatedAt = DateTime.Now
            };

            _context.TodoItems.Add(newItem);
            await _context.SaveChangesAsync();

            return Ok(newItem);
        }

        
        [HttpGet("ListTasks")]
        public async Task<IActionResult> GetAll(string? search, int page = 1)
        {
            var pageSize = 5;
            var query = _context.TodoItems.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(t => t.Title.Contains(search));

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var tasks = await query
                .OrderBy(t => t.Deadline)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(t => new
                {
                    t.Id,
                    t.Title,
                    t.Description,
                    t.Deadline,
                    t.AttachmentPath,
                    t.IsCompleted,
                    
                    IsUrgent = !t.IsCompleted && (t.Deadline - DateTime.Now).TotalHours <= 24 && (t.Deadline - DateTime.Now).TotalHours > 0
                })
                .ToListAsync();

            return Ok(new { totalItems, totalPages, currentPage = page, tasks });
        }

        
        [HttpGet("DownloadFile/{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);

            if (item == null || string.IsNullOrEmpty(item.AttachmentPath))
                return NotFound("لا يوجد ملف مرفق لهذه المهمة.");

            var fullPath = Path.Combine(_env.WebRootPath, item.AttachmentPath);

            if (!System.IO.File.Exists(fullPath))
                return NotFound("الملف غير موجود فعلياً على السيرفر.");

            var fileBytes = await System.IO.File.ReadAllBytesAsync(fullPath);
            var fileName = Path.GetFileName(fullPath);

            return File(fileBytes, "application/octet-stream", fileName);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return NotFound();

            if (!string.IsNullOrEmpty(item.AttachmentPath))
            {
                var fullPath = Path.Combine(_env.WebRootPath, item.AttachmentPath);
                if (System.IO.File.Exists(fullPath)) System.IO.File.Delete(fullPath);
            }

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("تم حذف المهمة والملف بنجاح.");
        }
    }
}