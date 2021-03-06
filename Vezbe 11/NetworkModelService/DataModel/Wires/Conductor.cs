using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class Conductor : ConductingEquipment
    {
        private ConductorMaterialKind conductorMaterial;
        private float length;

        public Conductor(long globalId) : base(globalId)
        {
        }

        public ConductorMaterialKind ConductorMaterial
        {
            get { return conductorMaterial; }
            set { conductorMaterial = value; }
        }

        public float Length
        {
            get { return length; }
            set { length = value; }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Conductor x = (Conductor)obj;
                return (x.conductorMaterial == this.conductorMaterial &&
                    x.length == this.length);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode() => base.GetHashCode();

        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {
                case ModelCode.CONDUCTOR_CONMATERIAL:
                case ModelCode.CONDUCTOR_LEN:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.CONDUCTOR_CONMATERIAL:
                    property.SetValue((short)conductorMaterial);
                    break;

                case ModelCode.CONDUCTOR_LEN:
                    property.SetValue(length);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.CONDUCTOR_CONMATERIAL:
                    conductorMaterial = (ConductorMaterialKind)property.AsEnum();
                    break;

                case ModelCode.CONDUCTOR_LEN:
                    length = property.AsFloat();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }
    }
}