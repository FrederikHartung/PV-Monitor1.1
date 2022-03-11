﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DevExpress.ExpressApp;
using PV_Monitor.Module.BusinessObjects._np;

namespace PV_Monitor.Module.Helper
{
    public static class Multi_helper
    {
        public static string Besorge_Stammverzeichnis()
        {
            return Environment.CurrentDirectory;
        }

        public static string Besorge_ZeileAusConfig(string objectvalueToSearchFor)
        {
            string[] file = File.ReadAllLines(App_helper.Einstellungspfad);
            foreach (string zeile in file)
            {
                if (zeile.Contains(objectvalueToSearchFor))
                {
                    int unwichtige_posi1 = zeile.IndexOf("\"");
                    int unwichtige_posi2 = zeile.IndexOf("\"", unwichtige_posi1 + 1);
                    int posi_start = zeile.IndexOf("\"", unwichtige_posi2 + 1);
                    int posi_ende = zeile.IndexOf("\"", posi_start + 1);
                    return zeile.Substring(posi_start + 1, posi_ende - posi_start - 1);
                }
            }

            return null;
        }

        public static void Zeige_Messagebox(string text)
        {
            if (App_helper.Status_App_istInitialisiert)
            {
                XafApplication app = App_helper.App;
                IObjectSpace os = app.CreateObjectSpace(typeof(Messagebox_np));
                Messagebox_np messagebox = new Messagebox_np();
                messagebox.Text = text;

                DetailView view = app.CreateDetailView(os, messagebox);

                app.ShowViewStrategy.ShowViewInPopupWindow(view);
            }
            else
            {
                App_helper.Zeige_Notfallmitteilung(text);
            }
        }
    }
}
