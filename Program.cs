using System;
using System.Numerics;

namespace Labb2Project
{

    public abstract class Shape
    {
        public abstract Vector3 Center { get; }
        public abstract float Area { get; } //Area av Vector3

        public static Shape GenerateShape()
        {
            Random rnd = new Random();
            float x = (float)rnd.NextDouble() * 10;
            float y = (float)rnd.NextDouble() * 10;
            float z = (float)rnd.NextDouble() * 10;
            Vector2 p1 = new Vector2((float)rnd.NextDouble() * 10, (float)rnd.NextDouble() * 10);
            Vector2 p2 = new Vector2((float)rnd.NextDouble() * 10, (float)rnd.NextDouble() * 10);
            Vector2 p3 = new Vector2((3 * x - (float)rnd.NextDouble() * 10 - (float)rnd.NextDouble() * 10), (3 * y - (float)rnd.NextDouble() * 10 - (float)rnd.NextDouble() * 10));
            float W = (float)rnd.NextDouble() * 10;
            float H = (float)rnd.NextDouble() * 10;
            float L = (float)rnd.NextDouble() * 10;
            float R = (float)rnd.NextDouble() * 10;
            int Choice = rnd.Next(0, 6);

            Console.WriteLine($"Your shape's number is: {Choice}");
            if (Choice == 0)
            {
                return new Circle(new Vector3(x, y, z), R);
            }
            else if (Choice == 1)
            {
                return new Rectangle(new Vector3(x, y, z), W, L);
            }
            else if (Choice == 2)
            {
                return new Square(new Vector3(x, y, z), L);
            }
            else if (Choice == 3)
            {
                return new Triangle(p1, p2, p3);
            }
            else if (Choice == 4)
            {
                return new Cuboid(new Vector3(x, y, z), L, W, H);
            }
            else if (Choice == 5)
            {
                return new Cube(new Vector3(x, y, z), L);
            }
            else if (Choice == 6)
            {
                return new Sphere(new Vector3(x, y, z), R);
            }
            else
            {
                return null;
            }

            //Vector2 position = new Vector2(4.5f, 3.0f);
            //float radius = 1.0f;
        }


    }


    public abstract class Shape2D : Shape
    {
        public abstract float Circumference { get; }

    }


    public abstract class Shape3D : Shape
    {
        public abstract float Volume { get; }

    }

    public class Circle : Shape2D
    {
        private float R;
        private Vector3 center;

        public override float Circumference
        {
            get { return 2 * 3.14F * R; }
        }
        public Circle(Vector3 Center, float R)
        {
            this.R = R;
            this.center = new Vector3(Center.X, Center.Y, 0);
        }

        public override string ToString()
        {
            return $"Circle@({Center.X:N2},{Center.Y:N2},{Center.Z:N2}):R={R:N2}";
        }

        public override Vector3 Center
        {
            get { return center; }

        }
        public override float Area
        {
            get
            {
                return 3.14F * R * R;
            }


        }
    }
    public class Rectangle : Shape2D
    {
        private float length;
        private float width;
        private Vector3 center;

        public override float Circumference
        {
            get { return 2 * (length + width); }
        }
        public Rectangle(Vector3 Center, float length, float width)
        {
            this.length = length;
            this.width = width;
            this.center = new Vector3(Center.X, Center.Y, 0);
        }

        public override Vector3 Center
        {
            get { return center; }

        }
        public override float Area
        {
            get
            {
                return length * width;
            }


        }
        public override string ToString()
        {
            return $"Rectangle@({Center.X:N2},{Center.Y:N2},{Center.Z:N2}):L={length:N2},W={width:N2}";
        }
    }

    public class Square : Shape2D
    {
        private float length;
        private Vector3 center;

        public override float Circumference
        {
            get { return 2 * (length + length); }
        }
        public Square(Vector3 Center, float length)
        {
            this.length = length;
            this.center = new Vector3(Center.X, Center.Y, 0);
        }

        public override Vector3 Center
        {
            get { return center; }

        }
        public override float Area
        {
            get
            {
                return length * length;
            }


        }
        public override string ToString()
        {
            return $"Square@({Center.X:N2},{Center.Y:N2},{Center.Z:N2}):L={length:N2}";
        }


    }
    public class Triangle : Shape2D
    {
        private Vector2 point1;
        private Vector2 point2;
        private Vector2 point3;
        private Vector3 center;
        public float lengthp1p2;
        public float lengthp2p3;
        public float lengthp3p1;

        public override float Circumference
        {
            get { return (lengthp1p2 + lengthp2p3 + lengthp3p1); }
        }
        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            this.point1 = p1;
            this.point2 = p2;
            this.point3 = p3;
            this.center = new Vector3((p1.X + p2.X + p3.X) / 3, (p1.Y + p2.Y + p3.Y) / 3, 0);
            this.lengthp1p2 = MathF.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
            this.lengthp2p3 = MathF.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y));
            this.lengthp3p1 = MathF.Sqrt((p3.X - p1.X) * (p3.X - p1.X) + (p3.Y - p1.Y) * (p3.Y - p1.Y));
        }
        public override Vector3 Center
        {
            get 
            { 
                return center; 
            }
        }
        public override float Area
        {
            get
            {
                return (point1.X * (point2.Y - point3.Y) + point2.X * (point3.Y - point1.Y) + point3.X * (point1.Y - point2.Y)) / 2;
            }
        }


        public override string ToString()
        {
            return $"Triangle@({center.X:N2},{center.Y:N2},{center.Z:N2}):P1{point1:N2}, P2{point2:N2},P3{point3:N2}";
        }

    }

    public class Cuboid : Shape3D
    {
        private float height;
        private float width;
        private float length;
        private Vector3 center;

        public override float Volume
        {
            get { return (length * height * width); }
        }

        public override float Area
        {
            get
            {
                return (length * height * 2 + length * width * 2 + height * width * 2);

            }

        }
        public Cuboid(Vector3 Center, float height, float width, float length)
        {
            this.height = height;
            this.width = width;
            this.length = length;
            this.center = new Vector3(Center.X, Center.Y, Center.Z);
        }

        public override Vector3 Center
        {
            get { return center; }

        }
        public override string ToString()
        {
            return $"Cuboid@({Center.X:N2},{Center.Y:N2},{Center.Z:N2}):W={width:N2}, H={height:N2},L={length:N2}";
        }
    }

    public class Cube : Shape3D
    {
        private float length;
        private Vector3 center;

        public override float Volume
        {
            get { return (length * length * length); }
        }
        public Cube(Vector3 Center, float length)
        {
            this.length = length;
            this.center = new Vector3(Center.X, Center.Y, Center.Z);
        }

        public override Vector3 Center
        {
            get { return center; }

        }
        public override float Area
        {
            get
            {
                return 6 * length * length;
            }


        }
        public override string ToString()
        {
            return $"Cube@({Center.X:N2},{Center.Y:N2},{Center.Z:N2}):L={length:N2}";
        }
    }

    public class Sphere : Shape3D
    {
        private float radius2;
        private Vector3 center;

        public override float Area
        {
            get
            {
                return 0;
            }
        }
        public override float Volume
        {
            get { return (4 * 3.14F * radius2 * radius2 * radius2) / 3; }
        }
        public Sphere(Vector3 Center, float radius2)
        {
            this.radius2 = radius2;
            this.center = new Vector3(Center.X, Center.Y, Center.Z);
        }

        public override Vector3 Center
        {
            get { return center; }

        }
        public override string ToString()
        {
            return $"Sephere@({Center.X:N2},{Center.Y:N2},{Center.Z:N2}):R={radius2}";
        }

    }
}


//    public class RandomShape : NewShape3D
//    {
//        public Vector3 NewCenter;
//        public float NewRadius;
//        public float NewHeight;
//        public float NewLength;
//        public float NewWidth;

//        public float random
//        {
//            set
//            {
//                Random RND = new Random();
//                V = RND.Next(1, 10);
//                NewRadius = V.NewRadius;
//                NewHeight = V.NewHeight;
//                NewLength = V.NewLength;
//                NewWidth = V.NewWidth;
//            }
//            get { NewRadius; NewHeight; NewLength; NewWidth}



//        }

//        public override float NewVolume
//        {  if (NewHeight==NewLength==NewWidth==0)
//            {
//            get { 
//            return (4 * 3.14F * radius2* radius2 * radius2) / 3;
//                }

//          else if (NewRadius==0&&NewHeight!=0;NewLength!=0;NewWidth!=0)
//         {
//            get { 
//            return (NewHeight* NewWidth* NewWidth)
//}

//}
//public Sphere(Vector3 Center, float NewRadius)
//{
//    this.NewRadius = NewRadius;
//    this.center = new Vector3(NewCenter.X, NewCenter.Y, NewCenter.Z);
//}

//public override Vector3 Center
//{
//    get { return center; }

//}









