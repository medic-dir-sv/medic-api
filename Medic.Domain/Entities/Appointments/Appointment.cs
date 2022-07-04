using Medic.Domain.Entities.Clinics;
using Medic.Domain.Entities.Doctors;
using Medic.Domain.Entities.Patients;

namespace Medic.Domain.Entities.Appointments;

public class Appointment
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public Patient? Patient { get; set; }
    
    public Doctor? Doctor { get; set; }
    
    public Center? Clinic { get; set; }
    
    public bool IsAccepted { get; set; }
}