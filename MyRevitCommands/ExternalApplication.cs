using Autodesk.Revit.UI;
using System;
using System.Reflection;
using Windows.UI.Xaml.Media.Imaging;

namespace MyRevitCommands
{
    class ExternalApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            //Create Ribbon Tab
            application.CreateRibbonTab("My Commands");

            string path = Assembly.GetExecutingAssembly().Location;
            PushButtonData button = new PushButtonData("Button1", "PlaceFamily", path, "MyRevitCommands.PlaceFamily");

            RibbonPanel panel = application.CreateRibbonPanel("My Commands", "Commands");

            //Add button image
            Uri imagePath = new Uri(@"C:\Users\vikit\Downloads\Ex_Files_Revit_Creating_C_Sharp_Plugins\Ex_Files_Revit_Creating_C_Sharp_Plugins\Exercise Files\05_04\Start");
            BitmapImage image = new BitmapImage(imagePath);

            PushButton pushButton = panel.AddItem(button) as PushButton;
            //pushButton.LargeImage = image;

            return Result.Succeeded;
        }
    }
}
