﻿namespace Typin.Schemas
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Stores command option schema.
    /// </summary>
    public class CommandOptionSchema : ArgumentSchema
    {
        internal static CommandOptionSchema HelpOption { get; } =
            new CommandOptionSchema(null, "help", 'h', null, false, "Shows help text.");

        internal static CommandOptionSchema VersionOption { get; } =
            new CommandOptionSchema(null, "version", null, null, false, "Shows version information.");

        /// <summary>
        /// Option name.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Option short name.
        /// </summary>
        public char? ShortName { get; }

        /// <summary>
        /// Name of variable used as a fallback value.
        /// </summary>
        public string? FallbackVariableName { get; }

        /// <summary>
        /// Whether option is required.
        /// </summary>
        public bool IsRequired { get; }

        /// <summary>
        /// Initializes an instance of <see cref="CommandOptionSchema"/>.
        /// </summary>
        internal CommandOptionSchema(PropertyInfo? property,
                                     string? name,
                                     char? shortName,
                                     string? fallbackVariableName,
                                     bool isRequired,
                                     string? description)
            : base(property, description)
        {
            Name = name;
            ShortName = shortName;
            FallbackVariableName = fallbackVariableName;
            IsRequired = isRequired;
        }

        /// <summary>
        /// Whether command's name matches the passed name.
        /// </summary>
        public bool MatchesName(string name)
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   string.Equals(Name, name, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Whether command's short name matches the passed short name.
        /// </summary>
        public bool MatchesShortName(char shortName)
        {
            return ShortName != null && ShortName == shortName;
        }

        /// <summary>
        /// Whether command's name or short name matches the passed name.
        /// </summary>
        public bool MatchesNameOrShortName(string alias)
        {
            return MatchesName(alias) ||
                   alias.Length == 1 && MatchesShortName(alias.Single());
        }

        internal string GetUserFacingDisplayString()
        {
            var buffer = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(Name))
            {
                buffer.Append("--")
                      .Append(Name);
            }

            if (!string.IsNullOrWhiteSpace(Name) && ShortName != null)
            {
                buffer.Append('|');
            }

            if (ShortName != null)
            {
                buffer.Append('-')
                      .Append(ShortName);
            }

            return buffer.ToString();
        }

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"{Property?.Name ?? "<implicit>"} ('{GetUserFacingDisplayString()}')";
        }
    }
}