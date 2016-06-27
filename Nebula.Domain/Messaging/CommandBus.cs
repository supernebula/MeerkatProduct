using System;
using Nebula.Domain.Commands;

namespace Nebula.Domain.Messaging
{
    public class CommandBus : ICommandBus
    {
        public ICommandHandlerFactory CommandHandlerFactory { get; set; }
        public void Send<T>(T command) where T : Command
        {
            var commandHandler = CommandHandlerFactory.GetHandler<T>();
            try
            {
                //translation.open()
                commandHandler.Execute(command);
            }
            catch (Exception ex)
            {
                //log(ex)
                //db.RollBack()
                throw;
            }
            
        }
    }
}
