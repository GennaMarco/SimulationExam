
//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------


namespace SimulationExam.Web.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Activity
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Activity()
    {

        this.ActivityDate = new HashSet<ActivityDate>();

        this.UserActivity = new HashSet<UserActivity>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public Nullable<int> EventId { get; set; }



    public virtual Event Event { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ActivityDate> ActivityDate { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<UserActivity> UserActivity { get; set; }

}

}
