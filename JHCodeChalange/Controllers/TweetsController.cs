using Microsoft.AspNetCore.Mvc;

using TwitterApi.Data;
using TwitterApi.Model;

namespace JHCodeChalange.Controllers;

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
    public async Task<int> TweetsCount()
    {
        return await tweetRepository.CountAsync();
    }


    [HttpGet]
    [Route("/[controller]/[action]/{limit}")]
    public async Task<HashtageEntry[]> TopHashTags(int limit)
    {
        return await hashTagRepository.GetTopHashTagsAsync(limit);
    }

    [HttpGet]
    [Route("/[controller]/[action]")]
    public async Task<int> HashTagsCount()
    {
        return await hashTagRepository.CountAsync();
    }

}