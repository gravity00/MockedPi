using System.Net.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MockedPi.ExampleServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .Configure(app =>
                {
                    app.MapMock(
                        filter => filter
                            .WhenMethod(HttpMethod.Get)
                            .WhenPathStartsWithSegments("/mock01"),
                        then => then
                            .ApplyStatusCode(200)
                            .ApplyContent("Hello from Mock 01!"));

                    app.MapMock(
                        filter => filter
                            .WhenMethod(HttpMethod.Get)
                            .WhenPathEquals("/mock02"),
                        then => then
                            .ApplyStatusCode(404)
                            .ApplyContent("Hello from Mock 02!"));

                    app.Run(async ctx =>
                    {
                        await ctx.Response.WriteAsync(
                            "Hello from MockedPi.ExampleServer! Request did not match any configured mock!");
                    });
                });
    }
}
