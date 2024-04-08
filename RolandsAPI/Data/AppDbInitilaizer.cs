using RolandsAPI.Models;

namespace RolandsAPI.Data
{
    public class AppDbInitilaizer
    {
        public static void Seed(IApplicationBuilder applicationbuilder)
        {
            using (var serviceScope = applicationbuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApiContext>();

                context.Database.EnsureCreated();

                //Majas
                if(!context.Majas.Any())
                {
                    context.Majas.AddRange(new List<Maja>()
                    {
                        new Maja()
                        {
                            Numurs = 1,
                            Iela = "Skolas iela 21",
                            Pilseta = "Jelgava",
                            Valsts = "Latvija",
                            PastaIndekss = "LV-4618"
                        },
                        new Maja()
                        {
                            Numurs = 2,
                            Iela = "Lielā iela 12",
                            Pilseta = "Jelgava",
                            Valsts = "Latvija",
                            PastaIndekss = "LV-4619"
                        },
                    });
                    context.SaveChanges();
                    

                }
                //Dzivokli
                if (!context.Dzivokli.Any())
                {

                }
                //Iedzivotaji
                if (!context.Iedzivotaji.Any())
                {

                }

            }
        }
    }
}
