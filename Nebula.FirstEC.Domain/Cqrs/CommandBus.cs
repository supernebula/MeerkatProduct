using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Common.Cqrs;

namespace Nebula.FirstEC.Domain.Cqrs
{
    public class CommandBus : ICommandBus
    {
        public ICommandHandlerFactory CommandHandlerFactory { get; set; }
        public void Send<T>(T command) where T : Command, new()
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
