﻿using System;
using Nebula.Common.Repository;
using Nebula.Domain.Commands;

namespace Nebula.Domain.Messaging
{
    public class CommandBus : ICommandBus
    {
        public ICommandHandlerFactory CommandHandlerFactory { get; set; }

        public IUnitOfWork UnitOfWork { get; set; }

        public CommandBus()
        {
        }

        public CommandBus(IUnitOfWork unitOfWork, ICommandHandlerFactory commandHandlerFactory)
        {
            UnitOfWork = unitOfWork;
            CommandHandlerFactory = commandHandlerFactory;
        }

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

        public void SendAsync<T>(T command) where T : Command
        {
            throw new NotImplementedException();
        }
    }
}
