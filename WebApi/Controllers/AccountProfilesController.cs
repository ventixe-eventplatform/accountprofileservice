using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountProfilesController(IAccountProfileService accountProfileService) : ControllerBase
{
    private readonly IAccountProfileService _accountProfileService = accountProfileService;

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateProfileModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new {Error = "Invalid profile informaiton."});

        var result = await _accountProfileService.CreateAsync(model);

        return result.Success ? Ok(result) : StatusCode(500, result.Error);       
    }
}
