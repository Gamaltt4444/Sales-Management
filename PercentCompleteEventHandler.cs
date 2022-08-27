using Microsoft.SqlServer.Management.Smo;
using System;

namespace InventoryManagementSystem
{
    internal class PercentCompleteEventHandler
    {
        private object progressEventHandler;

        public PercentCompleteEventHandler(object progressEventHandler)
        {
            this.progressEventHandler = progressEventHandler;
        }

        public PercentCompleteEventHandler(Action<object, PercentCompleteEventArgs> progressEventHandler)
        {
            this.progressEventHandler = progressEventHandler;
        }
    }
}