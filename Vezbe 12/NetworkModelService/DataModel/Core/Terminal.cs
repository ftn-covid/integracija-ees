using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class Terminal : IdentifiedObject
    {
        private bool connected;

        public bool Connected
        {
            get { return connected; }
            set { connected = value; }
        }

        private int seqNum;

        public int SeqNum
        {
            get { return seqNum; }
            set { seqNum = value; }
        }

        private long conEquipment = 0;

        public long ConEquipment
        {
            get { return conEquipment; }
            set { conEquipment = value; }
        }

        public Terminal(long globalId) : base(globalId)
        {
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Terminal x = (Terminal)obj;
                return (x.connected == this.connected && x.conEquipment == this.conEquipment && x.seqNum == this.seqNum);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.TERMINAL_CONDEQP:
                case ModelCode.TERMINAL_CONN:
                case ModelCode.TERMINAL_SEQUENCE_NUMBER:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.TERMINAL_CONDEQP:
                    prop.SetValue(conEquipment);
                    break;

                case ModelCode.TERMINAL_CONN:
                    prop.SetValue(connected);
                    break;

                case ModelCode.TERMINAL_SEQUENCE_NUMBER:
                    prop.SetValue(seqNum);
                    break;

                default:
                    base.GetProperty(prop);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TERMINAL_CONDEQP:
                    conEquipment = property.AsReference();
                    break;

                case ModelCode.TERMINAL_CONN:
                    connected = property.AsBool();
                    break;

                case ModelCode.TERMINAL_SEQUENCE_NUMBER:
                    seqNum = property.AsInt();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (conEquipment != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_CONDEQP] = new List<long>();
                references[ModelCode.TERMINAL_CONDEQP].Add(conEquipment);
            }

            base.GetReferences(references, refType);
        }

        #endregion IReference implementation
    }
}