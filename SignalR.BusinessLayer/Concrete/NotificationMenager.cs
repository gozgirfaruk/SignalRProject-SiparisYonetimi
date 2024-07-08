using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class NotificationMenager : INotificationService
	{
		private readonly INotificationDal _notificationDal;

		public NotificationMenager(INotificationDal notificationDal)
		{
			_notificationDal = notificationDal;
		}

        public void TChangeToRead(int id)
        {
            _notificationDal.ChangeToRead(id);
        }

        public void TChangeToUnRead(int id)
        {
			_notificationDal.ChangeToUnRead(id);
        }

        public void TDelete(Notification entity)
		{
			_notificationDal.Delete(entity);
		}

		public Notification TGetById(int id)
		{
			return _notificationDal.GetById(id);
		}

		public List<Notification> TGetListAll()
		{
			return _notificationDal.GetListAll();
		}

		public List<Notification> TGetNotificationContentUnRead()
		{
			return _notificationDal.GetNotificationContentUnRead();
		}

		public void TInsert(Notification entity)
		{
			_notificationDal.Insert(entity);
		}

		public int TNotificationByUnRead()
		{
			return _notificationDal.NotificationByUnRead();
		}

		public void TUpdate(Notification entity)
		{
			_notificationDal.Update(entity);
		}
	}
}
