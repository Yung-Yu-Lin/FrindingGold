using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;

namespace Gold_Application.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetGoldPrice(string Url)
        {
            string strResult = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);

            //聲明一個HttpWebRequest請求

            request.Timeout = 30000;

            //設置連接逾時時間

            request.Headers.Set("Pragma", "no-cache");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream streamReceive = response.GetResponseStream();

            Encoding encoding = Encoding.GetEncoding("UTF-8");

            StreamReader streamReader = new StreamReader(streamReceive, encoding);

            strResult = streamReader.ReadToEnd();

            HtmlDocument doc = new HtmlDocument();

            doc.LoadHtml(strResult);

            HtmlNodeCollection nameNodes = doc.DocumentNode.SelectNodes(@"//td[@class='right']");

            string[] GoldPrice = new string[nameNodes.Count];

            for(var i = 0; i < nameNodes.Count;i++)
            {
                GoldPrice[i] = nameNodes[i].InnerHtml;
            }

            return Json(GoldPrice, JsonRequestBehavior.AllowGet);
        }
    }
}