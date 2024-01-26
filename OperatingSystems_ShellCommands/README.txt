----------------------
    Functionality
----------------------

This program's functionality is pretty straightforward. You are shown a menu and prompted to pick an option from the list.
Based on the option you pick, you may be asked to provide additional information, and then a command string is generated.
From there, the system call is performed based on the string generated.

In C#, to make a system call, you must call the cmd.exe process in the background. To see how that was implemented, see
the RunShellCommand() function in Program.cs. This function returns an output string from the system call. For instance, if
the command was "dir", then the output string would be the file list in its entirety separated by newline characters. This
is then displayed back to the user, and the process is repeated until the user selects quit.

----------------------
      Discussion
----------------------

The main part of this section is to discuss the importance of validating user input and handling potential security
risks associated with using system calls. There are times when giving the user direct access to certain system commands
can be dangerous, especially if the user does not know that they are capable of harming their system. For instance, if
the user were to run a delete command and misspell their file path, they may end up permanently deleting the wrong file.
Displaying confirmation messages before these operations are critical to ensure loss of data does not occur. For certain
system-critical or otherwise protected files, the win32 delete will require additional confirmation before the deletion
actually occurs.

For the most part in this program, all options in the selection menu are harmless. There is no ability to delete files,
and no other available commands in the program are able to modify or delete data. However, there is definitely something
to be said about the ABILITY of software programs to run shell commands. Even without running as administrator, there
would benothing stopping a bad actor from writing code to begin deleting as many files in the user's C: drive as possible.
Even deletion confirmation messages can be overridden with an extra flag when calling the command. For this reason it is
important for the user to know that the software they are running is safe.