using DuplicateImageFinder.Core.Interfaces;
using DuplicateImageFinder.Core.Repository;
using DuplicateImageFinder.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DuplicateImageFinder
{
    class Program
    {
        private const string ExitCommand = "exit";

        static void Main(string[] args)
        {
            var services = SetUpDependancies();
            var fileFinder = services.GetRequiredService<IDuplicateFileFinder>();

            Console.WriteLine($"Welcome to the Duplicate image finder. Enter a valid path or type exit");
            string input;
            while ((input = Console.ReadLine()) != null && input.ToLower() != ExitCommand)
            {
                try
                {
                    var duplicates = fileFinder.FindDuplicates(input);
                    if (duplicates.Count == 0)
                        Console.WriteLine($"No duplicates found.");
                    else
                    {
                        foreach (var file in duplicates)
                            Console.WriteLine($"Duplicate found at: {file.FullFileName}");

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"An Error Occurred: {ex.Message}." );
                }
            }
        }

        private static ServiceProvider SetUpDependancies()
        {
            var services = new ServiceCollection()
                .AddSingleton<IFileRepository, ImageRepository>()
                .AddSingleton<IFileHashProvider, FileHashProvider>()
                .AddSingleton<IDuplicateFileFinder, DuplicateFileFinder>()
                .BuildServiceProvider();
            return services;
        }
    }
}
