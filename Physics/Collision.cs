using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Physics
{
    public class Collision
    {
        Vector _startPoint;
        Vector _endPoint;
        Vector _normal;

        RigidBody _body1;
        RigidBody _body2;

        public Collision(Vector startPoint, Vector endPoint, Vector normal, RigidBody body1, RigidBody body2)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Normal = normal;

            Body1 = body1;
            Body2 = body2;
        }

        public Vector StartPoint { get => _startPoint; set => _startPoint = (Vector)(Vector.Build.DenseOfVector(value)); }
        public Vector EndPoint { get => _endPoint; set => _endPoint = (Vector)(Vector.Build.DenseOfVector(value)); }
        public Vector Normal { get => _normal; set => _normal = (Vector)(Vector.Build.DenseOfVector(value)); }
        public RigidBody Body1 { get => _body1; set => _body1 = value; }
        public RigidBody Body2 { get => _body2; set => _body2 = value; }
    }
}
