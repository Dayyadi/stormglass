using System;
using System.Windows.Forms;


namespace WeatherTideStormglass
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WebRequestData web = new WebRequestData();

            DeserializeTide tide = web._tide;
            DeserializeWeather weather = web._weather;

            Console.WriteLine(tide.data[0].height);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}