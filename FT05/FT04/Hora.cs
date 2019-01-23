using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT04
{
    class Hora
    {
        private int hora;
        private int min;
        private int seg;
        
        public Hora()
        {
            hora = 0;
            min = 0;
            seg = 0;
        }
        public Hora(int h,int m,int s)
        {
            if (!setHora(h))
                hora = 0;
            if (!setMin(m))
                min = 0;
            if (!setSeg(s))
                seg = 0;
        }
        public Hora(Hora h)
        {
            hora = h.hora;
            min = h.min;
            seg = h.seg;
        }
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
        public int difEntre2Horas(Hora h)
        {
            float[] dif = { 0, 0 };
            dif[0] += seg;
            dif[0] += min * 60;
            dif[0] += hora * 60 * 60;
            dif[1] += h.seg;
            dif[1] += h.min * 60;
            dif[1] += h.hora * 60 * 60;


            return int.Parse(Math.Round(Math.Abs((dif[0] - dif[1]) / (60 * 60))).ToString());
        }
    }
}
