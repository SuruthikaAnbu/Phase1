using System;

        public class Program
        {
            public static void Main(string[] args)
            {
                int m=int.Parse(Console.ReadLine());
                int n=int.Parse(Console.ReadLine());
                int[,] arr1=new int[2,3];
                int[,] arr2=new int[3,2];
                int[,] arr3=new int[2,2];
                for(int i=0;i<m;i++)
                {
                    for(int j=0;j<n;j++)
                    {
                        arr1[i,j]=int.Parse(Console.ReadLine());
                    }
                }
                for(int i=0;i<n;i++)
                {
                    for(int j=0;j<m;j++)
                    {
                        arr2[i,j]=int.Parse(Console.ReadLine());
                    }
                }
                for(int i=0;i<2;i++)
                {
                    for(int j=0;j<m;j++)
                    {
                        for(int k=0;k<n;k++)
                        {
                            arr3[i,j]+=arr1[i,j]*arr1[j,i];
                        }
                    }
                }
                for(int i=0;i<2;i++)
                {
                    for(int j=0;j<2;j++)
                    {
                        Console.Write(arr3[i,j]);
                    }
                    Console.WriteLine();
                    
                }
            }
        }
            