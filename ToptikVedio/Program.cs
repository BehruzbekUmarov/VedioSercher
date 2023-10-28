using Telegram.Bot.Polling;
using Telegram.Bot;
using ToptikVedio.Services.Handlers;
using ToptikVedio.Services;
using ToptikVedio.Options;
using ToptikVedio.Services.Client;

const string BotKeyConfigKey = "BotKey";

var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetValue(BotKeyConfigKey, "");
builder.Services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(token!));
builder.Services.AddHostedService<BotBackgroundService>();
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();
builder.Services.Configure<Option>(builder.Configuration.GetSection("Pixel"));
var app = builder.Build();

app.Run();
