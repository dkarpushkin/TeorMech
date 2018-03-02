using System;
using System.Collections.Generic;
using System.Text;

namespace Physics
{
    class World
    {
        private ICollection<RigidBody> _bodies;
        private ICollection<IForce> _globalForces;

        public World()
        {
            _bodies = new HashSet<RigidBody>();
            _globalForces = new HashSet<IForce>();
        }

        public void addBody(RigidBody body)
        {
            _bodies.Add(body);
            _applyGlobalForces(body);
        }

        public void addGlobalForce(IForce force)
        {
            _globalForces.Add(force);

            foreach (RigidBody body in _bodies)
            {
                body.applyForce(force);
            }
        }

        public void update(double dt)
        {
            //_detectCollisions();

            foreach (RigidBody body in _bodies)
            {
                body.update(dt);
            }
        }

        protected void _applyGlobalForces(RigidBody body)
        {
            foreach (IForce force in _globalForces)
            {
                body.applyForce(force);
            }
        }

        protected void _applyGlobalForce(IForce force)
        {
            foreach (RigidBody body in _bodies)
            {
                body.applyForce(force);
            }
        }

        protected void _detectCollisions()
        {
            foreach (RigidBody body in _bodies)
            {
                _detectCollisions(body);
            }
        }

        protected void _detectCollisions(RigidBody body)
        {
            foreach (RigidBody otherBody in _bodies)
            {
                if (otherBody != body)
                {

                }
            }
        }

    }
}
