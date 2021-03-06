using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class ACLineSegment : Conductor
    {
        private bool cable;
        private float r;

        public ACLineSegment(long globalId) : base(globalId)
        {
        }

        public bool Cable
        {
            get { return cable; }
            set { cable = value; }
        }

        public float R
        {
            get { return r; }
            set { r = value; }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ACLineSegment x = (ACLineSegment)obj;
                return (x.cable == this.cable && x.r == this.r);
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
                case ModelCode.ACLINESEG_FEEDERCABLE:
                case ModelCode.ACLINESEG_R:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.ACLINESEG_FEEDERCABLE:
                    property.SetValue(cable);
                    break;

                case ModelCode.ACLINESEG_R:
                    property.SetValue(r);
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
                case ModelCode.ACLINESEG_FEEDERCABLE:
                    cable = property.AsBool();
                    break;

                case ModelCode.ACLINESEG_R:
                    r = property.AsFloat();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }
    }
}