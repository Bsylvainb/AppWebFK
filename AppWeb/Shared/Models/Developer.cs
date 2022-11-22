using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppWeb.Shared.Models
{
       
    public class YearCount
    {
        public int Count { get; set; }
        public int Year { get; set; }
    }
   
    public class Developer
    {
        public int DeveloperId { get; set; }
        public DateTime DateCrea { get; set; } = DateTime.Today;
        public int Count { get; set; }
        public int Year { get; set; }
        public string ECR 
        {
            get
            {
                return $"{Count.ToString().PadLeft(3, '0')}/{Year}";
            }
            set { }

        }
      //  [DisplayName("WorkPlace")]
       // [Required(ErrorMessage = "Workplace is required")]
        public string? Atelier { get; set; }
        [DisplayName("Name")]
       // [Required(ErrorMessage = "The name is required")]
        public string? Nom { get; set; }
        public string? PNC { get; set; }
        public string? DesignationC { get; set; }
        public string? AmdtC { get; set; }
        public string? IndiceC { get; set; }
        public string? PNP { get; set; }
        public string? Produit { get; set; }
        public string? AmdtP { get; set; }
        public string? IndiceP { get; set; }      
        public DateTime? DateP { get; set; }
       // [Required(ErrorMessage = "An Description of ECR is required")]
        public string? Description { get; set; }
        public string? Analyse { get; set; }
        public string? BlocT { get; set; }
        public string? BlocM { get; set; }
        public string? FEE { get; set; }
        public string? CloseOn { get; private set; }
        public string Statut
        {
            get
            {
                if (BlSAQ != "Validated")
                {
                    string var1;
                    var1 = "Open";
                    return var1;
                }
               else if ( BlSAQ == "Validated" )
                {
                    string var2;
                    var2 = "Close";
                    return var2;
                }
                return CloseOn;
            }

            private set {}        
               
        }
        public string? CodePrio { get; set; }
        public DateTime? DateSoldePr { get; set; } 
        public DateTime? DateSuivi { get; set; } 
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Calcul
        {
            get
            {
                if (DateSoldePr.HasValue && DateSoldePr.Value.Year < 2000)
                {
                    return 0;
                }
                if (DateSoldePr.HasValue &&  DateSoldePr.Value.Year > 2000)
                {
                    return (int)Math.Floor((DateTime.Today - DateSoldePr.Value).TotalDays);
                }
                else
                {
                    return 0;
                }
            }
        }
        public int RAF { get; set; }
        public string? CommentairePrio { get; set; }
        public string? DTbem { get; set; }
        public string? DTbee { get; set; }
        public string? DTrd { get; set; }
        public string? DImi { get; set; }
        public string? BlSAQ { get; set; }
        public int ECOCount { get; set; }
        public int ECOYear { get; set; }
        public bool ECOSelected { get; set; }
       // [NotMapped]
        public string ECO 
        {
            get
            {
                if (ECOSelected==true)
                {
                    return $"{ECOCount.ToString().PadLeft(3, '0')}/{ECOYear}";
                }
                
                return string.Empty;
            }
            set { }
        }        
        public DateTime? DateSolde { get; set; }
        public string? Commentaires { get; set; }
        public DateTime? DateFinBE { get; set; } 
        public DateTime? DateFinBEE { get; set; }
        public DateTime? DateFinDT { get; set; }
        public DateTime? DateFinMI { get; set; } 
        public DateTime? DateFinSQ { get; set; }    
     
        public List<ActionItem>? ActionItems { get; set; }
    }

    public class ActionItem
    {
        [Key]
        public int ActionId { get; set; }       
        public string? Tilte { get; set; }
        public string? DescriptionA { get; set; }        
        public string? State { get; set; }        
        public DateTime? OpenDate { get; set; }       
        public DateTime? PlanDate { get; set; }       
        public DateTime? CloseDate { get; set; }
        
        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; }
    } 
}