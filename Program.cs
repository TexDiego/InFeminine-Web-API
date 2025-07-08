using InFeminine_Web_API;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddSingleton<StorageService>();

builder.Build();
