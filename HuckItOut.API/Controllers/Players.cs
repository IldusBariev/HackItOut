using HuckItOut.API.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HuckItOut.API.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using HuckItOut.API.Request;
using HuckItOut.API.Request;

namespace HuckItOut.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Players : Controller
    {

        private readonly AppDbContext _dbContext;

        public Players(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("addPlayer")]
        public async Task<IActionResult> AddPlayerAsync(PlayerRequest request)
        {

            string[] fullNameSplit = request.FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (fullNameSplit.Length <= 1 ||
               fullNameSplit.Length >= 4)
                return BadRequest("ФИО написано не правильно");

            string firstName = fullNameSplit[1];
            string lastName = fullNameSplit[0];
            string? secondName = fullNameSplit.Length == 2 ? null : fullNameSplit[2];

            string endPhoneNumber = Regex.Replace(request.PhoneNumber, "[^0-9]", "");
            if (endPhoneNumber.Length != 11)
                return BadRequest("Номер телефона написан не правильно");

            string[] emailSplit = request.Email.Split('@', StringSplitOptions.RemoveEmptyEntries);
            if (emailSplit.Length != 2)
                return BadRequest("Не правильно написан Email");

            await _dbContext.Players.AddAsync(new Player(
                lastName, 
                firstName, 
                secondName,
                endPhoneNumber,
                emailSplit[0], 
                emailSplit[1]));
            await _dbContext.SaveChangesAsync();
            
            return Created();
        }

        //[HttpGet("allPlayers")]
        //public async Task<IActionResult> AllPlayersAsync ()
        //{
        //    var allPlayer = await _dbContext.Players.ToListAsync();

        //    return Ok(allPlayer);
        //}

        [HttpGet("position")]
        public IActionResult GetPosition()
        {
            // Путь к файлу на сервере
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "static/files", "position.docx");

            // Проверяем, существует ли файл
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Файл не найден");
            }

            // Возвращаем файл для скачивания
            var fileStream = System.IO.File.OpenRead(filePath);
            return File(fileStream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "filename.docx");
        }
        
        [HttpGet("task")]
        public IActionResult GetTask()
        {
            // Путь к файлу на сервере
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "static/files", "position.docx");

            // Проверяем, существует ли файл
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Файл не найден");
            }

            // Возвращаем файл для скачивания
            var fileStream = System.IO.File.OpenRead(filePath);
            return File(fileStream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "filename.docx");
        }

    }
}
