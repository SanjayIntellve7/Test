using System;
using Microsoft.XLANGs; //comes from Microsoft.XLANGs.BaseTypes.dll
using MIME; //comes from Microsoft.Biztalk.GlobalPropertySchemas.dll

namespace SMTPUtils
{
    public class Part
    {
        public Part()
        {
        }
        public static void SetContentType(Microsoft.XLANGs.BaseTypes.XLANGPart part,
                           string contentTypeValue)
        {
            part.SetPartProperty(typeof(Microsoft.XLANGs.BaseTypes.ContentType), contentTypeValue);
        }
        public static void SetFileName(Microsoft.XLANGs.BaseTypes.XLANGPart part, string fileName)
        {
            part.SetPartProperty(typeof(MIME.FileName), fileName);
        }
        public static System.Xml.XmlDocument SetInfopathForm(
               System.Xml.XmlDocument part, string InfopathFormUrl)
        {
            // Delete existing processing instructions.
            foreach (System.Xml.XmlNode pi in part.SelectNodes(
                            "processing-instruction()"))
            {
                pi.ParentNode.RemoveChild(pi);
            }
            // Add an xml declaration
            System.Xml.XmlDeclaration decl =
               part.CreateXmlDeclaration("1.0", null, null);
            part.InsertBefore(decl, part.DocumentElement);
            // Create the mso-application procesing instruction.
            System.Xml.XmlProcessingInstruction progid = part.CreateProcessingInstruction(
              "mso-application", "progid='InfoPath.Document'");
            part.InsertBefore(progid, part.DocumentElement);
            // Create the mso-infoPathSolution processing instruction
            System.Xml.XmlProcessingInstruction form = part.CreateProcessingInstruction(
              "mso-infoPathSolution", "PIVersion='1.0.0.0' href='" +
              InfopathFormUrl + "'");
            part.InsertBefore(form, part.DocumentElement);

            return part;
        }
    }
}