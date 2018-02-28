using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Physics
{
    class SimpleGravity : IForce
    {
        public const double DEFAULT_GRAV_CONSTANT = 9.0;

        protected double grav_constant;
        protected Vector direction;
        protected Vector magnitude;

        public SimpleGravity()
        {
            double[] dir = { 0, 0, -1 };
            this.grav_constant = DEFAULT_GRAV_CONSTANT;
            this.direction = (Vector)Vector.Build.DenseOfArray(dir);
            this.magnitude = (Vector)(this.direction * this.grav_constant);
        }

        public SimpleGravity(double gravConstant, Vector direction=null)
        {
            this.grav_constant = gravConstant;
            this.direction = (Vector)Vector.Build.DenseOfVector(direction).Normalize(2);
            this.magnitude = (Vector)(this.direction * this.grav_constant);
        }

        public Vector apply(double dt, RigidBody body)
        {
            return this.magnitude;
        }

        public bool isActive()
        {
            return true;
        }
    }
}
