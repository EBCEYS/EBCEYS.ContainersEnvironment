using EBCEYS.ContainersEnvironment.HealthChecks.Environment;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EBCEYS.ContainersEnvironment.HealthChecks.Extensions
{
    /// <summary>
    /// A <see cref="ServiceHealthCheckBuilderExtensions"/> class.
    /// </summary>
    public static class ServiceHealthCheckBuilderExtensions
    {
        /// <summary>
        /// Configures the service healthchecks api with <paramref name="port"/>.<br/>
        /// <see cref="IApplicationBuilder.ApplicationServices"/> should contain <see cref="PingServiceHealthStatusInfo"/> as <c>singleton</c>.<br/>
        /// Use <see cref="ConfigureHealthChecks(IServiceCollection)"/> before.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="port">The healthcheck server port.</param>
        /// <returns>The instance of <paramref name="app"/>.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IApplicationBuilder ConfigureHealthChecks(this IApplicationBuilder app, int port = HealthChecksEnvironmentVariables.StartingPort)
        {
            if (app.ApplicationServices.GetService<PingServiceHealthStatusInfo>() == null)
            {
                throw new InvalidOperationException($"{typeof(PingServiceHealthStatusInfo).Name} is not configured in service collection!");
            }
            return app.UseHealthChecks(ServiceHealthChecksRoutes.PingRoute, port, new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {
                Predicate = _ =>
                {
                    return true;
                },
                ResponseWriter = (ctx, healthReport) =>
                {
                    ctx.Response.StatusCode = StatusCodes.Status200OK;
                    ctx.Response.ContentType = "text/plain";
                    return ctx.Response.WriteAsync("pong");
                }
            })
            .UseHealthChecks(ServiceHealthChecksRoutes.HealthzRoute, port, new()
            {
                Predicate = _ => { return true; }
            }
            )
            .UseHealthChecks(ServiceHealthChecksRoutes.HealthzStatusRoute, port, new()
            {
                Predicate = _ => { return true; },
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            }
            );
        }
        /// <summary>
        /// Configures the service healthchecks api.<br/>
        /// <see cref="IApplicationBuilder.ApplicationServices"/> should contain <see cref="PingServiceHealthStatusInfo"/> as <c>singleton</c>.<br/>
        /// Use <see cref="ConfigureHealthChecks(IServiceCollection)"/>.<br/>
        /// Gets starting port from <see cref="HealthChecksEnvironmentVariables.HealthChecksPort"/>.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <returns>The instance of <paramref name="app"/>.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IApplicationBuilder ConfigureHealthChecks(this IApplicationBuilder app)
        {
            int port = HealthChecksEnvironmentVariables.HealthChecksPort.Value;
            return app.ConfigureHealthChecks(port);
        }
        /// <summary>
        /// Configures the healthcheck services.<br/>
        /// Adds <see cref="PingServiceHealthStatusInfo"/> as singleton.<br/>
        /// Adds <see cref="PingHealthCheck"/> as <see cref="IHealthCheck"/>.
        /// </summary>
        /// <param name="sc">The service collection.</param>
        /// <returns>The instance of <paramref name="sc"/>.</returns>
        public static IServiceCollection ConfigureHealthChecks(this IServiceCollection sc)
        {
            sc.AddSingleton<PingServiceHealthStatusInfo>();
            sc.AddHealthChecks().AddCheck<PingHealthCheck>(PingServiceHealthStatusInfo.HealthCheckName, HealthStatus.Unhealthy, [ServiceEnvironment.DefaultEnvironmentVariables.ContainerName.Value ?? string.Empty]);
            return sc;
        }
    }
}
