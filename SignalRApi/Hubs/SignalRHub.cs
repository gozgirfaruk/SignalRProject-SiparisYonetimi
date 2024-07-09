using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccess.Concrete;
using System.Runtime.InteropServices;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}
        public static int clientCount { get; set; } = 0;
        public async Task SendStatistic()
		{
			var value = _categoryService.TGetCategoryCount();
			await Clients.All.SendAsync("ReceiverCategoryCount", value);

            var value2 = _productService.TGetProductCount();
            await Clients.All.SendAsync("ReceiverProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByHamburger();
            await Clients.All.SendAsync("ReceiverProductCountByHamburder", value5);

            var value6 = _productService.TProductCountByDrink();
            await Clients.All.SendAsync("ReceiverProductCountByDrink", value6);

            var value7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiverAvgProduct", value7.ToString("0.00") + "₺");

            var value8 = _productService.TProductPriceMax();
            await Clients.All.SendAsync("ReceiverProductPriceMax", value8);

            var value9 = _productService.TProductPriceMin();
            await Clients.All.SendAsync("ReceiverProductPriceMin", value9);

            var value10 = _productService.TProductPriceByHamburger();
            await Clients.All.SendAsync("ReceiverAvgByHambuger", value10.ToString("0.00"+"₺"));

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiverTotalOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiverActiveOrderCount", value12);

            var value13 = _orderService.TLastOrder();
            await Clients.All.SendAsync("ReceiverLastOrderPrice", value13.ToString("0.00"+"₺"));

            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiverTotalMoneyCaseAmount", value14.ToString("0.00" + "₺"));

            var value15 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiverMenuTableCount", value15);
        }

        public async Task SendProgress()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiverTotalMoneyCaseAmount", value.ToString("0.00")+"₺");

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiverActiveOrderCount", value2);

            var value3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiverMenuTableCount", value3);
        }

        public async Task GetBookingList()
        {
            var value = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiverBookingList", value);
        }

        public async Task SendNotification()
        {
            var value = _notificationService.TNotificationByUnRead();
            await Clients.All.SendAsync("ReceiverNotificationUnRead",value);

            var value2=_notificationService.TGetNotificationContentUnRead();
            await Clients.All.SendAsync("ReceiverContentNotification",value2);
        }
    
        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("ReceiverMessage",user,message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiverClientCount", clientCount);
           await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiverClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
