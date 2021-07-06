using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace MyRevitCommands
{
    [TransactionAttribute(TransactionMode.ReadOnly)]
    public class GetParameter : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get UIDocument and Document
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            try
            {
                //Pick Object
                Reference pickedObj = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);

                if (pickedObj != null) 
                {
                    //Retrieve Element
                    ElementId eleID = pickedObj.ElementId;
                    Element ele = doc.GetElement(eleID);

                    //Get Parameter
                    Parameter param = ele.LookupParameter("Head Height");
                    InternalDefinition paramdef = param.Definition as InternalDefinition;

                    TaskDialog.Show("Parameters", string.Format("{0} with parameter of type {1} with built in parameter {2}.",
                        paramdef.Name,
                        //paramdef.UnitType,
                        paramdef.BuiltInParameter));

                }

                return Result.Succeeded;
            }

            catch (Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }
        }

    }
}
