using CoreGenericRepo.Models.DTO;
using CoreGenericRepo.Models.Entity;
using CoreGenericRepo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreGenericRepo.Controllers
{
    public class MovieController : Controller
    {
        private IBaseRepository<Movie> repo;
        private IBaseRepository<MovieType> mtRepo;
        private 
        MovieVM mvm = new MovieVM();
        public MovieController(IBaseRepository<Movie> _repo, IBaseRepository<MovieType> _mtrepo)
        {
            repo = _repo;
            mtRepo = _mtrepo;
        }
        public IActionResult Index()
        {
            mvm.mList = repo.List();
            mvm.mtList = mtRepo.List();

           return View(mvm);
        }
        public IActionResult Insert()
        {
            mvm.mtList = mtRepo.List();
            return View(mvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(MovieVM model)
        {
            if (model.Movies != null)
            {
                if (model.Movies.MovieImage == null)
                {
                    model.Movies.MovieImage = "default.jpg";
                }
                repo.Add(model.Movies);
                repo.Save();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            if (id != 0)
            {
                mvm.Movies = repo.Find(id);
                mvm.mtList = mtRepo.List();
            }
            return View(mvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, MovieVM model)
        {
            if (ModelState.IsValid)
            {
                Movie selectedm = repo.Find(id);

                if(model.Movies.MovieImage == null)
                {
                    selectedm.MovieImage = "default.jpg";
                }
                else
                {
                    selectedm.MovieImage = model.Movies.MovieImage;
                }
                selectedm.MovieName = model.Movies.MovieName;
                selectedm.MovieDescription = model.Movies.MovieDescription;              
                selectedm.MovieTypeID = model.Movies.MovieTypeID;
                repo.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                mvm.Movies = repo.Find(id);
                repo.Delete(mvm.Movies);
                repo.Save();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            mvm.Movies = repo.Find(id);
            mvm.mtList = mtRepo.List();

            return View(mvm);
        }
    }
}
