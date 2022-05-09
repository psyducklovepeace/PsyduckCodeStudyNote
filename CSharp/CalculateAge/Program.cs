using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculateAge
{
    class Program
    {
        string str_AgeStr;

        static void Main(string[] args)
        {
            Console.WriteLine("请输入身份证号：");
            string str_IdCardNo = Console.ReadLine();
            var a = new Program();
            a.CalculateAgeByIdCardNo(str_IdCardNo);
            string str_AgeStrShow = a.str_AgeStr;
            Console.WriteLine(str_AgeStrShow);

            Console.WriteLine("请输入出生日期：");
            string str_BirthDate = Console.ReadLine();
            a.CalculateAgeByBirthDate(str_BirthDate);
            str_AgeStrShow = a.str_AgeStr;
            Console.WriteLine(str_AgeStrShow);

            Console.ReadKey();
        }

        /// <summary>
        /// 通过出生日期计算年龄
        /// </summary>
        public void CalculateAgeByBirthDate(string input_BirthDate)
        {
            if (string.IsNullOrWhiteSpace(input_BirthDate))
            {
                Console.WriteLine("输入的出生日期为空，请重新输入");
                return;
            }

            string str_BirthDate = input_BirthDate;

            DateTime dt_BirthDate = Convert.ToDateTime(str_BirthDate);

            DateTime dt_CurrentDate = DateTime.Now;

            if (dt_BirthDate > dt_CurrentDate)
            {
                Console.WriteLine("输入的出生日期不能大于当前时间，请重新输入");
                return;
            }

            int diff_TotalMonth = (dt_CurrentDate.Year - dt_BirthDate.Year) * 12 + (dt_CurrentDate.Month - dt_BirthDate.Month);
            int diff_Year = diff_TotalMonth / 12;
            int diff_Month = diff_Year % 12;
            int diff_Day;

            int diff_M = diff_TotalMonth;

            //当前日期的年份
            int current_Year = dt_CurrentDate.Year;
            //当前日期的月份
            int current_Month = dt_CurrentDate.Month;
            //当前日期的天数
            int current_Day = dt_CurrentDate.Day;
            //生日日期的天数
            int birth_Day = dt_BirthDate.Day;
            //月份的天数
            int daysOfMonth = 0;

            switch (current_Month - 1)
            {
                case 1:
                    daysOfMonth = 31;
                    break;
                case 2:
                    if (current_Year % 4 == 0 && current_Year % 100 != 0)
                        daysOfMonth = 29;
                    else if (current_Year % 400 == 0)
                        daysOfMonth = 29;
                    else
                        daysOfMonth = 28;
                    break;
                case 3:
                    daysOfMonth = 31;
                    break;
                case 4:
                    daysOfMonth = 30;
                    break;
                case 5:
                    daysOfMonth = 31;
                    break;
                case 6:
                    daysOfMonth = 30;
                    break;
                case 7:
                    daysOfMonth = 31;
                    break;
                case 8:
                    daysOfMonth = 31;
                    break;
                case 9:
                    daysOfMonth = 30;
                    break;
                case 10:
                    daysOfMonth = 31;
                    break;
                case 11:
                    daysOfMonth = 30;
                    break;
                case 12:
                    daysOfMonth = 31;
                    break;
            }

            if (current_Day - birth_Day < 0)
            {
                diff_Day = daysOfMonth + current_Day - birth_Day;
                diff_M = diff_M - 1;
            }
            else
                diff_Day = current_Day - birth_Day;

            diff_Year = diff_M / 12;
            diff_Month = diff_M % 12;

            //以14岁为标准
            int default_Year = 14;

            if (diff_Year >= default_Year)
                str_AgeStr = $"{diff_Year}岁";
            else if (diff_Year >= 1 && diff_Year < default_Year)
            {
                if (diff_Month == 0)
                    str_AgeStr = $"{diff_Year}岁";
                else if (diff_Month > 0)
                    str_AgeStr = $"{diff_Year}岁{diff_Month}个月";
            }
            else if (diff_Year < 1)
            {
                if (diff_Month >= 1)
                {
                    if (diff_Day == 0)
                        str_AgeStr = $"{diff_Month}个月";
                    else if (diff_Day > 0)
                        str_AgeStr = $"{diff_Month}个月{diff_Day}天";
                }
                else if (diff_Month == 0)
                {
                    if (diff_Day == 0)
                        str_AgeStr = "1天";
                    else
                        str_AgeStr = $"{diff_Day}天";
                }
            }
        }

        /// <summary>
        /// 通过身份证号计算年龄
        /// </summary>
        public void CalculateAgeByIdCardNo(string input_IdCardNo)
        {
            if (!IsIdCard(input_IdCardNo))
            {
                Console.WriteLine("身份证号格式错误，请重新输入");
                return;
            }

            string str_BirthDate = input_IdCardNo.Substring(6, 4) + "-" + input_IdCardNo.Substring(10, 2) + "-" + input_IdCardNo.Substring(12, 2);

            DateTime dt_BirthDate = Convert.ToDateTime(str_BirthDate);

            DateTime dt_CurrentDate = DateTime.Now;

            int diff_TotalMonth = (dt_CurrentDate.Year - dt_BirthDate.Year) * 12 + (dt_CurrentDate.Month - dt_BirthDate.Month);
            int diff_Year = diff_TotalMonth / 12;
            int diff_Month = diff_Year % 12;
            int diff_Day;

            int diff_M = diff_TotalMonth;

            //当前日期的年份
            int current_Year = dt_CurrentDate.Year;
            //当前日期的月份
            int current_Month = dt_CurrentDate.Month;
            //当前日期的天数
            int current_Day = dt_CurrentDate.Day;
            //生日日期的天数
            int birth_Day = dt_BirthDate.Day;
            //月份的天数
            int daysOfMonth = 0;

            switch (current_Month - 1)
            {
                case 1:
                    daysOfMonth = 31;
                    break;
                case 2:
                    if (current_Year % 4 == 0 && current_Year % 100 != 0)
                        daysOfMonth = 29;
                    else if (current_Year % 400 == 0)
                        daysOfMonth = 29;
                    else
                        daysOfMonth = 28;
                    break;
                case 3:
                    daysOfMonth = 31;
                    break;
                case 4:
                    daysOfMonth = 30;
                    break;
                case 5:
                    daysOfMonth = 31;
                    break;
                case 6:
                    daysOfMonth = 30;
                    break;
                case 7:
                    daysOfMonth = 31;
                    break;
                case 8:
                    daysOfMonth = 31;
                    break;
                case 9:
                    daysOfMonth = 30;
                    break;
                case 10:
                    daysOfMonth = 31;
                    break;
                case 11:
                    daysOfMonth = 30;
                    break;
                case 12:
                    daysOfMonth = 31;
                    break;
            }

            if (current_Day - birth_Day < 0)
            {
                diff_Day = daysOfMonth + current_Day - birth_Day;
                diff_M = diff_M - 1;
            }
            else
                diff_Day = current_Day - birth_Day;

            diff_Year = diff_M / 12;
            diff_Month = diff_M % 12;

            //以14岁为标准
            int default_Year = 14;

            if (diff_Year >= default_Year)
                str_AgeStr = $"{diff_Year}岁";
            else if (diff_Year >= 1 && diff_Year < default_Year)
            {
                if (diff_Month == 0)
                    str_AgeStr = $"{diff_Year}岁";
                else if (diff_Month > 0)
                    str_AgeStr = $"{diff_Year}岁{diff_Month}个月";
            }
            else if (diff_Year < 1)
            {
                if (diff_Month >= 1)
                {
                    if (diff_Day == 0)
                        str_AgeStr = $"{diff_Month}个月";
                    else if (diff_Day > 0)
                        str_AgeStr = $"{diff_Month}个月{diff_Day}天";
                }
                else if (diff_Month == 0)
                {
                    if (diff_Day == 0)
                        str_AgeStr = "1天";
                    else
                        str_AgeStr = $"{diff_Day}天";
                }
            }

        }

        #region 身份证号校验

        /// <summary>
        /// 身份证号校验
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static bool IsIdCard(string strInput)
        {
            if (checkCode(strInput))
            {
                string date = strInput.Substring(6, 8);
                if (checkDate(date))
                {
                    if (checkProv(strInput.Substring(0, 2)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 校验身份证最后一位编码
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        static bool checkCode(string strInput)
        {
            Regex reg = new Regex("^[1-9]\\d{5}(18|19|20)\\d{2}((0[1-9])|(1[0-2]))(([0-2][1-9])|10|20|30|31)\\d{3}[0-9Xx]$");

            string[] factor = new string[] { "7", "9", "10", "5", "8", "4", "2", "1", "6", "3", "7", "9", "10", "5", "8", "4", "2" };
            string[] parity = new string[] { "1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2" };

            if (reg.IsMatch(strInput) == true)
            {
                string code = strInput.Substring(17);

                int sum = 0;
                for (int i = 0; i < 17; i++)
                {
                    sum += Convert.ToInt32(strInput.Substring(i, 1)) * Convert.ToInt32(factor[i]);
                }
                if (parity[sum % 11] == code.ToUpper())
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// 校验身份证上的出生日期是否正确
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        static bool checkDate(string strInput)
        {
            string year = strInput.Substring(0, 4);
            string month = strInput.Substring(4, 2);
            string day = strInput.Substring(6, 2);

            bool isTrueDate = DateTime.TryParse(year + "-" + month + "-" + day, out DateTime date);
            if (isTrueDate == true)
            {
                if (date > DateTime.Now)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 校验省份编码是否正确
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        static bool checkProv(string strInput)
        {
            Regex reg = new Regex("^[1-9][0-9]");
            string[] prov = new string[] { "11", "12", "13", "14", "15",
                "21", "22", "23 ", "31", "32", "33", "34", "35", "36", "37",
                "41", "42 ", "43", "44", "45", "46", "50", "51", "52", "53", "54 ",
                "61", "62", "63", "64", "65", "71", "81", "82" };
            if (reg.IsMatch(strInput) == true)
            {
                if (prov.Contains(strInput) == true)
                    return true;
            }
            return false;
        }

        #endregion
    }
}
