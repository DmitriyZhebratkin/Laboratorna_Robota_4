using System;

namespace L4_Z4
{
    public enum LicenseType
    {
        Trial = 0,
        Pro,
        Ultimate
    }
    public class ApplicationLicense
    {
        public LicenseType License
        {
            get;
            private set;
        } = LicenseType.Trial;

        private const string ProKey = "BR2246-56FZ-3F88VU-8579-NJFKZF-99QW1D-H293-JPC2CT-3N9W-5CY72F";
        private const string UltimateKey = "9W0JB3-LEQC-90QYK5-NX2J-DYD7PZ-4BV9ZZ-LD9N-QZ0VU3-WGHE-Q6UG5F";

        public LicenseType ChangeLicense(string key)
        {
            if (key == ProKey)
                AllowPro();
            else if (key == UltimateKey)
                AllowUltimate();
            else
                AllowTrial();

            return License;
        }

        private void AllowUltimate()
        {
            License = LicenseType.Ultimate;
        }
        private void AllowTrial()
        {
            License = LicenseType.Trial;
        }
        private void AllowPro()
        {
            License = LicenseType.Pro;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var license = new ApplicationLicense();

            Console.WriteLine("Log your license key or tap Enter");
            license.ChangeLicense(Console.ReadLine());

            Console.WriteLine($"Your license: {license.License}");

            Console.WriteLine("Operations, that you can use:");
            Console.WriteLine(@"Addition - '+' (Trial+)");
            Console.WriteLine(@"Multiply - '*' (Pro+)");
            Console.WriteLine(@"Exponentiation - '^' (Ultimate+)");
            Console.WriteLine();

            Console.WriteLine("Write 1 argument");
            double firstArgument = double.Parse(Console.ReadLine());

            Console.WriteLine("Choose operation - '+', '*', or '^'");
            char operation = Console.ReadLine()[0];

            Console.WriteLine("Write 2 argument");
            double secondArgument = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine($"Your license: {license.License}");
            switch (operation)
            {
                case '+':
                    Console.WriteLine("Addition is usable");
                    Console.WriteLine($"Answear: {firstArgument + secondArgument}");
                    break;

                case '*':
                    if (license.License >= LicenseType.Pro)
                    {
                        Console.WriteLine("Multiply is usable");
                        Console.WriteLine($"Answear: {firstArgument * secondArgument}");
                    }
                    else
                        Console.WriteLine("Your license hasn't rights for multipling");

                    break;

                case '^':
                    if (license.License >= LicenseType.Ultimate)
                    {
                        Console.WriteLine("Exponentiation is usable");
                        Console.WriteLine($"Answear: {Math.Pow(firstArgument, secondArgument)}");
                    }
                    else
                        Console.WriteLine("Your license hasn't rights for exponentiating");

                    break;
            }

            Console.ReadLine();
        }
    }
}
