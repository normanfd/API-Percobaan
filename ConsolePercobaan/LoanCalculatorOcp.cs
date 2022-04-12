namespace ConsolePercobaan
{
    public abstract class LoanCalculatorOcp
    {
        public abstract decimal CalculateInstallmentAmount(decimal FundingAmount, int Tenor);
        // ... other function
    }
    public class NdfCarLoanCalculatorOcp : LoanCalculatorOcp
    {
        public override decimal CalculateInstallmentAmount(decimal FundingAmount, int Tenor)
        {
            return (FundingAmount / Tenor) + (FundingAmount * 0.15M / Tenor);
        }
    }
    public class NdfMotorcycleLoanCalculatorOcp : LoanCalculatorOcp
    {
        public override decimal CalculateInstallmentAmount(decimal FundingAmount, int Tenor)
        {
            return (FundingAmount / Tenor) + ((FundingAmount * 0.12M) / Tenor);
        }
    }
}
