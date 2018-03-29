using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Physics
{
    class SimpleGravity : IForce
    {
        public const double DEFAULT_GRAV_CONSTANT = 9.8;

        protected double _grav_constant;
        protected Vector _direction;
        protected Vector _magnitude;

        public SimpleGravity()
        {
            double[] dir = { 0, -1, 0 };
            this._grav_constant = DEFAULT_GRAV_CONSTANT;
            this._direction = (Vector)Vector.Build.DenseOfArray(dir);
            this._magnitude = (Vector)(this._direction * this._grav_constant);
        }

        public SimpleGravity(double gravConstant, Vector direction=null)
        {
            this._grav_constant = gravConstant;
            this._direction = (Vector)Vector.Build.DenseOfVector(direction).Normalize(2);
            this._magnitude = (Vector)(this._direction * this._grav_constant);
        }

        public Vector apply(double dt, RigidBody body)
        {
            if (body.isStatic())
                return (Vector)(Vector.Build.Dense(3, 0.0));

            return (Vector)(_magnitude / body.InverceMass);
        }

        public bool isActive()
        {
            return true;
        }
    }
}
