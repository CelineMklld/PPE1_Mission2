using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestionClotureGSB
{
    class Program
    {

        /// <summary>
        /// Méthode "main" : exécution des modifications de BDD à apporter 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /* Tests unitaires 
            
            DatabaseConnection connection = new DatabaseConnection(@"Server=localhost;Port=3306;Database=gsb_frais;Uid=root;Pwd=;");
            connection.adminRequest("UPDATE visiteur SET nom='Andreee' WHERE id='a17'"); 

            Console.WriteLine(connection.getFromDb("SELECT nom FROM visiteur"));
            Console.ReadKey();

            Console.WriteLine(gestionDates.getMoisPrecedent(new DateTime(2018, 12, 25)));
            Console.ReadKey();

            Console.WriteLine(gestionDates.getMoisSuivant());
            Console.ReadKey();

            Console.WriteLine(gestionDates.getMoisSuivant(new DateTime(2018, 12, 25)));
            Console.ReadKey();

            Console.WriteLine(gestionDates.entre(15, 20));
            Console.ReadKey();

            Console.WriteLine(gestionDates.entre(new DateTime(2018, 12, 25), 15, 29));
            Console.ReadKey();

            */ 


            // Modifications à apporter
            DatabaseConnection connexion = new DatabaseConnection(@"Server=localhost;Port=3306;Database=gsb_frais;Uid=root;Pwd=;");

            while(true)
            {
                string moisPrecedent = gestionDates.getMoisPrecedent();


                if(gestionDates.entre(1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)))
                {
                    connexion.adminRequest("UPDATE fichefrais SET idetat='CL' WHERE idetat='CR'AND (SELECT RIGHT(mois, 2)='" + moisPrecedent + "')");
                }


                if (gestionDates.entre(20, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)))
                {
                    string dateNow = DateTime.Now.ToString("yyyy-MM-dd");
                    connexion.adminRequest("UPDATE fichefrais SET idetat='RB', datamodif='"+dateNow+"' WHERE idetat='VA' AND (SELECT RIGHT(mois, 2)='" + moisPrecedent + "')");
                }

                Thread.Sleep(2000);
            }

        }

    }
}
