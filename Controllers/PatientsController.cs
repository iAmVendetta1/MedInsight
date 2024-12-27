using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedInsight.Models;
using Microsoft.Extensions.Logging;

namespace MedInsight.Controllers
{
    public class PatientsController : Controller
    {
        private readonly MedInsightDbContext _context;
        private readonly ILogger<PatientsController> _logger;

        public PatientsController(MedInsightDbContext context, ILogger<PatientsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Itching, SkinRash, NodalSkinEruptions, ContinuousSneezing, Shivering, Chills, JointPain, StomachPain, Acidity, UlcersOnTongue, " +
            "MuscleWasting, Vomiting, BurningMicturition, SpottingUrination, Fatigue, WeightGain, Anxiety, ColdHandsAndFeet, MoodSwings, WeightLoss, Restlessness, Lethargy, PatchesInThroat, " +
            "IrregularSugarLevel, Cough, HighFever, SunkenEyes, Breathlessness, Sweating, Dehydration, Indigestion, Headache, YellowishSkin, DarkUrine, Nausea, LossOfAppetite, PainBehindTheEyes, " +
            "BackPain, Constipation, AbdominalPain, Diarrhea, MildFever, YellowUrine, YellowingOfEyes, AcuteLiverFailure, SwellingOfStomach, SwelledLymphNodes, Malaise, BlurredAndDistortedVision, " +
            "Phlegm, ThroatIrritation, RednessOfEyes, SinusPressure, RunnyNose, Congestion, ChestPain, WeaknessInLimbs, FastHeartRate, PainDuringBowelMovements, PainInAnalRegion, BloodyStool, " +
            "IrritationInAnus, NeckPain, Dizziness, Cramps, Bruising, Obesity, SwollenLegs, SwollenBloodVessels, PuffyFaceAndEyes, EnlargedThyroid, BrittleNails, SwollenExtremeties, ExcessiveHunger, " +
            "ExtraMaritalContacts, DryingAndTinglingLips, SlurredSpeech, KneePain, HipJointPain, MuscleWeakness, StiffNeck, SwellingJoints, MovementStiffness, SpinningMovements, LossOfBalance, " +
            "Unsteadiness, WeaknessOfOneBodySide, LossOfSmell, BladderDiscomfort, FoulSmellOfUrine, ContinuousFeelOfUrine, PassageOfGases, InternalItching, ToxicLook_Typhos, Depression, Irritability, " +
            "MusclePain, AlteredSensorium, RedSpotsOverBody, BellyPain, AbnormalMenstruation, DischromicPatches, WateringFromEyes, IncreasedAppetite, Polyuria, FamilyHistory, MucoidSputum, RustySputum, " +
            "LackOfConcentration, VisualDisturbances, ReceivingBloodTransfusion, ReceivingUnsterileInjections, Coma, StomachBleeding, DistentionOfAbdomen, HistoryOfAlcoholConsumption, fluid_overload, " +
            "BloodInSputum, ProminentVeinsOnCalf, Palpitations, PainfulWalking, PusFilledPimples, Blackheads, Scurring, SkinPeeling, SilverLikeDusting, SmallDentsInNails, InflammatoryNails, Blister, " +
            "RedSoreAroundNose, YellowCrustOoze, Prognosis")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Fever,Cough,Fatigue,DifficultyBreathing,Age,Gender,BloodPressure,CholesterolLevel,DiseasePrediction")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
