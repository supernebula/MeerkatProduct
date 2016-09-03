using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Nebula.Common.Repository;
using Nebula.Domain.Commands;
using Nebula.Domain.Data;

namespace Nebula.Domain.Messaging
{
    public class CommandBus : ICommandBus
    {
        [Dependency]
        public ICommandHandlerFactory CommandHandlerFactory { get; set; }

        [Dependency]
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
                UnitOfWork.BeginTransaction(new UnitOfWorkOptions() { IsolationLevel = IsolationLevel.ReadCommitted });
                //translation.open()
                commandHandler.Execute(command);
                UnitOfWork.Commit();
            }
            catch (Exception)
            {
                //log(ex)
                //db.RollBack()
                UnitOfWork.RollBack();
                throw;
            }
        }

        public async Task SendAsync<T>(T command) where T : Command
        {
            var commandHandler = CommandHandlerFactory.GetHandler<T>();
            try
            {
                UnitOfWork.BeginTransaction(new UnitOfWorkOptions() { IsolationLevel = IsolationLevel.ReadCommitted });
                //translation.open()
                await commandHandler.ExecuteAsync(command);
                UnitOfWork.Commit();
            }
            catch (Exception)
            {
                //log(ex)
                //db.RollBack()
                UnitOfWork.RollBack();
                throw;
            }
        }
    }
}
