using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Physics
{
    public class SphereBody : RigidBody
    {
        public readonly RigidBodyType BODY_TYPE = RigidBodyType.Sphere;

        double _radius;


        public double Radius { get; set; }

        public SphereBody(double mass, Vector position, Vector velocity = null)
            : base(mass, position, velocity) { }

        public SphereBody(double mass, double x, double y, double z, double vx, double vy, double vz)
        {
            Mass = mass;
            double[] pos = { x, y, z };
            double[] vel = { vx, vy, vz };
            _position = (Vector)(Vector.Build.DenseOfArray(pos));
            _velocity = (Vector)(Vector.Build.DenseOfArray(vel));
        }

        public Collision checkCollisionWith(SphereBody body)
        {

        }

        public Collision checkCollisionWith(PlaneBody body)
        {

        }
    }
}
