using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.System.Commands.LogErrors
{
    public class LogErrorCommand : IRequest
    {
        public string Message { get; set; }
    }

    public class LogErrorCommandHandler : IRequestHandler<LogErrorCommand>
    {
        private readonly ILogger<LogErrorCommandHandler> _logger;

        public LogErrorCommandHandler(ILogger<LogErrorCommandHandler> logger)
        {
            _logger = logger;
        }

        public Task<Unit> Handle(LogErrorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogError(request.Message);

            return Unit.Task;
        }
    }
}
