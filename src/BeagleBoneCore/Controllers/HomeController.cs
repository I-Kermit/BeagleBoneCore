using BeagleBoneCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeagleBoneCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly DmxService _dmxService;
        // MOVE THIS!
        private static readonly object Object = new object();

        public HomeController(DmxService dmxService)
        {
            _dmxService = dmxService;
//            var dbContext = new ApplicationDbContext();
//
//            var dmxData = dbContext.DmxDatas.Find(1);
//
//            if (dmxData == null)
//            {
//                //return HttpNotFound();
//            }
//
//            if (dmxData == null) return;
//            ViewBag.IpAddress = dmxData.DmxSocket.IpAddress;
//            ViewBag.Port = dmxData.DmxSocket.Port;

            ViewBag.IpAddress = _dmxService.GetDefaultIpAddress();
            ViewBag.Port = _dmxService.GetDefaultPort();
        }

        public IActionResult Index()
        {
            return View();
        }

        // Post back handler.
        [HttpPost]
        public ActionResult Program(string dmxValues)
        {
            //if (!MvcApplication.Skt.Client.Connected) return null;
            lock (Object)
            {
                if (!_dmxService.SocketConnected()) return null;

                _dmxService.AddToQueue(dmxValues);
                //MvcApplication.DmxValuesQueue.Enqueue(dmxValues);
                _dmxService.LogWriteLine(dmxValues);
                //MvcApplication.Log.WriteLine(dmxValues);

                //while (MvcApplication.DmxValuesQueue.Count != 0)
                while (_dmxService.GetQueueCount() != 0)
                {
                    //MvcApplication.Skt.Client.Send(Encoding.ASCII.GetBytes(MvcApplication.DmxValuesQueue.Dequeue()));
                    //MvcApplication.Skt.Client.Send(Encoding.ASCII.GetBytes(_dmxService.GetFromQueue()));
                    _dmxService.PostDmxData();
                }
            }
            return View();
            //return null;
        }

        // GET: StudioDue
        public ActionResult Program()
        {
            return View();
        }

        // GET: StudioDue
//        public ActionResult Debug()
//        {
//            return View();
//        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
