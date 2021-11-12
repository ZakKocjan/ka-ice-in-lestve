using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public  class igralec
    {
    public int Pozicija { get; set; }
    public char Znak { get; set; }
    public short Barva { get; set; }
        //ta funkcija zapiše en znak na določeno mesto glede na pozicijo igralca
        public static void zapisi(int poz, int ss, int sv, int pig, char znak,short barva)
        
    {
        barve.nastavi(barva);
        int x = sv * 4 + 1;
        int y = ss * 9 + 1;
        int py = poz;
        int tv = poz / ss;
        int l = 0;
        int t = 0;

        {
            if (poz >= ss)
            {
                py = poz - (tv * ss);

            }

            if (tv == 0 || poz==0)
             
                t = x- 3;
            else
                t = x - tv * 4 - 3;

            if (tv % 2 == 0)
            { 
                    l = 1 + pig + py * 9;
            }
            else
            {  
                l = y - (py + 1) * 9 + pig;
            }


            Console.CursorTop = t;
            Console.CursorLeft = l;
            Console.Write(znak);
            Console.ResetColor();
        }
    }
        //ta funkcija preveri ali je na trenutni poziciji igralca kacica in vrne true ali false
        public static bool Preverik(int[,] k, int poz, int pig, char znak, int x)
    {
        for(int i=0;i< k.GetLength(0);i++)
        {
            if(poz==k[i,0])
            {
                Console.CursorLeft = 0;
                
                Console.CursorTop = x + 1;
                Console.CursorLeft = 0;
                Console.Write("Igralec {0} je stopil na kačico zato se premakne {1} nazaj", znak, k[i, 1]);
                //Console.Write("Igralec {0} je stopil na kačico zato se premakne {1} nazaj poz:{2},k[i,0]:{3}",znak,k[i,1],poz+1,k[i,0]+1);

                return true;
                
            }
        }
        return false;
    }
        //ta funkcija preveri ali je na trenutni poziciji igralca kacica in vrne true ali false
        public static bool Preveril(int[,] l, int poz, int pig, char znak, int x)
    {
       
        
        for (int i = 0; i < l.GetLength(0); i++)
        {
            if (poz == l[i, 0])
            {
                Console.CursorLeft = 0;
           
                Console.CursorTop = x + 1;
                Console.Write("Igralec {0} je stopil na lestev zato se premakne {1} naprej", znak, l[i, 1]);
                //Console.Write("Igralec {0} je stopil na lestev zato se premakne {1} naprej poz:{2},l[i,0]:{3}", znak, l[i, 1],poz+1,l[i,0]+1);

                return true;
            }

        }
        return false;
    }
}
public static class Gpolja
    {   //class je namenjen za generiranje polja na zacetku igre
        //ta funkcija v tabelo char znakov zapolne znake I in - 
        public static void polje(char[,] z, int x, int y)
        {
        
            for (int r = 0; r < x; r++)
            {
                for (int t = 0; t < y; t++)
                {   //okvir
                    if (r % 4 == 0)
                    {
                        if (t % 9 == 0)
                            z[r, t] = 'I';
                        else
                            z[r, t] = '-';
                    }
                    //prazna polja   
                    else
                    {
                        if (t % 9 == 0)
                            z[r, t] = 'I';
                        else
                            z[r, t] = ' ';
                    }
                }
            }
        }
        //ta funkcija v tabelo char znakov zapolne stevilke ki oznacujejo poicijo polja 
        public static void st(char[,] z, int x, int y, int s)
        { //funkcija v tabelo char znakov napolni stevilke polja
            int stevec = 1;
            int stevecvr = 1;
            for (int i = x - 2; i > 0; i -= 4)
            {
                if (stevecvr % 2 == 0)
                {
                    for (int q = y - 2; q > 0; q -= 9)
                    {
                        string b = stevec.ToString();
                        if (stevec >= 100)
                        {
                            z[i, q - 2] = b[0];
                            z[i, q - 1] = b[1];
                            z[i, q] = b[2];
                        }
                        else if (stevec >= 10)
                        {
                            z[i, q - 1] = b[0];
                            z[i, q] = b[1];
                        }
                        else
                            z[i, q] = b[0];
                        stevec++;
                    }
                }
                else
                {
                    for (int q = 8; q < y; q += 9)
                    {
                        string b = stevec.ToString();
                        if (stevec >= 100)
                        {
                            z[i, q - 2] = b[0];
                            z[i, q - 1] = b[1];
                            z[i, q] = b[2];
                        }
                        else if (stevec >= 10)
                        {
                            z[i, q - 1] = b[0];
                            z[i, q] = b[1];
                        }
                        else
                            z[i, q] = b[0];
                        stevec++;
                    }
                }
                stevecvr++;
            }

        }
        //ta funkcija v tabeli k in l zapolne random pozicije in dolžino kačice ali lestve
        public static void generiraj(int [,] k,int [,] l,int ss,int sv)
    {
        Random r = new Random();
        //generiranje random pozicij kacic in dolzine kacic 
        for (int i = 0; i < ss + 1; i++)
        {
            //pozicija kacice-random
            k[i, 0] = r.Next(ss + 1, (ss * sv - 1));
            //preverjanje ali je na tej pozicji ze kacica
            //ce je i==0 potem na tem polju nemoreta biti dve kacici ker je to prva kacica
            if (i >= 1)
                for (int e = 0; e < i; e++)
                {
                    if (k[i, 0] == k[e, 0])
                    {
                        while (k[i, 0] == k[e, 0])
                        {
                            k[i, 0] = r.Next(ss + 1, (ss * sv - 1));
                        }
                    }

                }
            //dolzina kacice
            k[i, 1] = r.Next(1, k[i, 0]);
            //pozicija lestev /random
            l[i, 0] = r.Next(1, (ss * sv - ss));
            //dolzina lestev
            l[i, 1] = r.Next(1, (ss * sv - l[i, 0] - 1));

            //preverjanje ali je na tej pozicji ze lestev
            //ce je i==0 potem na tem polju nemoreta biti dve lestvi ker je to prva lestev
            if (i >= 1)
                for (int e = 0; e < i; e++)
                {
                    if (l[i, 0] == l[e, 0])
                    {
                        while (l[i, 0] == l[e, 0])
                        {
                            l[i, 0] = r.Next(ss + 1, (ss * sv - 1));
                        }
                    }

                }
            //kacica in lestev nemoreta biti na isti poziciji
            if (i == 0)
            {
                if (l[0, 0] == k[0, 0])
                {
                    while (l[i, 0] == k[i, 0])
                    {
                        l[i, 0] = r.Next(1, ss * sv - ss);
                    }

                }
            }
            else
            {
                for (int q = 0; q < i; q++)
                {
                    for (int m = 0; m < i; m++)
                    {
                        if (k[i, 0] == l[m, 0])
                        {
                            while (k[q, 0] == l[m, 0])
                            {
                                l[m, 0] = r.Next(1, ss * sv - ss);

                            }
                            if (k[q, 0] == l[i, 0])
                            {
                                while (k[q, 0] == l[i, 0])
                                {
                                    l[i, 0] = r.Next(1, ss * sv - ss);
                                    l[i, 1] = r.Next(1, (ss * sv - l[i, 0] - 1));

                                }
                                //ko spremenimo pozicijo lestev,ker je bila na tej poziciji  kacica
                                //moramo preveriti ali je na tej poziciji ze lestev
                                if (i >= 1)
                                    for (int e = 0; e < i; e++)
                                    {
                                        if (l[i, 0] == l[e, 0])
                                        {
                                            while (l[i, 0] == l[e, 0])
                                            {
                                                l[i, 0] = r.Next(ss + 1, (ss * sv - 1));
                                                l[i, 1] = r.Next(1, (ss * sv - l[i, 0] - 1));
                                            }
                                        }

                                    }

                            }
                        }

                    }


                }
            }
        }

    }
        //ta funkcija v tabelo char znakov zapolne zapise kač primer:(S=>(dolžina)),na prave pozicije
        public static void kacice(int[,] nk, char[,] z, int x, int y, int ss)
        {   //ta metoda v tabelo char znakov napovni pozicjije in dolzino kacic
            for (int i = 0; i < nk.GetLength(0); i++)
            {
                string s = " ";
                int poz = nk[i, 0];
                int tv = poz / ss;
                if (tv % 2 == 1)
                    s = "S=>";
                else
                    s = "<=S";
                string e = (nk[i, 1]).ToString();

                int u = 0;
                int f = x - 4;

                poz = poz - (tv * ss);
                f = f - (4 * tv);
                if (tv % 2 == 0)
                {
                    if (poz == 0)
                        u = 4;

                    else
                        u = 4 + poz * 9;
                }
                else
                {
                    if (poz == 0)
                        u = y - 6;

                    else
                        u = y - 6 - poz * 9;
                }
                if (nk[i, 1] < 10)
                {
                    s = s + e[0];
                    z[f, u] = s[0];
                    z[f, u + 1] = s[1];
                    z[f, u + 2] = s[2];
                    z[f, u + 3] = s[3];
                }
                else if (nk[i, 1] < 100)
                {
                    s = s + e[0] + e[1];
                    u -= 1;
                    z[f, u] = s[0];
                    z[f, u + 1] = s[1];
                    z[f, u + 2] = s[2];
                    z[f, u + 3] = s[3];
                    z[f, u + 4] = s[4];
                }
                else
                {
                    s = s + e[0] + e[1] + e[2];
                    u -= 2;
                    z[f, u] = s[0];
                    z[f, u + 1] = s[1];
                    z[f, u + 2] = s[2];
                    z[f, u + 3] = s[3];
                    z[f, u + 4] = s[4];
                    z[f, u + 4] = s[5];
                }

            }
        }
        //ta funkcija v tabelo char znakov zapolne zapise lestev primer:(#=>(dolžina)),na prave pozicije
        public static void lujtre(int[,] nk, char[,] z, int x, int y, int ss)
        {   //ta metoda v tabelo char znakov napovni pozicjije in dolzino lestev
            for (int i = 0; i < nk.GetLength(0); i++)
            {
                int poz = nk[i, 0];
                int tv = poz / ss;
                string s = "";
                if (tv % 2 == 0)
                    s = "#=>";
                else
                    s = "<=#";
                string e = nk[i, 1].ToString();

                int u = 0;
                int f = x - 4;

                poz = poz - (tv * ss);
                f = f - (4 * tv);
                if (tv % 2 == 0)
                {
                    if (poz == 0)
                        u = 4;
                    else
                        u = 4 + poz * 9;
                }
                else
                {
                    if (poz == 0)
                        u = y - 6;
                    else
                        u = y - 6 - poz * 9;
                }
                if (nk[i, 1] < 10)
                {
                    s = s + e[0];
                    z[f, u] = s[0];
                    z[f, u - 1] = ' ';
                    z[f, u - 2] = ' ';
                    z[f, u + 1] = s[1];
                    z[f, u + 2] = s[2];
                    z[f, u + 3] = s[3];
                    z[f, u + 4] = ' ';

                }
                else if (nk[i, 1] < 100)
                {
                    s = s + e[0] + e[1];
                    u -= 1;
                    z[f, u] = s[0];
                    z[f, u - 1] = ' ';
                    z[f, u + 1] = s[1];
                    z[f, u + 2] = s[2];
                    z[f, u + 3] = s[3];
                    z[f, u + 4] = s[4];
                    z[f, u + 5] = ' ';
                }
                else
                {
                    s = s + e[0] + e[1] + e[2];
                    u -= 2;
                    z[f, u] = s[0];
                    z[f, u + 1] = s[1];
                    z[f, u + 2] = s[2];
                    z[f, u + 3] = s[3];
                    z[f, u + 4] = s[4];
                    z[f, u + 5] = s[5];
                    z[f, u + 6] = ' ';
                }



            }
        }
    }
public static class barve
{
    //funkcija za nastavitev barve izpisa na konzoli
    public static void nastavi(short b)
    {
        switch (b)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.Red;

                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Green;

                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Blue;

                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Magenta;

                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Yellow;

                break;

        }
    }
}

    class MainClass
    {
        //ta funkcija izpiše tabelo char znakov ob začetku igre
        public static void Izpis(char[,] tabela, int x, int y,short barva)
        {
            for (int e = 0; e < x; e++)
            {
                for (int t = 0; t < y; t++)
                {   if (tabela[e, t] == 'I' || tabela[e, t] == '-')
                {
                    barve.nastavi(barva);
                    Console.Write("{0}", tabela[e, t]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("{0}", tabela[e, t]);
                }
            }
                Console.WriteLine();
            }
        }

    public static void Main(string[] args)
    {
        //neskončna zanka izvede igro od začetka in nas po končani igri vpraša ali želimo začeti novo igro
        while (true)
        {
            Random r = new Random();

            
            Console.WriteLine("Vnesi stevilo igralcev:");
            int sigralcev = int.Parse(Console.ReadLine());
            //tabela objektov igralcev 
            igralec[] igralci = new igralec[sigralcev];
            
            //vnos znakov in barve posameznega igralca
            for (int i = 0; i < sigralcev; i++)
            {
                Console.WriteLine("Vnesi znak za {0}. igralca:", i + 1);
                igralci[i] = new igralec();
                igralci[i].Pozicija = 0;
                igralci[i].Znak = Console.ReadLine()[0];
                Console.WriteLine("Vnesi barvo igralca 0-Rdeča,1-Zelena,2-Modra,3-Vijola,4-Rumena:");
                igralci[i].Barva = short.Parse(Console.ReadLine());
            }
            
            Console.WriteLine("Vnesi barvo polja 0-Rdeča,1-Zelena,2-Modra,3-Vijola,4-Rumena:");
            short barvapolja = short.Parse(Console.ReadLine());

            Console.WriteLine("Vnesi stevilo stolpcev,nato stevilo vrstic");
            int ss = int.Parse(Console.ReadLine());
            int sv = int.Parse(Console.ReadLine());
            Console.Clear();
            //int ss = 10;
            //int sv = 10;
            Console.Clear();

            int x = (sv * 4) + 1;
            int y = (ss * 9) + 1;

            char[,] tabela = new char[x, y];
            //tabela kačic je velika za stevilo stolpcev +1 
            int[,] k = new int[ss + 1, 2];
            //tabela lestev je velika za stevilo stolpcev +1
            int[,] l = new int[ss + 1, 2];



            Gpolja.generiraj(k, l, ss, sv);
            Gpolja.polje(tabela, x, y);
            Gpolja.st(tabela, x, y, sv);
            Gpolja.kacice(k, tabela, x, y, ss);
            Gpolja.lujtre(l, tabela, x, y, ss);
            //izpis polja 
            Izpis(tabela, x, y, barvapolja);
            //igralce postavimo na zacetno polje
            for (int i = 0; i < sigralcev; i++)
            {
                igralci[i].Pozicija = 0;
                igralec.zapisi(igralci[i].Pozicija, ss, sv, i, igralci[i].Znak, igralci[i].Barva);
            }

            Console.ReadLine();
            bool igra = true;
            while (igra)
            {
                for (int i = 0; i < sigralcev; i++)
                {
                    int met = r.Next(1, 7);

                    Console.CursorTop = x;
                    Console.CursorLeft = 0;
                    Console.WriteLine("                                                                                                      ");
                    Console.WriteLine("                                                                                                      ");
                    Console.WriteLine("                                                                                                      ");

                    int[] npozicije = new int[sigralcev];
                    Console.CursorTop = x;
                    Console.CursorLeft = 0;
                    Console.Write("igralec {1}. je vrgel {0}", met, igralci[i].Znak);
                    Console.ReadLine();
                    npozicije[i] = igralci[i].Pozicija + met;
                    if (npozicije[i] >= (ss * sv - 1))
                    {
                        npozicije[i] = ss * sv - 1;

                        Console.WriteLine("zmagal je igralec {0}", i + 1);
                        igralec.zapisi(igralci[i].Pozicija, ss, sv, i, ' ', igralci[i].Barva);
                        igralec.zapisi(npozicije[i], ss, sv, i, igralci[i].Znak, igralci[i].Barva);
                        igra = false;
                        break;
                    }
                    igralec.zapisi(igralci[i].Pozicija, ss, sv, i, ' ', igralci[i].Barva);
                    igralec.zapisi(npozicije[i], ss, sv, i, igralci[i].Znak, igralci[i].Barva);
                    igralci[i].Pozicija = npozicije[i];

                    while (igralec.Preverik(k, igralci[i].Pozicija, i, igralci[i].Znak, x + 1) || (igralec.Preveril(l, igralci[i].Pozicija, i, igralci[i].Znak, x + 1)))
                    {
                        if (igralec.Preverik(k, igralci[i].Pozicija, i, igralci[i].Znak, x + 1))
                        {
                            Console.ReadLine();
                            for (int i2 = 0; i2 < k.GetLength(0); i2++)
                            {
                                if (igralci[i].Pozicija == k[i2, 0])
                                {
                                    npozicije[i] = igralci[i].Pozicija - k[i2, 1];
                                    igralec.zapisi(igralci[i].Pozicija, ss, sv, i, ' ', igralci[i].Barva);
                                    igralec.zapisi(npozicije[i], ss, sv, i, igralci[i].Znak, igralci[i].Barva);
                                    igralci[i].Pozicija = npozicije[i];

                                }
                            }


                        }
                        if (igralec.Preveril(l, igralci[i].Pozicija, i, igralci[i].Znak, x + 1))
                        {
                            Console.ReadLine();
                            for (int i2 = 0; i2 < l.GetLength(0); i2++)
                            {
                                if (igralci[i].Pozicija == l[i2, 0])
                                {
                                    npozicije[i] = igralci[i].Pozicija + l[i2, 1];
                                    igralec.zapisi(igralci[i].Pozicija, ss, sv, i, ' ', igralci[i].Barva);
                                    igralec.zapisi(npozicije[i], ss, sv, i, igralci[i].Znak, igralci[i].Barva);
                                    igralci[i].Pozicija = npozicije[i];

                                }
                            }
                        }

                    }


                }

                Console.ReadLine();

            }
            
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Želite začeti novo igro vnesi: Y-da N-ne");
            char dane = Console.ReadLine()[0];
            if (dane == 'N')
                break;
        }
    }
    }






    
    

