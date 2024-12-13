using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace CryptoExchange.Core.RequestResponse.BaseFramework
{
    public class CommandDispatcher : ICommandDispatcher
    {
        #region Fields
        private readonly IServiceProvider _serviceProvider;
        #endregion

        #region Constructors
        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        #endregion

        #region Send Commands
        public async Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            try
            {
                var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();

                return await handler.Handle(command);

            }
            catch (InvalidOperationException ex)
            {
                throw;
            }


        }

        public async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>
        {
            try
            {
                var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TData>>();
                return await handler.Handle(command);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #endregion
    }
}
