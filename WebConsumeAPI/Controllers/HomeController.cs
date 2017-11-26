using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebConsumeAPI.Controllers
{
    public class HomeController : Controller
    {

        //Hosted web API REST Service base url  
        string Baseurl = "http://192.168.1.10/LocalAPI/";
        public async Task<ActionResult> Index()
        {
            List<Models.cOrders> Orders = new List<Models.cOrders>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer m6G4ED9ssrPwH9G9ZpFadGFJ6JxW9WtkzARaIDrRwys5BaGou6sXe2ds85aJ2mj5WTMOC2TBULFWWctZ6q6XRv3Zln_D1YpvxFT67zzvo49i0E-n8OMkBE13gIPvdwZB9IFdP4eXEUQyjG5aMMK1GpAQls7NbtSeKjOKs9lZr4uhpEycK9onqcgbV0jV30zownqBEAQC_qzuEYluvf1IxIP1MjmfrUD2uN1KyccvKR44kS2KhqiHR8vGOOwEERKQG2sR486C1owslbvu2Ov2abfLLKirTo8Mk5vXLfSEJB4qtgvKHyqcOKmJD-WE9hVWhTqkDzTAl2re9HMf-Bqp1WwFvNIvW_QhuBW_CVULPYIM9cHrCZKACnA8GIXCWdoOyQdENysa4aUZ5wuUqhj19K2w_qlZGsBai1Mos_O70NyRfHUGfAiy1up5YqKnFIdO2I5YawPnhN0euj2J7iFTUCQF6cxCua1gLoZU04tF9II");

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Hope");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing t                    //EmpInfo = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);he response recieved from web api and storing into the Employee list  
                    //Orders = JsonConvert.DeserializeObject<List<Models.cOrders>>(EmpResponse);
                    DataSet dsResult = JsonConvert.DeserializeObject<DataSet>(EmpResponse);

                }
                //returning the employee list to view  
                return View();
            }
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}