using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace XML_Partition
{
    class Program
    {
        public static string GetXMLAsString(XmlDocument myxml)
        {
            return myxml.OuterXml;
        }
        static void Main(string[] args)
        {
            //int supprimer = 0;
            // ajouter alter ??
            string part = "<part id=\"";
            string part_end = "</part>";
            string mesure = "<measure number=\"";
            string mesure_end = "</measure>";
            string beats = "<beats>";
            string beats_end = "</beats>";
            string beatType = "<beat-type>";
            string beatType_end = "</beat-type>";
            string sign = "<sign>";
            string sign_end = "</sign>";
            string step = "<step>";
            string step_end = "</step>";
            string octave = "<octave>";
            string octave_end = "</octave>";
            string type = "<type>";
            string type_end = "</type>";
            string fin = "</score-partwise>";

            XmlDocument test = new XmlDocument();
            test.Load("digitalized.xml");
            string essai = "";
            string essaiBis = ""; //chaîne qui copiera bout par bout essai, et qui sera analysé
            essai = GetXMLAsString(test);

            while (!essaiBis.Contains(fin))
            {
                essaiBis = "";
                int m = 0;
                //va enregistrer les éléments de essai jusqu'à tomber sur la fermeture d'une balise qui nous intéresse (ex </mesure>) ==> essaiBis ne contiendra donc jamais deux fois un même type de balise
                while (!essaiBis.Contains(fin) && !essaiBis.Contains(part_end) && !essaiBis.Contains(beats_end) && !essaiBis.Contains(beatType_end) && !essaiBis.Contains(sign_end) && !essaiBis.Contains(mesure_end) && !essaiBis.Contains(step_end) && !essaiBis.Contains(octave_end) && !essaiBis.Contains(type_end))
                {
                    essaiBis += essai[m];
                    m++; //m permet de supprimer de essai tout ce qui a été enregistré et qui va être analysé dans essaiBis, donc qui n'est plus utile de garder dans essai
                }

                essai = essai.Remove(0, m - 1);

                //verification de la présence d'une ou plusieurs balises de début qui nous intéressent (ex : <mesure ...>, <beats>, ...)
                if (essaiBis.Contains(part))
                {
                    int index = essaiBis.IndexOf(part);
                    Console.Write("Partie : ");
                    int i = index + 10;
                    while (essaiBis[i] != '\"') //cherche le guillemet de fin de la balise <part>
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.WriteLine();
                }

                if (essaiBis.Contains(mesure))
                {
                    int index = essaiBis.IndexOf(mesure);
                    Console.Write("Numéro de mesure : ");
                    int i = index + 17;
                    while (essaiBis[i] != '\"')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.WriteLine();
                }

                if (essaiBis.Contains(beats))
                {
                    int index = essaiBis.IndexOf(beats);
                    Console.Write("Nombre de temps : ");
                    int i = index + 7;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.WriteLine();
                }
                if (essaiBis.Contains(beatType))
                {
                    int index = essaiBis.IndexOf(beatType);
                    Console.Write("Type de temps : ");
                    int i = index + 11;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.WriteLine();
                }

                if (essaiBis.Contains(sign))
                {
                    int index = essaiBis.IndexOf(sign);
                    Console.Write("Clef de : ");
                    int i = index + 6;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.WriteLine();
                }

                if (essaiBis.Contains(step))
                {
                    int index = essaiBis.IndexOf(step);
                    Console.Write("Note : ");
                    int i = index + 6;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.WriteLine();
                }

                if (essaiBis.Contains(octave))
                {
                    int index = essaiBis.IndexOf(octave);
                    Console.Write("Octave : ");
                    int i = index + 8;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.WriteLine();
                }

                if (essaiBis.Contains(type))
                {
                    int index = essaiBis.IndexOf(type);
                    Console.Write("Type de rythme : ");
                    int i = index + 6;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Fin de la partition.");
        }
    }
}
