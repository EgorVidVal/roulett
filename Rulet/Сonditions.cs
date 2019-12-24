using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rulet
{
    class Сonditions
    {        
        public int[] Test()
        {
            int[] x = new int[10];
            string[] y = new string[10];
           
            Table tab = new Table();
           
            for (int i = 0; i < 10; i++)
            {
                tab.Rand();
                x[i] = tab.Roulett;
                y[i] = tab.Color_numb;
                
            }                      
            return x;
        }
    }
}
