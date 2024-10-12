using KPCOS.Api.Constants;
using KPCOS.Api.Service.Interface;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Errors;
using MBKC.Service.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPCOS.Api.Controllers
{
    [Route("api/v1/userprofile-manager")]
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [ProducesResponseType(typeof(GetAccountsRespone), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserProfile(int userId)
        {
            var profile = await _userProfileService.GetUserProfileAsync(userId);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [ProducesResponseType(typeof(GetAccountsRespone), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserProfile(int userId, [FromBody] UserProfileResponse profileDto)
        {
            if (userId != profileDto.UserID)
            {
                return BadRequest("User ID mismatch.");
            }

            var result = await _userProfileService.UpdateUserProfileAsync(userId, profileDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


        [ProducesResponseType(typeof(GetAccountsRespone), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserProfile(int userId)
        {
            var result = await _userProfileService.DeleteUserProfileAsync(userId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}