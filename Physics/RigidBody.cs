using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Physics
{
    public enum RigidBodyType
    {
        None,
        Sphere,
        Plane,
    }

    public abstract class RigidBody
    {
        public readonly RigidBodyType BODY_TYPE = RigidBodyType.None;

        protected double _inverceMass;
        protected Vector _position;
        protected Vector _velocity;

        protected ICollection<IForce> _effectiveForces = new HashSet<IForce>();


        protected RigidBody()
        {
            _position = (Vector) (Vector.Build.Dense(3));
            _velocity = (Vector) (Vector.Build.Dense(3));
        }

        protected RigidBody(double mass, Vector position, Vector velocity = null)
        {
            Mass = mass;

            Position = position;

            if (velocity == null)
            {
                double[] vel = {0, 0, 0};
            }

            Velocity = velocity;
            _effectiveForces = new HashSet<IForce>();
        }

        protected RigidBody(
            double mass,
            double x, double y, double z,
            double vx = 0, double vy = 0, double vz = 0)
        {
            Mass = mass;

            double[] pos = {x, y, z};
            double[] vel = {vx, vy, vz};

            Position = (Vector) (Vector.Build.DenseOfArray(pos));
            Velocity = (Vector) (Vector.Build.DenseOfArray(vel));

            _effectiveForces = new HashSet<IForce>();
        }

        public double InverceMass
        {
            get => _inverceMass;
            set => _inverceMass = value;
        }

        public double Mass
        {
            get => 1 / _inverceMass;
            set => _inverceMass = (value != 0) ? 1 / value : double.PositiveInfinity;
        }

        public virtual Vector Position
        {
            get => _position;
            set { _position = (Vector) (Vector.Build.DenseOfVector(value)); }
        }

        public double X
        {
            get => _position[0];
            set => _position[0] = value;
        }

        public double Y
        {
            get => _position[1];
            set => _position[1] = value;
        }

        public double Z
        {
            get => _position[2];
            set => _position[2] = value;
        }

        public Vector Velocity
        {
            get => _velocity;
            set { _velocity = (Vector) (Vector.Build.DenseOfVector(value)); }
        }

        public double Vx
        {
            get => _velocity[0];
            set => _velocity[0] = value;
        }

        public double Vy
        {
            get => _velocity[1];
            set => _velocity[1] = value;
        }

        public double Vz
        {
            get => _velocity[2];
            set => _velocity[2] = value;
        }

        public bool isStatic()
        {
            return InverceMass == 0;
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

        protected void _applyResultant(Vector resultantForce, double dt)
        {
            Vector accel = (Vector) (resultantForce * _inverceMass);

            Vector halfVel = (Vector) (accel * dt * 0.5);
            _velocity = (Vector) (_velocity + halfVel);
            _position = (Vector) (_position + _velocity * dt);
            _velocity = (Vector) (_velocity + halfVel);

            //_position = (Vector)(_position + (_velocity + accel * dt * 0.5) * dt);
            //_velocity = (Vector)(_velocity + accel * dt * 0.5);
        }

        protected Vector _calculateResulantForce(double dt)
        {
            double[] zero = {0, 0, 0};
            Vector result = (Vector) Vector.Build.DenseOfArray(zero);

            foreach (IForce force in _effectiveForces)
            {
                result = (Vector) (result + force.apply(dt, this));
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