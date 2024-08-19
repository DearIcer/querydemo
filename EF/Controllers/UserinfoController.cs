using EF.Entity;
using EF.Service.UserinfoRepository;
using Microsoft.AspNetCore.Mvc;

namespace EF.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserinfoController : Controller
{
    private readonly UserinfoRepository _userinfoRepository;
    public UserinfoController(UserinfoRepository userinfoRepository)
    {
        _userinfoRepository = userinfoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _userinfoRepository.GetUserinfoAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Userinfo userinfo)
    {
        await _userinfoRepository.AddAsync(userinfo);
        return Ok();
    }
}