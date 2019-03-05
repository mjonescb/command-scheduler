namespace Api
{
    using Microsoft.AspNetCore.Builder;
    using Hangfire;

    public static class HangfireStartup
    {
        public static void UseHangfire(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();

            app.UseHangfireServer();
        }
    }
}