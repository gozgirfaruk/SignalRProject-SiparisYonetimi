using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class BookingMenager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingMenager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

		public void TBookingStatusApproved(int id)
		{
            _bookingDal.BookingStatusApproved(id);
		}

		public void TBookingStatusCancel(int id)
		{
			_bookingDal.BookingStatusCancel(id);
		}

		public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public Booking TGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public List<Booking> TGetListAll()
        {
            return _bookingDal.GetListAll();
        }

        public void TInsert(Booking entity)
        {
            _bookingDal.Insert(entity);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
