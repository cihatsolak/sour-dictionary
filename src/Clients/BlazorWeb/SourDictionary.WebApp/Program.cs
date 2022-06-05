var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(serviceProvider => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("WebApiClient", httpClient =>
{
    string serviceUri = builder.Configuration.GetValue<string>("WebApiClient:ServiceUri");
    httpClient.BaseAddress = new Uri(serviceUri);
});

builder.Services.AddScoped(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient("WebApiClient");
});

await builder.Build().RunAsync();
