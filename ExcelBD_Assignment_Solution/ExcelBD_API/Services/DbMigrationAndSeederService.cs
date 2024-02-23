using ExelBD_Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelBD_API.Services
{
    public class DbMigrationAndSeederService(ExcelDbContext db)
    {
        //private readonly ExcelDbContext db;
        //public DbMigrationAndSeederService(ExcelDbContext db)
        //{
        //    this.db = db;
        //}
        public async Task MigrateAsync()
        {
            var pendingMigrations = await db.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                await db.Database.MigrateAsync();
            }
        }
        public async Task SeedAsync()
        {
            if (!(await db.Allergies.AnyAsync()))
            {
                await db.Allergies.AddRangeAsync(new Allergy[]
               {
                    new Allergy{ AllergyName="Drugs - Penicilin"},
                    new Allergy{ AllergyName="Drugs - Others" },
                    new Allergy{ AllergyName="Oinments"},
                    new Allergy{ AllergyName="Sprays"}
               });
            }

            if (!await db.NCDs.AnyAsync())
            {
                await db.NCDs.AddRangeAsync(new NCD[]
                {
                new NCD{ NCDName="Asthma"},
                new NCD{ NCDName="Cancer"},
                new NCD{ NCDName="Disorder of eye"},
                new NCD{ NCDName="Disorder of ear"}
                });
            }
            if (!await db.DiseaseInformations.AnyAsync())
            {
                await db.DiseaseInformations.AddRangeAsync(new DiseaseInformation[]
               {
                    new DiseaseInformation{ DiseaseName="Ulcer"},
                    new DiseaseInformation{ DiseaseName="Hepatitis"},
                    new DiseaseInformation{ DiseaseName="Hypertension"}
               });
            }

            await db.SaveChangesAsync();
        }
    }
}

