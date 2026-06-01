using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage;
using sealHkthon.Services.ThuanVCT;

namespace sealHkthon.WebMVCApp.ThuanVCT.Hubs
{
    public class EventHub : Hub
    {
        //private readonly ITransactionEnlistmentManager _transactionEnlistmentManager;
        private readonly IEventsThuanVctService _eventsThuanVct;

        public EventHub(
            //ITransactionEnlistmentManager transactionEnlistmentManager, 
            IEventsThuanVctService eventsThuanVctService)
        {
            //_transactionEnlistmentManager = transactionEnlistmentManager;
            _eventsThuanVct = eventsThuanVctService;
        }

        // delete 
        public async Task HubDeleteEvent(int eventId)
        {
            // Enlist in the current transaction
            await _eventsThuanVct.DeleteAsync(eventId);

            // Perform the delete operation (this is just a placeholder, replace with actual logic)
            // For example, you might call a service to delete the event from the database
            // await _eventService.DeleteEventAsync(eventId);

            // Notify clients about the deletion
            await Clients.All.SendAsync("Reciver_EventDeleted", eventId);
        }
    }
}
