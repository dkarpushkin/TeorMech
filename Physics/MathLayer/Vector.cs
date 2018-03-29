using System;
using MathNet.Numerics.LinearAlgebra;

namespace MathLayer
{
    public class DVector3 : Vector3<double> {}
    
    public class Vector3<TScalar>
        where TScalar : struct, IEquatable<TScalar>, IFormattable
    {
        private Vector<TScalar> _vector;

        protected Vector3()
        {
            _vector = Vector<TScalar>.Build.Dense(3);
        }

        public Vector3(TScalar x, TScalar y, TScalar z)
        {
            TScalar[] vec = { x, y, z };
            _vector = Vector<TScalar>.Build.DenseOfArray(vec);
        }

        private Vector3(Vector<TScalar> vector)
        {
            _vector = Vector<TScalar>.Build.DenseOfVector(vector);
        }

        public static Vector3<TScalar> operator +(Vector3<TScalar> vec1, Vector3<TScalar> vec2)
        {
            return new Vector3<TScalar>(vec1._vector + vec2._vector);
        }

        public static Vector3<TScalar> operator -(Vector3<TScalar> vec1, Vector3<TScalar> vec2)
        {
            return new Vector3<TScalar>(vec1._vector - vec2._vector);
        }

        public TScalar scalarProduct(Vector3<TScalar> vec)
        {
            return _vector.DotProduct(vec._vector);
        }
    }
}
