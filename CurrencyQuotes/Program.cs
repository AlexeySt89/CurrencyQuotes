using System.Data;
using System.Text;

namespace CurrencyQuotes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currency =  Console.ReadLine();
            Console.WriteLine("Текущая котировка: ");
            Console.WriteLine(GetUSDRate(currency));
        }

        public static string GetUSDRate(string curr)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string url = "http://www.cbr.ru/scripts/XML_daily.asp";
            //XmlDocument xml_doc = new XmlDocument();
            //xml_doc.Load(url);
            DataSet ds = new DataSet();
            ds.ReadXml(url);
            DataTable currency = ds.Tables["Valute"];
            foreach (DataRow row in currency.Rows)
            {
                if (row["CharCode"].ToString() == curr)//Ищу нужный код валюты
                {
                    return row["Value"].ToString(); //Возвращаю значение курсы валюты
                }
            }
            return "";
        }
    }
}