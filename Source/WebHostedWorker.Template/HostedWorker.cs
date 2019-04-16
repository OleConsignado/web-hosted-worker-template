using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Otc.HostedWorker.Abstractions;

namespace WebHostedWorker.Template
{
    /// <summary>
    /// This class implements the HostedWorker. 
    /// By pulling the trigger (POST /v1/Trigger/Pull), 
    /// <see cref="HostedWorker.WorkAsync(CancellationToken)"/> will 
    /// run in background.
    /// </summary>
    public class HostedWorker : IHostedWorker
    {
        private readonly ILogger logger;
        private const int WorkIterations = 10;
        private const int WorkLoopIterationDelay = 1000;

        public bool HasPendingWork { get; set; }

        public HostedWorker(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory?.CreateLogger<HostedWorker>() ?? throw new System.ArgumentNullException(nameof(loggerFactory));
        }

        public async Task WorkAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("WorkAsync begin.");

            try
            {
                for (int i = 0; i < WorkIterations; i++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        throw new OperationCanceledException($"Operation was canceled, perfomed {i} iterations of {WorkIterations}.", cancellationToken);
                    }

                    logger.LogInformation("WorkAsync iteration #{IterationIndex}", i);

                    await Task.Delay(WorkLoopIterationDelay);
                }
            }
            catch (OperationCanceledException e)
            {
                logger.LogWarning(e, "Cacelation requested.");
            }

            logger.LogInformation("WorkAsync end.");
        }
    }
}
