using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Physics
{
    interface IForce
    {
        Vector apply(double dt, RigidBody body);

        bool isActive();
    }
}
