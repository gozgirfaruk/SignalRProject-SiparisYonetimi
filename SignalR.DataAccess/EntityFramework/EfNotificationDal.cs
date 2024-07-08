using Microsoft.EntityFrameworkCore;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccess.EntityFramework
{
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		public EfNotificationDal(SignalRContext context) : base(context)
		{
		}

        public void ChangeToRead(int id)
        {
			using var context = new SignalRContext();
			var values = context.Notifications.Find(id);
			values.Status = true;
			context.SaveChanges();
        }

        public void ChangeToUnRead(int id)
        {
            using var context = new SignalRContext();
            var values = context.Notifications.Find(id);
            values.Status = false;
            context.SaveChanges();
        }

        public List<Notification> GetNotificationContentUnRead()
		{
			using var context = new SignalRContext();
			var values =context.Notifications.Where(x=>x.Status==false).ToList();
			return values;
		}

		public int NotificationByUnRead()
		{
			using var context= new SignalRContext();
			return context.Notifications.Where(x=>x.Status==false).Count();
		}
	}
}
