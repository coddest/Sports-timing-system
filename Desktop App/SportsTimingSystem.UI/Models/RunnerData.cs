using CommunityToolkit.Mvvm.ComponentModel;
using Ganss.Excel;
using System;

namespace SportsTimingSystem.UI.Models
{
    public class RunnerData : ObservableObject
    {
        public int Id { get; set; }

        [Column("Poz.")]
        public int Position { get; set; }
        [Column("Nr.")]
        public int RunnerNumber { get; set; }
        [Column("Nazwisko i Imię")]
        public string FullName { get; set; }
        [Column("Klub")]
        public string Club { get; set; }
        [Column("Bieg 1")]
        public double FirstRun { get; set; }
        [Column("Bieg 2")]
        public double SecondRun { get; set; }
        [Column("Czas")]
        [DataFormat("mm:ss.00")]
        public DateTime Duration { get; set; }
        [Column("Strata")]
        public double TimeLoss { get; set; }
    }
}
