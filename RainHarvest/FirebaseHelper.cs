using System;
using System.Collections.Generic;
using System.Text;
using Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
//using System.Collections.Generic;

namespace RainHarvest
{
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://rainharvestmad-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public async Task AddRecord(string dt, string t, string n, string state, double  ra, double ca,  double run, double tr)
        {
            await firebase
                .Child("RainHarvestRecords")
                .PostAsync(new RainHarvestRecord() { DateRecorded = dt, Title = t, Note = n, Rainfall = ra,  CatchmentArea = ca, RunOffCoeff = run, TotalRainfall = tr});
        }

        public async Task<List<RainHarvestRecord>> GetAllRainHarvestRecord()
        {
            return (await firebase
                .Child("RainHarvestRecords")
                .OnceAsync<RainHarvestRecord>()).Select(item => new RainHarvestRecord
                {
                    DateRecorded = item.Object.DateRecorded,
                    Title = item.Object.Title,
                    Note = item.Object.Note,
                    Rainfall = item.Object.Rainfall,
                    CatchmentArea = item.Object.CatchmentArea,
                    RunOffCoeff = item.Object.RunOffCoeff,
                    TotalRainfall = item.Object.TotalRainfall,
                }).ToList();
        }
        
        public async Task<List<RainHarvestRecord>> GetFindRecord(string title)
        {
            var allRainHarvestRecord = await GetAllRainHarvestRecord();
            await firebase
              .Child("RainHarvestRecords")
              .OnceAsync<RainHarvestRecord>();
            return allRainHarvestRecord.Where(a => a.Title == title).ToList();
        }
        
        internal Task AddRecord(string selectdate, string title, string note, double rainfall, double catchmentarea, double runoffcoeff,double totalRainfall)
        {
            throw new NotImplementedException();
        }
        
    }
}
