﻿/* Licensed under the MIT/X11 license.
 * Copyright (c) 2006-2008 the osuTK Team.
 * This notice may not be removed from any source distribution.
 * See license.txt for licensing detailed licensing details.
 */

using System;

namespace osuTK
{
    /// <summary>
    /// Represents a handle to an OpenGL or OpenAL context.
    /// </summary>
    public struct ContextHandle : IComparable<ContextHandle>, IEquatable<ContextHandle>
    {
        private IntPtr handle;

        /// <summary>
        /// Gets a System.IntPtr that represents the handle of this ContextHandle.
        /// </summary>
        public IntPtr Handle { get { return handle; } }

        /// <summary>A read-only field that represents a handle that has been initialized to zero.</summary>
        public static readonly ContextHandle Zero = new ContextHandle(IntPtr.Zero);

        /// <summary>
        /// Constructs a new instance with the specified handle.
        /// </summary>
        /// <param name="h">A System.IntPtr containing the value for this instance.</param>
        public ContextHandle(IntPtr h) { handle = h; }

        /// <summary>
        /// Converts this instance to its equivalent string representation.
        /// </summary>
        /// <returns>A System.String that contains the string representation of this instance.</returns>
        public override string ToString()
        {
            return Handle.ToString();
        }

        /// <summary>
        /// Compares this instance to the specified object.
        /// </summary>
        /// <param name="obj">The System.Object to compare to.</param>
        /// <returns>True if obj is a ContextHandle that is equal to this instance; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ContextHandle)
            {
                return this.Equals((ContextHandle)obj);
            }
            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A System.Int32 with the hash code of this instance.</returns>
        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        /// <summary>
        /// Converts the specified ContextHandle to the equivalent IntPtr.
        /// </summary>
        /// <param name="c">The ContextHandle to convert.</param>
        /// <returns>A System.IntPtr equivalent to the specified ContextHandle.</returns>
        public static explicit operator IntPtr(ContextHandle c)
        {
            return c != ContextHandle.Zero ? c.handle : IntPtr.Zero;
        }

        /// <summary>
        /// Converts the specified IntPtr to the equivalent ContextHandle.
        /// </summary>
        /// <param name="p">The System.IntPtr to convert.</param>
        /// <returns>A ContextHandle equivalent to the specified IntPtr.</returns>
        public static explicit operator ContextHandle(IntPtr p)
        {
            return new ContextHandle(p);
        }

        /// <summary>
        /// Compares two ContextHandles for equality.
        /// </summary>
        /// <param name="left">The ContextHandle to compare.</param>
        /// <param name="right">The ContextHandle to compare to.</param>
        /// <returns>True if left is equal to right; false otherwise.</returns>
        public static bool operator ==(ContextHandle left, ContextHandle right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two ContextHandles for inequality.
        /// </summary>
        /// <param name="left">The ContextHandle to compare.</param>
        /// <param name="right">The ContextHandle to compare to.</param>
        /// <returns>True if left is not equal to right; false otherwise.</returns>
        public static bool operator !=(ContextHandle left, ContextHandle right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Compares the numerical value of this instance to the specified ContextHandle and
        /// returns a value indicating their relative order.
        /// </summary>
        /// <param name="other">The ContextHandle to compare to.</param>
        /// <returns>Less than 0, if this instance is less than other; 0 if both are equal; Greater than 0 if other is greater than this instance.</returns>
        public int CompareTo(ContextHandle other)
        {
            unsafe { return (int)((int*)other.handle.ToPointer() - (int*)this.handle.ToPointer()); }
        }

        /// <summary>
        /// Compares this instance to the specified ContextHandle for equality.
        /// </summary>
        /// <param name="other">The ContextHandle to compare to.</param>
        /// <returns>True if this instance is equal to other; false otherwise.</returns>
        public bool Equals(ContextHandle other)
        {
            return Handle == other.Handle;
        }
    }
}
