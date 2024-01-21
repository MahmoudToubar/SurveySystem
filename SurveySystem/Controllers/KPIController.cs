using Microsoft.AspNetCore.Mvc;
using SurveySystem.Models;
using SurveySystem.Repositories;

namespace SurveySystem.Controllers
{
    public class KPIController : Controller
    {
        private readonly IKPIRepository kpiRepository;

        public KPIController(IKPIRepository kpiRepository) 
        {
            this.kpiRepository = kpiRepository;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(TblKPI addKpi)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            var kpi = new TblKPI
            {
                KPIDNum = addKpi.KPIDNum,
                DepNo = addKpi.DepNo,
                KPIDescription = addKpi.KPIDescription,
                MeasurementUnit = addKpi.MeasurementUnit,
                TargetedValue = addKpi.TargetedValue
            };

            await kpiRepository.AddAsync(kpi);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var kpi = await kpiRepository.GetAsync(id);

            if (kpi != null)
            {
                var editKpi = new TblKPI
                {
                    KPIDNum = kpi.KPIDNum,
                    DepNo = kpi.DepNo,
                    KPIDescription = kpi.KPIDescription,
                    MeasurementUnit = kpi.MeasurementUnit,
                    TargetedValue = kpi.TargetedValue
                };

                return View(editKpi);

            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TblKPI editKpi)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Edit");
            }
            var kpi = new TblKPI
            {
                KPIDNum = editKpi.KPIDNum,
                DepNo = editKpi.DepNo,
                KPIDescription = editKpi.KPIDescription,
                MeasurementUnit = editKpi.MeasurementUnit,
                TargetedValue = editKpi.TargetedValue
            };

            var updatedKpi = await kpiRepository.UpdateAsync(kpi);

            if (updatedKpi != null)
            {
                return RedirectToAction("Index", "Home");
            }

            else
            {
                return RedirectToAction("Edit");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(TblKPI editKpi)
        {
            var deletedKpi = await kpiRepository.DeleteAsync(editKpi.KPIDNum);

            if (deletedKpi != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Edit", new { id = editKpi.KPIDNum });

        }

    }
}
