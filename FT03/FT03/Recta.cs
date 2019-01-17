using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT03
{
    class Recta
    {
        private Ponto p1;
        private Ponto p2;

        public Recta()
        {
            p1 = new Ponto();
            p2 = new Ponto();
        }
        public Recta(int x1,int y1,int x2,int y2)
        {
            p1 = new Ponto(x1, y1);
            p2 = new Ponto(x2, y2);
        }
        public Recta(Ponto p1,Ponto p2)
        {
            this.p1 = new Ponto(p1);
            this.p2 = new Ponto(p2);
        }
        public Recta(Recta r)
        {
            p1 = r.p1;
            p2 = r.p2;
        }
        public Ponto getPonto(int x)
        {
            switch (x)
            {
                case 1:
                    return p1;
                case 2:
                    return p2;
                default:
                    return new Ponto();
            }
        }
        public string toString()
        {
            return "P1: " + p1.toString() + " P2: " + p2.toString();
        } 
    }
}
