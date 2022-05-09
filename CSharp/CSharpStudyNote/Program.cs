using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudyNote
{
    class Program
    {       
        static void Main(string[] args)
        {
            Console.WriteLine("hello world :)");
            Console.ReadKey();
        }

        /// <summary>
        /// 反射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        private void Mapping<T>(T source, T target)
        {
            var props = typeof(T).GetProperties();

            foreach (var item in props)
            {
                var s_Value = item.GetValue(source, null);
                item.SetValue(target, s_Value, null);
            }
        }
    }
}
