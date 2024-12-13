using CryptoExchange.Core.RequestResponse.BaseFramework;
using CryptoExchange.Core.RequestResponse.Common;
using CryptoExchange.Endpoints.API.Extentions;
using Microsoft.AspNetCore.Mvc;


namespace CryptoExchange.Endpoints.API.Exchange;

public abstract class BaseController : Controller
{
    protected ICommandDispatcher CommandDispatcher => HttpContext.CommandDispatcher();

    protected IQueryDispatcher QueryDispatcher => HttpContext.QueryDispatcher();




    protected async Task<IActionResult> Create<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>
    {
        CommandResult<TCommandResult> commandResult = await CommandDispatcher.Send<TCommand, TCommandResult>(command);
        if (commandResult.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode(201, commandResult.Data);
        }

        return BadRequest(commandResult.Messages);
    }

    protected async Task<IActionResult> Create<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        CommandResult commandResult = await CommandDispatcher.Send(command);
        if (commandResult.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode(201);
        }

        return BadRequest(commandResult.Messages);
    }

    protected async Task<IActionResult> Edit<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>
    {
        CommandResult<TCommandResult> commandResult = await CommandDispatcher.Send<TCommand, TCommandResult>(command);
        if (commandResult.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode(200, commandResult.Data);
        }

        if (commandResult.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode(404, command);
        }

        return BadRequest(commandResult.Messages);
    }

    protected async Task<IActionResult> Edit<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        CommandResult commandResult = await CommandDispatcher.Send(command);
        if (commandResult.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode(200);
        }

        if (commandResult.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode(404, command);
        }

        return BadRequest(commandResult.Messages);
    }

    protected async Task<IActionResult> Delete<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>
    {
        CommandResult<TCommandResult> commandResult = await CommandDispatcher.Send<TCommand, TCommandResult>(command);
        if (commandResult.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode(200, commandResult.Data);
        }

        if (commandResult.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode(404, command);
        }

        return BadRequest(commandResult.Messages);
    }

    protected async Task<IActionResult> Delete<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        CommandResult commandResult = await CommandDispatcher.Send(command);
        if (commandResult.Status == ApplicationServiceStatus.Ok)
        {
            return StatusCode(200);
        }

        if (commandResult.Status == ApplicationServiceStatus.NotFound)
        {
            return StatusCode(404, command);
        }

        return BadRequest(commandResult.Messages);
    }

    protected async Task<IActionResult> Query<TQuery, TQueryResult>(TQuery query) where TQuery : class, IQuery<TQueryResult>
    {
        QueryResult<TQueryResult> queryResult = await QueryDispatcher.Execute<TQuery, TQueryResult>(query);
        if (queryResult.Status.Equals(ApplicationServiceStatus.InvalidDomainState) || queryResult.Status.Equals(ApplicationServiceStatus.ValidationError))
        {
            return BadRequest(queryResult.Messages);
        }

        if (queryResult.Status.Equals(ApplicationServiceStatus.NotFound) || queryResult.Data == null)
        {
            return StatusCode(204);
        }

        if (queryResult.Status.Equals(ApplicationServiceStatus.Ok))
        {
            return Ok(queryResult.Data);
        }

        return BadRequest(queryResult.Messages);
    }
}
