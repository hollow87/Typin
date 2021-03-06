﻿namespace Typin.Tests.Data.Commands.Invalid
{
    using Typin.Attributes;
    using Typin.Tests.Data.Commands;

    [Command("cmd")]
    public class DuplicateParameterNameCommand : SelfSerializeCommandBase
    {
        [CommandParameter(0, Name = "param")]
        public string? ParamA { get; set; }

        [CommandParameter(1, Name = "param")]
        public string? ParamB { get; set; }
    }
}