using BlazorServerApp.Models.PostsModels;
using BlazorServerApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorServerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShareController : ControllerBase
    {
        private readonly EncryptSymmetricService _encryptSymmetricService;

        public ShareController(EncryptSymmetricService encryptSymmetricService)
        {
            _encryptSymmetricService = encryptSymmetricService;
        }

        [HttpGet("get-posts")]
        public async Task<IActionResult> GetPosts()
        {
            PostController postsController = new PostController();
            
            List<UserPost> posts = await postsController.GetAllPosts();

            string postsToJsonString = JsonConvert.SerializeObject(posts);

            string encryptedData = _encryptSymmetricService.EncryptSymmetric(postsToJsonString);

            return Ok(encryptedData);
        }
    }

}
