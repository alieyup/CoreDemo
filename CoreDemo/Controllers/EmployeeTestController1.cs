using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Controllers
{
    public class EmployeeTestController1 : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("");
            var jsonString=await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }
        public class Class1 {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
}
