using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Physics
{
    class TemporalForce : IForce
    {
        private Vector _magnitude;
        private double _timeframe;

        public TemporalForce(Vector magnitude, double timeframe)
        {
            _timeframe = timeframe;
            _magnitude = (Vector)(Vector.Build.DenseOfVector(magnitude));
        }

        public Vector apply(double dt, RigidBody body)
        {
            double p = dt / _timeframe;
            Vector portion = (Vector)(p * _magnitude);

            _magnitude = (Vector)((_timeframe - p) * _magnitude);
            _timeframe = _timeframe - dt;

            return portion;
        }

        public bool isActive()
        {
            return _magnitude.Norm(2) > 0;
        }
    }
}
