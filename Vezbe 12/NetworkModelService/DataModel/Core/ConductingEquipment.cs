using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using FTN.Common;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class ConductingEquipment : Equipment
    {
        private PhaseCode phases;
        private float ratedVoltage;
        private long baseVoltage = 0;

        private List<long> terminals = new List<long>();

        public List<long> Terminals
        {
            get { return terminals; }
            set { terminals = value; }
        }

        public ConductingEquipment(long globalId) : base(globalId)
        {
        }

        public PhaseCode Phases
        {
            get
            {
                return phases;
            }

            set
            {
                phases = value;
            }
        }

        public float RatedVoltage
        {
            get { return ratedVoltage; }
            set { ratedVoltage = value; }
        }

        public long BaseVoltage
        {
            get { return baseVoltage; }
            set { baseVoltage = value; }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ConductingEquipment x = (ConductingEquipment)obj;
                return (x.phases == this.phases && x.ratedVoltage == this.ratedVoltage && x.baseVoltage == this.baseVoltage && CompareHelper.CompareLists(x.terminals, this.terminals, true));
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
                case ModelCode.CONDEQ_PHASES:
                case ModelCode.CONDEQ_RATEDVOLTAGE:
                case ModelCode.CONDEQ_BASVOLTAGE:
                case ModelCode.CONDEQ_TERMINALS:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.CONDEQ_PHASES:
                    prop.SetValue((short)phases);
                    break;

                case ModelCode.CONDEQ_RATEDVOLTAGE:
                    prop.SetValue(ratedVoltage);
                    break;

                case ModelCode.CONDEQ_BASVOLTAGE:
                    prop.SetValue(baseVoltage);
                    break;

                case ModelCode.CONDEQ_TERMINALS:
                    prop.SetValue(terminals);
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
                case ModelCode.CONDEQ_PHASES:
                    phases = (PhaseCode)property.AsEnum();
                    break;

                case ModelCode.CONDEQ_RATEDVOLTAGE:
                    ratedVoltage = property.AsFloat();
                    break;

                case ModelCode.CONDEQ_BASVOLTAGE:
                    baseVoltage = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return terminals.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (baseVoltage != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.CONDEQ_BASVOLTAGE] = new List<long>();
                references[ModelCode.CONDEQ_BASVOLTAGE].Add(baseVoltage);
            }

            if (terminals != null && terminals.Count != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.CONDEQ_TERMINALS] = terminals.GetRange(0, terminals.Count);
            }
            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TERMINAL_CONDEQP:
                    terminals.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TERMINAL_CONDEQP:
                    if (terminals.Contains(globalId))
                    {
                        terminals.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }
                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }

        #endregion IReference implementation
    }
}