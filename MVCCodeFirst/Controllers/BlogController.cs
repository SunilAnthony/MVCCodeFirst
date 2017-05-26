using MVCCodeFirst.Context;
using MVCCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCCodeFirst.Controllers
{
    public class BlogController : Controller
    {
        BlogContext db = new BlogContext();
        // GET: Blog
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        // GET: Blog/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
                return HttpNotFound();
            return View(blog);
        }

        // GET: Blog/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Blogs.Add(blog);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(blog);
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
                return HttpNotFound();
            //Return the employee
            return View(blog);
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Blog blog)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Entry(blog).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                return View(blog);
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
                return HttpNotFound();
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Blog blog = new Blog();
                if(ModelState.IsValid)
                {
                    blog = db.Blogs.Find(id);
                    if (blog == null)
                        return HttpNotFound();
                    db.Blogs.Remove(blog);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(blog);
                
            }
            catch
            {
                return View();
            }
        }
    }
}
