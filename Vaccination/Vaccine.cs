using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vaccination
{
    public enum VaccinationName{Covishield,Covaccine}
    public class Vaccine
    {
        private static int s_vaccineID=2000;
        public string VaccineID { get; set; }
        public string VaccineName { get; set; }
        public int NoOfDoseAvailable { get; set; }

        public Vaccine(string vaccineName,int noOfDoseAvailable)
        {
            s_vaccineID++;
            VaccineID="CID"+s_vaccineID;
            VaccineName=vaccineName;
            NoOfDoseAvailable=noOfDoseAvailable;
        }

    }
}