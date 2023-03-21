using ControlDeMetas.Client;
using ControlDeMetas.Client.Contracts;
using ControlDeMetas.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

namespace ControlDeMetas.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTM4NDg0M0AzMjMwMmUzNDJlMzBpQVcwTzhuUnRKY0FqdTl0RXhnWTdXUjNnU0RBcUY2cjdJZzJldWhHTzRJPQ==;Mgo DSMBaFt/QHRqVVhkVFpHaV1FQmFJfFBmRGNTel16dVBWACFaRnZdQV1gS35RdEBgWHpYdXRQ;Mgo DSMBMAY9C3t2VVhkQlFacldJXnxLeUx0RWFab19wflBFal1UVBYiSV9jS31TdUdjW31bc3VQQGZZVA==;Mgo DSMBPh8sVXJ0S0J XE9AflRBQmFOYVF2R2BJfl56cVZMYVlBJAtUQF1hSn5QdEVhW3pdcXFTQWhZ;MTM4NDg0N0AzMjMwMmUzNDJlMzBjWGF4akQyYVFvL0JXYjhGNlF2c3ZDd1VkSnowOEFhdnUzSkcwRjNoL1hJPQ==;NRAiBiAaIQQuGjN/V0Z WE9EaFtKVmBWfFRpR2NbfE5xdF9DY1ZQQWY/P1ZhSXxQdkZhWX1cdXdUQ2ddUkE=;ORg4AjUWIQA/Gnt2VVhkQlFacldJXnxLeUx0RWFab19wflBFal1UVBYiSV9jS31TdUdjW31bc3VQQWJUVA==;MTM4NDg1MEAzMjMwMmUzNDJlMzBSQzNHYkE4WU43UGJsckV6RGVyeHEzck9MVVFBVkl3OVdZQzFEc3p3Q2tjPQ==;MTM4NDg1MUAzMjMwMmUzNDJlMzBvTjhpSHlnL1lOWHV4TTB3NnBQaTJHT25LWXRGWmlTemJ5b0hDVlNBZzRzPQ==;MTM4NDg1MkAzMjMwMmUzNDJlMzBXeVlGZXlUT1FJeHdBZkdKRHc2Um1yZXo3dVFTaWdLMk5ROVcyRmJXZm1ZPQ==;MTM4NDg1M0AzMjMwMmUzNDJlMzBJZGxrVEcydE0yNjlITWZ1N3JzUEYrSk9RSlhwL25IeUdxQ1ViUW5ZQ3ZFPQ==;MTM4NDg1NEAzMjMwMmUzNDJlMzBpQVcwTzhuUnRKY0FqdTl0RXhnWTdXUjNnU0RBcUY2cjdJZzJldWhHTzRJPQ==");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5188/") });
            builder.Services.AddTransient<MetaClientService>();
            builder.Services.AddTransient<TareaClientService>();
            builder.Services.AddSyncfusionBlazor();

            await builder.Build().RunAsync();
        }
    }
}