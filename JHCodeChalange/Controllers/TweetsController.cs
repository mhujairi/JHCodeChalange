using Microsoft.AspNetCore.Mvc;

using TwitterApi.Data;

namespace JHCodeChalange.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetRepository tweetRepository;
        private readonly IHashTagRepository hashTagRepository;

        public TweetsController(ITweetRepository tweetRepository, IHashTagRepository hashTagRepository)
        {
            this.tweetRepository = tweetRepository;
            this.hashTagRepository = hashTagRepository;
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<int> TwwetsCount()
        {
            return await tweetRepository.CountAsync();
        }


        [HttpGet]
        [Route("/[controller]/[action]/{limit}")]
        public async Task<string[]> TopHashTags(int limit)
        {
            return await hashTagRepository.GetTopHashTagsAsync(limit);
        }
    }
}