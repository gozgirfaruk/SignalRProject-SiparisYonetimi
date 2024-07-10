﻿using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public  IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator createqrCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squareCode = createqrCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                using(Bitmap image = squareCode.GetGraphic(10))
                {
                    image.Save(memoryStream,ImageFormat.Png);
                    ViewBag.qrCodeImage="data:image/png;base64,"+Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return View();
        }
    }
}
