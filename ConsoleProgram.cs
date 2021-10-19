using Labb2Project;
using System;
using System.Collections.Generic;

namespace Lab2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            float sum = 0;
            float sum1 = 0;
            float average = 0;
            float maxVolume = 0;
            Dictionary<string, int> countShapes = new Dictionary<string, int>();
            Shape maxVolumeShape = null;
            string maxTypeShape = " ";
            int maxShapes = 0;
            countShapes.Add("circle", 0);
            countShapes.Add("rectangle", 0);
            countShapes.Add("sphere", 0);
            countShapes.Add("cuboid", 0);
            countShapes.Add("triangle", 0);




            for (int i = 0; i < 20; i++)
            {
                Shape myShape = Shape.GenerateShape();
                Console.WriteLine(myShape);
                Console.WriteLine("The area of this shape is" + " " + $"{myShape.Area:N2}");

                if (myShape is Triangle triangle)
                {
                    //Console.WriteLine("The Circuference of this triangle is"+$"{triangle.Circumference:N2}");
                    sum += (triangle.Circumference);
                }




                if (myShape is Shape3D s)
                {
                    if (s.Volume > maxVolume)
                    {
                        maxVolume = s.Volume;
                        maxVolumeShape = s;
                    }
                }


                if (myShape is Circle)
                {
                    countShapes["circle"] += 1;
                }

                if (myShape is Rectangle)
                {
                    countShapes["rectangle"] += 1;
                }

                if (myShape is Sphere)
                {
                    countShapes["sphere"] += 1;
                }
                if (myShape is Cuboid)
                {
                    countShapes["cuboid"] += 1;
                }
                if (myShape is Triangle)
                {
                    countShapes["triangle"] += 1;
                }

                foreach (KeyValuePair<string, int> t in countShapes)
                {
                    if (maxShapes< t.Value)
                    {
                        maxShapes = t.Value;
                        maxTypeShape = t.Key;
                    }
                }


                sum1 += (myShape.Area);
            }
            average = sum1 / 20;

            Console.WriteLine("");
            Console.WriteLine($"The cicle shapes you have generated are {countShapes["circle"]}");
            Console.WriteLine($"The rectangle shapes you have generated are {countShapes["rectangle"]}");
            Console.WriteLine($"The sphere shapes you have generated are {countShapes["sphere"]}");
            Console.WriteLine($"The cuboid shapes you have generated are {countShapes["cuboid"]}");
            Console.WriteLine($"The triangle shapes you have generated are {countShapes["triangle"]}");
            Console.WriteLine();
            Console.WriteLine("");
            Console.WriteLine($"Your total circumference of Triangles is {sum:N2}");
            Console.WriteLine($"The average area of all shapes is {average:N2}");
            Console.WriteLine($"The biggest volume of all shape3d is {maxVolumeShape} and the volume is {maxVolume:N2}");       
            Console.WriteLine($"The most type of shapes were generated from myShapes is  {maxTypeShape} and the number is  {maxShapes}");
       
        }

    }
}