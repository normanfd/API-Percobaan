using System;

namespace ConsolePercobaan
{
    static class Program
    {
        static void Main(string[] args)
        {
            string a = "2113808.2191";
            string b = a.Replace(".", ",");
            decimal dc = 123.213M;
            decimal g = Convert.ToDecimal(b);
            
            decimal premiumSinarmas = 2113808.2191M;
            decimal komisiSinarmas = 528452.0548M;

            decimal premiSinarmas = premiumSinarmas - (komisiSinarmas + (10 / 100 * komisiSinarmas) - (2 / 100 * komisiSinarmas));
            Console.WriteLine(premiSinarmas);
            //var ndfCarLoanCalculator = new NdfCarLoanCalculatorOcp();
            //var installmentAmountNdfCar = ndfCarLoanCalculator.CalculateInstallmentAmount(100000000, 12);
            //Console.WriteLine("installment amount = " + Math.Round(installmentAmountNdfCar, 2));
        }
    }
}
