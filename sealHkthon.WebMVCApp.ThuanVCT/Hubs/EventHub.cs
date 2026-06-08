using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage;
using sealHkthon.Entities.ThuanVCT.Models;
using sealHkthon.Services.ThuanVCT;

namespace sealHkthon.WebMVCApp.ThuanVCT.Hubs
{
    public class EventHub : Hub
    {
        private readonly IEventsThuanVctService _eventsThuanVct;

        public EventHub(
            IEventsThuanVctService eventsThuanVctService)
        {
            _eventsThuanVct = eventsThuanVctService;
        }

        //edit
        public async Task HubUpdateEvent(string eventJsonString)
        {
            var newEvent = JsonSerializer.Deserialize<EventsThuanVct>(eventJsonString);
            try
            {
                await _eventsThuanVct.UpdateAsync(newEvent);
            }
            catch (Exception ex) { }
            await Clients.All.SendAsync("Reciver_EventEdited", newEvent);
        }

        // create
        public async Task HubCreateEvent(string eventJsonString)
        {
            var newEvent = JsonSerializer.Deserialize<EventsThuanVct>(eventJsonString);
            await _eventsThuanVct.CreateAsync(newEvent);
            await Clients.All.SendAsync("Reciver_EventCreated", newEvent);
        }

        // delete 
        public async Task HubDeleteEvent(int eventId)
        {
            await _eventsThuanVct.DeleteAsync(eventId);
            await Clients.All.SendAsync("Reciver_EventDeleted", eventId);
        }

    }
}
