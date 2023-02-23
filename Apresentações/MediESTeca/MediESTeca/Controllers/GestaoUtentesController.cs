using MediESTeca.Areas.Identity.Data;
using MediESTeca.Data;
using MediESTeca.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediESTeca.Controllers
{
    [Authorize(Roles = "admins")]
    public class GestaoUtentesController : Controller
    {
        private readonly MediESTecaComIdentityContext _context;
        private readonly UserManager<Utente> _userManager;

        public GestaoUtentesController(MediESTecaComIdentityContext context,
            UserManager<Utente> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: GestaoUtentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: GestaoUtentes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(new UtenteEditViewModel()
            {
                Id = user.Id,
                Email = user.Email,

                // Include the Utente info:
                Nome = user.Nome,
                Telefone = user.Telefone
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Email,Nome,Telefone")] UtenteEditViewModel editUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return NotFound();
                }

                user.UserName = editUser.Email;
                user.Email = editUser.Email;
                user.Nome = editUser.Nome;
                user.Telefone = editUser.Telefone;

                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First().Description);
                    return View();
                }

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something failed.");
            return View();
        }

        // GET: GestaoUtentes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        // POST: GestaoUtentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return BadRequest();
                }

                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First().Description);
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
