/*Jiafei Chen
 * ST10187612
 * PROG6221
 * ICE Task 1
*/
class ScriptDistrabutor
{
    //variable declaration with lambda function
    public int numOfScripts { get => _numOfScripts; set => _numOfScripts = value > 0 ? value : 0; }
    private int _numOfScripts;
    public int numOfQ { get => _numOfQ; set => _numOfQ = (value >= 1 && value <= 10) ? value : 0; }
    private int _numOfQ;
    public int subTotal { get => _subTotal; set => _subTotal = value > 0 ? value : 0; }
    private int _subTotal;
    public int total;
    public int numOfLec { get => _numOfLec; set => _numOfLec = value > 0 ? value : 0; }
    private int _numOfLec;
    
    //method to calculate and display report
    public void DisplayReport()
    {
        //calulate number of scripts that needs to be marked
        int numPerLec = _numOfScripts / _numOfLec;
        int extraScript = _numOfScripts % _numOfLec;
        Console.WriteLine($"There are {numPerLec} scripts per lecturers");
        if (extraScript != 0)
        {
            Console.WriteLine($"There are {extraScript} scripts extra for the last lecturer");
        }

        //calculate time needed to mark scripts
        double hours = CalcTime(numPerLec);
        hours += CalcTime(extraScript);
        double minutes = hours * 60;
        double seconds = minutes * 60;
        minutes = minutes % 60;
        seconds = seconds % 60;
        if (seconds > 30)
            minutes++;
        Console.WriteLine($"The time needed to mark all the scripts is {Math.Floor(hours)} hours {Math.Floor(minutes)} minutes");
        Console.ReadLine();
    }

    //method for calculating hours needed
    private double CalcTime(int ns)
    {
        int numOfTicks = ns * _numOfQ * total;
        double seconds = numOfTicks * 2;
        double hours = seconds /60/60;
        return hours;
    }
}

//main class
class ScriptDistrabutorApp
{
    public static void Main(string[] args)
    {
        var sd = new ScriptDistrabutor();
        Console.WriteLine("****************************************************");
        Console.WriteLine("Thank you for using the Script Distrabutor");
        Console.WriteLine("****************************************************");

        //basic input validation loop
        while (sd.numOfScripts == 0)
        {
            Console.WriteLine("Please enter the number of scripts (Can't be 0 or negative)");
            sd.numOfScripts = Convert.ToInt32(Console.ReadLine());
        }
        while (sd.numOfQ == 0)
        {
            Console.WriteLine("Please enter the number of questions on the script (From 1 to 10)");
            sd.numOfQ = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < sd.numOfQ; i++)
        {
            Console.WriteLine($"Please enter the subtotal for Question {i + 1} (Can't be 0 or negative)");
            while (sd.subTotal == 0)
            {
                sd.subTotal = Convert.ToInt32(Console.ReadLine());
            }
            sd.total += sd.subTotal;
            sd.subTotal = 0;
        }
        while(sd.numOfLec == 0)
        {
            Console.WriteLine("Please enter the number of lecturers marking the scripts (Can't be 0 or negative)");
            sd.numOfLec = Convert.ToInt32(Console.ReadLine());
        }
        //calls method to calculate and display all data
        sd.DisplayReport();
    }
}