using System;
using System.Globalization;
using System.Linq;

namespace IWontToDai
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ,.!".ToCharArray();//создание масива алфавита  

            Console.WriteLine("введите ключь");
            char[] key = Console.ReadLine().ToUpper().Distinct().ToArray();//в верхний регистр уберая повторения

            int colum = key.Length;
            int rows = alphabet.Length / colum;

            char[,] table = new char[rows, colum];

            for(int i=0; i < key.Length; i++)
            {

                table[0, i] = key[i];
                

               
            }



            alphabet = alphabet.Except(key).ToArray();

            int caunter = 0;
            for (int j = 1; j < rows; j++)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    table[j, i] = alphabet[caunter];
                    caunter++;
                    
                }
                if(caunter>36)
                {
                    break;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colum; j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("введите сообщение для зашифровки");

            string mesedg = Console.ReadLine().ToUpper();

            if(mesedg.Length % 2 != 0)
            {
                mesedg += "я";
            }

            string enskript="";

            char s1 = ' ', s2 = ' ';

            int normal_rows1 = 0, normal_colum1 = 0, normal_rows2 = 0, normal_colum2 = 0;
            int ens_rows1 = 0, ens_colum1 = 0, ens_rows2 = 0, ens_colum2 = 0;


            for (int i=0; i<mesedg.Length; i+=2)
            {
                bool loog = false;
                for (int j = 0; j < rows; j++)
                {
                    for (int n = 0; n < colum; n++)
                    {
                        if (mesedg[i] == table[j, n])
                        {
                            normal_rows1 = j;
                            normal_colum1 = n;
                        }
                        if (mesedg[i + 1] == table[j, n])
                        {
                            normal_rows2 = j;
                            normal_colum2 = n;
                        }
                    }
                }

                //если в одной строке
                if(normal_rows1==normal_rows2)
                {
                    loog = true;
                    //если в переди первый символ
                    if(normal_rows1 < normal_rows2)
                    {
                        ens_colum1 = normal_colum2;
                        ens_rows1 = normal_rows1;
                        if(normal_colum2+1!=colum)
                        {
                            ens_colum2 = normal_colum2 + 1;
                        }else
                        {
                            ens_colum2 = 0;
                        }
                        ens_rows2 = normal_rows2;
                        
                    }else
                    {
                        ens_colum2 = normal_colum1;
                        ens_rows2 = normal_rows2;
                        if (normal_colum1 + 1 != colum)
                        {
                            ens_colum1 = normal_colum1 + 1;
                        }
                        else
                        {
                            ens_colum1 = 0;
                        }
                        ens_rows1 = normal_rows1;
                    }

                   
                }

                //если в одном столбце
                if (normal_colum1 == normal_colum2)
                {
                    loog = true;
                    //если с верху первая
                    if(normal_rows1<normal_rows2)
                    {
                        ens_rows1 = normal_rows2;
                        ens_colum1 = normal_colum1;

                        //если в не последней строке
                        if(normal_rows2+1 !=rows)
                        {
                            ens_rows2 = normal_rows2 + 1;
                        }else
                        {
                            ens_rows2 = 0;
                        }
                    }else
                    {
                        ens_rows2 = normal_rows1;
                        ens_colum2 = normal_colum2;

                        
                        if (normal_rows1 + 1 != rows)
                        {
                            ens_rows1= normal_rows1 + 1;
                        }
                        else
                        {
                            ens_rows1 = 0;
                        }
                    }

                }

                if(!loog)
                {
                    ens_colum1 = normal_colum2;
                    ens_rows1 = normal_rows1;

                    ens_colum2 = normal_colum1;
                    ens_rows2 = normal_rows2;
                }

                s1 = table[ens_rows1, ens_colum1];
                s2 = table[ens_rows2, ens_colum2];

                enskript += Convert.ToString(s1).ToLower() + Convert.ToString(s2).ToLower();

                
            }

            Console.WriteLine(enskript);
           
        }

        
    }
}
