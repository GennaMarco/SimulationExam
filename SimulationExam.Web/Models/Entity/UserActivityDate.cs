//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimulationExam.Web.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserActivityDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ActivityDateId { get; set; }
        public Nullable<byte> IsPartecipant { get; set; }
        public Nullable<byte> WillCome { get; set; }
    
        public virtual ActivityDate ActivityDate { get; set; }
        public virtual User User { get; set; }
    }
}
