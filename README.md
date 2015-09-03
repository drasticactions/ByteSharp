# ByteSharp

ByteSharp is a third-party client library for [Byte](http://byte.co). 

Right now it maps one to one with the current [Byte API](https://github.com/bytehq/api/blob/master/api.md). Anything you can do there, you should be able to do through this library.

Get it on [Nuget](https://www.nuget.org/packages/ByteSharp/0.0.2) or Clone/Compile this solution.

Features:

 * Finding bytes via ID or Name.
 * Getting the newest, or most popular byte feeds, and paging through them.
 * Sending comments, stars, and flags on bytes.
 * Checking and validating names for bytes.
 * Checking and setting your current user status and account status.
 * Creating and logging in users.

Currently under development/known issues:
 * Creating new bytes
 * Editing existing bytes
 * Sending new files/images up to the byte servers.

# Basic Usage

### Creating new user/logging in

```csharp
var authManager = new AuthManager(new WebManager());
// The library automatically parses phone numbers for you,
// but you can format it yourself to match E.164 standards.
var phoneNumber = "555 555 5555";
var codeResult = await authManager.RequestCodeAsync(phoneNumber);
var code = "Code gotten from phone SMS";
var authResult = await authManager.RegisterAsync(phoneNumber, code);
```

This will create a new user and return an authentication token. This token must be used for every other manager in order for the user to do anything.

### Get names
Names are URLs for Byte. It is either set by the user or created on the server. In order to get a random URL that has not been taken, you can call this manager to both get a list of names, as well as validate them.

```csharp
var nameManager = new NameManager(new WebManager("AuthToken"));
var result = await nameManager.GetNamesAsync();
Console.WriteLine($"First Generated Name: {result.Data.Names.First()}");
var validResult = await nameManager.ValidateNameAsync(result.Data.Names.First());
Console.WriteLine($"Is Valid: {validResult.Data.Ok} ");
```

### Get User Status/Account Information

Once the user creates an account, you can check on their status and view the devices they have registered, as well as set some additional parameter fields.

```csharp
var userManager = new UserManager(_webManager);
var result = await userManager.GetAccountAsync();
Console.WriteLine($"User Id: {result.Data.Id}");
Console.WriteLine($"Description: {result.Data.Description}");

var status = await userManager.GetStatusAsync();
Console.WriteLine($"Latest Message: {status.Data.LatestMessageString}");
Console.WriteLine($"Description: {status.Data.Description}");
Console.WriteLine("Write new description: ");
var des = Console.ReadLine();

var newAccountResult = await userManager.UpdateAccountAsync(des);
Console.WriteLine($"New Description: {newAccountResult.Data.Description}");
```

### Get posts

Currently you can get the newest bytes, the more popular bytes, or the current users bytes. You can also search for them by name or id.

```csharp
var postManager = new PostManager(_webManager);
var result = await postManager.GetLatestPostsAsync();
var result2 = await postManager.GetPopularPostsAsync();
var posts = result.Data.Posts;
Console.WriteLine(posts.First().Name);
var firstPostByName = await postManager.GetPostByNameAsync(posts.First().Name);
Console.WriteLine(firstPostByName.Data.Post.Name);
```

### Contribute

If you want to contribute to this project (Any little bit helps!) then just fork this project and submit a pull request.

You need to have Visual Studio 2015, and the [Nubuild Project System](https://visualstudiogallery.msdn.microsoft.com/3efbfdea-7d51-4d45-a954-74a2df51c5d0).
