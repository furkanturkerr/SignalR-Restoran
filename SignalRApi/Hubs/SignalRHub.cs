using BusinessLayer.Abstract;
using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.SignalR;

namespace SignalRApi.Hubs;

public class SignalRHub: Hub
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;
    private readonly IMoneyCaseService _moneyCaseService;
    private readonly IMenuTableService _menuTableService;
    private readonly IBookingService _bookingService;
    private readonly INotificationService _notificationService;
    
    public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService , IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _orderService = orderService;
        _moneyCaseService = moneyCaseService;
        _menuTableService = menuTableService;
        _bookingService  = bookingService;
        _notificationService = notificationService;
    }

    public async Task SendStatistic()
    {
        var value1 = _categoryService.TCategoryCount();
        await Clients.All.SendAsync("ReceiveCategoryCount", value1);
        
        var value2 = _productService.TProductCount();
        await Clients.All.SendAsync("ReceiveProductCount", value2);
        
        var value3 = _categoryService.TActiveCategoryCount();
        await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);
        
        var value4 = _categoryService.TPassiveCategoryCount();
        await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

        var value5 = _productService.TProductCountByCategoryNameHamburger();
        await Clients.All.SendAsync("ReceiveProductCountByHamburger", value5);
        
        var value6 = _productService.TProductCountByCategoryNameDrink();
        await Clients.All.SendAsync("ReceiveProductCountDrink", value6);
        
        var value7 = _productService.TProductPriceAvg();
        await Clients.All.SendAsync("ReceiveProductPriveAvg", value7.ToString("0.00"+"₺"));
        
        var value8 = _productService.TProducNameByPriceMax();
        await Clients.All.SendAsync("ReceiveProductNameByPriceMax", value8);
        
        var value9 = _productService.TProducNameByPriceMin();
        await Clients.All.SendAsync("ReceiveProductNameByPriceMin", value9);
        
        var value10 = _productService.TProductPriceByHamburger();
        await Clients.All.SendAsync("ReceiveProductPriceByHamburger", value10);

        var value11 = _orderService.TTotalOrderCount();
        await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);
        
        var value12 = _orderService.TActiveOrderCount();
        await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);
        
        var value13 = _orderService.TLastOrderTotalPrice();
        await Clients.All.SendAsync("ReceiveLastOrderTotalPrice", value13.ToString("0.00"+"₺"));
        
        var value14 = _moneyCaseService.TMoneyCaseTotalPrice();
        await Clients.All.SendAsync("ReceiveMoneyCaseTotalPrice", value14.ToString("0.00"+"₺"));
        
        var value16 = _menuTableService.MenuTableCount();
        await Clients.All.SendAsync("ReceiveMenuTableCount", value16);
    }
    
    public async Task SendProgress()
    {
        var value = _moneyCaseService.TMoneyCaseTotalPrice();
        await Clients.All.SendAsync("ReceiveMoneyCaseTotalPrice", value.ToString("0.00" + "₺"));
        
        var value2 = _menuTableService.MenuTableCount();
        await Clients.All.SendAsync("ReceiveMenuTableCount", value2);
        
        var value3 = _orderService.TActiveOrderCount();
        await Clients.All.SendAsync("ReceiveActiveOrderCount", value3);
    }

    public async Task GetBookingList()
    {
        var values = _bookingService.TGetListAll();
        await Clients.All.SendAsync("ReceiveBookingList", values);
    }

    public async Task SendNotificationList()
    {
        var values = _notificationService.TNotificationCountByStatusFalse();
        await Clients.All.SendAsync("ReceiveNotificationFalseList", values);
    }
}