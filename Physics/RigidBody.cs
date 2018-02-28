using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;

namespace Physics
{
    enum RigidBodyType
    {
        None,
        Sphere,
        Plane,
    }

    abstract class RigidBody
    {
        public readonly RigidBodyType BODY_TYPE = RigidBodyType.None;

        protected double _mass;
        protected Vector _position;
        protected Vector _velocity;

        protected ICollection<IForce> _effectiveForces;


        protected RigidBody() { }

        protected RigidBody(double mass, Vector position, Vector velocity = null)
        {
            Mass = mass;

            Position = position;

            if (velocity == null)
            {
                double[] vel = { 0, 0, 0 };
                Velocity = (Vector)(Vector.Build.DenseOfArray(vel));
            }
            else
                Velocity = velocity;
            
            _effectiveForces = new HashSet<IForce>();
        }

        protected RigidBody(
            double mass,
            double x, double y, double z,
            double vx = 0, double vy = 0, double vz = 0)
        {
            Mass = mass;

            double[] pos = { x, y, z };
            double[] vel = { vx, vy, vz };

            Position = (Vector)(Vector.Build.DenseOfArray(pos));
            Velocity = (Vector)(Vector.Build.DenseOfArray(vel));
            
            _effectiveForces = new HashSet<IForce>();
        }
        
        public double Mass
        {
            get { return _mass; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Mass must not be 0");

                _mass = value;
            }
        }

        public virtual Vector Position
        {
            get { return _position; }
            set
            {
                _position = (Vector)(Vector.Build.DenseOfVector(value));
            }
        }

        public Vector Velocity
        {
            get { return _velocity; }
            protected set
            {
                _position = value;
            }
        }

        public bool isStatic()
        {
            return double.IsPositiveInfinity(Mass);
        }

        public virtual bool applyForce(IForce force)
        {
            if (isStatic())
                return false;

            if (_effectiveForces is null)
                _effectiveForces = new HashSet<IForce>();

            _effectiveForces.Add(force);

            return true;
        }

        public virtual void update(double dt)
        {
            if (isStatic())
                return;

            Vector resultant = _calculateResulantForce(dt);

            _applyResultant(resultant, dt);

            _removeUnacktiveForces();
        }

        public virtual Collision checkCollisioin(RigidBody otherBody)
        {
            switch (otherBody.BODY_TYPE)
            {
                case RigidBodyType.Sphere:
                    return checkCollisionWith((SphereBody)otherBody);
                    break;
                case RigidBodyType.Plane:
                    return checkCollisionWith((PlaneBody)otherBody);
                    break;
                default:
                    return null;
                    break;
            }
        }

        public abstract Collision checkCollisionWith(SphereBody body);

        public abstract Collision checkCollisionWith(PlaneBody body);



        protected void _applyResultant(Vector resultantForce, double dt)
        {
            // TODO: Переделать для неконстантной силы. Добавить интеграцию силы.
            Vector accel = (Vector)(resultantForce / _mass);

            _position = (Vector)(_position + (_velocity + accel * dt / 2) * dt);
            _velocity = (Vector)(_velocity + accel * dt);
        }

        protected Vector _calculateResulantForce(double dt)
        {
            double[] zero = { 0, 0, 0 };
            Vector result = (Vector)Vector.Build.DenseOfArray(zero);

            foreach (IForce force in _effectiveForces)
            {
                result = (Vector)(result + force.apply(dt, this));
            }

            return result;
        }

        protected void _removeUnacktiveForces()
        {
            foreach (IForce force in _effectiveForces)
            {
                if (!force.isActive())
                    _effectiveForces.Remove(force);
            }
        }
    }
}
