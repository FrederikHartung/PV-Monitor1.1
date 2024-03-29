﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PV_Monitor.Module.BusinessObjects
{
    [DefaultClassOptions]

    public class PV_Modul : BaseObject
    { 
        public PV_Modul(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (!IsLoading && !IsSaving)
            {
                if (propertyName == nameof(DatenbankID))
                {
                    //Messagebox.Show
                }
            }
        }


        private string _Beschreibung;
        public string Beschreibung
        {
            get { return _Beschreibung; }
            set { SetPropertyValue<string>(nameof(Beschreibung), ref _Beschreibung, value); }
        }


        private int _DatenbankID;
        [XafDisplayName("Datenbank ID")]
        public int DatenbankID
        {
            get { return _DatenbankID; }
            set { SetPropertyValue<int>(nameof(DatenbankID), ref _DatenbankID, value); }
        }


        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("Messwerte")]
        public XPCollection<Messwert> Messwert_Liste
        {
            get { return GetCollection<Messwert>(nameof(Messwert_Liste)); }
        }


        private DateTime _DatumInbetriebnahme;
        public DateTime DatumInbetriebnahme
        {
            get { return _DatumInbetriebnahme; }
            set { SetPropertyValue<DateTime>(nameof(DatumInbetriebnahme), ref _DatumInbetriebnahme, value); }
        }


    }
}