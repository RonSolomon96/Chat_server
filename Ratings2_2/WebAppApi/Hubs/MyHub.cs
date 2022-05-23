using Microsoft.AspNetCore.SignalR;

namespace WebAppApi.Hubs
{
    public class MyHub : Hub
    {
        public async Task addCont(string username)
        {
            await Clients.All.SendAsync("contactAdded",username); 
        }
    }
}
