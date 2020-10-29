using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CifradoCesar
{
    class Commons
    {
        public static char[] abc = new char[]{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public static int[] numbers = new int[] {0,1,2,3,4,5,6,7,8,9};

        public static int GetPositionLetter(char letter, bool isNum)
        {
            if (isNum)
            {
                for (int pos = 0; pos < numbers.Length; pos++)
                {
                    int oLetter = numbers[pos];
                    int num = int.Parse(letter.ToString());
                    if (num.Equals(oLetter))
                    {
                        return pos;
                    }
                }
            }
            else
            {
                for (int pos = 0; pos < abc.Length; pos++)
                {
                    char oLetter = abc[pos];

                    if (letter.Equals(oLetter))
                    {
                        return pos;
                    }
                }
            }

 

            return 0;
        }


        internal static string DesEncrypt(string msgEncript)
        {
            int mod = 4;
            string msgEncrypt = " ";
            string[] split = msgEncript.Split(" ");
            // recorre por palabras
            foreach (string obj in split)
            {
                char[] palab = obj.ToCharArray();

                for (int pos = 0; pos < palab.Length; pos++)
                {
                    
                    char let = palab[pos];
                    int posLet;
                    try
                    {
                        int convertNum = int.Parse(let.ToString());
                        posLet = Commons.GetPositionLetter(let, true);
                    }
                    catch (Exception)
                    {
                        posLet = Commons.GetPositionLetter(let, false);
                    }
                    //int posLet = Commons.GetPositionLetter(let, false);
                    int posReplace = posLet - mod;

                    if (posReplace < 0)
                    {
    
                        posReplace *= -1;
                        int letterFind = Commons.abc.Length - (posReplace-1);

                        string charLet = Commons.GetLetterOrNumber(letterFind-1, false);
                        msgEncrypt += charLet;
                    }
                    else
                    {
                        string charLet = Commons.GetLetterOrNumber(posLet - mod, false);
                        msgEncrypt += charLet;
                    }

                }

                msgEncrypt = msgEncrypt + " ";
            }

            return msgEncrypt;

        }

        public static string GetLetterOrNumber(int pos, bool isNum)
        {
            if (isNum)
            {
                return numbers[pos].ToString();
            }
            else
            {
                return abc[pos].ToString();
            }
        }

        public static string Encrypt(string msg)
        {
            int mod = 4;
            string msgEncrypt = "";
            string[] split = msg.Split(" ");
                // recorre por palabras
                foreach (string obj in split)
                {
                    char[] palab = obj.ToCharArray();

                    for (int pos = 0; pos < palab.Length; pos++)
                    {
                        char let = palab[pos];
                        int posLet = Commons.GetPositionLetter(let, false);
                        int posReplace = posLet + mod;

                        if (posReplace > Commons.abc.Length)
                        {
                            int cont = 0;
                            for (int i= Commons.abc.Length; i < posReplace; i++)
                            {
                                cont++;
                            }

                            string charLet = Commons.GetLetterOrNumber(cont, true);
                            msgEncrypt += charLet;
                        }
                        else
                        {
                            string charLet = Commons.GetLetterOrNumber(posLet + mod, false);
                            msgEncrypt += charLet;
                        }

                    }

                    msgEncrypt = msgEncrypt + " ";
                }

            return msgEncrypt;

            }
    }
}
