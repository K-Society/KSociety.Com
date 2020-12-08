using System;

namespace KSociety.Com.Driver.Enip.ControlLogixNet
{
    /// <summary>
    /// Raised when an invalid response was detected from the processor
    /// </summary>
    public class InvalidProcessorResponseException : Exception
    {
        /// <summary>
        /// Creates a new InvalidProcessorResponseException
        /// </summary>
        /// <param name="description">Description of the exception</param>
        internal InvalidProcessorResponseException(string description)
            : base(description)
        {

        }
    }

    /// <summary>
    /// Raised when the dimensions have not been set before accessing a
    /// multi-dimensional tag.
    /// </summary>
    public class DimensionsNotSetException : Exception
    {
        /// <summary>
        /// Creates a new DimensionsNotSetException
        /// </summary>
        /// <param name="description">Description of the exception</param>
        internal DimensionsNotSetException(string description)
            : base(description)
        {

        }
    }

    /// <summary>
    /// Raised when trying to add a group to a <see cref="LogixProcessor"/> that
    /// already exists.
    /// </summary>
    public class GroupAlreadyExistsException : Exception
    {
        internal GroupAlreadyExistsException(string description)
            : base(description)
        {

        }
    }

    /// <summary>
    /// Raised when trying to retrieve a group that doesn't exist on the processor
    /// </summary>
    public class GroupNotFoundException : Exception
    {
        internal GroupNotFoundException(string description)
            : base(description)
        {

        }
    }

    /// <summary>
    /// Raised when trying to address a field in a UDT that does not exist.
    /// </summary>
    public class UDTMemberNotFoundException : Exception
    {
        internal UDTMemberNotFoundException(string description)
            : base(description)
        {

        }
    }

    /// <summary>
    /// Raised when the specified type cannot be converted to the correct type.
    /// </summary>
    public class TypeConversionException : Exception
    {
        internal TypeConversionException(string description)
            : base(description)
        {

        }
    }

    /// <summary>
    /// Raised when an array length is not of the required size
    /// </summary>
    public class ArrayLengthException : Exception
    {
        internal ArrayLengthException(string description)
            : base(description) { }
    }
}
