using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT03
{
    class Hora
    {
        private int hora;
        private int min;
        private int seg;
        
        public int getHora()
        {
            return hora;
        }
        public bool setHora(int x)
        {
            if(x<24 && x>=0)
            {
                hora = x;
                return true;
            }
            return false;
        }
        public int getMin()
        {
            return min;
        }
        public bool setMin(int x)
        {
            if (x >= 0 && x < 60)
            {
                min = x;
                return true;
            }
            return false;
        }
        public int getSeg()
        {
            return seg;
        }
        public bool setSeg(int x)
        {
            if (x >= 0 && x < 60)
            {
                seg = x;
                return true;
            }

            return false;
        }
        public string toString()
        {
            return (hora.ToString() + ":" + min.ToString() + ":" + seg.ToString());
        }
       
    }
}
