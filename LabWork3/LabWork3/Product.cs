using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace LabWork3
{
    [Serializable]
    [DataContract]
    public class Product
    {
        [DataMember]
        private string productDateOfManufacture;
        [DataMember]
        private string productCode;
        [DataMember]
        private int currentDay, currentMonth, currentYear;
        [DataMember]
        bool whetherFitForConsumption = true;
        public Product()
        {
        }
        public Product(int i)
        {
            if(i == 1)
            {
                ProductName = "Товар1";
                ProductCode = "1111111111111";
                ProductDateOfManufacture = "01.01.2001";
                ExpirationDate = 100;
                EndDateOfConsumption();
                WhetherFitForConsumption();
            }
            else if (i == 2)
            {
                ProductName = "Товар2";
                ProductCode = "2222222222222";
                ProductDateOfManufacture = "01.01.2021";
                ExpirationDate = 400;
                EndDateOfConsumption();
                WhetherFitForConsumption();
            }
            else if (i == 3)
            {
                ProductName = "Товар3";
                ProductCode = "3333333333333";
                ProductDateOfManufacture = "03.03.2021";
                ExpirationDate = 100;
                EndDateOfConsumption();
                WhetherFitForConsumption();
            }
            else
            {
                ProductName = "Товар N";
                ProductCode = "4444444444444";
                ProductDateOfManufacture = "29.11.2021";
                ExpirationDate = 60;
                EndDateOfConsumption();
                WhetherFitForConsumption();
            }
        }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ProductCode
        {

            get { return productCode; }
            set
            {
                if (value.Length == 13)
                {
                    string check1 = Convert.ToString(value[0]);
                    string check2 = Convert.ToString(value[1]);
                    string check3 = Convert.ToString(value[2]);
                    string check4 = Convert.ToString(value[3]);
                    string check5 = Convert.ToString(value[4]);
                    string check6 = Convert.ToString(value[5]);
                    string check7 = Convert.ToString(value[6]);
                    string check8 = Convert.ToString(value[7]);
                    string check9 = Convert.ToString(value[8]);
                    string check10 = Convert.ToString(value[9]);
                    string check11 = Convert.ToString(value[10]);
                    string check12 = Convert.ToString(value[11]);
                    string check13 = Convert.ToString(value[12]);
                    if ((Regex.IsMatch(check1, "^[0-9]+$") == true) && (Regex.IsMatch(check2, "^[0-9]+$") == true) &&
                    (Regex.IsMatch(check3, "^[0-9]+$") == true) && (Regex.IsMatch(check4, "^[0-9]+$") == true) &&
                    (Regex.IsMatch(check5, "^[0-9]+$") == true) && (Regex.IsMatch(check6, "^[0-9]+$") == true) &&
                    (Regex.IsMatch(check7, "^[0-9]+$") == true) && (Regex.IsMatch(check8, "^[0-9]+$") == true) &&
                    (Regex.IsMatch(check9, "^[0-9]+$") == true) && (Regex.IsMatch(check10, "^[0-9]+$") == true) &&
                    (Regex.IsMatch(check11, "^[0-9]+$") == true) && (Regex.IsMatch(check12, "^[0-9]+$") == true) &&
                    (Regex.IsMatch(check13, "^[0-9]+$") == true))
                    {
                        productCode = value;
                    }
                }
                else
                {
                    productCode = "0000000000000";
                }
                productCode = value;
            }
        }
        [DataMember]
        public string ProductDateOfManufacture
        {
            get { return productDateOfManufacture; }
            set
            {
                if (value.Length == 10)
                {
                    string[] check = new string[10] { Convert.ToString(value[0]), Convert.ToString(value[1]), Convert.ToString(value[2]),
                Convert.ToString(value[3]), Convert.ToString(value[4]), Convert.ToString(value[5]), Convert.ToString(value[6]),
                Convert.ToString(value[7]), Convert.ToString(value[8]), Convert.ToString(value[9])};
                    int intCheck1 = Convert.ToInt32(check[0] + check[1]);
                    int intCheck2 = Convert.ToInt32(check[3] + check[4]);
                    int intCheck3 = Convert.ToInt32(check[6] + check[7] + check[8] + check[9]);

                    if ((Regex.IsMatch(check[0], "^[0-9]+$") == true) && (Regex.IsMatch(check[1], "^[0-9]+$") == true) &&
                        (check[2] == ".") && (Regex.IsMatch(check[3], "^[0-9]+$") == true) &&
                        (Regex.IsMatch(check[4], "^[0-9]+$") == true) && (check[2] == ".") &&
                        (Regex.IsMatch(check[6], "^[0-9]+$") == true) && (Regex.IsMatch(check[7], "^[0-9]+$") == true) &&
                        (Regex.IsMatch(check[8], "^[0-9]+$") == true) && (Regex.IsMatch(check[9], "^[0-9]+$") == true))
                    {
                        if ((intCheck1 < 32 && intCheck1 > 0) && (intCheck2 < 13 && intCheck2 > 0) && (intCheck3 < 2022 && intCheck3 > 1900))
                        {
                            double doubleCheck3 = Convert.ToDouble(intCheck3);
                            if (intCheck1 < 30 && intCheck2 == 2 && ((intCheck3 / 4 == doubleCheck3 / 4)))
                            {
                                currentDay = intCheck1;
                                currentMonth = intCheck2;
                                currentYear = intCheck3;
                                productDateOfManufacture = value;
                            }
                            else if ((intCheck1 < 32 && intCheck2 == 1) || (intCheck1 < 29 && intCheck2 == 2 && (intCheck3 / 4 != doubleCheck3 / 4)) ||
                                (intCheck1 < 32 && intCheck2 == 3) || (intCheck1 < 31 && intCheck2 == 4) || (intCheck1 < 32 && intCheck2 == 5) ||
                                (intCheck1 < 31 && intCheck2 == 6) || (intCheck1 < 32 && intCheck2 == 7) || (intCheck1 < 32 && intCheck2 == 8) ||
                                (intCheck1 < 31 && intCheck2 == 9) || (intCheck1 < 32 && intCheck2 == 10) || (intCheck1 < 31 && intCheck2 == 11) ||
                                (intCheck1 < 32 && intCheck2 == 12))
                            {
                                //if(intCheck1 )
                                currentDay = intCheck1;
                                currentMonth = intCheck2;
                                currentYear = intCheck3;
                                productDateOfManufacture = value;
                            }
                            else
                            {
                                productDateOfManufacture = "Неправильна дата";
                            }

                        }
                        else
                        {
                            productDateOfManufacture = "Неправильна дата";
                        }
                    }
                }
                else
                {
                    productDateOfManufacture = "Неправильна дата";
                }
            }
        }
        [DataMember]
        public int ExpirationDate
        {
            get; set;
        }
        public string EndDateOfConsumption()
        {
            try
            {
                DateTime date = new DateTime(currentYear, currentMonth, currentDay);
                DateTime dateTime = new DateTime(2021, 11, 30);
                date = date.AddDays(ExpirationDate);
                if (date.CompareTo(dateTime) == -1)
                {
                    whetherFitForConsumption = false;
                }
                string endDate = Convert.ToString(date);
                endDate = endDate.Remove(11);
                return endDate;
            }
            catch
            {
                throw new Exception("Ex1");
            }
        }
        public bool WhetherFitForConsumption()
        {
            return whetherFitForConsumption;
        }
    }
}
