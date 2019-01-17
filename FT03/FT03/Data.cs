using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT03
{
    class Data
    {
        private int dia;
        private int mes;
        private int ano;
        private Hora hora;
        private string diasem;

        public Data()
        {
            dia = 1;
            mes = 1;
            ano = 2000;
            diasem = "segunda-feira";
            hora = new Hora();
        }
        public Data(int dia,int mes,int ano, int diasem, int hora,int minuto,int segundo)
        {
            if (!setAno(ano))
                ano = 2000;
            if (!setMes(mes))
                mes = 1;
            if (!setDia(dia))
                dia = 1;
            if (!setDiasem(diasem))
                setDiasem(1);
            this.hora = new Hora(hora,minuto,segundo);
        }
        public Data(int dia, int mes, int ano, int diasem,Hora hora)
        {
            if (!setAno(ano))
                ano = 2000;
            if (!setMes(mes))
                mes = 1;
            if (!setDia(dia))
                dia = 1;
            if (!setDiasem(diasem))
                setDiasem(1);
            this.hora = new Hora(hora);
        }
        public Data(Data d)
        {
            dia = d.dia;
            mes = d.mes;
            ano = d.ano;
            diasem = d.diasem;
            hora = new Hora(d.hora);
        }
        public Hora getHora()
        {
            return hora;
        }
        public int getDia()
        {
            return dia;
        }
        public bool setDia(int x)
        {
            if (x <= 0 || x > 31)
            {
                return false; //Dia invalido
            }
            if (mes < 8 && mes != 2)
            {
                if (mes % 2 == 0 && x <= 30)
                {
                    dia = x;
                }
                else
                {
                    if (mes % 2 == 1 && x <= 31)
                    {
                        dia = x;
                    }
                    else
                    {
                        return false;//Dia invalido devido ao mes
                    }
                }
            }
            else
            {
                if (mes >= 8 && mes != 2)
                {
                    if (mes % 2 == 1 && x <= 30)
                    {
                        dia = x;
                    }
                    else
                    {
                        if (mes % 2 == 0 && x <= 31)
                        {
                            dia = x;
                        }
                        else
                        {
                            return false;//Dia invalido devido ao mes
                        }
                    }
                }
            }
            if (mes == 2)
            {
                if (ano % 4 == 0 && x <= 29)
                {
                    dia = x;
                }
                else
                {
                    if (ano % 4 == 1 && x <= 28)
                    {
                        dia = x;
                    }
                    else
                    {
                        return false;//Dia invalido devido ao ano e mes
                    }
                }
            }
            return true;
        }
        public int getMes()
        {
            return mes;
        }
        public bool setMes(int x)
        {
            if (x <= 0 || x > 12)
            {
                return false; //Mes invalido
            }
            if (x < 8 && x != 2)
            {
                if (x % 2 == 0 && dia <= 30)
                {
                    mes = x;
                }
                else
                {
                    if (x % 2 == 1 && dia <= 31)
                    {
                        mes = x;
                    }
                    else
                    {
                        return false;//Mes invalido devido ao dia
                    }
                }
            }
            else
            {
                if (x >= 8 && x != 2)
                {
                    if (x % 2 == 1 && dia <= 30)
                    {
                        mes = x;
                    }
                    else
                    {
                        if (x % 2 == 0 && dia <= 31)
                        {
                            mes = x;
                        }
                        else
                        {
                            return false;//Mes invalido devido ao dia
                        }
                    }
                }
            }
            if (x == 2)
            {
                if (ano % 4 == 0 && dia <= 29)
                {
                    mes = x;
                }
                else
                {
                    if (ano % 4 == 1 && dia <= 28)
                    {
                        mes = x;
                    }
                    else
                    {
                        return false;//Mes invalido devido ao dia e ano
                    }
                }
            }
            return true;
        }
        public int getAno()
        {
            return ano;
        }
        public bool setAno(int x)
        {
            if (x <= 0)
            {
                return false; //Ano invalido
            }
            if (mes == 2 && dia == 29 && x % 4 != 0)
            {
                return false; // Ano invalido devido a ser dia 29/2 num ano nao bissexto
            }
            ano = x;
            return true;
        }
        public string getDiasem()
        {
            return diasem;
        }
        public bool setDiasem(int x)
        {
            switch(x)
            {
                case 1:
                    diasem = "Domingo";
                    break;
                case 2:
                    diasem = "Segunda-feira";
                    break;
                case 3:
                    diasem = "Terça-feira";
                    break;
                case 4:
                    diasem = "Quarta-feira";
                    break;
                case 5:
                    diasem = "Quinta-feira";
                    break;
                case 6:
                    diasem = "Sexta-feira";
                    break;
                case 7:
                    diasem = "Sábado";
                    break;
                default:
                    return false;
            }
            return true;
        }
        public string toString()
        {
            return (dia.ToString() + "/" + mes.ToString() + "/" + ano.ToString() + " " + hora.toString());
        }
        public int difEntre2Anos(Data d)
        {
            int maior = -1;
            if (d.mes >= mes && d.dia >= dia)
                    maior = 0;
                    
            return (d.ano-ano)+maior;
        }
    }
}
