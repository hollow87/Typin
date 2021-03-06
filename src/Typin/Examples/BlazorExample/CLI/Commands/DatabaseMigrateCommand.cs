﻿namespace BlazorExample.CLI.Commands
{
    using System.Threading.Tasks;
    using Typin;
    using Typin.Attributes;
    using Typin.Console;

    [Command("database migrate", Description = "Migrates the database.")]
    public class DatabaseMigrateCommand : ICommand
    {
        private readonly ICliContext _cliContext;

        public DatabaseMigrateCommand(ICliContext cliContext)
        {
            _cliContext = cliContext;
        }

        public async ValueTask ExecuteAsync(IConsole console)
        {
            console.Output.WriteLine("This will normally apply EF Core migrations.");

            console.Output.WriteLine($"DEBUG INFO:");
            console.Output.WriteLine();
            await console.Output.WriteLineAsync(_cliContext.Metadata.ExecutableName);
            await console.Output.WriteLineAsync(string.Join(", ", _cliContext.RootSchema!.GetCommandNames()));
            console.Output.WriteLine($"scope: {_cliContext.Scope}");
        }
    }
}
