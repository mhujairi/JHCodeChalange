make sure to add a user secret as follow:

dotnet user-secrets set "twitter:BearerKey" "<your twitter Bearer Key>"

to the following projects:
1- JHCodeChalange
2- TwitterApi.Tests

And you are all set..

to increase the accuracy of the top hash tag feature you can increase the "hashtagsBufferSize" setting in the "appsettings.json" file
but that will also increase the used memory for your web app. So, update it wisely.