using DbConnection.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbConnection.Controllers
{
	
	public class StudentController : Controller
	{
		private readonly UsbmContext context;
		public StudentController(UsbmContext context)
		{
			this.context = context;
		}

        

        public IActionResult Index()
		{
			var Data=context.Students.ToList();
			return View(Data);
		}

		public IActionResult Delete(int? id)
		{
			var Data = context.Students.Find(id);
			return View(Data);
		}

		
		public IActionResult DeleteUser(int StdId)
		{

			var Data = context.Students.Find(StdId);
			if (Data != null)
			{
				context.Students.Remove(Data);
			}

			context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Create()
		{
			return View();
		}

        public IActionResult InsertVal(Student Obj)
        {
            context.Students.Add(Obj);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id,[Bind("StdId,StdName,Age,City")]Student Obj)
        {
            var Data = context.Students.Find(id);
            return View(Data);
        }

        public IActionResult EditUser([Bind("StdId,StdName,Age,City")] Student Obj)
        {
            
            context.Update(Obj);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id)
        {
            var Data = context.Students.Find(id);
            return View(Data);
        }




    }
}
