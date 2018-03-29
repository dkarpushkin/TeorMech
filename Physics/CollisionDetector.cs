using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra.Double;


namespace Physics
{
    public abstract class CollisionDetector
    {
        protected ICollection<CollisionDetector> _detectors = new HashSet<CollisionDetector>();

//        public Collision checkCollisiion(RigidBody body1, RigidBody body2);
    }

    public class SphereSphereCD : CollisionDetector
    {
        public SphereSphereCD()
        {
            this._detectors.Add(this);
        }
        
        public Collision checkCollisiion(SphereBody body1, SphereBody body2)
        {
            throw new NotImplementedException();
        }
    }
}
