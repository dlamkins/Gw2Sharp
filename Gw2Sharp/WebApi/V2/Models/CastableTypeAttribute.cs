using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// An attribute for specifying the types to which the model object can be casted to.
    /// Required when defining typable models.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class CastableTypeAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of the <see cref="CastableTypeAttribute"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> or <paramref name="objectType"/> is <c>null</c>.</exception>
        public CastableTypeAttribute(object value, Type objectType)
        {
            this.Value = value ?? throw new ArgumentNullException(nameof(value));
            if (!value.GetType().IsEnum)
                throw new ArgumentException("An enum value is required", nameof(value));
            this.ObjectType = objectType ?? throw new ArgumentNullException(nameof(objectType));
        }

        /// <summary>
        /// The enum value.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// The object type.
        /// </summary>
        public Type ObjectType { get; }
    }
}
