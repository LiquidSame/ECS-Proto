﻿using System;
using System.Diagnostics.CodeAnalysis;
using Unity.Mathematics;

namespace Systems.Grid.GridGeneration.Utils
{
    public readonly struct GridPosition : IEquatable<GridPosition>, IComparable<GridPosition>
    {
        private readonly float3 _value;

        private const int Precision = 5;

        private GridPosition(float3 value)
        {
            var precisionOrder = math.pow(10, Precision);
            for (var i = 0; i < 3; ++i)
                value[i] = math.round(value[i] * precisionOrder) / precisionOrder;
            _value = value;
        }

        public bool Equals(GridPosition other) { return _value.Equals(other._value); }

        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public int CompareTo(GridPosition other)
        {
            if (_value.x != other._value.x) return _value.x.CompareTo(other._value.x);
            if (_value.y != other._value.y) return _value.y.CompareTo(other._value.y);
            if (_value.z != other._value.z) return _value.z.CompareTo(other._value.z);

            return 0;
        }

        public override string ToString() { return _value.ToString(); }

        public override int GetHashCode() { return _value.GetHashCode(); }

        public static implicit operator GridPosition(float3 v) { return new GridPosition(v); }

        public static implicit operator float3(GridPosition gp) { return gp._value; }
    }
}