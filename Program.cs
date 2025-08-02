using ImageProcessorApp.Configurations;
using ImageProcessorApp.Interfaces;
using ImageProcessorApp.Plugins;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ImageProcessingOptions>(
    builder.Configuration.GetSection("ImageProcessing"));

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddSingleton<IImageProcessor, ImageProcessor>();
builder.Services.AddScoped<IImageProcessingService, ImageProcessingService>();

builder.Services.AddSingleton<IImagePlugin, BlurPlugin>();
builder.Services.AddSingleton<IImagePlugin, GrayscalePlugin>();
builder.Services.AddSingleton<IImagePlugin, ResizePlugin>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();