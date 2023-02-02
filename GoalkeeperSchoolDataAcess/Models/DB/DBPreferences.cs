using System.ComponentModel.DataAnnotations;
using GoalkeeperSchoolDataAcess.Models.DB;

namespace GoalkeeperSchoolDataAcess.Models;

public class DBPreferences
{
    [Required]
    public DBAddress PlaceOfTraining { get; set; }
    
    [Required]
    public DBHoursEnum TrainingHoursMonday { get; set; }
    
    [Required]
    public DBHoursEnum TrainingHoursTuesday  { get; set; }
    
    [Required]
    public DBHoursEnum TrainingHoursMonday { get; set; }
    
    [Required]
    public DBHoursEnum TrainingHoursMonday { get; set; }
    
    [Required]
    public DBHoursEnum TrainingHoursMonday { get; set; }
    
    [Required]
    public DBHoursEnum TrainingHoursMonday { get; set; }
    
    [Required]
    public DBHoursEnum TrainingHoursMonday { get; set; }
}