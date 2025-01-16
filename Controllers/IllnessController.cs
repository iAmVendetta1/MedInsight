using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedInsight.Models;
using Microsoft.Extensions.Logging;
using MedInsight.Services;

namespace MedInsight.Controllers
{
    public class IllnessController : Controller
    {
        private readonly MedInsightDbContext _context;
        private readonly ILogger<IllnessController> _logger;
        private readonly PredictionService _predictionService;

        public IllnessController(MedInsightDbContext context, ILogger<IllnessController> logger, PredictionService predictionService)
        {
            _context = context;
            _logger = logger;
            _predictionService = predictionService;
        }

        // GET: illness
        public async Task<IActionResult> Index()
        {
            return View(await _context.Illness.ToListAsync());
        }

        // GET: illness/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var illness = await _context.Illness
                .FirstOrDefaultAsync(m => m.Id == id);
            if (illness == null)
            {
                return NotFound();
            }

            return View(illness);
        }

        // GET: illness/Create
        public IActionResult Create()
        {
            var illness = new Illness();
            return View(illness);
        }

        // POST: illness/Create
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
    "RedSoreAroundNose, YellowCrustOoze")] Illness illness)
        {
            if (ModelState.IsValid)
            {
                int[] symptoms = new int[] { illness.Itching,
illness.SkinRash,
illness.NodalSkinEruptions,
illness.ContinuousSneezing,
illness.Shivering,
illness.Chills,
illness.JointPain,
illness.StomachPain,
illness.Acidity,
illness.UlcersOnTongue,
illness.MuscleWasting,
illness.Vomiting,
illness.BurningMicturition,
illness.SpottingUrination,
illness.Fatigue,
illness.WeightGain,
illness.Anxiety,
illness.ColdHandsAndFeet,
illness.MoodSwings,
illness.WeightLoss,
illness.Restlessness,
illness.Lethargy,
illness.PatchesInThroat,
illness.IrregularSugarLevel,
illness.Cough,
illness.HighFever,
illness.SunkenEyes,
illness.Breathlessness,
illness.Sweating,
illness.Dehydration,
illness.Indigestion,
illness.Headache,
illness.YellowishSkin,
illness.DarkUrine,
illness.Nausea,
illness.LossOfAppetite,
illness.PainBehindTheEyes,
illness.BackPain,
illness.Constipation,
illness.AbdominalPain,
illness.Diarrhea,
illness.MildFever,
illness.YellowUrine,
illness.YellowingOfEyes,
illness.AcuteLiverFailure,
illness.SwellingOfStomach,
illness.SwelledLymphNodes,
illness.Malaise,
illness.BlurredAndDistortedVision,
illness.Phlegm,
illness.ThroatIrritation,
illness.RednessOfEyes,
illness.SinusPressure,
illness.RunnyNose,
illness.Congestion,
illness.ChestPain,
illness.WeaknessInLimbs,
illness.FastHeartRate,
illness.PainDuringBowelMovements,
illness.PainInAnalRegion,
illness.BloodyStool,
illness.IrritationInAnus,
illness.NeckPain,
illness.Dizziness,
illness.Cramps,
illness.Bruising,
illness.Obesity,
illness.SwollenLegs,
illness.SwollenBloodVessels,
illness.PuffyFaceAndEyes,
illness.EnlargedThyroid,
illness.BrittleNails,
illness.SwollenExtremeties,
illness.ExcessiveHunger,
illness.ExtraMaritalContacts,
illness.DryingAndTinglingLips,
illness.SlurredSpeech,
illness.KneePain,
illness.HipJointPain,
illness.MuscleWeakness,
illness.StiffNeck,
illness.SwellingJoints,
illness.MovementStiffness,
illness.SpinningMovements,
illness.LossOfBalance,
illness.Unsteadiness,
illness.WeaknessOfOneBodySide,
illness.LossOfSmell,
illness.BladderDiscomfort,
illness.FoulSmellOfUrine,
illness.ContinuousFeelOfUrine,
illness.PassageOfGases,
illness.InternalItching,
illness.ToxicLook_Typhos,
illness.Depression,
illness.Irritability,
illness.MusclePain,
illness.AlteredSensorium,
illness.RedSpotsOverBody,
illness.BellyPain,
illness.AbnormalMenstruation,
illness.DischromicPatches,
illness.WateringFromEyes,
illness.IncreasedAppetite,
illness.Polyuria,
illness.FamilyHistory,
illness.MucoidSputum,
illness.RustySputum,
illness.LackOfConcentration,
illness.VisualDisturbances,
illness.ReceivingBloodTransfusion,
illness.ReceivingUnsterileInjections,
illness.Coma,
illness.StomachBleeding,
illness.DistentionOfAbdomen,
illness.HistoryOfAlcoholConsumption,
illness.fluid_overload,
illness.BloodInSputum,
illness.ProminentVeinsOnCalf,
illness.Palpitations,
illness.PainfulWalking,
illness.PusFilledPimples,
illness.Blackheads,
illness.Scurring,
illness.SkinPeeling,
illness.SilverLikeDusting,
illness.SmallDentsInNails,
illness.InflammatoryNails,
illness.Blister,
illness.RedSoreAroundNose,
illness.YellowCrustOoze };

                illness.Prognosis = await _predictionService.GetPredictionAsync(illness.Itching,
illness.SkinRash,
illness.NodalSkinEruptions,
illness.ContinuousSneezing,
illness.Shivering,
illness.Chills,
illness.JointPain,
illness.StomachPain,
illness.Acidity,
illness.UlcersOnTongue,
illness.MuscleWasting,
illness.Vomiting,
illness.BurningMicturition,
illness.SpottingUrination,
illness.Fatigue,
illness.WeightGain,
illness.Anxiety,
illness.ColdHandsAndFeet,
illness.MoodSwings,
illness.WeightLoss,
illness.Restlessness,
illness.Lethargy,
illness.PatchesInThroat,
illness.IrregularSugarLevel,
illness.Cough,
illness.HighFever,
illness.SunkenEyes,
illness.Breathlessness,
illness.Sweating,
illness.Dehydration,
illness.Indigestion,
illness.Headache,
illness.YellowishSkin,
illness.DarkUrine,
illness.Nausea,
illness.LossOfAppetite,
illness.PainBehindTheEyes,
illness.BackPain,
illness.Constipation,
illness.AbdominalPain,
illness.Diarrhea,
illness.MildFever,
illness.YellowUrine,
illness.YellowingOfEyes,
illness.AcuteLiverFailure,
illness.SwellingOfStomach,
illness.SwelledLymphNodes,
illness.Malaise,
illness.BlurredAndDistortedVision,
illness.Phlegm,
illness.ThroatIrritation,
illness.RednessOfEyes,
illness.SinusPressure,
illness.RunnyNose,
illness.Congestion,
illness.ChestPain,
illness.WeaknessInLimbs,
illness.FastHeartRate,
illness.PainDuringBowelMovements,
illness.PainInAnalRegion,
illness.BloodyStool,
illness.IrritationInAnus,
illness.NeckPain,
illness.Dizziness,
illness.Cramps,
illness.Bruising,
illness.Obesity,
illness.SwollenLegs,
illness.SwollenBloodVessels,
illness.PuffyFaceAndEyes,
illness.EnlargedThyroid,
illness.BrittleNails,
illness.SwollenExtremeties,
illness.ExcessiveHunger,
illness.ExtraMaritalContacts,
illness.DryingAndTinglingLips,
illness.SlurredSpeech,
illness.KneePain,
illness.HipJointPain,
illness.MuscleWeakness,
illness.StiffNeck,
illness.SwellingJoints,
illness.MovementStiffness,
illness.SpinningMovements,
illness.LossOfBalance,
illness.Unsteadiness,
illness.WeaknessOfOneBodySide,
illness.LossOfSmell,
illness.BladderDiscomfort,
illness.FoulSmellOfUrine,
illness.ContinuousFeelOfUrine,
illness.PassageOfGases,
illness.InternalItching,
illness.ToxicLook_Typhos,
illness.Depression,
illness.Irritability,
illness.MusclePain,
illness.AlteredSensorium,
illness.RedSpotsOverBody,
illness.BellyPain,
illness.AbnormalMenstruation,
illness.DischromicPatches,
illness.WateringFromEyes,
illness.IncreasedAppetite,
illness.Polyuria,
illness.FamilyHistory,
illness.MucoidSputum,
illness.RustySputum,
illness.LackOfConcentration,
illness.VisualDisturbances,
illness.ReceivingBloodTransfusion,
illness.ReceivingUnsterileInjections,
illness.Coma,
illness.StomachBleeding,
illness.DistentionOfAbdomen,
illness.HistoryOfAlcoholConsumption,
illness.fluid_overload,
illness.BloodInSputum,
illness.ProminentVeinsOnCalf,
illness.Palpitations,
illness.PainfulWalking,
illness.PusFilledPimples,
illness.Blackheads,
illness.Scurring,
illness.SkinPeeling,
illness.SilverLikeDusting,
illness.SmallDentsInNails,
illness.InflammatoryNails,
illness.Blister,
illness.RedSoreAroundNose,
illness.YellowCrustOoze);

                _context.Add(illness);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(illness);
        }


        // GET: illness/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var illness = await _context.Illness.FindAsync(id);
            if (illness == null)
            {
                return NotFound();
            }
            return View(illness);
        }

        // POST: illness/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name, Itching, SkinRash, NodalSkinEruptions, ContinuousSneezing, Shivering, Chills, JointPain, StomachPain, Acidity, UlcersOnTongue, " +
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
    "RedSoreAroundNose, YellowCrustOoze")] Illness illness)

            {
                if (id != illness.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(illness);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!illnessExists(illness.Id))
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
                return View(illness);
            }
        

        // GET: illness/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var illness = await _context.Illness
                .FirstOrDefaultAsync(m => m.Id == id);
            if (illness == null)
            {
                return NotFound();
            }

            return View(illness);
        }

        // POST: illness/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var illness = await _context.Illness.FindAsync(id);
            if (illness != null)
            {
                _context.Illness.Remove(illness);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool illnessExists(int id)
        {
            return _context.Illness.Any(e => e.Id == id);
        }

        // Predict Endpoint
        [HttpPost]
        public async Task<IActionResult> Predict([FromBody] Dictionary<string, int> symptoms)
        {
            if (symptoms == null || !symptoms.Any())
            {
                return BadRequest("Invalid symptoms data.");
            }

            int Itching = symptoms.GetValueOrDefault("Itching", 0);
            int SkinRash = symptoms.GetValueOrDefault("SkinRash", 0);
            int NodalSkinEruptions = symptoms.GetValueOrDefault("NodalSkinEruptions", 0);
            int ContinuousSneezing = symptoms.GetValueOrDefault("ContinuousSneezing", 0);
            int Shivering = symptoms.GetValueOrDefault("Shivering", 0);
            int Chills = symptoms.GetValueOrDefault("Chills", 0);
            int JointPain = symptoms.GetValueOrDefault("JointPain", 0);
            int StomachPain = symptoms.GetValueOrDefault("StomachPain", 0);
            int Acidity = symptoms.GetValueOrDefault("Acidity", 0);
            int UlcersOnTongue = symptoms.GetValueOrDefault("UlcersOnTongue", 0);
            int MuscleWasting = symptoms.GetValueOrDefault("MuscleWasting", 0);
            int Vomiting = symptoms.GetValueOrDefault("Vomiting", 0);
            int BurningMicturition = symptoms.GetValueOrDefault("BurningMicturition", 0);
            int SpottingUrination = symptoms.GetValueOrDefault("SpottingUrination", 0);
            int Fatigue = symptoms.GetValueOrDefault("Fatigue", 0);
            int WeightGain = symptoms.GetValueOrDefault("WeightGain", 0);
            int Anxiety = symptoms.GetValueOrDefault("Anxiety", 0);
            int ColdHandsAndFeet = symptoms.GetValueOrDefault("ColdHandsAndFeet", 0);
            int MoodSwings = symptoms.GetValueOrDefault("MoodSwings", 0);
            int WeightLoss = symptoms.GetValueOrDefault("WeightLoss", 0);
            int Restlessness = symptoms.GetValueOrDefault("Restlessness", 0);
            int Lethargy = symptoms.GetValueOrDefault("Lethargy", 0);
            int PatchesInThroat = symptoms.GetValueOrDefault("PatchesInThroat", 0);
            int IrregularSugarLevel = symptoms.GetValueOrDefault("IrregularSugarLevel", 0);
            int Cough = symptoms.GetValueOrDefault("Cough", 0);
            int HighFever = symptoms.GetValueOrDefault("HighFever", 0);
            int SunkenEyes = symptoms.GetValueOrDefault("SunkenEyes", 0);
            int Breathlessness = symptoms.GetValueOrDefault("Breathlessness", 0);
            int Sweating = symptoms.GetValueOrDefault("Sweating", 0);
            int Dehydration = symptoms.GetValueOrDefault("Dehydration", 0);
            int Indigestion = symptoms.GetValueOrDefault("Indigestion", 0);
            int Headache = symptoms.GetValueOrDefault("Headache", 0);
            int YellowishSkin = symptoms.GetValueOrDefault("YellowishSkin", 0);
            int DarkUrine = symptoms.GetValueOrDefault("DarkUrine", 0);
            int Nausea = symptoms.GetValueOrDefault("Nausea", 0);
            int LossOfAppetite = symptoms.GetValueOrDefault("LossOfAppetite", 0);
            int PainBehindTheEyes = symptoms.GetValueOrDefault("PainBehindTheEyes", 0);
            int BackPain = symptoms.GetValueOrDefault("BackPain", 0);
            int Constipation = symptoms.GetValueOrDefault("Constipation", 0);
            int AbdominalPain = symptoms.GetValueOrDefault("AbdominalPain", 0);
            int Diarrhea = symptoms.GetValueOrDefault("Diarrhea", 0);
            int MildFever = symptoms.GetValueOrDefault("MildFever", 0);
            int YellowUrine = symptoms.GetValueOrDefault("YellowUrine", 0);
            int YellowingOfEyes = symptoms.GetValueOrDefault("YellowingOfEyes", 0);
            int AcuteLiverFailure = symptoms.GetValueOrDefault("AcuteLiverFailure", 0);
            int SwellingOfStomach = symptoms.GetValueOrDefault("SwellingOfStomach", 0);
            int SwelledLymphNodes = symptoms.GetValueOrDefault("SwelledLymphNodes", 0);
            int Malaise = symptoms.GetValueOrDefault("Malaise", 0);
            int BlurredAndDistortedVision = symptoms.GetValueOrDefault("BlurredAndDistortedVision", 0);
            int Phlegm = symptoms.GetValueOrDefault("Phlegm", 0);
            int ThroatIrritation = symptoms.GetValueOrDefault("ThroatIrritation", 0);
            int RednessOfEyes = symptoms.GetValueOrDefault("RednessOfEyes", 0);
            int SinusPressure = symptoms.GetValueOrDefault("SinusPressure", 0);
            int RunnyNose = symptoms.GetValueOrDefault("RunnyNose", 0);
            int Congestion = symptoms.GetValueOrDefault("Congestion", 0);
            int ChestPain = symptoms.GetValueOrDefault("ChestPain", 0);
            int WeaknessInLimbs = symptoms.GetValueOrDefault("WeaknessInLimbs", 0);
            int FastHeartRate = symptoms.GetValueOrDefault("FastHeartRate", 0);
            int PainDuringBowelMovements = symptoms.GetValueOrDefault("PainDuringBowelMovements", 0);
            int PainInAnalRegion = symptoms.GetValueOrDefault("PainInAnalRegion", 0);
            int BloodyStool = symptoms.GetValueOrDefault("BloodyStool", 0);
            int IrritationInAnus = symptoms.GetValueOrDefault("IrritationInAnus", 0);
            int NeckPain = symptoms.GetValueOrDefault("NeckPain", 0);
            int Dizziness = symptoms.GetValueOrDefault("Dizziness", 0);
            int Cramps = symptoms.GetValueOrDefault("Cramps", 0);
            int Bruising = symptoms.GetValueOrDefault("Bruising", 0);
            int Obesity = symptoms.GetValueOrDefault("Obesity", 0);
            int SwollenLegs = symptoms.GetValueOrDefault("SwollenLegs", 0);
            int SwollenBloodVessels = symptoms.GetValueOrDefault("SwollenBloodVessels", 0);
            int PuffyFaceAndEyes = symptoms.GetValueOrDefault("PuffyFaceAndEyes", 0);
            int EnlargedThyroid = symptoms.GetValueOrDefault("EnlargedThyroid", 0);
            int BrittleNails = symptoms.GetValueOrDefault("BrittleNails", 0);
            int SwollenExtremeties = symptoms.GetValueOrDefault("SwollenExtremeties", 0);
            int ExcessiveHunger = symptoms.GetValueOrDefault("ExcessiveHunger", 0);
            int ExtraMaritalContacts = symptoms.GetValueOrDefault("ExtraMaritalContacts", 0);
            int DryingAndTinglingLips = symptoms.GetValueOrDefault("DryingAndTinglingLips", 0);
            int SlurredSpeech = symptoms.GetValueOrDefault("SlurredSpeech", 0);
            int KneePain = symptoms.GetValueOrDefault("KneePain", 0);
            int HipJointPain = symptoms.GetValueOrDefault("HipJointPain", 0);
            int MuscleWeakness = symptoms.GetValueOrDefault("MuscleWeakness", 0);
            int StiffNeck = symptoms.GetValueOrDefault("StiffNeck", 0);
            int SwellingJoints = symptoms.GetValueOrDefault("SwellingJoints", 0);
            int MovementStiffness = symptoms.GetValueOrDefault("MovementStiffness", 0);
            int SpinningMovements = symptoms.GetValueOrDefault("SpinningMovements", 0);
            int LossOfBalance = symptoms.GetValueOrDefault("LossOfBalance", 0);
            int Unsteadiness = symptoms.GetValueOrDefault("Unsteadiness", 0);
            int WeaknessOfOneBodySide = symptoms.GetValueOrDefault("WeaknessOfOneBodySide", 0);
            int LossOfSmell = symptoms.GetValueOrDefault("LossOfSmell", 0);
            int BladderDiscomfort = symptoms.GetValueOrDefault("BladderDiscomfort", 0);
            int FoulSmellOfUrine = symptoms.GetValueOrDefault("FoulSmellOfUrine", 0);
            int ContinuousFeelOfUrine = symptoms.GetValueOrDefault("ContinuousFeelOfUrine", 0);
            int PassageOfGases = symptoms.GetValueOrDefault("PassageOfGases", 0);
            int InternalItching = symptoms.GetValueOrDefault("InternalItching", 0);
            int ToxicLook_Typhos = symptoms.GetValueOrDefault("ToxicLook_Typhos", 0);
            int Depression = symptoms.GetValueOrDefault("Depression", 0);
            int Irritability = symptoms.GetValueOrDefault("Irritability", 0);
            int MusclePain = symptoms.GetValueOrDefault("MusclePain", 0);
            int AlteredSensorium = symptoms.GetValueOrDefault("AlteredSensorium", 0);
            int RedSpotsOverBody = symptoms.GetValueOrDefault("RedSpotsOverBody", 0);
            int BellyPain = symptoms.GetValueOrDefault("BellyPain", 0);
            int AbnormalMenstruation = symptoms.GetValueOrDefault("AbnormalMenstruation", 0);
            int DischromicPatches = symptoms.GetValueOrDefault("DischromicPatches", 0);
            int WateringFromEyes = symptoms.GetValueOrDefault("WateringFromEyes", 0);
            int IncreasedAppetite = symptoms.GetValueOrDefault("IncreasedAppetite", 0);
            int Polyuria = symptoms.GetValueOrDefault("Polyuria", 0);
            int FamilyHistory = symptoms.GetValueOrDefault("FamilyHistory", 0);
            int MucoidSputum = symptoms.GetValueOrDefault("MucoidSputum", 0);
            int RustySputum = symptoms.GetValueOrDefault("RustySputum", 0);
            int LackOfConcentration = symptoms.GetValueOrDefault("LackOfConcentration", 0);
            int VisualDisturbances = symptoms.GetValueOrDefault("VisualDisturbances", 0);
            int ReceivingBloodTransfusion = symptoms.GetValueOrDefault("ReceivingBloodTransfusion", 0);
            int ReceivingUnsterileInjections = symptoms.GetValueOrDefault("ReceivingUnsterileInjections", 0);
            int Coma = symptoms.GetValueOrDefault("Coma", 0);
            int StomachBleeding = symptoms.GetValueOrDefault("StomachBleeding", 0);
            int DistentionOfAbdomen = symptoms.GetValueOrDefault("DistentionOfAbdomen", 0);
            int HistoryOfAlcoholConsumption = symptoms.GetValueOrDefault("HistoryOfAlcoholConsumption", 0);
            int fluid_overload = symptoms.GetValueOrDefault("fluid_overload", 0);
            int BloodInSputum = symptoms.GetValueOrDefault("BloodInSputum", 0);
            int ProminentVeinsOnCalf = symptoms.GetValueOrDefault("ProminentVeinsOnCalf", 0);
            int Palpitations = symptoms.GetValueOrDefault("Palpitations", 0);
            int PainfulWalking = symptoms.GetValueOrDefault("PainfulWalking", 0);
            int PusFilledPimples = symptoms.GetValueOrDefault("PusFilledPimples", 0);
            int Blackheads = symptoms.GetValueOrDefault("Blackheads", 0);
            int Scurring = symptoms.GetValueOrDefault("Scurring", 0);
            int SkinPeeling = symptoms.GetValueOrDefault("SkinPeeling", 0);
            int SilverLikeDusting = symptoms.GetValueOrDefault("SilverLikeDusting", 0);
            int SmallDentsInNails = symptoms.GetValueOrDefault("SmallDentsInNails", 0);
            int InflammatoryNails = symptoms.GetValueOrDefault("InflammatoryNails", 0);
            int Blister = symptoms.GetValueOrDefault("Blister", 0);
            int RedSoreAroundNose = symptoms.GetValueOrDefault("RedSoreAroundNose", 0);
            int YellowCrustOoze = symptoms.GetValueOrDefault("YellowCrustOoze", 0);

            string prediction = await _predictionService.GetPredictionAsync(
                Itching,
                SkinRash,
                NodalSkinEruptions,
                ContinuousSneezing,
                Shivering,
                Chills,
                JointPain,
                StomachPain,
                Acidity,
                UlcersOnTongue,
                MuscleWasting,
                Vomiting,
                BurningMicturition,
                SpottingUrination,
                Fatigue,
                WeightGain,
                Anxiety,
                ColdHandsAndFeet,
                MoodSwings,
                WeightLoss,
                Restlessness,
                Lethargy,
                PatchesInThroat,
                IrregularSugarLevel,
                Cough,
                HighFever,
                SunkenEyes,
                Breathlessness,
                Sweating,
                Dehydration,
                Indigestion,
                Headache,
                YellowishSkin,
                DarkUrine,
                Nausea,
                LossOfAppetite,
                PainBehindTheEyes,
                BackPain,
                Constipation,
                AbdominalPain,
                Diarrhea,
                MildFever,
                YellowUrine,
                YellowingOfEyes,
                AcuteLiverFailure,
                SwellingOfStomach,
                SwelledLymphNodes,
                Malaise,
                BlurredAndDistortedVision,
                Phlegm,
                ThroatIrritation,
                RednessOfEyes,
                SinusPressure,
                RunnyNose,
                Congestion,
                ChestPain,
                WeaknessInLimbs,
                FastHeartRate,
                PainDuringBowelMovements,
                PainInAnalRegion,
                BloodyStool,
                IrritationInAnus,
                NeckPain,
                Dizziness,
                Cramps,
                Bruising,
                Obesity,
                SwollenLegs,
                SwollenBloodVessels,
                PuffyFaceAndEyes,
                EnlargedThyroid,
                BrittleNails,
                SwollenExtremeties,
                ExcessiveHunger,
                ExtraMaritalContacts,
                DryingAndTinglingLips,
                SlurredSpeech,
                KneePain,
                HipJointPain,
                MuscleWeakness,
                StiffNeck,
                SwellingJoints,
                MovementStiffness,
                SpinningMovements,
                LossOfBalance,
                Unsteadiness,
                WeaknessOfOneBodySide,
                LossOfSmell,
                BladderDiscomfort,
                FoulSmellOfUrine,
                ContinuousFeelOfUrine,
                PassageOfGases,
                InternalItching,
                ToxicLook_Typhos,
                Depression,
                Irritability,
                MusclePain,
                AlteredSensorium,
                RedSpotsOverBody,
                BellyPain,
                AbnormalMenstruation,
                DischromicPatches,
                WateringFromEyes,
                IncreasedAppetite,
                Polyuria,
                FamilyHistory,
                MucoidSputum,
                RustySputum,
                LackOfConcentration,
                VisualDisturbances,
                ReceivingBloodTransfusion,
                ReceivingUnsterileInjections,
                Coma,
                StomachBleeding,
                DistentionOfAbdomen,
                HistoryOfAlcoholConsumption,
                fluid_overload,
                BloodInSputum,
                ProminentVeinsOnCalf,
                Palpitations,
                PainfulWalking,
                PusFilledPimples,
                Blackheads,
                Scurring,
                SkinPeeling,
                SilverLikeDusting,
                SmallDentsInNails,
                InflammatoryNails,
                Blister,
                RedSoreAroundNose,
                YellowCrustOoze
            );

            return Ok(new { Prediction = prediction });
        }

    }
}

