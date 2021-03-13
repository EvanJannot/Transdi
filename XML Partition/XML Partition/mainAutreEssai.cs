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
                    m++; //m devrait permettre de supprimer de essai tout ce qui a été enregistré puis analysé dans essaiBis, donc qui n'est plus utile de garder
                }

                //verification de la présence d'une ou plusieurs balises de début qui nous intéresse (ex : <mesure ...>, <beats>, ...)
                if (essaiBis.Contains(part))
                {
                    int index = essaiBis.IndexOf(part);
                    Console.Write("Partie : ");
                    int i = index + 10;
                    int cpt = 0; //servira pour supprimer le bon nb d'éléments dans essais
                    while (essaiBis[i] != '\"') //cherche le guillemet de fin de la balise <part>
                    {
                        Console.Write(essaiBis[i]);
                        cpt++;
                        i++;
                    }
                    Console.WriteLine();
                    //essai.Remove(essai.IndexOf(part_end), 6); //enlève la balise de fermeture pour ne pas bloquer la boucle
                    //essai.Remove(essai.IndexOf(part), essai.IndexOf(part) + 10 + cpt); //enlève la balise de début de <part>
                    //Je n'ai pas encore supprimé ces lignes au cas où, mais normalement elles ne serviront plus, si la ligne essai.Remove(0,m-1) à la toute fin finit par fonctionner
                }

                if (essaiBis.Contains(mesure))
                {
                    int index = essaiBis.IndexOf(mesure);
                    Console.Write("Numéro de mesure : ");
                    int i = index + 17;
                    int cpt = 0;
                    while (essaiBis[i] != '\"')
                    {
                        Console.Write(essaiBis[i]);
                        cpt++;
                        i++;
                    }
                    Console.WriteLine();
                    //essai.Remove(essai.IndexOf(mesure_end), 9); //enlève la balise de fermeture pour ne pas bloquer la boucle
                    //essai.Remove(essai.IndexOf(mesure), 17 + cpt); //enlève la balise de début jusqu'à la fin de ce qu'elle contient
                }

                if (essaiBis.Contains(beats))
                {
                    int index = essaiBis.IndexOf(beats);
                    Console.Write("Nombre de temps : ");
                    int i = index + 7;
                    int cpt = 0;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        cpt++;
                        i++;
                    }
                    Console.WriteLine();
                    //essai.Remove(essai.IndexOf(beats_end), 7); //enlève la balise de fermeture pour ne pas bloquer la boucle
                    //essai.Remove(essai.IndexOf(beats), 7 + cpt);
                }
                if (essaiBis.Contains(beatType))
                {
                    int index = essaiBis.IndexOf(beatType);
                    Console.Write("Type de temps : ");
                    int i = index + 11;
                    int cpt = 0;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        cpt++;
                        i++;
                    }
                    Console.WriteLine();
                    //essai.Remove(essai.IndexOf(beatType_end), 11); //enlève la balise de fermeture pour ne pas bloquer la boucle
                    //essai.Remove(essai.IndexOf(beatType), 11 + cpt);
                }

                if (essaiBis.Contains(sign))
                {
                    int index = essaiBis.IndexOf(sign);
                    Console.Write("Clef de : ");
                    int i = index + 6;
                    int cpt = 0;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        cpt++;
                        i++;
                    }
                    Console.WriteLine();
                    //essai.Remove(essai.IndexOf(sign_end), 6); //enlève la balise de fermeture pour ne pas bloquer la boucle
                    //essai.Remove(essai.IndexOf(sign), 6 + cpt);
                }

                if (essaiBis.Contains(step))
                {
                    int index = essaiBis.IndexOf(step);
                    Console.Write("Note : ");
                    int i = index + 6;
                    int cpt = 0;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        cpt++;
                        i++;
                    }
                    Console.WriteLine();
                    //essai.Remove(essai.IndexOf(step_end), 6); //enlève la balise de fermeture pour ne pas bloquer la boucle
                    //essai.Remove(essai.IndexOf(step), 6 + cpt);
                }

                if (essaiBis.Contains(octave))
                {
                    int index = essaiBis.IndexOf(octave);
                    Console.Write("Octave : ");
                    int i = index + 8;
                    int cpt = 0;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        cpt++;
                        i++;
                    }
                    Console.WriteLine();
                    //essai.Remove(essai.IndexOf(octave_end), 8); //enlève la balise de fermeture pour ne pas bloquer la boucle
                    //essai.Remove(essai.IndexOf(octave), 8 + cpt);
                }

                if (essaiBis.Contains(type))
                {
                    int index = essaiBis.IndexOf(type);
                    Console.Write("Type de rythme : ");
                    int i = index + 6;
                    int cpt = 0;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        cpt++;
                        i++;
                    }
                    Console.WriteLine();
                    //essai.Remove(essai.IndexOf(type_end), 6); //enlève la balise de fermeture pour ne pas bloquer la boucle
                    //essai.Remove(essai.IndexOf(type), 6 + cpt);
                }
                essai = essai.Remove(0, m - 1);
            }
            Console.WriteLine("Fin de la partition.");
        }
    }
}
