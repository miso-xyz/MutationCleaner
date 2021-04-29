using dnlib.DotNet;
using dnlib.DotNet.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IntptrPoint
{
    class Program
    {
        public static string Asmpath;
        public static ModuleDefMD module;
        public static Assembly asm;
        static void Main(string[] args)
        {
            Console.Title = "Point Remover by OFF_LINE";
            Console.ForegroundColor = ConsoleColor.White;
            string lol = @"  _____      _       _     _____                                    
 |  __ \    (_)     | |   |  __ \                                   
 | |__) |__  _ _ __ | |_  | |__) |___ _ __ ___   _____   _____ _ __ 
 |  ___/ _ \| | '_ \| __| |  _  // _ \ '_ ` _ \ / _ \ \ / / _ \ '__|
 | |  | (_) | | | | | |_  | | \ \  __/ | | | | | (_) \ V /  __/ |   
 |_|   \___/|_|_| |_|\__| |_|  \_\___|_| |_| |_|\___/ \_/ \___|_|   
                                                                    ";
            Console.WriteLine(lol);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Original Application by OFF_LINE");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" Mod by misonothx");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("  |- TimeSpan Cleaner");
            Console.WriteLine("  |- CUI Changes & fixes");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                Program.module = ModuleDefMD.Load(args[0], (ModuleCreationOptions) null);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [!] Not a .NET Assembly");
                Console.ResetColor();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Successfully loaded assembly!");
            try
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Now cleaning...");
                Console.WriteLine();
                IntptrPoint.PointRemover.Clean();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Failed to clean. (" + ex.Message + ")");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Removed " + PointRemover.timeSpanCleaned + " TimeSpans mutations");
            Console.WriteLine(" Removed " + IntptrPoint.PointRemover.amount + " point mutations");
            Console.WriteLine();
            ModuleWriterOptions writerOptions = new ModuleWriterOptions(Program.module);
            writerOptions.MetaDataOptions.Flags |= MetaDataFlags.PreserveAll;
            writerOptions.Logger = DummyLogger.NoThrowInstance;
            NativeModuleWriterOptions NativewriterOptions = new NativeModuleWriterOptions(Program.module);
            NativewriterOptions.MetaDataOptions.Flags |= MetaDataFlags.PreserveAll;
            NativewriterOptions.Logger = DummyLogger.NoThrowInstance;
            bool isILOnly = Program.module.IsILOnly;
            if (isILOnly)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Now saving " + Path.GetFileNameWithoutExtension(args[0]) + "-IL" + Path.GetExtension(args[0]) + " (IL)...");
                try
                {
                    Program.module.Write(Path.GetFileNameWithoutExtension(args[0]) + "-IL" + Path.GetExtension(args[0]), writerOptions);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" (IL) '" + Path.GetFileNameWithoutExtension(args[0]) + "-IL" + Path.GetExtension(args[0]) + "' successfully saved!");
                    Console.ResetColor();
                    Console.WriteLine(" Press any key to exit...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [!] Failed to save '" + Path.GetFileNameWithoutExtension(args[0]) + "-IL" + Path.GetExtension(args[0]) + "' (IL)");
                    Console.ResetColor();
                    Console.WriteLine(" Press any key to exit...");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Now saving '" + Path.GetFileNameWithoutExtension(args[0]) + "-Native" + Path.GetExtension(args[0]) + "' (Native)...");
                try
                {
                    Program.module.NativeWrite(Path.GetFileNameWithoutExtension(args[0]) + "-Native" + Path.GetExtension(args[0]), NativewriterOptions);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" (Native) '" + Path.GetFileNameWithoutExtension(args[0]) + "-Native" + Path.GetExtension(args[0]) + "' successfully saved!");
                    Console.ResetColor();
                    Console.WriteLine(" Press any key to exit...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [!] Failed to save (Native) application");
                    Console.ResetColor();
                    Console.WriteLine(" Press any key to exit...");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
            }
        }
    }
}