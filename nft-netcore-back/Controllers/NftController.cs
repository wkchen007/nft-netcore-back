using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nft_netcore_back.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nft_netcore_back.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NftController : ControllerBase
    {
        private readonly Models.nftwebContext _nftwebContext;

        public NftController(Models.nftwebContext nftwebContext)
        {
            _nftwebContext = nftwebContext;
        }

        // GET: <NftController>
        [HttpGet]
        public async Task<ActionResult<List<nft>>> Get()
        {
            var list = await _nftwebContext.nft.ToListAsync();

            return Ok(list);
        }

        // GET: <NftController>/demo
        [HttpGet("demo")]
        public async Task<ActionResult<List<nft>>> demo()
        {
            var result = await _nftwebContext.nft
                .Where(n => n.demo == 1)
                .Join(
                    _nftwebContext.users,
                    n => n.userId,
                    u => u.id,
                    (n, u) => new
                    {
                        id = n.id,
                        name = n.name,
                        description = n.description,
                        meta = n.meta,
                        image = n.image,
                        userFirstName = u.first_name
                    }
                ).ToListAsync();

            return Ok(result);
        }

        // GET <NftController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<nft>> Get(int id)
        {
            var result = await _nftwebContext.nft
                .Where(a => a.id == id)
                .SingleOrDefaultAsync();

            if (result == null)
            {
                return NotFound($"找不到 Id：{id} 的盲盒資料");
            }

            return Ok(result);
        }

        // POST <NftController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT <NftController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE <NftController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
