using System;

namespace RyanairSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = new TaxInfo();


            Console.Write("Hour Rate : ");
            info.Rate = Convert.ToInt32(Console.ReadLine().Trim());

            Console.Write("Work Hours : ");
            info.Worked = Convert.ToInt32(Console.ReadLine().Trim());

            Console.Write("Location(Country) : ");
            info.Location = Console.ReadLine().Trim().ToString();

            var process = new TaxCalculateProcess(CountryFactory(info.Location));

            var result = process.Calculate(info);

            ShowResults(result);
        }

        static void ShowResults(TaxInfoOutput taxInfoOutput)
        {
            Console.WriteLine($"Employee Location: {taxInfoOutput.Location}");
            Console.WriteLine($"GrossAmount: €{taxInfoOutput.Gross}");
            Console.WriteLine("Less deductions");
            Console.WriteLine($"Income Tax: €{taxInfoOutput.IncomeTax}");
            Console.WriteLine($"Universal Social Charge: €{taxInfoOutput.SocialCharge}");
            Console.WriteLine($"Pension:€{taxInfoOutput.Pension}");
            Console.WriteLine($"Net Amount: €{taxInfoOutput.NetAmount}");
        }

        static ITaxCalculator CountryFactory(string location)
        {
            switch (location)
            {
                case "Ireland":
                    return new IrelandTaxCalculator();
                case "Italy":
                    return new ItaliaTaxCalculator();
                case "Germany":
                    return new GermanyTaxCalculator();
                default:
                    return new TaxCalculator();
            }
        }
    }


    public class TaxCalculateProcess
    {
        private readonly ITaxCalculator calculator;

        public TaxCalculateProcess(ITaxCalculator calculator)
        {
            this.calculator = calculator;
        }

        public TaxInfoOutput Calculate(TaxInfo taxInfo)
        {
            return this.calculator.CalculateTax(taxInfo);
        }
    }

    public class TaxInfo
    {
        public int Rate { get; set; }
        public int Worked { get; set; }
        public string Location { get; set; }
    }

    public class TaxInfoOutput
    {
        public double Gross { get; set; }
        public double IncomeTax { get; set; }
        public double Pension { get; set; }
        public double SocialCharge { get; set; }
        public double NetAmount { get; set; }
        public string Location { get; set; }
    }

    public interface ITaxCalculator
    {
        TaxInfoOutput CalculateTax(TaxInfo taxInfo);
    }

    public class TaxCalculator : ITaxCalculator
    {
        public TaxInfoOutput CalculateTax(TaxInfo taxInfo)
        {
            return new TaxInfoOutput
            {
                Location = taxInfo.Location,
                Gross = taxInfo.Worked * taxInfo.Rate,
            };
        }
    }

    public class IrelandTaxCalculator : ITaxCalculator
    {
        public TaxInfoOutput CalculateTax(TaxInfo taxInfo)
        {
            var gross = taxInfo.Worked * taxInfo.Rate;

            var firstIncomeTax = 600 * 0.25;
            var incomeTax = (gross - 600) * 0.4 + firstIncomeTax;

            const double firstSocialCharge = 500 * 0.07;
            var universalSocialCharge = (gross - 500) * 0.08 + firstSocialCharge;

            var pension = gross * 0.04;

            return new TaxInfoOutput
            {
                Location = taxInfo.Location,
                IncomeTax = incomeTax,
                Gross = gross,
                Pension = pension,
                SocialCharge = universalSocialCharge,
                NetAmount = gross - (incomeTax + universalSocialCharge + pension)
            };
        }
    }

    public class ItaliaTaxCalculator : ITaxCalculator
    {
        public TaxInfoOutput CalculateTax(TaxInfo taxInfo)
        {
            var gross = taxInfo.Worked * taxInfo.Rate;
            var incomeTax = gross * 0.25;

            double iNPSContribution = gross * 0.0919;

            var netAmount = gross - (incomeTax + iNPSContribution);


            return new TaxInfoOutput
            {
                Location = taxInfo.Location,
                IncomeTax = incomeTax,
                Gross = gross,
                NetAmount = netAmount
            };
        }
    }

    public class GermanyTaxCalculator : ITaxCalculator
    {
        public TaxInfoOutput CalculateTax(TaxInfo taxInfo)
        {
            var gross = taxInfo.Worked * taxInfo.Rate;

            var firstIncomeTax = 400 * 0.25;
            var incomeTax = (gross - 400) * 0.32 + firstIncomeTax;

            var pension = gross * 0.02;

            return new TaxInfoOutput
            {
                Location = taxInfo.Location,
                IncomeTax = incomeTax,
                Gross = gross,
                Pension = pension,
            };
        }
    }
}
