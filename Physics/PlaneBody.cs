using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Physics
{
    class PlaneBody : RigidBody
    {
        public readonly RigidBodyType BODY_TYPE = RigidBodyType.Plane;

        Vector _normal; //  3-х мерный вектор: {A, B, C}
        double _anchor; //  D

        public Vector Normal
        {
            get { return _normal; }
            set
            {
                if (value.Norm(2) == 0)
                    throw new ArgumentNullException("Normal vector cannot be zero");

                _normal = (Vector)(Vector.Build.DenseOfVector(value).Normalize(2));
            }
        }

        public override Vector Position
        {
            get { return _position; }
            set
            {
                _position = (Vector)(Vector.Build.DenseOfVector(value));
                _anchor = 0 - _normal.DotProduct(_position);
            }
        }

        public PlaneBody(
            double mass,
            double x, double y, double z,
            double a, double b, double c,
            double vx = 0, double vy = 0, double vz = 0)

            //: base(mass, x, y, z, vx, vy, vz)
        {
            Mass = mass;

            double[] n = { a, b, c };
            Normal = (Vector)(Vector.Build.DenseOfArray(n));

            double[] pos = { x, y, z };
            Position = (Vector)(Vector.Build.DenseOfArray(pos));
            
            double[] vel = { vx, vy, vz };
            Velocity = (Vector)(Vector.Build.DenseOfArray(vel));
        }

        public PlaneBody(double mass, Vector position, Vector normal, Vector velocity = null)
            //: base(mass, position, velocity)
        {
            Mass = mass;
            Normal = normal;
            Position = position;
            Velocity = velocity;
        }

        public double distanceToPoint(Vector point)
        {
            return (_normal.DotProduct(point) + _anchor) / _normal.Norm(2);
        }

        public override Collision checkCollisionWith(SphereBody body)
        {
            double dist = distanceToPoint(body.Position);

            if (dist < body.Radius)
            {
                Vector normal = Normal;
                Vector startPoint = (Vector)(body.Position - Normal);
                Vector endPoint = (Vector)(body.Position - Normal * dist);

                return new Collision(startPoint, endPoint, normal);
            }
            else
                return null;
        }

        public override Collision checkCollisionWith(PlaneBody body)
        {
            return null;
        }
    }
}
