using System;
using System.Threading.Tasks;
using IoT.Capstone.KeyGen.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoT.Capstone.KeyGen.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EdxUserController : ControllerBase
    {
        private static readonly Random UidGenerator = new Random();
        private readonly KeyGenContext _keyGenContext;

        public EdxUserController(KeyGenContext keyGenContext)
        {
            _keyGenContext = keyGenContext;
        }


        // GET: api/EdxUser
        [HttpGet]
        public async Task<EdxUser[]> Get()
        {
            var edxUsers = await _keyGenContext.EdxUsers.ToArrayAsync();
            return edxUsers;
            //var json = JsonConvert.SerializeObject(edxUser);

            //return File(Encoding.UTF8.GetBytes(json), "text/csv", "EdxUserList.csv");
        }

        // GET: api/EdxUser/5
        [HttpGet("{edxId}", Name = "GetEdxUser")]
        [AllowAnonymous]
        public async Task<EdxUser> Get(string edxId)
        {
            var edxUser = await _keyGenContext.EdxUsers.SingleOrDefaultAsync(e => e.EdxId == edxId);
            if (edxUser == null)
            {
                // create one!
                var success = false;
                while (!success)
                    try
                    {
                        edxUser = new EdxUser {EdxId = edxId, Uid = UidGenerator.Next()};
                        _keyGenContext.EdxUsers.Add(edxUser);
                        var result = await _keyGenContext.SaveChangesAsync(true);
                        success = true;
                    }
                    catch (DbUpdateException)
                    {
                        // this would fail if Uid is not unique, so we want to try again with a new Uid
                    }
            }

            return edxUser;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{edxId}")]
        public async Task Delete(string edxId)
        {
            var edxUser = await _keyGenContext.EdxUsers.SingleOrDefaultAsync(e => e.EdxId == edxId);
            if (edxUser != null)
            {
                _keyGenContext.EdxUsers.Remove(edxUser);
                await _keyGenContext.SaveChangesAsync(true);
            }
        }
    }
}