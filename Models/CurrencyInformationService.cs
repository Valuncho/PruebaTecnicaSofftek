namespace PruebaTecnicaSofftek.Models
{
    public class CurrencyInformationService
    {
        private string dolarInformation;
        private string cryptoInformation;

        public void SetDolarInformation(string dolarInfo) 
        {
            dolarInformation = dolarInfo;
        }
        public void SetCryptoInformation(string cryptoInfo)
        {
            cryptoInformation = cryptoInfo;
        }

        public string getDolarInformation() 
        {
            return dolarInformation;
        }
        public string getCryptoInformation()
        {
            return cryptoInformation;
        }
    }
}
