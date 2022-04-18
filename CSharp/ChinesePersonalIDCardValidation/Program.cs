using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ChinesePersonalIDCardValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入身份证号：");
            string str_IdCardNo = Console.ReadLine();
            if (VerifyIdCardNo(str_IdCardNo))
                Console.WriteLine("身份证号校验成功:)");
            else
                Console.WriteLine("身份证号校验失败:(");  
            Console.ReadKey();
        }

        #region 校验身份证号码
        /// <summary>
        /// 根据入参判断身份证号格式是否正确
        /// </summary>
        /// <param name="input_IdCardNo"></param>
        /// <returns></returns>
        static bool VerifyIdCardNo(string input_IdCardNo)
        {
            if (CheckCode(input_IdCardNo))
            {
                string str_BirthDate = input_IdCardNo.Substring(6, 8);

                if (CheckDate(str_BirthDate))
                {
                    string str_ProvCode = input_IdCardNo.Substring(0, 2);

                    if (CheckProv(str_ProvCode))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 校验身份证号位数、格式以及最后一位数字是否正确
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        static bool CheckCode(string str_Input)
        {
            //正则表达式，用于校验身份证格式
            Regex reg = new Regex("^[1-9]\\d{5}(18|19|20)\\d{2}((0[1-9])|(1[0-2]))(([0-2][1-9])|10|20|30|31)\\d{3}[0-9Xx]$");

            //用于计算身份证号最后一位是否正确的数组，每个数字与身份证号前17位数字一一对应
            int[] factor = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            //对照组，将按计算规则得出的余数作为索引得到对应的字符，判断是否与身份证号最后一位一致
            string[] parity = new string[] { "1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2" };

            if (reg.IsMatch(str_Input) == true)
            {
                string lastCode = str_Input.Substring(17, 1);

                int sum = 0;

                for (int i = 0; i < 17; i++)
                    sum += Convert.ToInt32(str_Input.Substring(i, 1)) * factor[i];

                if (parity[sum % 11] == lastCode.ToUpper())
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 校验身份证号上的出生日期是否为正确的日期格式
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        static bool CheckDate(string str_Input)
        {
            string year = str_Input.Substring(0, 4);
            string month = str_Input.Substring(4, 2);
            string day = str_Input.Substring(6, 2);

            bool isTrueDate = DateTime.TryParse(year + "-" + month + "-" + day, out DateTime date);

            if (isTrueDate == true)
            {
                if (date > DateTime.Now)
                    return false;

                return true;
            }
            return false;
        }

        /// <summary>
        /// 校验身份证号上的省份编码是否正确
        /// </summary>
        /// <param name="str_Input"></param>
        /// <returns></returns>
        static bool CheckProv(string str_Input)
        {
            Regex reg = new Regex("^[1-9][0-9]");
            string[] prov = new string[] { "11", "12", "13", "14", "15",
                "21", "22", "23 ", "31", "32", "33", "34", "35", "36", "37",
                "41", "42 ", "43", "44", "45", "46", "50", "51", "52", "53", "54 ",
                "61", "62", "63", "64", "65", "71", "81", "82" };
            if (reg.IsMatch(str_Input) == true)
            {
                if (prov.Contains(str_Input) == true)
                    return true;
            }
            return false;
        }
        #endregion
      
    }
}
