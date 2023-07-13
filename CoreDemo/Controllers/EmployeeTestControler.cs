using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class EmployeeTestControler : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpclient = new HttpClient();
            var response = await httpclient.GetAsync("https://localhost:44311/api/Employees");
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(json);

            return View(values);
        }
        [HttpGet]
       public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 class1)
        {
            var httpclient = new HttpClient();
            var jsonEmployee=JsonConvert.SerializeObject(class1);
            StringContent content = new StringContent(jsonEmployee, System.Text.Encoding.UTF8, "application/json");
            var response = await httpclient.PostAsync("https://localhost:44311/api/Employees", content);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(class1);
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpclient = new HttpClient();
            var response = await httpclient.GetAsync("https://localhost:44311/api/Employees/id?id=" + Convert.ToString(id));
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(json);
                return View(values);
            }
            return RedirectToAction("Index");



        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 class1)
        {
            var httpclient = new HttpClient();
            var json = JsonConvert.SerializeObject(class1);
            StringContent stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await httpclient.PutAsync("https://localhost:44311/api/Employees", stringContent);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(class1);

        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpclient = new HttpClient();
            var response = await httpclient.DeleteAsync("https://localhost:44311/api/Employees/id?id=" + id);
            return RedirectToAction("Index");

        }

     }

    public class Class1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
