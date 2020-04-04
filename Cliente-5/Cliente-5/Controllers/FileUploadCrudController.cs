using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Cliente_5.Models;
using System.IO;

namespace Cliente_5.Controllers
{
    public class FileUploadCrudController : Controller
    {
        private readonly ApplicationDbContext _adb;
        private readonly IWebHostEnvironment _iweb;

        public FileUploadCrudController(ApplicationDbContext adb, IWebHostEnvironment iwed)
        {
            _adb = adb;
            _iweb = iwed;
        }
        public IActionResult Index()
        {
            var displayImagen = _adb.Saveimg.ToList();
            return View(displayImagen);
        }

        [HttpPost]


        public async Task<ActionResult> Index(IFormFile fileobj, ImageCrudClass icc)
        {
            var imgext = Path.GetExtension(fileobj.FileName);
            if (imgext == ".jpg" || imgext == ".gif" || imgext == ".png" || imgext == ".pdf" || imgext == ".docx")
            {
                var uploadimg = Path.Combine(_iweb.WebRootPath, "Imagen", fileobj.FileName);
                var stream = new FileStream(uploadimg, FileMode.Create);
                await fileobj.CopyToAsync(stream);
                stream.Close();

                icc.Imgname = fileobj.FileName;
                icc.Imgpath = uploadimg;
                await _adb.Saveimg.AddAsync(icc);
                await _adb.SaveChangesAsync();

            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var displayimgdetails = await _adb.Saveimg.FindAsync(id);

            return View(displayimgdetails);

        }

        [HttpPost]

        public async Task<ActionResult> Edit(IFormFile fileobj, ImageCrudClass icc, string fname, int id)
        {
            if (ModelState.IsValid)
            {

                var getimagedetails = await _adb.Saveimg.FindAsync(id);
                _adb.Saveimg.Remove(getimagedetails);
                fname = Path.Combine(_iweb.WebRootPath, "Imagen", getimagedetails.Imgname);
                FileInfo fi = new FileInfo(fname);
                if (fi.Exists)
                {
                    System.IO.File.Delete(fname);
                    fi.Delete();
                }
            }



            var imgext = Path.GetExtension(fileobj.FileName);
            if (imgext == ".jpg" || imgext == ".gif" || imgext == ".png" || imgext == ".pdf" || imgext == ".docx")
            {
                var uploadimg = Path.Combine(_iweb.WebRootPath, "Imagen", fileobj.FileName);
                var stream = new FileStream(uploadimg, FileMode.Create);
                await fileobj.CopyToAsync(stream);
                stream.Close();

                icc.Imgname = fileobj.FileName;
                icc.Imgpath = uploadimg;
                _adb.Update(icc);
                await _adb.SaveChangesAsync();

            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var displayimgdetails = await _adb.Saveimg.FindAsync(id);

            return View(displayimgdetails);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var displayimgdetails = await _adb.Saveimg.FindAsync(id);

            return View(displayimgdetails);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string fname,int id)
        {
            var getimagedetails = await _adb.Saveimg.FindAsync(id);
            _adb.Saveimg.Remove(getimagedetails);
            fname = Path.Combine(_iweb.WebRootPath, "Imagen", getimagedetails.Imgname);
            FileInfo fi = new FileInfo(fname);
            if (fi.Exists)
            {
                System.IO.File.Delete(fname);
                fi.Delete();
            }
            await _adb.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Solicitud()
        {
            return View();
        }


        public IActionResult Calculadora()
        {
            return View();
        }
    }
}