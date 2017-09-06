﻿// ****************************************************************************
// * Project:  Tests
// * File:     Program.cs
// * Author:   Latency McLaughlin
// * Date:     07/15/2014
// ****************************************************************************

using System;
using System.Threading;
using System.Windows.Forms;

namespace BitFields_GUI {
  internal static class Program {
    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main() {
      Application.ThreadException += ExceptionSink;
      Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, true);
      AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionEventSink;

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }

    public static void ExceptionSink(object sender, ThreadExceptionEventArgs args) {
      MessageBox.Show(args.Exception.ToString(), @"Exception Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }


    public static void UnhandledExceptionEventSink(object sender, UnhandledExceptionEventArgs args) {
      MessageBox.Show(args.ExceptionObject.ToString(), @"Exception Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}