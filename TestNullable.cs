using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skoleni_Csharp_NET
{
    class TestNullable
    {
        static void Main(string[] args)
        {
            Nullable<int> inta = new Nullable<int>();
            int? intb = null;

            Console.WriteLine(string.Format("inta == inta {0}", inta == intb));
            Console.WriteLine(string.Format("inta == null {0}", inta == null)); 
            Console.WriteLine(string.Format("inta.HasValue {0}", inta.HasValue));//zadna vyjimka
            Console.WriteLine(string.Format("inta.HasValue {0}", intb.HasValue));//zadna vyjimka
            try
            {
                Console.WriteLine(string.Format("inta.HasValue {0}", intb.Value));//!!! InvalidOperationException
            }
            catch (InvalidOperationException)
            {
            }
            
            try
            {
                Console.WriteLine(string.Format("inta.Value {0}", inta.Value));//!!! InvalidOperationException
            }
            catch (InvalidOperationException)
            {
            }

            int intc = inta ?? 0;
            Console.WriteLine(string.Format("intc {0}", intc));

            Console.ReadKey(true);
        }
    }
}
