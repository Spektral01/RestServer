using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestASPtoDo.Models;
using System.Collections.Generic;

namespace RestASPtoDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>();

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _users;
        }

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            user.Id = GenerateId();
            _users.Add(user);
            return user;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if ( user is null)
                return BadRequest();
            _users.Remove(user);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteAllUsers()
        {
            try
            {
                // Код для удаления всех пользователей
                _users.Clear(); // Например, очистка списка пользователей

                return Ok("Все пользователи успешно удалены.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при удалении пользователей: {ex.Message}");
            }
        }

        private int GenerateId()
        {
            // Генерация уникального идентификатора (можно заменить на свою реализацию)
            Random rnd = new Random();
            int id = rnd.Next();
            return id;
        }
    }
}
