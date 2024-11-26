using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace RailTrip.Presentation.Controllers
{
    /// <summary>
    /// Represents the base API controller.
    /// Sets the route and provides ISender (MediatR).
    /// 
    /// Why are these controllers not defined in the RailTrip.WebApi project??
    /// Typically in the WebApi project, the service registrations for the DI container is done - which requires referencing most projects.
    /// With references to the infrastructure project for example, a controller can inject the dbContext for data access.
    /// Since there is no need to reference the infrastructure project in the RailTrip.Presentation (this) project, it isn't be possible to bypass the enforced CQRS implementation.
    /// This gives control over the desired architecture.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private ISender? _sender;

        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>()!;
    }
}
