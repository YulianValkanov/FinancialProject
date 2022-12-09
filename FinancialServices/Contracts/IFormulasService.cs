namespace FinancialServices.Contracts
{
    public interface IFormulasService
    {
        double GetPmt(double ir, int np, double pv);


        string FormatThisNumber(double number);

    }
}
