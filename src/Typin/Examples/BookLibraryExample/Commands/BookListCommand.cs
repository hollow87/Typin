﻿namespace BookLibraryExample.Commands
{
    using System;
    using System.Threading.Tasks;
    using BookLibraryExample.Internal;
    using BookLibraryExample.Services;
    using Typin;
    using Typin.Attributes;
    using Typin.Console;

    [Command("book list", Description = "List all books in the library.")]
    public class BookListCommand : ICommand
    {
        private readonly LibraryService _libraryService;

        public BookListCommand(LibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public ValueTask ExecuteAsync(IConsole console)
        {
            var library = _libraryService.GetLibrary();

            var isFirst = true;
            foreach (var book in library.Books)
            {
                // Margin
                if (!isFirst)
                    console.Output.WriteLine();
                isFirst = false;

                // Render book
                console.RenderBook(book);
            }

            if (isFirst)
                console.WithForegroundColor(ConsoleColor.Red, () => console.Output.WriteLine("No books"));

            return default;
        }
    }
}