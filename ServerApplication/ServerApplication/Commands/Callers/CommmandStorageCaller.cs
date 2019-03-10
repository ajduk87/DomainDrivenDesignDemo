using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace ServerApplication.Commands.Callers
{
    public class CommmandStorageCaller
    {
        private IContainer container;

        public CommmandStorageCaller(IContainer container)
        {
            this.container = container;
        }

        public void HandleRequest(long numberOfRequest, Request rq)
        {
            ICommand command = container.ResolveKeyed<ICommand>(typeof(CommmandStorage));
            command.Execute(numberOfRequest, rq);
        }
    }
}
