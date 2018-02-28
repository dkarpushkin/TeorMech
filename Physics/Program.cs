using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Physics
{
    class Program
    {
        static void outputBodyData(SphereBody body)
        {
            Console.WriteLine("Position");
            Console.WriteLine(body.Position);
        }

        static void Main(string[] args)
        {
            World world = new World();

            PlaneBody ground = new PlaneBody(
                double.PositiveInfinity,
                0, 0, 0,
                0, 0, 1);
            SphereBody body = new SphereBody(
                1,
                0, 0, 100,
                0, 0, 0);

            world.addBody(ground);
            world.addBody(body);

            world.addGlobalForce(new SimpleGravity());
            
            //double[] v = { 0, 0, 10 };
            //body.applyForce(new TemporalForce((Vector)Vector.Build.DenseOfArray(v), 1.0));

            double iterationStep = 0.1;
            double iterationFrame = 1;

            for (double t = 0; t < iterationFrame; t += iterationStep)
            {
                world.update(iterationStep);

                outputBodyData(body);
            }

            return;
        }
    }
}
