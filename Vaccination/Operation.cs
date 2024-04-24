using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Vaccination;
public static class Operation
{
    public static List<Vaccination> vaccinationList = new List<Vaccination>();
    public static List<Beneficiary> beneficiearyList = new List<Beneficiary>();
    public static List<Vaccine> vaccineList = new List<Vaccine>();
    public static Beneficiary currentCustomer;
    //mainmenu
    //main menu
    public static void MainMenu()
    {

        bool mainFlag = true;
        do
        {
            Console.WriteLine("--VACCINATION APPLICATION--");
            Console.WriteLine("--CHOOSE ONE--\n1.Beneficiary Registration\n2.login\n3.Get vaccine info\n4.Exit");
            int mainChoice = int.Parse(Console.ReadLine());
            switch (mainChoice)
            {
                case 1:
                    {
                        Console.WriteLine("Registration");
                        Registration();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Login");
                        Login();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Get vaccine info");
                        GetVaccineInfo();
                        break;
                    }
                case 4:
                    {
                        mainFlag = false;
                        Console.WriteLine("Exit from main menu");
                        break;
                    }
            }
        } while (mainFlag);
    }
        //registration
    public static void Registration()
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your age : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter your Gender male/female : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter your mobile : ");
            string mobile = Console.ReadLine();
            Console.Write("Enter your city : ");
            string city = Console.ReadLine();

            Beneficiary customer = new Beneficiary(name, age, gender, mobile, city);
            beneficiearyList.Add(customer);
            Console.WriteLine("Registtration successful your registration number is : " + customer.RegistrationNumber);

        }
        //Login
        public static void Login()
        {
            Console.WriteLine("--Log IN--");
            Console.WriteLine("Enter your registration number");
            string checkRegistrationID = Console.ReadLine();
            bool flag = true;
            foreach (Beneficiary customer in beneficiearyList)
            {
                if (customer.RegistrationNumber == checkRegistrationID)
                {
                    flag = false;
                    currentCustomer = customer;
                    Console.WriteLine("Login successful");
                    SubMenu();
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid registration number");
            }

        }
        //submenu
        public static void SubMenu()
        {
            bool subFlag = true;
            do
            {
                Console.WriteLine("--choose one--\n1.Show my detail\n2.take vaccination\n3.my vaccination history\n4.next due date\n5.Exit");
                int subChoice = int.Parse(Console.ReadLine());
                switch (subChoice)
                {
                    case 1:
                        {
                            Console.WriteLine("Show Customer Details");
                            ShowMyDetails();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Show Product Details");
                            TakeVaccination();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Wallet Recharge");
                            VaccinationHistory();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Take Order");
                            NextDueDate();
                            break;
                        }
                    case 5:
                        {
                            subFlag = false;
                            Console.WriteLine("Exit from submenu");
                            break;
                        }
                }

            } while (subFlag);
        }
        //ShowMyDetails
        public static void ShowMyDetails()
        {
            Console.WriteLine("Register Number	Name	Age	Gender	Mobile	City");
            foreach (Beneficiary ben1 in beneficiearyList)
            {
                if(currentCustomer.RegistrationNumber==ben1.RegistrationNumber)
                {
                Console.WriteLine($"{ben1.RegistrationNumber}|{ben1.Name}|{ben1.Age}|{ben1.Gender}|{ben1.MobileNumber}|{ben1.City}");
                }
            }

        }
        public static void TakeVaccination()
        {
            Console.WriteLine("VaccineID	VaccineName	NoOfDoseAvailable");
            foreach (Vaccine vac in vaccineList)
            {
                Console.WriteLine($"{vac.VaccineID}|{vac.VaccineName}|{vac.NoOfDoseAvailable}");
            }
            bool flag=true;
            Console.WriteLine("Enter the vaccine id");
            string choosenVaccineId=Console.ReadLine();
            foreach (Vaccine vaccine in vaccineList)
            {
                if(vaccine.VaccineID==choosenVaccineId)
                {
                    flag=false;
                    int count=0;
                    DateTime lastVaccinationDate=new DateTime();
                    //Console.WriteLine("1111");
                    foreach(Vaccination vaccination1 in vaccinationList)
                    {
                        if(currentCustomer.RegistrationNumber==vaccination1.RegistrationNumber)
                        {
                            count++;
                            lastVaccinationDate=vaccination1.VaccinatedDate;
                        }
                    }
                    DateTime span=lastVaccinationDate.AddDays(30);
                    if(count==3)
                    {
                        Console.WriteLine("all the three vaccination are completed, you cannot vaccinated noe");
                    }
                    if(count>0 && count<3)
                    {
                        bool vaccinationflag=true;
                        foreach(Vaccination vaccination2 in vaccinationList)
                        {
                            if(choosenVaccineId==vaccination2.VaccineID)
                            {
                                vaccinationflag=false;
                                if(span< DateTime.Now)
                                {
                                    Vaccination vaccination0=new Vaccination(currentCustomer.RegistrationNumber,choosenVaccineId,count+1,DateTime.Now);
                                    vaccinationList.Add(vaccination0);
                                    vaccine.NoOfDoseAvailable--;
                                    Console.WriteLine("vaccination completed and your vaccination id is "+vaccination0.VacciantionID);
                                    break;
                                }
                            }
                        }
                        if(vaccinationflag)
                        {
                            Console.WriteLine("you have selected the different vaccination id. you have vaccine with "+vaccine.VaccineName);
                            TakeVaccination();
                        }
                    }
                    if(count==0)
                    {
                        Console.WriteLine("New beneficiary");
                        if(currentCustomer.Age>14)
                        {
                            Vaccination vaccination1=new Vaccination(currentCustomer.RegistrationNumber,choosenVaccineId,count+1,DateTime.Now);
                            vaccinationList.Add(vaccination1);
                            vaccine.NoOfDoseAvailable--;
                            Console.WriteLine("vaccination completed and your vaccination id is "+vaccination1.VacciantionID);
                            break;
                            
                        }
                        else{
                            Console.WriteLine("age must be generated more than 14 and you are not eligible");
                        }
                    }

                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid vaccineID");
            }


        }
        public static void VaccinationHistory()
        {
            Console.WriteLine("VaccinationID	RegisterNumber	VaccineID	DoseNumber	VaccinatedDate");
                foreach (Vaccination vacc in vaccinationList)
                {
                    if(currentCustomer.RegistrationNumber==vacc.RegistrationNumber)
                    {
                    Console.WriteLine($"{vacc.VacciantionID}|{vacc.RegistrationNumber}|{vacc.VaccineID}|{vacc.DoseNumber}|{vacc.VaccinatedDate}");
                    }
                }


        }
        public static void NextDueDate()
        {
            int count=0;
            DateTime lastVaccinationDate=new DateTime();
            foreach(Vaccination vacc in vaccinationList)
            {
                if(currentCustomer.RegistrationNumber==vacc.RegistrationNumber)
                {
                    count++;
                    lastVaccinationDate=vacc.VaccinatedDate;
                }
            }
            if(count==0)
            {
                Console.WriteLine("you can take vaccine now");

            }
            if(count==1)
            {
                Console.WriteLine($"your next dose {count+1} date for vaccination{lastVaccinationDate.AddDays(30).ToString("dd/MM/yyyy")}");

            }
            if(count==2)
            {
                Console.WriteLine($"your next dose {count+1} date for vaccination{lastVaccinationDate.AddDays(30).ToString("dd/MM/yyyy")}");

            }
            if(count==3)
            {
                Console.WriteLine("you have completed all vaccination. thanks for participating in the vaccination drive");

            }

        }
        //get vaccine Info

        public static void GetVaccineInfo()
            {
                Console.WriteLine("VaccineID	VaccineName	NoOfDoseAvailable");
                foreach (Vaccine vac in vaccineList)
                {
                    Console.WriteLine($"{vac.VaccineID}|{vac.VaccineName}|{vac.NoOfDoseAvailable}");
                }

            }

            //add default data
            public static void AddDefaultData()
            {
                Beneficiary beneficiary1 = new Beneficiary("Ravichandran", 21, Gender.male, "8484484", "Chennai");
                Beneficiary beneficiary2 = new Beneficiary("Baskaran", 22, Gender.male, "8484487", "Chennai");
                beneficiearyList.Add(beneficiary1);
                beneficiearyList.Add(beneficiary2);
                Console.WriteLine("Register Number	Name	Age	Gender	Mobile	City");
                foreach (Beneficiary ben1 in beneficiearyList)
                {
                    Console.WriteLine($"{ben1.RegistrationNumber}|{ben1.Name}|{ben1.Age}|{ben1.Gender}|{ben1.MobileNumber}|{ben1.City}");
                }

                Vaccine vaccine1 = new Vaccine("Covishield", 50);
                Vaccine vaccine2 = new Vaccine("Covaccine", 50);
                vaccineList.Add(vaccine1);
                vaccineList.Add(vaccine2);
                Console.WriteLine("VaccineID	VaccineName	NoOfDoseAvailable");
                foreach (Vaccine vac in vaccineList)
                {
                    Console.WriteLine($"{vac.VaccineID}|{vac.VaccineName}|{vac.NoOfDoseAvailable}");
                }

                Vaccination vac1 = new Vaccination("BID1001", "CID2001", 1, new DateTime(2021, 11, 11));
                Vaccination vac2 = new Vaccination("BID1001", "CID2001", 2, new DateTime(2022, 11, 03));
                Vaccination vac3 = new Vaccination("BID1002", "CID2002", 1, new DateTime(2021, 04, 04));
                vaccinationList.Add(vac1);
                vaccinationList.Add(vac2);
                vaccinationList.Add(vac3);
                Console.WriteLine("VaccinationID	RegisterNumber	VaccineID	DoseNumber	VaccinatedDate");
                foreach (Vaccination vacc in vaccinationList)
                {
                    Console.WriteLine($"{vacc.VacciantionID}|{vacc.RegistrationNumber}|{vacc.VaccineID}|{vacc.DoseNumber}|{vacc.VaccinatedDate}");
                }


            }

        }
    
