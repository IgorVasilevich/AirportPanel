using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel
{
    enum flightStatus : int
    {
        CheckIn,
        GateClosed,
        Arrived,
        Departedat,
        Unknown,
        Canceled,
        Expected_At,
        Delayed,
        In_Flight
    }

    struct FlightInformation
    {
        public DateTime DayAndTimeArriv;
        public DateTime DayAndTimeDeprt;
        public string FlightNumber;
        public string PortArriv;
        public string PortDepart;
        public string Airline;
        public char Terminal;
        public flightStatus FlighStatus;
        public string Gate;

        public FlightInformation(DateTime dayAndTimeArriv, DateTime dayAndTimeDeprt, string flightnumber, string portArriv, string portDepart, string airline, char terminal, flightStatus flightstatus, string gate)
        {
            DayAndTimeArriv = dayAndTimeArriv;
            DayAndTimeDeprt = dayAndTimeDeprt;
            FlightNumber = flightnumber;
            PortArriv = portArriv;
            PortDepart = portDepart;
            Airline = airline;
            Terminal = terminal;
            FlighStatus = flightstatus;
            Gate = gate;
        }

    }

    class Program
    {


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WindowWidth = 159;

            FlightInformation[] FlightArrive = new FlightInformation[10];

            FlightArrive[0] = new FlightInformation(DateTime.Parse("07/08/2016 08:30:00"), DateTime.Parse("07/08/2016 05:45:00"), "KH8", "Kharkov", "Kyiv", "Turkish Airlines", 'A', flightStatus.Arrived, "59-16");
            FlightArrive[1] = new FlightInformation(DateTime.Parse("07/08/2016 10:45:00"), DateTime.Parse("07/08/2016 06:30:00"), "AH8", "Kharkov", "Lviv", "Turkish Airlines", 'B', flightStatus.Canceled, "66-16");
            FlightArrive[2] = new FlightInformation(DateTime.Parse("08/08/2016 00:22:00"), DateTime.Parse("07/08/2016 20:12:00"), "SG8", "Kyiv", "Tbilisi", "Ukrainian Airlines", 'B', flightStatus.Canceled, "22-15");
            FlightArrive[3] = new FlightInformation(DateTime.Parse("08/08/2016 07:22:00"), DateTime.Parse("08/08/2016 03:22:00"), "SK8", "Pekin", "Kiev", "China Airlines", 'C', flightStatus.Expected_At, "32-15");
            FlightArrive[4] = new FlightInformation(DateTime.Parse("10/08/2016 22:22:00"), DateTime.Parse("09/08/2016 23:15:00"), "PK8", "Kyiv", "Pekin", "China Airlines", 'C', flightStatus.CheckIn, "32-15");
            FlightArrive[5] = new FlightInformation(DateTime.Parse("08/08/2016 07:52:00"), DateTime.Parse("08/08/2016 13:22:00"), "SK7", "Paris", "Kiev", "China Airlines", 'A', flightStatus.In_Flight, "12-16");
            FlightArrive[6] = new FlightInformation(DateTime.Parse("10/08/2016 07:54:00"), DateTime.Parse("09/08/2016 15:54:00"), "SK9", "Kyiv", "Paris", "China Airlines", 'C', flightStatus.Departedat, "32-15");



            Console.WriteLine("Welcome to Airport panel\n\n\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("press any key to continue....");
            Console.ReadLine();
            Console.Clear();

            int choice = -1;
            
            do
            {


                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();

                Console.WriteLine("Menu:");
                Console.WriteLine("1. View all information about flights");
                Console.WriteLine("2. Search");
                Console.WriteLine("3. Emergency information");
                Console.WriteLine("4. Edit Data");
                Console.WriteLine("5: Exit");
                Console.Write("Enter your choise: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        int choise = -1;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("What output you want:");
                            Console.WriteLine("1. One by one");
                            Console.WriteLine("2. In grid");
                            Console.WriteLine("0. Back");
                            Console.WriteLine("Enter your choise:");
                            choise = int.Parse(Console.ReadLine());

                            if (choise == 1)
                            {

                                for (int i = 0; i < FlightArrive.Length; i++)
                                {
                                    if (FlightArrive[i].Airline != null && FlightArrive[i].FlightNumber != null && FlightArrive[i].PortArriv != null)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("FLIGHT INFORMATION");
                                        Console.WriteLine("Date and time arrival:{0}", (FlightArrive[i].DayAndTimeArriv.ToString()));
                                        Console.WriteLine("Date and time departure:{0}", (FlightArrive[i].DayAndTimeDeprt.ToString()));
                                        Console.WriteLine("Flight number:{0}", (FlightArrive[i].FlightNumber));
                                        Console.WriteLine("City of arrival:{0}", (FlightArrive[i].PortArriv));
                                        Console.WriteLine("City of departure:{0}", (FlightArrive[i].PortDepart));
                                        Console.WriteLine("Airline:{0}", (FlightArrive[i].Airline));
                                        Console.WriteLine("Terminal:{0}", (FlightArrive[i].Terminal.ToString()));
                                        Console.WriteLine("Flight status:{0}", (FlightArrive[i].FlighStatus.ToString()).Split('_'));
                                        Console.WriteLine("Gate:{0}", (FlightArrive[i].Gate));

                                        Console.WriteLine("------------------------------------------------------------------------------------------");
                                        Console.WriteLine("Next flight?(Yes(y) or No(n)");
                                        char yn = char.Parse(Console.ReadLine());
                                        if (yn == 'n')
                                            break;
                                        else if (yn == 'y')
                                            continue;
                                        else
                                        {
                                            Console.WriteLine("Wrong choise!");
                                            Console.ReadLine();
                                            break;
                                        }

                                    }
                                }
                                
                            }
                            else if (choise == 2)
                            {
                                Console.Clear();

                                Console.WriteLine("|Date and time arrival|Date and time departure|Flight N|City of arrival|City of departure|Airline                    |Terminal|Flight status|Gate ");
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
                                for (int i = 0; i < FlightArrive.Length; i++)
                                {
                                    if (FlightArrive[i].Airline != null && FlightArrive[i].FlightNumber != null && FlightArrive[i].PortArriv != null)
                                    {
                                        //Console.WriteLine("FLIGHT INFORMATION");
                                        Console.Write("|{0}", (FlightArrive[i].DayAndTimeArriv.ToString().PadRight(21)));
                                        Console.Write("|{0}", (FlightArrive[i].DayAndTimeDeprt.ToString().PadRight(23)));
                                        Console.Write("|{0}", (FlightArrive[i].FlightNumber).PadRight(8));
                                        Console.Write("|{0}", (FlightArrive[i].PortArriv).PadRight(15));
                                        Console.Write("|{0}", (FlightArrive[i].PortDepart).PadRight(17));
                                        Console.Write("|{0}", (FlightArrive[i].Airline).PadRight(27));
                                        Console.Write("|{0}", (FlightArrive[i].Terminal.ToString()).PadRight(8));
                                        Console.Write("|{0}", (FlightArrive[i].FlighStatus.ToString()).PadRight(13));
                                        Console.Write("|{0}", (FlightArrive[i].Gate).PadRight(8));
                                        Console.WriteLine();
                                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
                                    }

                                }

                                Console.WriteLine("Press any key to back");
                                Console.ReadLine();
                                
                            }
                            else if (choise == 0)
                            {
                                Console.Clear();
                                break;
                                
                            }
                        }
                        while (choise != 0);

                        break;

                    case 2:
                        int choiseCase2 = -1;

                        do
                        {

                            Console.Clear();
                            Console.WriteLine("Search menu:");
                            Console.WriteLine("1. Search by fligth number");
                            Console.WriteLine("2. Search by time arrival");
                            Console.WriteLine("3. Search by city of arrival");
                            Console.WriteLine("4. Search by nearest 5 hours to the specified time");
                            Console.WriteLine("0.Back");

                            choiseCase2 = int.Parse(Console.ReadLine());
                            //Search by fligth number
                            if (choiseCase2 == 1)
                            {
                                Console.WriteLine("Enter flight number:");
                                string fligtN = Console.ReadLine();
                                int counter = 0;
                                Console.Clear();
                                char yn;
                                for (int i = 0; i < FlightArrive.Length; i++)
                                {
                                    if (FlightArrive[i].FlightNumber == fligtN)
                                    {
                                        Console.WriteLine("Date and time arrival:{0}", (FlightArrive[i].DayAndTimeArriv.ToString()));
                                        Console.WriteLine("Date and time departure:{0}", (FlightArrive[i].DayAndTimeDeprt.ToString()));
                                        Console.WriteLine("Flight number:{0}", (FlightArrive[i].FlightNumber));
                                        Console.WriteLine("City of arrival:{0}", (FlightArrive[i].PortArriv));
                                        Console.WriteLine("City of departure:{0}", (FlightArrive[i].PortDepart));
                                        Console.WriteLine("Airline:{0}", (FlightArrive[i].Airline));
                                        Console.WriteLine("Terminal:{0}", (FlightArrive[i].Terminal.ToString()));
                                        Console.WriteLine("Flight status:{0}", (FlightArrive[i].FlighStatus.ToString()));
                                        Console.WriteLine("Gate:{0}", (FlightArrive[i].Gate));

                                        Console.WriteLine("------------------------------------------------------------------------------------------");
                                        counter++;
                                        Console.WriteLine("Next flight?(Yes(y) or No(n)");
                                        yn = char.Parse(Console.ReadLine());
                                        if (yn == 'n')
                                            break;

                                        else if (yn == 'y')
                                            continue;
                                        else
                                        {
                                            Console.WriteLine("Wrong choise!");
                                            Console.ReadLine();
                                            break;
                                        }
                                    }

                                }

                                if (counter == 0)
                                    Console.WriteLine("No data to otput");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                                

                            }

                            //Search by time arrival
                            if (choiseCase2 == 2)
                            {
                                Console.WriteLine("Enter search date and time from(dd/mm/yyyy hh:mm:ss):");
                                DateTime dateArr = DateTime.Parse(Console.ReadLine());

                                Console.WriteLine("Enter search date and time to(dd/mm/yyyy hh:mm:ss):");
                                DateTime dateArr1 = DateTime.Parse(Console.ReadLine());
                                char yn;
                                int counter = 0;
                                for (int i = 0; i < FlightArrive.Length; i++)
                                {
                                    if ((FlightArrive[i].DayAndTimeArriv > dateArr) && (FlightArrive[i].DayAndTimeArriv < dateArr1))
                                    {
                                        Console.WriteLine("Date and time arrival:{0}", (FlightArrive[i].DayAndTimeArriv.ToString()));
                                        Console.WriteLine("Date and time departure:{0}", (FlightArrive[i].DayAndTimeDeprt.ToString()));
                                        Console.WriteLine("Flight number:{0}", (FlightArrive[i].FlightNumber));
                                        Console.WriteLine("City of arrival:{0}", (FlightArrive[i].PortArriv));
                                        Console.WriteLine("City of departure:{0}", (FlightArrive[i].PortDepart));
                                        Console.WriteLine("Airline:{0}", (FlightArrive[i].Airline));
                                        Console.WriteLine("Terminal:{0}", (FlightArrive[i].Terminal.ToString()));
                                        Console.WriteLine("Flight status:{0}", (FlightArrive[i].FlighStatus.ToString()));
                                        Console.WriteLine("Gate:{0}", (FlightArrive[i].Gate));

                                        Console.WriteLine("------------------------------------------------------------------------------------------");
                                        counter++;
                                        Console.WriteLine("Next flight?(Yes(y) or No(n)");
                                        yn = char.Parse(Console.ReadLine());
                                        if (yn == 'n')
                                            break;
                                        else if (yn == 'y')
                                            continue;
                                        else
                                        {
                                            Console.WriteLine("Wrong choise!");
                                            Console.ReadLine();
                                            break;
                                        }
                                    }

                                }
                                if (counter == 0)
                                    Console.WriteLine("No data to otput");
                                Console.ReadLine();
                                Console.Clear();
                                
                                break;

                            }

                            //Search by city of arrival
                            if (choiseCase2 == 3)
                            {
                                Console.WriteLine("Enter a city of arrival:");
                                string cityArr = Console.ReadLine();
                                int counter = 0;
                                char yn;
                                for (int i = 0; i < FlightArrive.Length; i++)
                                {
                                    if (FlightArrive[i].PortArriv == cityArr)
                                    {
                                        Console.WriteLine("Date and time arrival:{0}", (FlightArrive[i].DayAndTimeArriv.ToString()));
                                        Console.WriteLine("Date and time departure:{0}", (FlightArrive[i].DayAndTimeDeprt.ToString()));
                                        Console.WriteLine("Flight number:{0}", (FlightArrive[i].FlightNumber));
                                        Console.WriteLine("City of arrival:{0}", (FlightArrive[i].PortArriv));
                                        Console.WriteLine("City of departure:{0}", (FlightArrive[i].PortDepart));
                                        Console.WriteLine("Airline:{0}", (FlightArrive[i].Airline));
                                        Console.WriteLine("Terminal:{0}", (FlightArrive[i].Terminal.ToString()));
                                        Console.WriteLine("Flight status:{0}", (FlightArrive[i].FlighStatus.ToString()));
                                        Console.WriteLine("Gate:{0}", (FlightArrive[i].Gate));

                                        Console.WriteLine("------------------------------------------------------------------------------------------");
                                        counter++;
                                        Console.WriteLine("Next flight?(Yes(y) or No(n)");
                                        yn = char.Parse(Console.ReadLine());
                                        if (yn == 'n')
                                            break;
                                        else if (yn == 'y')
                                            continue;
                                        else
                                        {
                                            Console.WriteLine("Wrong choise!");
                                            Console.ReadLine();
                                            break;
                                        }
                                    }

                                }

                                if (counter == 0)
                                    Console.WriteLine("No data to otput");
                                Console.ReadLine();
                                Console.Clear();
                                
                                break;

                            }

                            //Search by nearest to the specified time
                            if (choiseCase2 == 4)
                            {
                                int counter1 = 0;
                                Console.WriteLine("Enter a city of arrival(or press Enter to search by city of departure):");
                                string cityArr = Console.ReadLine();
                                string cityDep = "";
                                if (cityArr == "")
                                {
                                    Console.WriteLine("Enter a city of Departure:");
                                    cityDep = Console.ReadLine();
                                }


                                Console.WriteLine("Enter nearest date and time from(dd/mm/yyyy hh:mm:ss):");
                                DateTime dateArr = DateTime.Parse(Console.ReadLine());
                                DateTime dateArr2 = dateArr;
                                //adding 5 hourse to search
                                dateArr2 = dateArr2.AddHours(5);


                                //search nearest hour of departures
                                if (cityArr != "")
                                {
                                    FlightInformation[] FlightArrive1 = new FlightInformation[FlightArrive.Length];
                                    FlightInformation[] FlightAriive2 = new FlightInformation[FlightArrive.Length];
                                    for (int i = 0; i < FlightArrive.Length; i++)
                                    {
                                        if ((FlightArrive[i].DayAndTimeArriv > dateArr) && (FlightArrive[i].DayAndTimeArriv < dateArr2) && (FlightArrive[i].PortArriv == cityArr))
                                        {
                                            FlightArrive1[counter1] = FlightArrive[i];
                                            counter1++;
                                        }


                                    }

                                    if (counter1 > 1 && counter1 != 0)
                                    {
                                        for (int i = 0; i < (FlightArrive1.Length - 1); i++)
                                        {
                                            if (FlightArrive1[i].DayAndTimeDeprt > FlightArrive1[i + 1].DayAndTimeDeprt)
                                            {
                                                FlightAriive2[i] = FlightArrive1[i];
                                                FlightArrive1[i] = FlightArrive1[i + 1];
                                                FlightArrive1[i + 1] = FlightAriive2[2];
                                            }
                                        }
                                    }


                                    for (int i = 0; i < FlightArrive1.Length; i++)
                                    {

                                        if (FlightArrive1[i].Airline != null && FlightArrive1[i].FlightNumber != null && FlightArrive1[i].PortArriv != null)
                                        {
                                            Console.WriteLine("Date and time arrival:{0}", (FlightArrive1[i].DayAndTimeArriv.ToString()));
                                            Console.WriteLine("Date and time departure:{0}", (FlightArrive1[i].DayAndTimeDeprt.ToString()));
                                            Console.WriteLine("Flight number:{0}", (FlightArrive1[i].FlightNumber));
                                            Console.WriteLine("City of arrival:{0}", (FlightArrive1[i].PortArriv));
                                            Console.WriteLine("City of departure:{0}", (FlightArrive1[i].PortDepart));
                                            Console.WriteLine("Airline:{0}", (FlightArrive1[i].Airline));
                                            Console.WriteLine("Terminal:{0}", (FlightArrive1[i].Terminal.ToString()));
                                            Console.WriteLine("Flight status:{0}", (FlightArrive1[i].FlighStatus.ToString()));
                                            Console.WriteLine("Gate:{0}", (FlightArrive1[i].Gate));

                                            Console.WriteLine("------------------------------------------------------------------------------------------");

                                        }
                                    }
                                }



                                if (cityArr == "")
                                {
                                    FlightInformation[] FlightArrive1 = new FlightInformation[FlightArrive.Length];
                                    FlightInformation[] FlightAriive2 = new FlightInformation[FlightArrive1.Length];
                                    for (int i = 0; i < FlightArrive.Length; i++)
                                    {
                                        if ((FlightArrive[i].DayAndTimeDeprt > dateArr) && (FlightArrive[i].DayAndTimeDeprt < dateArr2) && (FlightArrive[i].PortDepart == cityDep))
                                        {
                                            FlightArrive1[counter1] = FlightArrive[i];
                                            counter1++;
                                        }


                                    }


                                    if (counter1 > 1 && counter1 != 0)
                                    {
                                        for (int i = 0; i < (FlightArrive1.Length - 1); i++)
                                        {
                                            if (FlightArrive1[i].DayAndTimeArriv > FlightArrive1[i + 1].DayAndTimeArriv)
                                            {
                                                FlightAriive2[i] = FlightArrive[i];
                                                FlightArrive[i] = FlightArrive[i + 1];
                                                FlightArrive[i + 1] = FlightAriive2[2];
                                            }
                                        }
                                    }


                                    for (int i = 0; i < FlightArrive1.Length; i++)
                                    {

                                        if (FlightArrive1[i].Airline != null && FlightArrive1[i].FlightNumber != null && FlightArrive1[i].PortArriv != null)
                                        {
                                            Console.WriteLine("Date and time arrival:{0}", (FlightArrive[i].DayAndTimeArriv.ToString()));
                                            Console.WriteLine("Date and time departure:{0}", (FlightArrive[i].DayAndTimeDeprt.ToString()));
                                            Console.WriteLine("Flight number:{0}", (FlightArrive[i].FlightNumber));
                                            Console.WriteLine("City of arrival:{0}", (FlightArrive[i].PortArriv));
                                            Console.WriteLine("City of departure:{0}", (FlightArrive[i].PortDepart));
                                            Console.WriteLine("Airline:{0}", (FlightArrive[i].Airline));
                                            Console.WriteLine("Terminal:{0}", (FlightArrive[i].Terminal.ToString()));
                                            Console.WriteLine("Flight status:{0}", (FlightArrive[i].FlighStatus.ToString()));
                                            Console.WriteLine("Gate:{0}", (FlightArrive[i].Gate));

                                            Console.WriteLine("------------------------------------------------------------------------------------------");
                                            counter1++;
                                        }
                                    }
                                }





                                if (counter1 == 0)
                                    Console.WriteLine("No data to otput");
                                Console.ReadLine();
                                Console.Clear();
                                
                                break;

                            }
                            if (choiseCase2 == 0)
                               break;
                        }
                        while (choiseCase2 != 0);
                        break;
                        
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine(@"Emergency Information
We are committed to providing accurate, timely information to news media should an on-site emergency take place at International Airport. 
Please be mindful that the early minutes of an emergency situation are dedicated to the emergency response.
Please keep the following in mind should an emergency occur at the airport.
Early during the emergency period, we will issue an advisory designating the location of media briefings. 
We will do our best to provide a working area for credentialed media.
The Airport Authority will provide periodic briefings as information becomes available. 
If an aircraft is involved, the National Transportation Safety Board (NTSB) 
will become responsible for the release of information once the agency arrives on site.
The Airport Authority spokesperson will only provide basic information during the early stages of the emergency.
Once airport officials have been given approval, the Airport Authority will escort media to the incident site.
In the case of aircraft incidents off airport property, an Airport Authority representative will respond. 
The time and location for media briefings will be coordinated with the local jurisdiction.
Information Dissemination Responsibilities
The following is a summary of information disseminated during an emergency and the agency responsible for communicating with the media.
Confirmation of an incident: Airport Authority Marketing Communications
Cause of an aircraft incident: National Transportation Safety Board
Passenger manifest: Airline involved in the incident
Passenger and bag screening process: Transportation Security Administration
Air traffic control communication: Federal Aviation Administration);");
                        Console.WriteLine("Press any key");
                        Console.ReadLine();
                        

                        break;
                        
                    case 4:
                        int choiseCase4 = -1;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("1. Input information");
                            Console.WriteLine("2. Edit information");
                            Console.WriteLine("3. Delete information");
                            Console.WriteLine("4. Back");
                            choiseCase4 = int.Parse(Console.ReadLine());
                            int iteration = -1;
                            if (choiseCase4 == 1)
                            {
                                //enable space to wright
                                for (int i = 0; i < FlightArrive.Length; i++)
                                {
                                    if ((FlightArrive[i].Airline == null && FlightArrive[i].FlightNumber == null))
                                    {
                                        iteration = i;

                                    }
                                }

                                if (iteration == -1)
                                {
                                    Console.WriteLine("No place to input");
                                   
                                    break;
                                }


                                Console.WriteLine("Enter value of date and time of Arrive(dd/mm/yyyy hh:mm:ss):");
                                FlightArrive[iteration].DayAndTimeArriv = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Enter value of date and time of Departure(dd/mm/yyyy hh:mm:ss):");
                                FlightArrive[iteration].DayAndTimeDeprt = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Enter value of Flight number:");
                                FlightArrive[iteration].FlightNumber = Console.ReadLine();
                                Console.WriteLine("Enter a city of arrive:");
                                FlightArrive[iteration].PortArriv = Console.ReadLine();
                                Console.WriteLine("Enter a city of departure:");
                                FlightArrive[iteration].PortDepart = Console.ReadLine();
                                Console.WriteLine("Enter a name of Airline:");
                                FlightArrive[iteration].Airline = Console.ReadLine();
                                Console.WriteLine("Enter a Terminal:");
                                FlightArrive[iteration].Terminal = char.Parse(Console.ReadLine());
                                Console.WriteLine("Enter a Flight status:");


                                string status = Console.ReadLine();
                                if (status == "Chek in" || status == "chek in" || status == "Chek In")
                                    FlightArrive[iteration].FlighStatus = flightStatus.CheckIn;
                                else if (status == "Gate closed" || status == "gate closed" || status == "Gate closed")
                                    FlightArrive[iteration].FlighStatus = flightStatus.GateClosed;
                                else if (status == "Arrived" || status == "arrived" || status == "arived")
                                    FlightArrive[iteration].FlighStatus = flightStatus.Arrived;
                                else if (status == "Department At" || status == "Departmnet at" || status == "department at")
                                    FlightArrive[iteration].FlighStatus = flightStatus.Departedat;
                                else if (status == "Unknown" || status == "unknown" || status == "uknown")
                                    FlightArrive[iteration].FlighStatus = flightStatus.Departedat;
                                else if (status == "Canceled" || status == "canceled" || status == "cancel")
                                    FlightArrive[iteration].FlighStatus = flightStatus.Canceled;
                                else if (status == "Expected At" || status == "expected at" || status == "Expected at")
                                    FlightArrive[iteration].FlighStatus = flightStatus.Expected_At;
                                else if (status == "Delayed" || status == "delayed" || status == "delay")
                                    FlightArrive[iteration].FlighStatus = flightStatus.Delayed;
                                else if (status == "In flight" || status == "In Flight" || status == "in flight")
                                    FlightArrive[iteration].FlighStatus = flightStatus.Departedat;

                                Console.WriteLine("Enter a Gate:");
                                FlightArrive[iteration].Gate = Console.ReadLine();



                                Console.WriteLine("Proccess end!");
                                Console.ReadLine();
                            }
                            if (choiseCase4 == 2)
                            {
                                char yn;
                                for (int i = 0; i < FlightArrive.Length; i++)
                                {
                                    Console.Clear();
                                    if (FlightArrive[i].Airline != null)
                                    {
                                        Console.WriteLine("Position number:{0}", i);
                                        Console.WriteLine("Date and time arrival:{0}", (FlightArrive[i].DayAndTimeArriv.ToString()));
                                        Console.WriteLine("Date and time departure:{0}", (FlightArrive[i].DayAndTimeDeprt.ToString()));
                                        Console.WriteLine("Flight number:{0}", (FlightArrive[i].FlightNumber));
                                        Console.WriteLine("City of arrival:{0}", (FlightArrive[i].PortArriv));
                                        Console.WriteLine("City of departure:{0}", (FlightArrive[i].PortDepart));
                                        Console.WriteLine("Airline:{0}", (FlightArrive[i].Airline));
                                        Console.WriteLine("Terminal:{0}", (FlightArrive[i].Terminal.ToString()));
                                        Console.WriteLine("Flight status:{0}", (FlightArrive[i].FlighStatus.ToString()));
                                        Console.WriteLine("Gate:{0}", (FlightArrive[i].Gate));

                                        Console.WriteLine("------------------------------------------------------------------------------------------");
                                        Console.WriteLine("Next flight?(Yes(y) or No(n)");
                                        yn = char.Parse(Console.ReadLine());
                                        if (yn == 'n')
                                            break;

                                        else if (yn == 'y')
                                            continue;
                                        else
                                        {
                                            Console.WriteLine("Wrong choise!");
                                            Console.ReadLine();
                                            break;
                                        }


                                    }
                                }
                               
                                Console.WriteLine("Enter position number:");
                                int iter = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter value of date and time of Arrive(dd/mm/yyyy hh:mm:ss):");
                                FlightArrive[iter].DayAndTimeArriv = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Enter value of date and time of Departure(dd/mm/yyyy hh:mm:ss):");
                                FlightArrive[iter].DayAndTimeDeprt = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Enter value of Flight number:");
                                FlightArrive[iter].FlightNumber = Console.ReadLine();
                                Console.WriteLine("Enter a city of arrive:");
                                FlightArrive[iter].PortArriv = Console.ReadLine();
                                Console.WriteLine("Enter a city of departure:");
                                FlightArrive[iter].PortDepart = Console.ReadLine();
                                Console.WriteLine("Enter a name of Airline:");
                                FlightArrive[iter].Airline = Console.ReadLine();
                                Console.WriteLine("Enter a Terminal:");
                                FlightArrive[iter].Terminal = char.Parse(Console.ReadLine());
                                Console.WriteLine("Enter a Flight status:");

                                string status = Console.ReadLine();
                                if (status == "Chek in" || status == "chek in" || status == "Chek In")
                                    FlightArrive[iter].FlighStatus = flightStatus.CheckIn;
                                else if (status == "Gate closed" || status == "gate closed" || status == "Gate closed")
                                    FlightArrive[iter].FlighStatus = flightStatus.GateClosed;
                                else if (status == "Arrived" || status == "arrived" || status == "arived")
                                    FlightArrive[iter].FlighStatus = flightStatus.Arrived;
                                else if (status == "Department At" || status == "Departmnet at" || status == "department at")
                                    FlightArrive[iteration].FlighStatus = flightStatus.Departedat;
                                else if (status == "Unknown" || status == "unknown" || status == "uknown")
                                    FlightArrive[iter].FlighStatus = flightStatus.Departedat;
                                else if (status == "Canceled" || status == "canceled" || status == "cancel")
                                    FlightArrive[iteration].FlighStatus = flightStatus.Canceled;
                                else if (status == "Expected At" || status == "expected at" || status == "Expected at")
                                    FlightArrive[iter].FlighStatus = flightStatus.Expected_At;
                                else if (status == "Delayed" || status == "delayed" || status == "delay")
                                    FlightArrive[iter].FlighStatus = flightStatus.Delayed;
                                else if (status == "In flight" || status == "In Flight" || status == "in flight")
                                    FlightArrive[iter].FlighStatus = flightStatus.Departedat;

                                Console.WriteLine("Enter a Gate:");
                                FlightArrive[iter].Gate = Console.ReadLine();
                                
                                break;

                            }





                            if (choiseCase4 == 3)
                            {
                                for (int i = 0; i < FlightArrive.Length; i++)
                                {

                                    if (FlightArrive[i].Airline != null)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Position number:{0}", i);
                                        Console.WriteLine("Date and time arrival:{0}", (FlightArrive[i].DayAndTimeArriv.ToString()));
                                        Console.WriteLine("Date and time departure:{0}", (FlightArrive[i].DayAndTimeDeprt.ToString()));
                                        Console.WriteLine("Flight number:{0}", (FlightArrive[i].FlightNumber));
                                        Console.WriteLine("City of arrival:{0}", (FlightArrive[i].PortArriv));
                                        Console.WriteLine("City of departure:{0}", (FlightArrive[i].PortDepart));
                                        Console.WriteLine("Airline:{0}", (FlightArrive[i].Airline));
                                        Console.WriteLine("Terminal:{0}", (FlightArrive[i].Terminal.ToString()));
                                        Console.WriteLine("Flight status:{0}", (FlightArrive[i].FlighStatus.ToString()));
                                        Console.WriteLine("Gate:{0}", (FlightArrive[i].Gate));

                                        Console.WriteLine("------------------------------------------------------------------------------------------");
                                        Console.WriteLine("Next flight?(Yes(y) or No(n)");
                                        char yn = char.Parse(Console.ReadLine());
                                        if (yn == 'n')
                                            break;
                                        else if (yn == 'y')
                                            continue;
                                        else
                                        {
                                            Console.WriteLine("Wrong choise!");
                                            Console.ReadLine();
                                            break;
                                        }

                                    }
                                }
                                    Console.WriteLine("Enter position number:");
                                    int iter = int.Parse(Console.ReadLine());

                                    FlightArrive[iter].Airline = null;
                                    FlightArrive[iter].DayAndTimeArriv = new DateTime();
                                    FlightArrive[iter].DayAndTimeDeprt = new DateTime();
                                    FlightArrive[iter].FlightNumber = null;
                                    FlightArrive[iter].Gate = null;
                                    FlightArrive[iter].PortArriv = null;
                                    FlightArrive[iter].PortDepart = null;
                                    FlightArrive[iter].Terminal = ' ';

                                
                            }
                            if (choiseCase4 == 1)
                                
                                break;
                        }
                        while (choiseCase4 != 4);
                        break;

                    case 5:
                        break;
                    default:
                        Console.WriteLine("Enter wrong choice!!!!");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                       

                }

            }
            while (choice != 5);

        }

    }
}

