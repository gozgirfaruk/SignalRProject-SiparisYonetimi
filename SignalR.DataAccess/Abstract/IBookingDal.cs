using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccess.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusApproved(int id);
        void BookingStatusCancel(int id);
    }
}
