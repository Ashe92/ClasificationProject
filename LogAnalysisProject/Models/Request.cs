using System;
using System.Text;

namespace LogAnalysisProject.Models
{
    public class Request
    {
        public string Ip { get; set; }
        private string _dateTime;
        public string DateTime
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                if (!string.IsNullOrEmpty(value))
                {
                    ParseDateTime(value);
                }
            }
        }

        public DateTime Date { get; private set; }
        public string PlusTime { get; set; }
        public string RequestType { get; set; }
        public int PageId { get; private set; }
        private string _page;

        public string Page
        {
            get => _page;
            set
            {
                _page = value;
                GetIdOfPage();
            }
        }
        public string PageVersion { get; set; }
        public string RequestResponse { get; set; }
        public string ErrorCode { get; set; }

        private void ParseDateTime(string value)
        {
            var date = value.Substring(0, value.IndexOf(":"));

            var fromDigit = value.IndexOf(":") + 1;
            var toDigit = value.Length - fromDigit;
            var time = value.Substring(fromDigit, toDigit);
            var addHour = false;
            var addMinutes = false;
            var timeBuilder = new StringBuilder(time);
            if (time[3].ToString() == "6")
            {
                timeBuilder[3] = '0';
                addHour = true;
            }
            if (time[6].ToString() == "6")
            {
                timeBuilder[6] = '0';
                addMinutes = true;
            }

            try
            {
                Date = Convert.ToDateTime($"{date} {timeBuilder}");
                if (addHour) Date = Date.AddHours(1);
                if (addMinutes) Date = Date.AddMinutes(1);
            }
            catch (Exception e)
            {
                throw new Exception("Błąd konwertowania daty");
            }
        }

        private void GetIdOfPage()
        {
            switch (Page)
            {
                case "Shop.html":
                    PageId = 0;
                    break;
                case "AddProduct.html":
                    PageId = 1;
                    break;
                case "Summary.html":
                    PageId = 2;
                    break;
                case "Payment.html":
                    PageId = 3;
                    break;
                case "About.html":
                    PageId = 4;
                    break;
                case "Contact.html":
                    PageId = 5;
                    break;
                default:
                    PageId = -1;
                    break;
            }
        }
    }
}