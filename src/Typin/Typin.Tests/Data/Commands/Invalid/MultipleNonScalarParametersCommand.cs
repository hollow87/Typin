﻿namespace Typin.Tests.Data.Commands.Invalid
{
    using System.Collections.Generic;
    using Typin.Attributes;
    using Typin.Tests.Data.Commands;

    [Command("cmd")]
    public class MultipleNonScalarParametersCommand : SelfSerializeCommandBase
    {
        [CommandParameter(0)]
        public IReadOnlyList<string>? ParamA { get; set; }

        [CommandParameter(1)]
        public IReadOnlyList<string>? ParamB { get; set; }
    }
}