namespace Api.Controllers
{
    using Hangfire;
    using Microsoft.AspNetCore.Mvc;
    using Model;
    using System;

    [Route("api/commands")]
    [ApiController]
    public class JobController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(
            [FromBody] CreateJobCommand command)
        {
            string jobId = Guid.Empty.ToString();

            if(command.Timestamp.HasValue)
            {
                DateTimeOffset datetime = DateTimeOffset.FromUnixTimeSeconds(
                    command.Timestamp.Value);

                BackgroundJob.Schedule<JobHandler>(
                    x => x.Go(command.Url, command.Method, command.State),
                    datetime);
            }
            else
            {
                jobId = Guid.NewGuid().ToString();

                RecurringJob.AddOrUpdate<JobHandler>(
                    jobId,
                    x => x.Go(command.Url, command.Method, command.State),
                    command.Cron);
            }

            return Created(jobId, new { });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return UnprocessableEntity("Not implemented.");
        }
    }
}
