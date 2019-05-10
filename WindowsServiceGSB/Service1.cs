using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace WindowsServiceGSB
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

         void main()
        {
            DatabaseConnection connexion = new DatabaseConnection(@"Server=localhost;Port=3306;Database=gsb_frais;Uid=root;Pwd=;");

            while (true)
            {
                string moisPrecedent = gestionDates.getMoisPrecedent(),
                       dateNow = DateTime.Now.ToString("yyyy-MM-dd");


                if (gestionDates.entre(1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)))
                    connexion.adminRequest("UPDATE fichefrais SET idetat='CL', datemodif='" + dateNow + "' WHERE idetat='CR'AND (SELECT RIGHT(mois, 2)='" + moisPrecedent + "')");


                if (gestionDates.entre(20, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)))
                    connexion.adminRequest("UPDATE fichefrais SET idetat='RB', datemodif='" + dateNow + "' WHERE idetat='VA' AND (SELECT RIGHT(mois, 2)='" + moisPrecedent + "')");

                Thread.Sleep(2000);
            }
          }


        

        protected override void OnStart(string[] args)
        {
            Thread worker = new Thread(main);
            worker.Start();
        }

        protected override void OnStop()
        {
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            
        }
    }
}
