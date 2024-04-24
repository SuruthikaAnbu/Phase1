using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vaccination
{
    public class Vaccination
    {
        private static int s_vaccinationID=3000;
        public string VacciantionID { get; set; }
        public string RegistrationNumber { get; set; }
        public string VaccineID { get; set; }
        public int DoseNumber { get; set; }
        public DateTime VaccinatedDate { get; set; }
        //constructor
        public Vaccination(string registrationNumber,string vaccineID,int doseNumber,DateTime vaccinatedDate)
        {
            s_vaccinationID++;
            VacciantionID="VID"+s_vaccinationID;
            RegistrationNumber=registrationNumber;
            VaccineID=vaccineID;
            DoseNumber=doseNumber;
            VaccinatedDate=vaccinatedDate;
        }
    }
}