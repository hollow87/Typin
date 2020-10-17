﻿namespace Typin.Attributes
{
    using System;
    using Typin.Internal.Exceptions;

    /// <summary>
    /// Annotates a property that defines a command option.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CommandOptionAttribute : Attribute
    {
        /// <summary>
        /// Option name (must be longer than a single character).
        /// Either <see cref="Name"/> or <see cref="ShortName"/> must be set.
        /// All options in a command must have different names (comparison is not case-sensitive).
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Option short name (single character).
        /// Either <see cref="Name"/> or <see cref="ShortName"/> must be set.
        /// All options in a command must have different short names (comparison is case-sensitive).
        /// </summary>
        public char? ShortName { get; }

        /// <summary>
        /// Whether an option is required.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Option description, which is used in help text.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Fallback variable that will be used as fallback if no option value is specified.
        /// </summary>
        public string? FallbackVariableName { get; set; }

        /// <summary>
        /// Initializes an instance of <see cref="CommandOptionAttribute"/>.
        /// </summary>
        private CommandOptionAttribute(string? name, char? shortName)
        {
            Name = name;
            ShortName = shortName;
        }

        /// <summary>
        /// Initializes an instance of <see cref="CommandOptionAttribute"/>.
        /// </summary>
        public CommandOptionAttribute(string name, char shortName)
            : this(name, (char?)shortName)
        {

        }

        /// <summary>
        /// Initializes an instance of <see cref="CommandOptionAttribute"/>.
        /// </summary>
        public CommandOptionAttribute(string name)
            : this(name, null)
        {

        }

        /// <summary>
        /// Initializes an instance of <see cref="CommandOptionAttribute"/>.
        /// </summary>
        public CommandOptionAttribute(char shortName)
            : this(null, (char?)shortName)
        {

        }
    }
}