using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CMDemulator
{
    class Program
    {
        #region ConsoleTools
        public static void EveryTimeMessage(string message = "")
        {
            string EveryTimePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Console.Write($"{EveryTimePath}>" + message);
        }

        public static void ShowResult(string message = "")
        {
            Console.Write(message + "\n");
        }

        public static void WriteFile(string path, string inputtedCommand)
        {
            FileInfo fileInfo = new FileInfo(path);
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(inputtedCommand);
            }
        }
        public static void ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        #endregion

        #region Console commands
        // DONE
        public static void Viewall()
        {
            Console.WriteLine("Dir path:");
            Console.Write(">>>");
            string DirPath = Console.ReadLine();
            DirectoryInfo DirInfoV = new DirectoryInfo(DirPath);

            if (DirInfoV.Exists)
            {
                foreach (var folders in DirInfoV.GetDirectories())
                {
                    Console.WriteLine(" * " + folders.CreationTime + "   " + folders.Name);
                }
                foreach (var files in DirInfoV.GetFiles())
                {
                    Console.WriteLine(" * " + files.CreationTime + "   " + files.Name);
                }
            }
            else
            {
                Console.WriteLine("Dir doesn't exists.");
            }
        }

        // DONE
        public static void Move()
        {
            Console.WriteLine("file");
            Console.WriteLine("or");
            Console.WriteLine("dir");
            Console.Write(">>>");
            string FileOrDir = Console.ReadLine();

            switch (FileOrDir)
            {
                case "file":
                    Console.WriteLine("Source path:");
                    Console.Write(">>>");
                    string SourcePathFile = Console.ReadLine();

                    Console.WriteLine("Target path:");
                    Console.Write(">>>");
                    string TargetPathFile = Console.ReadLine();
                    FileInfo TargetFile = new FileInfo(TargetPathFile);

                    FileInfo FileSource = new FileInfo(SourcePathFile);
                    if (FileSource.Exists)
                    {
                        FileSource.MoveTo(TargetFile.FullName);
                        Console.WriteLine("File transfered successfully.");
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist.");
                    }
                    break;
                case "dir":
                    Console.WriteLine("Source path:");
                    Console.Write(">>>");
                    string SourcePathDir = Console.ReadLine();

                    Console.WriteLine("Target path:");
                    Console.Write(">>>");
                    string TargetPathDir = Console.ReadLine();
                    FileInfo TargetDir = new FileInfo(TargetPathDir);

                    DirectoryInfo DirSource = new DirectoryInfo(SourcePathDir);
                    if (DirSource.Exists)
                    {
                        DirSource.MoveTo(TargetDir.FullName);
                        Console.WriteLine("Directory transfered successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Directory doesn't exist.");
                    }
                    break;
            }
        }

        // TODO (Incompleted for dir)
        public static void Copy()
        {
            Console.WriteLine("file");
            Console.WriteLine("or");
            Console.WriteLine("dir");
            Console.Write(">>>");
            string FileOrDirCopy = Console.ReadLine();

            switch (FileOrDirCopy)
            {
                case "file":
                    Console.WriteLine("Source path:");
                    Console.Write(">>>");
                    string PathFileCopy = Console.ReadLine();

                    if (File.Exists(PathFileCopy))
                    {
                        FileInfo FilePathInfoForCopy = new FileInfo(PathFileCopy);
                        Console.WriteLine("Target path: ");
                        string TargetCopyPath = Console.ReadLine();
                        DirectoryInfo FileTargetInfo = new DirectoryInfo(TargetCopyPath);
                        FilePathInfoForCopy.CopyTo(FileTargetInfo.FullName, true);
                        Console.WriteLine("File copied successfully.");
                    }
                    else
                    {
                        Console.WriteLine("File doesn't not exists.");
                    }
                    break;
                case "dir":
                    Console.WriteLine("Source path:");
                    Console.Write(">>>");
                    string PathDirCopy = Console.ReadLine();

                    if (File.Exists(PathDirCopy))
                    {
                        // TODO (DOESN'T WORK)
                        /*
                        DirectoryInfo DirPathInfoForCopy = new DirectoryInfo(PathDirCopy);
                        Console.WriteLine("Target path: ");
                        string TargetCopyPath = Console.ReadLine();
                        DirectoryInfo DirTargetInfo = new DirectoryInfo(TargetCopyPath);
                        DirPathInfoForCopy.CopyTo(DirTargetInfo.FullName, true);
                        Console.WriteLine("Dir copied successfully.");
                        */
                    }
                    else
                    {
                        Console.WriteLine("Dir doesn't not exists.");
                    }
                    break;
            }
        }

        // DONE
        public static void Createandview()
        {
            Console.WriteLine("file");
            Console.WriteLine("or");
            Console.WriteLine("dir");
            Console.Write(">>>");
            string FileOrDirC = Console.ReadLine();

            switch (FileOrDirC)
            {
                case "file":
                    Console.WriteLine("Source path:");
                    Console.Write(">>>");
                    string PathFileCreate = Console.ReadLine();

                    Console.WriteLine("Do you want to write something in file?");
                    Console.WriteLine("yes");
                    Console.WriteLine("or");
                    Console.WriteLine("no");
                    Console.Write(">>>");
                    string choiceFileOrDirC = Console.ReadLine();

                    switch (choiceFileOrDirC)
                    {
                        case "yes":
                            Console.WriteLine("Enter text:");
                            Console.Write(">>>");
                            string FtextFileOrDirC = Console.ReadLine();

                            if (!File.Exists(PathFileCreate))
                            {
                                using (FileStream fileStream = new FileStream(PathFileCreate, FileMode.Create, FileAccess.Write, FileShare.None))
                                {
                                    using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Unicode))
                                    {
                                        streamWriter.WriteLine(FtextFileOrDirC);
                                    }
                                }
                                Console.WriteLine("File successfully created.");

                                Console.WriteLine("Do you want to view file?");
                                Console.WriteLine("yes");
                                Console.WriteLine("or");
                                Console.WriteLine("no");
                                Console.Write(">>>");
                                string fileViewChoice = Console.ReadLine().ToLower();

                                switch (fileViewChoice)
                                {
                                    case "yes":
                                        using (StreamReader sr = new StreamReader(PathFileCreate))
                                        {
                                            Console.WriteLine(sr.ReadToEnd());
                                        }
                                        break;
                                    case "no":
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("File already exists.");
                            }
                            break;
                        case "no":
                            if (!File.Exists(PathFileCreate))
                            {
                                using (FileStream fileStream = new FileStream(PathFileCreate, FileMode.Create, FileAccess.Write, FileShare.None))
                                {
                                    using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Unicode))
                                    {

                                    }
                                }
                                Console.WriteLine("File successfully created.");
                            }
                            else
                            {
                                Console.WriteLine("File already exists.");
                            }
                            break;
                    }
                    break;
                case "dir":
                    Console.WriteLine("Source path:");
                    Console.Write(">>>");
                    string PathDirCreate = Console.ReadLine();

                    if (!Directory.Exists(PathDirCreate))
                    {
                        Directory.CreateDirectory(PathDirCreate);
                        Console.WriteLine("Dir successfully created.");
                    }
                    else
                    {
                        Console.WriteLine("Dir already exists.");
                    }
                    break;
            }
        }

        // DONE
        public static void Clear()
        {
            Console.Clear();
            EveryTimeMessage();
        }

        // DONE
        public static void Viewfileattr()
        {
            Console.WriteLine("Source path:");
            Console.Write(">>>");
            string filePath = Console.ReadLine();
            FileInfo fileAttribute = new FileInfo(filePath);
            if (fileAttribute.Exists)
            {
                Console.WriteLine();
                Console.WriteLine("\tName\t\t\t" + fileAttribute.Name);
                Console.WriteLine("\tFolder path\t\t" + fileAttribute.FullName);
                Console.WriteLine("\tLocation (directory)\t" + fileAttribute.DirectoryName);
                Console.WriteLine("\tSize\t\t\t" + fileAttribute.Length + " B (bytes)");
                Console.WriteLine("\tDate created\t\t" + fileAttribute.CreationTime);
            }
            else
            {
                Console.WriteLine("File doesn't exist.");
            }
        }        

        // TODO (Incompleted for group of files)
        public static void Renamefile()
        {
            Console.WriteLine("one");
            Console.WriteLine("or");
            Console.WriteLine("group");
            Console.Write(">>>");
            string FileRename = Console.ReadLine();

            switch (FileRename)
            {
                case "one":
                    Console.WriteLine("Source path:");
                    Console.Write(">>>");
                    string PathRenameOne = Console.ReadLine();

                    if (File.Exists(PathRenameOne))
                    {
                        FileInfo file_oldONE = new FileInfo(PathRenameOne);
                        Console.WriteLine("Enter file's path incuding NEW NAME:");
                        Console.Write(">>>");
                        string file_newONEPATH = Console.ReadLine();

                        FileInfo file_newONE = new FileInfo(file_newONEPATH);
                        file_oldONE.CopyTo(file_newONE.FullName, true);
                        file_oldONE.Delete();
                        Console.WriteLine("File was successfully renamed.");
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exists.");
                    }
                    break;
                case "group":
                    Console.WriteLine("Source path:");
                    Console.Write(">>>");
                    string PathRenameGroup = Console.ReadLine();

                    if (File.Exists(PathRenameGroup))
                    {
                        // TODO
                        Console.WriteLine("File was successfully renamed.");
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exists.");
                    }
                    break;
            }
        }

        // DONE
        public static void Createanddelete()
        {
            Console.WriteLine("create");
            Console.WriteLine("or");
            Console.WriteLine("delete");
            Console.Write(">>>");
            string FileOrDirCD = Console.ReadLine();

            switch (FileOrDirCD)
            {
                case "create":
                    Console.WriteLine("In order to create directory, use CREATEANDVIEW command");
                    break;
                case "delete":
                    Console.WriteLine("file");
                    Console.WriteLine("or");
                    Console.WriteLine("dir");
                    Console.Write(">>>");
                    string FileOrDirDelete = Console.ReadLine();

                    switch (FileOrDirDelete)
                    {
                        case "file":
                            Console.WriteLine("Source path:");
                            Console.Write(">>>");
                            string PathFileDelete = Console.ReadLine();

                            if (File.Exists(PathFileDelete))
                            {
                                File.Delete(PathFileDelete);
                                Console.WriteLine("File successfully deleted.");
                            }
                            else
                            {
                                Console.WriteLine("File doesn't exists.");
                            }
                            break;
                        case "dir":
                            Console.WriteLine("Source path:");
                            Console.Write(">>>");
                            string PathDirDelete = Console.ReadLine();

                            if (Directory.Exists(PathDirDelete))
                            {
                                Directory.Delete(PathDirDelete, true);
                                Console.WriteLine("Dir successfully deleted.");
                            }
                            else
                            {
                                Console.WriteLine("Dir doesn't exists.");
                            }
                            break;
                    }
                    break;
            }
        }

        // TODO
        public static void Find()
        {

        }

        // DONE
        public static void Log(string log_file)
        {
            //File.WriteAllText(log_file, String.Empty);
            Console.WriteLine("List of inputted commands:");
            ReadFile(log_file);
        }

        // TODO
        public static void Ping()
        {

        }

        // DONE
        public static void Help()
        {
            Console.WriteLine("For more information on a specific command, type HELP command-name");
            Console.WriteLine();

            Console.WriteLine("VIEWALL\t\t\tOutputs files and folders in inputted directory");
            Console.WriteLine("MOVE\t\t\tMoves files and folders into another directory");
            Console.WriteLine("COPY\t\t\tCopies files and folders");
            Console.WriteLine("CREATEANDVIEW\t\tCreates files and folders and outputs file information after creation");
            Console.WriteLine("CLEAR\t\t\tClears CMD");
            Console.WriteLine("VIEWFILEATTR\t\tOutputs file's attributes");
            Console.WriteLine("RENAMEFILE\t\tRenames one or group of files");
            Console.WriteLine("CREATEANDDELETE\t\tCreates or deletes file");
            Console.WriteLine("FIND\t\t\tOutputs file's attributes");
            Console.WriteLine("LOG\t\t\tLogs user's actions");
            Console.WriteLine("EXIT\t\t\tExits CMD");

            Console.WriteLine();
            Console.WriteLine("For more information on tools see the command-line reference in the online help.");
        }

        // DONE
        public static void Exit()
        {
            Environment.Exit(0);
        }
        #endregion

        static void Main(string[] args)
        {
            Console.Title = "Commmand Prompt";
            Console.WriteLine("Microsoft Windows [Version 10.0.19042.804]");
            Console.WriteLine("(c) 2020 Microsoft Corporation. All rights reserved.");
            Console.WriteLine();

            string logFile = "log.txt";

            string mainCommand;
            EveryTimeMessage();
            do
            {
                mainCommand = Console.ReadLine();
                switch (mainCommand)
                {
                    case "viewall":
                        string logCommand1 = "viewall was used";
                        WriteFile(logFile, logCommand1);
                        Viewall();                       
                        break;
                    case "move":
                        string logCommand2 = "move was used";
                        WriteFile(logFile, logCommand2);
                        Move();                      
                        break;
                    case "copy":
                        string logCommand3 = "copy was used";
                        WriteFile(logFile, logCommand3);
                        Copy();
                        break;
                    case "createandview":
                        string logCommand4 = "createandview was used";
                        WriteFile(logFile, logCommand4);
                        Createandview();
                        break;
                    case "clear":
                        string logCommand5 = "clear was used";
                        WriteFile(logFile, logCommand5);
                        Clear();
                        break;
                    case "viewfileattr":
                        string logCommand6 = "viewfileattr was used";
                        WriteFile(logFile, logCommand6);
                        Viewfileattr();
                        break;
                    case "renamefile":
                        string logCommand7 = "renamefile was used";
                        WriteFile(logFile, logCommand7);
                        Renamefile();
                        break;
                    case "createanddelete":
                        string logCommand8 = "createanddelete was used";
                        WriteFile(logFile, logCommand8);
                        Createanddelete();
                        break;
                    case "find":
                        string logCommand9 = "find was used";
                        WriteFile(logFile, logCommand9);
                        Find();
                        break;
                    case "log":
                        string logCommand10 = "log was used";
                        WriteFile(logFile, logCommand10);
                        Log(logFile);
                        break;
                    case "ping":
                        string logCommand11 = "ping was used";
                        WriteFile(logFile, logCommand11);
                        Ping();
                        break;
                    case "help":
                        string logCommand12 = "help was used";
                        WriteFile(logFile, logCommand12);
                        Help();
                        break;
                    case "exit":
                        string logCommand13 = "exit was used";
                        WriteFile(logFile, logCommand13);
                        Exit();
                        break;
                    case "":
                        EveryTimeMessage();
                        break;                  
                    default:
                        ShowResult("'" + mainCommand + "' " + "is not recognized as an internal or external command, operable program or batch file.");
                        break;
                }
            } while (mainCommand != "exit");

            Console.ReadKey();
        }     
    }
}
