using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccess.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		SignalRContext _context=new SignalRContext();

		public async Task SendCategoryCount()
		{
			var value = _context.Categories.Count();
			await Clients.All.SendAsync("ReceiverCategoryCount", value);
		}
	}
}
