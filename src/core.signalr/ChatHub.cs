using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace core.signalr
{
	public class ChatHub : Hub
	{
		public async Task SendMessage(string user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
	}
}