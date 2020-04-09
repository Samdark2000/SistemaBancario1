using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Techh_Onvi.Data;
using Techh_Onvi.Models;

namespace Techh_Onvi.Controllers
{
    public class TrasanctionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrasanctionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trasanctions
        public async Task<IActionResult> Index()
        {
            return View(await _context._Trasanction.ToListAsync());
        }



        // GET: Trasanctions/Create
        public async Task <IActionResult> AddOrEdit(int id = 0)
        {
            if(id == 0)

            return View(new Trasanction());
            else
            {
                var transactionModel = await _context._Trasanction.FindAsync(id);
                if(transactionModel == null)
                {
                    return NotFound();
                }
                return View(transactionModel);
            }
        }

      

     

        // POST: Trasanctions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TransactionId,AccountNumber,Beneficiario,BankName,SWIFTCode,Monto,date")] Trasanction trasanction)
        {

            if (ModelState.IsValid)
            {
                if(id == 0)
                {
                    trasanction.date = DateTime.Now;
                    _context.Add(trasanction);
                    await _context.SaveChangesAsync();
                   

                } else
                {
                    try
                    {
                        _context.Update(trasanction);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TrasanctionExists(trasanction.TransactionId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                }


                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this,"_ViewAll", _context._Trasanction.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", trasanction) });
        }

      

        // POST: Trasanctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trasanction = await _context._Trasanction.FindAsync(id);
            _context._Trasanction.Remove(trasanction);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context._Trasanction.ToList()) });
        }

        private bool TrasanctionExists(int id)
        {
            return _context._Trasanction.Any(e => e.TransactionId == id);
        }
    }
}
