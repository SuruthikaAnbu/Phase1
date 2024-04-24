using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalShop
{
    public class MedicineDetails
    {
        private static int s_medicineID=100;
        public string MedicineID { get; set; }
        public string MedicineName { get; set; }
        public int AvailableCount { get; set; }
        public double Price { get; set; }
        public DateTime DateOfExpiry { get; set; }
        //constructor
        public MedicineDetails(string medicineName,int availableCount,double price,DateTime dateOfExpiry)
        {
            s_medicineID++;
            MedicineID="MD"+s_medicineID;
            MedicineName=medicineName;
            AvailableCount=availableCount;
            Price=price;
            DateOfExpiry=dateOfExpiry;
        }
        public MedicineDetails(string values)
        {
            string[] value=values.Split(",");
            s_medicineID=int.Parse(value[0].Remove(0,2));
            MedicineID=value[0];
            MedicineName=value[1];
            AvailableCount=int.Parse(value[2]);
            Price=double.Parse(value[3]);
            DateOfExpiry=DateTime.ParseExact(value[4],"dd/MM/yyyy",null);
        }
    }
}