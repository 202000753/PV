using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApiClient.Models;
using System.Net;

namespace StudentWebApiClient.Controllers
{
    public class StudentsController : Controller
    {
        private HttpClient _httpClient;

        public StudentsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5212");
        }
        // GET: StudentsController
        public async Task<ActionResult> Index()
        {
            List<Student> students = new List<Student>();

            HttpResponseMessage response = await _httpClient.GetAsync("api/students");

            if (response.IsSuccessStatusCode)
            {
                students = await response.Content.ReadAsAsync<List<Student>>();
            }

            return View(students);
        }

        // GET: StudentsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Student student = null;

            HttpResponseMessage response = await _httpClient.GetAsync($"api/students/{id}");
            if (response.IsSuccessStatusCode)
            {
                student = await response.Content.ReadAsAsync<Student>();
            }

            return View(student);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("StudentId,Name,Number")] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/students", student);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: StudentsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Student student = null;

            HttpResponseMessage response = await _httpClient.GetAsync($"api/students/{id}");
            if (response.IsSuccessStatusCode)
            {
                student = await response.Content.ReadAsAsync<Student>();
            }

            return View(student);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("StudentId,Name,Number")] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/students/{student.StudentId}", student);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }

            }
            return View(student);
        }

        // GET: StudentsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Student student = null;

            HttpResponseMessage response = await _httpClient.GetAsync($"api/students/{id}");
            if (response.IsSuccessStatusCode)
            {
                student = await response.Content.ReadAsAsync<Student>();
            }

            return View(student);
        }

        // POST: StudentsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/students/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return BadRequest();
        }
    }
}
