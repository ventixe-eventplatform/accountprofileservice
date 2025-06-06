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
            return BadRequest(new {Error = "Invalid profile information."});

        var result = await _accountProfileService.CreateAsync(model);

        return result.Success ? Ok(result) : StatusCode(500, result.Error);       
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetProfileAsync(string userId)
    {
        var result = await _accountProfileService.GetProfileAsync(userId);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAsync(UpdateProfileModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { Error = "Invalid profile information." });

        var result = await _accountProfileService.UpdateAsync(model);

        return result.Success ? Ok(result) : StatusCode(500, new { error = result.Error });
    }

    [HttpPost("exists")]
    public async Task<IActionResult> UserExistsAsync([FromBody] UserIdRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = await _accountProfileService.UserExistsAsync(request);

        return result.Success ? Ok(new { result.Data }) : NotFound(new { result.Data });
    }
}
