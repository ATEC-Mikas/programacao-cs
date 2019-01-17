using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT03
{
    class Ponto
    {
        private int x;
        private int y;

        public Ponto()
        {
            x = 0;
            y = 0;
        }
        public Ponto(int x,int y)
        {
            if (!setX(x))
                x = 0;
            if (!setY(y))
                y = 0;
            
        }
        public Ponto(Ponto p)
        {
            x = p.x;
            y = p.y;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public bool setX(int x)
        {
            this.x = x;
            return true;
            

            //TODO
            //return false;
        }
        public bool setY(int y)
        {
            this.y = y;
            return true;

            //TODO
            //return false;
        }
        public string toString()
        {
            return "("+x.ToString()+","+y.ToString()+")";
        }
        public double distEntre2Pontos(Ponto p)
        {
            return (double)Math.Sqrt(Math.Pow((p.x-x),2)+Math.Pow((p.y - y), 2));
        }
    }
}
