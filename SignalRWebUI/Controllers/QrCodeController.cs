using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace SignalRWebUI.Controllers;

public class QrCodeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            ViewBag.QrCodeImage = null;
            return View();
        }

        using var generator = new QRCodeGenerator();
        using QRCodeData qrCodeData = generator.CreateQrCode(value, QRCodeGenerator.ECCLevel.L);

        // System.Drawing yerine: PNG byte üret
        var pngQr = new PngByteQRCode(qrCodeData);
        byte[] pngBytes = pngQr.GetGraphic(pixelsPerModule: 10);

        ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(pngBytes);
        return View();
    }
}