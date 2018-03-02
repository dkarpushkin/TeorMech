using System;
using System.IO;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Physics
{
    class Program
    {
        static void outputBodyData(StreamWriter stream, double time, RigidBody body)
        {
            string format = "{0,6:0.00}{1,10:0.00}{2,10:0.00}{3,10:0.00}{4,10:0.00}{5,10:0.00}{6,10:0.00}";
            stream.WriteLine(string.Format(
                format,
                time, body.X, body.Y, body.Z, body.Vx, body.Vy, body.Vz));
            Console.WriteLine(string.Format(
                format,
                time, body.X, body.Y, body.Z, body.Vx, body.Vy, body.Vz));
        }

        static void Main(string[] args)
        {
            World world = new World();
            //PlaneBody ground = new PlaneBody(
            //    double.PositiveInfinity,
            //    0, 0, 0,
            //    0, 0, 1);
            //world.addBody(ground);
            SphereBody body = new SphereBody(
                1,
                0, 0, 100,
                0, 0, 0);
            world.addBody(body);
            world.addGlobalForce(new SimpleGravity());

            //double[] v = { 0, 0, 10 };
            //body.applyForce(new TemporalForce((Vector)Vector.Build.DenseOfArray(v), 1.0));

            Console.Write("Tell me the magnitude of the initial velocity:  ");
            double vel_scalar;
            while (! double.TryParse(Console.ReadLine(), out vel_scalar))
            {
                Console.Write("I need a floating point number:  ");
            }

            Console.Write("Tell me its angle to the X axis:  ");
            double angle;
            while (!double.TryParse(Console.ReadLine(), out angle))
            {
                Console.Write("I need a floating point number:  ");
            }

            double tan = Math.Tan(angle * Math.PI / 180);
            double[] vel = { 1, tan, 0 };
            Vector velocity = (Vector)(Vector.Build.DenseOfArray(vel).Normalize(2) * vel_scalar);
            body.Velocity = velocity;


            double iterationStep = 0.1;
            double iterationFrame = 10;
            StreamWriter outputStream = new StreamWriter("./output.txt");
            outputStream.WriteLine(string.Format(
                "{0,6}{1,10}{2,10}{3,10}{4,10}{5,10}{6,10}",
                "Time", "X", "Y", "Z", "Vx", "Vy", "Vz")
                );

            for (double t = 0; t < iterationFrame; t += iterationStep)
            {
                outputBodyData(outputStream, t, body);
                world.update(iterationStep);
            }

            outputStream.Close();

            return;
        }
    }
}
