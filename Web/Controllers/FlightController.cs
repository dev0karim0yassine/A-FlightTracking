using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightRepository flightRepository;
        private readonly IPlaneRepository planeRepository;
        private readonly IAirportRepository airportRepository;

        public FlightController(IFlightRepository _flightRepository
            , IPlaneRepository _planeRepository
            , IAirportRepository _airportRepository)
        {
            flightRepository = _flightRepository;
            planeRepository = _planeRepository;
            airportRepository = _airportRepository;
        }

        // GET: FlightController
        public ActionResult Index()
        {
            var flights = flightRepository.GetFlights();

            return View(flights);
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            var FlightViewModel = new CreateFlightViewModel
            {
                Planes = planeRepository.LoadFake(),
                CheckInAirport = airportRepository.LoadFake(),
                CheckOutAirport = airportRepository.LoadFake()
            };

            return View(FlightViewModel);
        }

        // POST: FlightController/Create
        [HttpPost]
        public ActionResult Create(Flight Flight)
        {
            if (!ModelState.IsValid)
            {
                return View(Flight);
            }

            return RedirectToAction("Index");
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
