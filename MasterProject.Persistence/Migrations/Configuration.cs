namespace MasterProject.Persistence.Migrations
{
    using System.Data.Entity.Migrations;
    using Core.Models;

    public sealed class Configuration : DbMigrationsConfiguration<HospitalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HospitalContext context)
        {
            context.Wards.AddOrUpdate(x => x.Name, new Wards { Name = "Oddział Ginekologiczno-Położniczy" });
            context.Wards.AddOrUpdate(x => x.Name, new Wards { Name = "Szpitalny Oddział Ratunkowy" });

            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Alergologia",
                Code = "0731"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Anestezjologia i intensywna terapia",
                Code = "0701"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Angiologia",
                Code = "0732"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Audiologia i foniatria",
                Code = "0733"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Balneologia i medycyna fizykalna",
                Code = "0734"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Chirurgia dziecięca",
                Code = "0702"
            }); context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Chirurgia klatki piersiowej",
                Code = "0735"
            }); context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Chirurgia naczyniowa",
                Code = "0736"
            }); context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Chirurgia ogólna",
                Code = "0703"
            }); context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Chirurgia onkologiczna",
                Code = "0737"
            }); context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Chirurgia plastyczna",
                Code = "0738"
            }); context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Chirurgia szczękowo-twarzowa",
                Code = "0704"
            }); context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Choroby płuc",
                Code = "0739"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Choroby płuc dzieci",
                Code = "0792"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Choroby wewnętrzne",
                Code = "0705"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Choroby zakaźne",
                Code = "0706"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Dermatologia i wenerologia",
                Code = "0707"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Diabetologia",
                Code = "0740"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Diagnostyka laboratoryjna",
                Code = "0708"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Endokrynologia",
                Code = "0741"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Endokrynologia ginekologiczna i rozrodczość",
                Code = "0799"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Endokrynologia i diabetologia dziecięca",
                Code = "0796"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Epidemiologia",
                Code = "0710"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Farmakologia kliniczna",
                Code = "0742"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Gastroenterologia",
                Code = "0743"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Gastroenterologia dziecięca",
                Code = "0797"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Genetyka kliniczna",
                Code = "0709"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Geriatria",
                Code = "0744"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Ginekologia onkologiczna",
                Code = "0787"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Hematologia",
                Code = "0745"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Hipertensjologia",
                Code = "0788"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Immunologia kliniczna",
                Code = "0746"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Intensywna terapia",
                Code = "0801"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Kardiochirurgia",
                Code = "0747"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Kardiologia",
                Code = "0748"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Kardiologia dziecięca",
                Code = "0762"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Medycyna lotnicza",
                Code = "0793"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Medycyna morska i tropikalna",
                Code = "0794"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Medycyna nuklearna",
                Code = "0749"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Medycyna paliatywna",
                Code = "0750"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Medycyna pracy",
                Code = "0711"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Medycyna ratunkowa",
                Code = "0712"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Medycyna rodzinna",
                Code = "0713"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Medycyna sądowa",
                Code = "0714"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Medycyna sportowa",
                Code = "0751"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Mikrobiologia lekarska",
                Code = "0716"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Nefrologia",
                Code = "0752"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Nefrologia dziecięca",
                Code = "0798"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Neonatologia",
                Code = "0753"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Neurochirurgia",
                Code = "0717"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Neurologia",
                Code = "0718"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Neurologia dziecięca",
                Code = "0763"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Neuropatologia",
                Code = "0789"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Okulistyka",
                Code = "0719"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Onkologia i hematologia dziecięca",
                Code = "0755"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Onkologia kliniczna",
                Code = "0754"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Ortopedia i traumatologia narządu ruchu",
                Code = "0720"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Otorynolaryngologia",
                Code = "0721"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Otorynolaryngologia dziecięca",
                Code = "0790"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Patomorfologia",
                Code = "0722"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Pediatria",
                Code = "0723"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Pediatria metaboliczna",
                Code = "0795"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Perinatologia",
                Code = "0800"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Położnictwo i ginekologia",
                Code = "0724"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Psychiatria",
                Code = "0725"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Psychiatria dzieci i młodzieży",
                Code = "0756"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Radiologia i diagnostyka obrazowa",
                Code = "0726"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Radioterapia onkologiczna",
                Code = "0727"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Rehabilitacja medyczna",
                Code = "0728"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Reumatologia",
                Code = "0757"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Seksuologia",
                Code = "0758"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Toksykologia kliniczna",
                Code = "0759"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Transfuzjologia kliniczna",
                Code = "0760"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Transplantologia kliniczna",
                Code = "0761"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Urologia",
                Code = "0729"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Urologia dziecięca",
                Code = "0791"
            });
            context.Specialties.AddOrUpdate(x => x.Name, new Specialties
            {
                Name = "Zdrowie publiczne",
                Code = "0730"
            });


            context.SaveChanges();
            //This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.E.g.
        }
    }
}
