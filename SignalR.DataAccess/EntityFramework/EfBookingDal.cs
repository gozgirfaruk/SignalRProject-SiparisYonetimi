using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccess.EntityFramework
{
	public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

		public void BookingStatusApproved(int id)
		{
			using var context = new SignalRContext();
			var values = context.Bookings.Where(x => x.BookingID == id).FirstOrDefault();
			values.Description = "Rezervasyon Kabul Edildi";
			context.SaveChanges();
		}

		public void BookingStatusCancel(int id)
		{
			using var context = new SignalRContext();
			var values = context.Bookings.Where(x => x.BookingID == id).FirstOrDefault();
			values.Description = "Rezervasyon İptal Edildi";
			context.SaveChanges();
		}
	}
}
