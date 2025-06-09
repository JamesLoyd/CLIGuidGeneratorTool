// See https://aka.ms/new-console-template for more information

using System.Reflection;

internal class Program
{
    static void Main(string[] args)
    {
        var test = int.TryParse(string.Join(' ', args), out var _);
        if (!test && !string.IsNullOrWhiteSpace(string.Join(' ', args)) && string.Join(' ', args).ToLower() == "help")
        {
            var versionString = Assembly.GetEntryAssembly()?
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion
                .ToString();

            Console.WriteLine($"Guid Generator v{versionString}");
            Console.WriteLine("-------------");
            Console.WriteLine("\nUsage:");
            Console.WriteLine(
                "  generate-guid <number of guids> - Generates a specified number of GUIDs. default is 1.");
            return;
        }

        GenerateGuids(string.Join(' ', args));
    }

   private static void GenerateGuids(string args)
    {
        // Default to 1 if empty string
        if (string.IsNullOrWhiteSpace(args))
        {
            args = "1";
        }
        
        // Check if the input string is a valid number
        if (int.TryParse(args, out int count))
        {
            // Validate the count is positive
            if (count <= 0)
            {
                Console.WriteLine("Error: Please enter a positive number of GUIDs to generate.");
                return;
            }
    
            // Generate the specified number of GUIDs
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Guid.NewGuid().ToString());
            }
        }
        else
        {
            // If not a valid number, show error message
            Console.WriteLine("Error: You must provide a valid number of GUIDs to generate.");
        }
    }
}