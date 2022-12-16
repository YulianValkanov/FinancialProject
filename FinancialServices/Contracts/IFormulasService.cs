namespace FinancialServices.Contracts
{
    public interface IFormulasService
    {
        double GetPmt(double ir, int np, double pv);


        string FormatNumbersAddSpace(double number);

        string GetMsp(int personal, double assets, double revenues);

    }
}
