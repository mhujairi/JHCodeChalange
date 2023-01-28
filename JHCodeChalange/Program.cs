using JHCodeChalange.BackgroundServices;

using System.Net.Http.Headers;

using TwitterApi.Data;
using TwitterApi.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var baseTwitterAddress = new Uri("https://api.twitter.com");
var twitterBearerKey = builder.Configuration.GetValue("twitter:BearerKey", string.Empty);
var twitterBearerAuthenticationHeader = new AuthenticationHeaderValue("Bearer", twitterBearerKey);
var GetHttpClient = () =>
{
    var result = new HttpClient
    {
        BaseAddress = baseTwitterAddress
    };
    result.DefaultRequestHeaders.Authorization = twitterBearerAuthenticationHeader;

    return result;
};
builder.Services.AddSingleton<HttpClient>(GetHttpClient());

builder.Services.AddTransient<ITwitterClient, SampleTwitterClient>();

int hashtagsBufferSize = builder.Configuration.GetValue("hashtagsBufferSize",1000);
var tweetsRepository = new TwitterRepository(hashtagsBufferSize);
builder.Services.AddSingleton<ITweetRepository>((serviceProvider) => tweetsRepository);
builder.Services.AddSingleton<IHashTagRepository>((serviceProvider) => tweetsRepository);

builder.Services.AddHostedService<TweetsBackgroundService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
