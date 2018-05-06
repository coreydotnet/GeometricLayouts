
namespace GeometricLayouts
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// Main entry into web application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Runs the web host.
        /// </summary>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Builds the web host.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
