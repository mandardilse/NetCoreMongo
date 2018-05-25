using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetCoreMongo.Models;
using NetCoreMongo.Models.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace NetCoreMongo.Controllers
{
    [Route("api/[controller]")]
    public class UserController: Controller
    {
		private readonly AppDbContext db;
		public UserController(AppDbContext context) => db = context;
		[HttpGet]
		public async Task<IEnumerable<User>> Get() =>
        await db.Users.Find(_ => true).ToListAsync();
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if(ModelState.IsValid){
                await db.Users.InsertOneAsync(user);
                return Ok(true);
            }
            return BadRequest(false);
        }
        [HttpPut]
        public async Task<bool> Put([FromBody] User user)
        {
            if(ModelState.IsValid){
                var filter = Builders<User>.Filter.Eq(u=>u.Id, "Id");
                var update = Builders<User>.Update.Set(x=>x.FirstName, user.FirstName)
                                .Set(x=>x.MiddleName, user.MiddleName)
                                .Set(x=>x.LastName, user.LastName)
                                .Set(x=>x.Email, user.Email)
                                .Set(x=>x.Password, user.Password)
                                .Set(x=>x.UpdatedBy, user.UpdatedBy)
                                .CurrentDate(u=>u.UpdatedOn);

                var result = await db.Users.UpdateOneAsync(filter,update);
                return result.IsAcknowledged && result.ModifiedCount > 0;
            }
            return false;
        }

        [HttpDelete]
        public async Task<bool> Delete(string id)
        {
            var filter = Builders<User>.Filter.Eq(u=>u.Id, id);
            var result = await db.Users.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

	}
}