using CoreGenericRepo.Models.DTO;
using CoreGenericRepo.Models.Entity;
using CoreGenericRepo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreGenericRepo.Controllers
{
    public class MovieTypeController : Controller
    {
        private IBaseRepository<MovieType> repo;
        MovieVM mtvm = new MovieVM();
        public MovieTypeController(IBaseRepository<MovieType> _repo)
        {
            repo = _repo;
        }
        public IActionResult Index()
        {
            return View(repo.List());
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(MovieVM model)
        {
                if(model.MovieTypes != null)
                {
                    repo.Add(model.MovieTypes);
                    repo.Save();
                }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            if(id != 0)
            { 
            mtvm.MovieTypes = repo.Find(id);
            }
            return View(mtvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, MovieVM model)
        {
            if (ModelState.IsValid)
            {
                MovieType selectedmt = repo.Find(id);
                if(model.MovieTypes.MovieTypeName != null || model.MovieTypes.MovieTypeName != string.Empty)
                {
                    selectedmt.MovieTypeName = model.MovieTypes.MovieTypeName;
                }
                repo.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public IActionResult Detail(int id)
        {
            mtvm.MovieTypes = repo.Find(id);

            return View(mtvm);
        }
        public IActionResult Delete(int id)
        {
            if(id != 0)
            { 
            mtvm.MovieTypes = repo.Find(id);
            repo.Delete(mtvm.MovieTypes);
            repo.Save();
            }
            return RedirectToAction("Index");
        }
    }
}
