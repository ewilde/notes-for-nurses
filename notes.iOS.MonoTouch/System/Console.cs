namespace Edward.Wilde.Note.For.Nurses.iOS.System
{
    public class Console
    {
        [global::System.Diagnostics.Conditional("DEBUG")]
        public static void WriteLine(string format, params object[] arg)
        {
            global::System.Console.WriteLine(format, arg);
        }

        [global::System.Diagnostics.Conditional("DEBUG")]
        public static void WriteLine(string message)
        {
            global::System.Console.WriteLine(message);
        }
    }
}
