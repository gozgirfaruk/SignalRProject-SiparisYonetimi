using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccess.Abstract
{
	public interface INotificationDal : IGenericDal<Notification>
	{
		int NotificationByUnRead();
		List<Notification> GetNotificationContentUnRead();
		void ChangeToRead(int id);
		void ChangeToUnRead(int id);
	}
}
