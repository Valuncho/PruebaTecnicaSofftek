namespace PruebaTecnicaSofftek.Models
{
    public class CurrencyInformationService
    {
        private decimal dolarInformation;
        private decimal cryptoInformation;

        public void SetDolarInformation(decimal dolarInfo) 
        {
            dolarInformation = dolarInfo;
        }
        public void SetCryptoInformation(decimal cryptoInfo)
        {
            cryptoInformation = cryptoInfo;
        }

        public decimal getDolarInformation() 
        {
            return dolarInformation;
        }
        public decimal getCryptoInformation()
        {
            return cryptoInformation;
        }
    }
}
