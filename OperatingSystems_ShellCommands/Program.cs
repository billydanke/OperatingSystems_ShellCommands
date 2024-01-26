// Operating Systems Homework 1
// Aaron Barrett

// Note: See README.txt for more detailed information and discussion

using System;
using System.Diagnostics;

namespace OperatingSystems_ShellCommands
{
    internal class Program
    {
        static void DisplayMenu() {
            //Console.Clear();

            Console.WriteLine("Operating Systems Homework 1 - Running Shell Commands - Aaron Barrett\n");
            Console.WriteLine("┌──────────────────────────────────┐");
            Console.WriteLine("│         Command Options          │");
            Console.WriteLine("├──────────────────────────────────┤");
            Console.WriteLine("│ 1. List Directory Contents       │");
            Console.WriteLine("│ 2. Print Working Directory       │");
            Console.WriteLine("│ 3. Create New Directory          │");
            Console.WriteLine("│ 4. Display a Message             │");
            Console.WriteLine("│ 5. Display file contents         │");
            Console.WriteLine("│ 6. Display File Tree             │");
            Console.WriteLine("│ 7. Open New Program              │");
            Console.WriteLine("│ 8. Exit This Program             │");
            Console.WriteLine("└──────────────────────────────────┘");
            Console.WriteLine("");
        }

        static void PromptContinue()
        {
            Console.WriteLine("\n");
            Console.WriteLine("==================================================================");
            Console.WriteLine("                    Press any key to continue");
            Console.WriteLine("==================================================================");

            Console.ReadKey(true); // waits for a keypress before continuing
        }

        static string RunShellCommand(string command)
        {
            Process cmdProcess = new Process(); // Create a process

            cmdProcess.StartInfo.FileName = "cmd.exe"; // Specify that cmd is the process
            cmdProcess.StartInfo.Arguments = $"/c {command}"; // Set its argument as the desired command
            cmdProcess.StartInfo.RedirectStandardOutput = true; // Redirect the cmd output to the process output stream for viewing
            cmdProcess.StartInfo.UseShellExecute = false; // Disable using the OS shell to start the process
            cmdProcess.StartInfo.CreateNoWindow = true; // Disable the window from being shown during the operation

            cmdProcess.Start(); // Run the process

            string processResult = cmdProcess.StandardOutput.ReadToEnd(); // Get the returned text from the output stream
            cmdProcess.WaitForExit(); // Halts execution until the process is finished (should be quick)
            return processResult; // Returns the output text from the command operation
        }

        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();

                Console.Write("Enter Command Number: ");
                string commandOption = Console.ReadLine();

                string command = ""; // Make a blank command string

                if(commandOption == "1") // List a target directory using dir
                {
                    // Prompt the user for a target directory
                    Console.Write("Enter target directory: ");
                    string targetDirectory = Console.ReadLine();

                    command = $"dir {targetDirectory}";
                }
                else if(commandOption == "2") // Print the current directory using dir
                {
                    command = "dir";
                }
                else if( commandOption == "3") // Make a new directory at target using mkdir
                {
                    Console.WriteLine("(Be aware that this command has no output. Check the directory to ensure completion!)");

                    // Prompt the user for a target directory
                    Console.Write("Enter desired base directory for placement (w/o final slash): ");
                    string sourceDirectory = Console.ReadLine();

                    // Prompt the user for new directory name
                    Console.Write("Enter new directory name: ");
                    string newDirectory = Console.ReadLine();

                    command = $@"mkdir {sourceDirectory}\{newDirectory}";
                }
                else if(commandOption == "4") // Display a message using echo
                {
                    // Prompt the user for a message
                    Console.Write("Enter message: ");
                    string message = Console.ReadLine();

                    command = $"echo {message}";
                }
                else if(commandOption == "5") // Display file contents using type
                {
                    // Prompt the user for a target directory
                    Console.Write("Enter filepath: ");
                    string filePath = Console.ReadLine();

                    command = $"type {filePath}";
                }
                else if(commandOption == "6") // List filetree using tree
                {
                    Console.WriteLine("(Be careful with this, as choosing something like C:\\ as root can take a while to complete)");
                    // Prompt the user for start path
                    Console.Write("Enter root path: ");
                    string rootPath = Console.ReadLine();

                    command = $"tree {rootPath}";
                    Console.WriteLine($"Loading tree from {rootPath}...");
                }
                else if(commandOption == "7") // Open a new program at specified path using start
                {
                    // Get specified path
                    Console.Write("Enter program path (if program is on PATH, just enter its name): ");
                    string programPath = Console.ReadLine();

                    if (programPath != "")
                    {
                        command = $"start {programPath}";
                    }
                    else
                    {
                        command = "start";
                    }
                }
                else if(commandOption == "8") // Exit program
                {
                    Console.WriteLine("\nGoodbye!");
                    Environment.Exit(0);
                }

                string shellOutput = RunShellCommand(command);

                if(shellOutput != "")
                {
                    Console.WriteLine("The command generated the following output:\n");
                    Console.WriteLine(shellOutput);
                }
                Console.WriteLine("Command completed.");
                PromptContinue();
            }
        }
    }
}
