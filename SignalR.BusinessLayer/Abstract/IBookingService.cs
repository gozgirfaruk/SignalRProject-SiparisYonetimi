using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
		void TBookingStatusApproved(int id);
		void TBookingStatusCancel(int id);
	}
}
