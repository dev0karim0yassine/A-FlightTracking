using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Web.ViewModels;
using Web.Extensions;

namespace Web.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightRepository flightRepository;
        private readonly IPlaneRepository planeRepository;
        private readonly IAirportRepository airportRepository;
        CreateFlightViewModel FlightViewModel;

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
            List<Flight> flights = flightRepository.GetFlights().ToList();

            flights.ForEach(f =>
            {
                f = f.MapListFlight(
                    planeRepository.LoadFake().FirstOrDefault(p => p.Id.Equals(f.PlaneId)),
                    airportRepository.LoadFake().FirstOrDefault(a => a.Id.Equals(f.CheckInAirportId)),
                    airportRepository.LoadFake().FirstOrDefault(a => a.Id.Equals(f.CheckOutAirport)));
            });

            return View(flights);
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            FlightViewModel = FlightViewModel.InitFlightViewModel(planeRepository.LoadFake(), airportRepository.LoadFake());

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

            flightRepository.BookFlight(Flight);
            return RedirectToAction("Index");
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            var flight = flightRepository.GetFlight(id);
            FlightViewModel = flight.MapDetailsFlight(planeRepository.LoadFake(), airportRepository.LoadFake());

            return View(FlightViewModel);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Flight Flight)
        {
            if (!ModelState.IsValid)
            {
                return View(Flight);
            }

            flightRepository.EditFlight(id, Flight);
            return RedirectToAction("Index");
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            var flight = flightRepository.GetFlight(id);
            DetailsFlightViewModel viewModel = flight.MapDetailsFlightViewModel(
                flightRepository.CalculateDistance(flight.CheckInAirport, flight.CheckOutAirport),
                flightRepository.CalculateEffortTakeOff(flight.Plane),
                flightRepository.CalculateFlightTime(flight.FlightTakeOffTime, flight.FlightLandingTime),
                flight.Plane.Name,
                flight.CheckInAirport.Name, 
                flight.CheckOutAirport.Name);
                
            return View(viewModel);
        }
    }
}
