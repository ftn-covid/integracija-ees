using FTN.Common;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Vezbe8
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ResourceDescription baseVoltage1 = new ResourceDescription
            {
                Id = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.BASEVOLTAGE, -1),
                Properties = new List<Property> {
                    new Property(ModelCode.BASEVOLTAGE_NOMINALVOLTAGE, 110f),
                    new Property(ModelCode.IDOBJ_NAME, "voltage 1"),
                    new Property(ModelCode.IDOBJ_MRID, "mrid 1"),
                    new Property(ModelCode.IDOBJ_DESCRIPTION, "voltage 1 description")}
            };

            ResourceDescription baseVoltage2 = new ResourceDescription
            {
                Id = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.BASEVOLTAGE, -2),
                Properties = new List<Property> {
                    new Property(ModelCode.BASEVOLTAGE_NOMINALVOLTAGE, 20f),
                    new Property(ModelCode.IDOBJ_NAME, "voltage 2"),
                    new Property(ModelCode.IDOBJ_MRID, "mrid 2"),
                    new Property(ModelCode.IDOBJ_DESCRIPTION, "voltage 2 description")}
            };

            ResourceDescription location = new ResourceDescription
            {
                Id = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.LOCATION, -1),
                Properties = new List<Property>
                {
                    new Property(ModelCode.IDOBJ_MRID, "location mrid"),
                    new Property(ModelCode.LOCATION_CORPORATECODE, "CorporationCode"),
                    new Property(ModelCode.LOCATION_CATEGORY, "Category"),
                    new Property(ModelCode.IDOBJ_NAME, "Location"),
                    new Property(ModelCode.IDOBJ_DESCRIPTION, "Location description"),
                }
            };

            ResourceDescription winding1 = new ResourceDescription()
            {
                Id = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.POWERTRWINDING, -1),
                Properties = new List<Property>
                {
                    new Property(ModelCode.POWERTRWINDING_CONNTYPE, (short)WindingConnection.Scott),
                    new Property(ModelCode.POWERTRWINDING_GROUNDED, true),
                    new Property(ModelCode.POWERTRWINDING_RATEDS, 66f),
                    new Property(ModelCode.POWERTRWINDING_RATEDU,55f),
                    new Property(ModelCode.POWERTRWINDING_WINDTYPE, 1),
                    new Property(ModelCode.POWERTRWINDING_PHASETOGRNDVOLTAGE, 220f),
                    new Property(ModelCode.POWERTRWINDING_PHASETOPHASEVOLTAGE, 380f),
                    new Property(ModelCode.CONDEQ_BASVOLTAGE, baseVoltage1.Id),
                    new Property(ModelCode.IDOBJ_NAME, "winding 1"),
                    new Property(ModelCode.IDOBJ_DESCRIPTION,"winding 1 description"),
                    new Property(ModelCode.IDOBJ_MRID, "winding 1 mrid"),
                    new Property(ModelCode.PSR_CUSTOMTYPE, "custom type"),
                    new Property(ModelCode.EQUIPMENT_ISPRIVATE, true),
                    new Property(ModelCode.EQUIPMENT_ISUNDERGROUND,false),
                    new Property(ModelCode.CONDEQ_PHASES, (short)PhaseCode.ABCN),
                    new Property(ModelCode.CONDEQ_RATEDVOLTAGE, 440f)
                }
            };
            ResourceDescription winding2 = new ResourceDescription
            {
                Id = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.POWERTRWINDING, -2),
                Properties = new List<Property> {
                    new Property(ModelCode.POWERTRWINDING_CONNTYPE, (short)WindingConnection.Scott),
                    new Property(ModelCode.POWERTRWINDING_GROUNDED, true),
                    new Property(ModelCode.POWERTRWINDING_RATEDS, 66f),
                    new Property(ModelCode.POWERTRWINDING_RATEDU,55f),
                    new Property(ModelCode.POWERTRWINDING_WINDTYPE, 1),
                    new Property(ModelCode.POWERTRWINDING_PHASETOGRNDVOLTAGE, 220f),
                    new Property(ModelCode.POWERTRWINDING_PHASETOPHASEVOLTAGE, 380f),
                    new Property(ModelCode.CONDEQ_BASVOLTAGE, baseVoltage2.Id),
                    new Property(ModelCode.IDOBJ_NAME, "winding 2"),
                    new Property(ModelCode.IDOBJ_DESCRIPTION,"winding 2 description"),
                    new Property(ModelCode.IDOBJ_MRID, "winding 2 mrid"),
                    new Property(ModelCode.PSR_CUSTOMTYPE, "custom type"),
                    new Property(ModelCode.EQUIPMENT_ISPRIVATE, true),
                    new Property(ModelCode.EQUIPMENT_ISUNDERGROUND,false),
                    new Property(ModelCode.CONDEQ_PHASES, (short)PhaseCode.ABCN),
                    new Property(ModelCode.CONDEQ_RATEDVOLTAGE, 440f)
              }
            };

            ResourceDescription tranformer = new ResourceDescription()
            {
                Id = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.POWERTR, -1),
                Properties = new List<Property>
                {
                    new Property(ModelCode.POWERTR_FUNC, 6),
                    new Property(ModelCode.POWERTR_AUTO, true),
                    new Property(ModelCode.PSR_LOCATION, location.Id),
                    new Property(ModelCode.IDOBJ_NAME,"transformer 1"),
                    new Property(ModelCode.IDOBJ_MRID, "transformer 1 mrid"),
                    new Property(ModelCode.IDOBJ_DESCRIPTION, "transformer 1 description"),
                    new Property(ModelCode.PSR_CUSTOMTYPE, "custom type"),
                    new Property(ModelCode.EQUIPMENT_ISUNDERGROUND, false),
                    new Property(ModelCode.EQUIPMENT_ISPRIVATE, true),
                }
            };
            winding1.AddProperty(new Property(ModelCode.POWERTRWINDING_POWERTRW, tranformer.Id));
            winding2.AddProperty(new Property(ModelCode.POWERTRWINDING_POWERTRW, tranformer.Id));
            var delta = new Delta();

            delta.InsertOperations.Add(baseVoltage1);
            delta.InsertOperations.Add(baseVoltage2);
            delta.InsertOperations.Add(location);
            delta.InsertOperations.Add(winding1);
            delta.InsertOperations.Add(winding2);
            delta.InsertOperations.Add(tranformer);

            XmlTextWriter writer = new XmlTextWriter("result.xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
            writer.WriteStartDocument();
            delta.ExportToXml(writer);
            writer.WriteEndDocument();
            writer.Dispose();
        }
    }
}