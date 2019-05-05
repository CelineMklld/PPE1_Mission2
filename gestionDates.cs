using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClotureGSB
{
    public abstract class gestionDates
    {
        /// <summary>
        /// Méthode « getMoisPrecedent » : récupère le mois précédent par rapport à la date actuelle
        /// </summary>
        /// <returns> Retourne le mois précédent par rapport à la date actuelle </returns>
        public static string getMoisPrecedent()
        {
            return DateTime.Now.AddMonths(-1).ToString("MM");
        }

        /// <summary>
        /// Méthode « getMoisPrecedent » : récupère le mois précédent par rapport à une date aléatoire
        /// </summary>
        /// <param name="date"> Date dont on veut obtenir le mois précédent </param>
        /// <returns> Retourne le mois précédent par rapport à la date en paramètre </returns>
        public static string getMoisPrecedent(DateTime date)
        {
            return date.AddMonths(-1).ToString("MM");
        }

        /// <summary>
        /// Méthode « getMoisSuivant » : récupère le mois suivant par rapport à la date actuelle
        /// </summary>
        /// <returns> Retourne le mois suivant par rapport à la date actuelle </returns>
        public static string getMoisSuivant()
        {
            return DateTime.Now.AddMonths(+1).ToString("MM");
        }

        /// <summary>
        /// Méthode « getMoisSuivant » : récupère le mois suivant par rapport à une date aléatoire
        /// </summary>
        /// <param name="date"> Date dont on veut obtenir le mois suivant </param>
        /// <returns> Retourne le mois suivant par rapport à la date en paramètre </returns>
        public static string getMoisSuivant(DateTime date)
        {
            return date.AddMonths(+1).ToString("MM");
        }

        /// <summary>
        /// Méthode booléenne « entre » : avec jour actuel entre 2 dates 
        /// </summary>
        /// <param name="jourUn"> Premier jour de la fourchette de dates </param>
        /// <param name="jourDeux"> Dernier jour de la fourchette de dates </param>
        /// <returns> Retourne le jour actuel entre les 2 jours en paramètre </returns>
        public static bool entre(int jourUn, int jourDeux)
        {
            int jourActuel = DateTime.Now.Day;
            return jourActuel <= jourDeux && jourActuel >= jourUn;
            
        }

        /// <summary>
        /// Méthode booléenne « entre » : avec jour aléatoire entre 2 dates
        /// </summary>
        /// <param name="date"> Date comprise entre la fourchette des 2 jours </param>
        /// <param name="jourUn"> Premier jour de la fourchette de dates </param>
        /// <param name="jourDeux"> Dernier jour de la fourchette de dates </param>
        /// <returns> Retourne un jour entre les 2 jours en paramètre </returns> 
        public static bool entre(DateTime date, int jourUn, int jourDeux)
        {
            int jourTest = date.Day;
            return jourTest <= jourDeux && jourTest >= jourUn;
        }

    }
}
