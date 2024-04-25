using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inside
{
    public class First
    {
        public int publicNumber = 10;
        
    }
    public class Second
    {
        protected int protectdNumber = 20;
        public void SecondMethod()
        {
            First one = new First();
            
            Console.WriteLine(protectedNumber);
        }
    }
}