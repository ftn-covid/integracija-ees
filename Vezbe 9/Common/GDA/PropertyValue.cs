using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace FTN.Common
{
	[Serializable]
	[DataContract]	
	[KnownType(typeof(LongPropertyValue))]
	[KnownType(typeof(FloatPropertyValue))]
	[KnownType(typeof(DoublePropertyValue))]
	[KnownType(typeof(StringPropertyValue))]
	[KnownType(typeof(LongPropertyValues))]
	[KnownType(typeof(FloatPropertyValues))]
	[KnownType(typeof(StringPropertyValues))]	
	public abstract class PropertyValue
	{
		[XmlIgnore]
		public virtual long LongValue
		{
			get { throw new Exception("Get of invalid value type: long"); }
			set { throw new Exception("Set of invalid value type: long"); }
		}

		[XmlIgnore]
		public virtual float FloatValue
		{
			get { throw new Exception("Get of invalid value type: float"); }
			set { throw new Exception("Set of invalid value type: float"); }
		}

		[XmlIgnore]
		public virtual double DoubleValue
		{
			get { throw new Exception("Get of invalid value type: double"); }
			set { throw new Exception("Set of invalid value type: double"); }
		}

		[XmlIgnore]
		public virtual string StringValue
		{
			get { throw new Exception("Get of invalid value type: string"); }
			set { throw new Exception("Set of invalid value type: string"); }
		}
	
		[XmlIgnore]
		public virtual List<long> LongValues
		{
			get { throw new Exception("Get of invalid value type: List<long>"); }
			set { throw new Exception("Set of invalid value type: List<long>"); }
		}

		[XmlIgnore]
		public virtual List<float> FloatValues
		{
			get { throw new Exception("Get of invalid value type: List<float>"); }
			set { throw new Exception("Set of invalid value type: List<float>"); }
		}

		[XmlIgnore]
		public virtual List<string> StringValues
		{
			get { throw new Exception("Get of invalid value type: List<string>"); }
			set { throw new Exception("Set of invalid value type: List<string>"); }
		}	

		/// <summary>
		/// Returns the size of the value in bytes.
		/// </summary>
		/// <returns></returns>
		public abstract int SizeOf();

		/// <summary>
		/// Try to parse and set value from stringValues.
		/// </summary>
		/// <param name="stringValues">values to parse</param>
		/// <returns>returns true if parsing successed, false otherwise</returns>
		public abstract bool TrySetValue(string[] stringValues);

		/// <summary>
		/// Compares two PropertyValue objects on specific way - used for joins.
		/// </summary>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <returns>TRUE if condition is fulfilled and FALSE in other case.</returns>
		public static bool operator ==(PropertyValue first, PropertyValue second)
		{
			if (Object.ReferenceEquals(first, null) && Object.ReferenceEquals(second, null))
			{
				return true;
			}
			else if ((Object.ReferenceEquals(first, null) && !Object.ReferenceEquals(second, null)) || (!Object.ReferenceEquals(first, null) && Object.ReferenceEquals(second, null)))
			{
				return false;
			}
			else
			{
				if (first.GetType() == typeof(LongPropertyValue))
				{
					if (second.GetType() == typeof(LongPropertyValue))
					{
						return (first.LongValue == second.LongValue);
					}
					else if (second.GetType() == typeof(LongPropertyValues))
					{
						return second.LongValues.Contains(first.LongValue);
					}
					else
					{
						return false;
					}
				}
				else if (first.GetType() == typeof(LongPropertyValues))
				{
					if (second.GetType() == typeof(LongPropertyValue))
					{
						return first.LongValues.Contains(second.LongValue);
					}
					if (second.GetType() == typeof(LongPropertyValues))
					{
						return CompareHelper.CompareLists(first.LongValues, second.LongValues, true);
					}
					else
					{
						return false;
					}
				}
				else if (first.GetType() == typeof(FloatPropertyValue))
				{
					if (second.GetType() == typeof(FloatPropertyValue))
					{
						return (first.FloatValue == second.FloatValue);
					}
					else
					{
						return false;
					}
				}
				else if (first.GetType() == typeof(StringPropertyValue))
				{
					if (second.GetType() == typeof(StringPropertyValue))
					{
						return (first.StringValue == second.StringValue);
					}
					else
					{
						return false;
					}
				}
				else if (first.GetType() == typeof(FloatPropertyValues))
				{
					if (second.GetType() == typeof(FloatPropertyValues))
					{
						return CompareHelper.CompareLists(first.FloatValues, second.FloatValues);
					}
					else
					{
						return false;
					}
				}
				else if (first.GetType() == typeof(StringPropertyValues))
				{
					if (second.GetType() == typeof(StringPropertyValues))
					{
						return CompareHelper.CompareLists(first.StringValues, second.StringValues);
					}
					else
					{
						return false;
					}
				}				

				return false;
			}
		}

		public static bool operator !=(PropertyValue first, PropertyValue second)
		{
			return !(first == second);
		}

		public override bool Equals(object obj)
		{
			return obj is PropertyValue && this == (PropertyValue)obj;
		}

		public override int GetHashCode()
		{
			int hashCode = 0;

			if (this.GetType() == typeof(LongPropertyValue))
			{
				hashCode = LongValue.GetHashCode();
			}
			else if (this.GetType() == typeof(LongPropertyValues))
			{
				foreach(long longValue in LongValues)
				{
					hashCode += longValue.GetHashCode();
				}
			}
			else if (this.GetType() == typeof(FloatPropertyValue))
			{
				hashCode = FloatValue.GetHashCode();
			}
			else if (this.GetType() == typeof(StringPropertyValue))
			{
				hashCode = StringValue.GetHashCode();
			}
			else if (this.GetType() == typeof(FloatPropertyValues))
			{
				foreach (float floatValue in FloatValues)
				{
					hashCode += floatValue.GetHashCode();
				}
			}
			else if (this.GetType() == typeof(StringPropertyValues))
			{
				foreach (String stringValue in StringValues)
				{
					hashCode += stringValue.GetHashCode();
				}
			}			

			return hashCode;
		}
	}

	[Serializable]
	[DataContract]	
	public class LongPropertyValue : PropertyValue
	{
		private long longValue;

		public LongPropertyValue()
		{
		}

		public LongPropertyValue(long longValue)
		{
			this.longValue = longValue;
		}

		public LongPropertyValue(LongPropertyValue toCopy)
		{
			this.longValue = toCopy.longValue;
		}

		[DataMember]	
		public override long LongValue
		{
			get { return longValue; }
			set { longValue = value; }
		}

		[XmlIgnore]
		public override float FloatValue
		{
			get { throw new Exception("Get of invalid value type: float; expected: long"); }
			set { throw new Exception("Set of invalid value type: float; expected: long"); }
		}

		[XmlIgnore]
		public override string StringValue
		{
			get { throw new Exception("Get of invalid value type: string; expected: long"); }
			set { throw new Exception("Set of invalid value type: string; expected: long"); }
		}

		[XmlIgnore]
		public override List<long> LongValues
		{
			get { throw new Exception("Get of invalid value type: List<long>; expected: long"); }
			set { throw new Exception("Set of invalid value type: List<long>; expected: long"); }
		}

		[XmlIgnore]
		public override List<float> FloatValues
		{
			get { throw new Exception("Get of invalid value type: List<float>; expected: long"); }
			set { throw new Exception("Set of invalid value type: List<float>; expected: long"); }
		}

		[XmlIgnore]
		public override List<string> StringValues
		{
			get { throw new Exception("Get of invalid value type: List<string>; expected: long"); }
			set { throw new Exception("Set of invalid value type: List<string>; expected: long"); }
		}

		public override int SizeOf()
		{
			return sizeof(long);
		}

		public override bool TrySetValue(string[] stringValues)
		{
			if (stringValues == null)
			{
				throw new ArgumentNullException("stringValues");
			}

			if (stringValues.Length != 1)
			{
				throw new ArgumentOutOfRangeException("stringValues");
			}

			if (stringValues[0].ToLower().Trim() == "false")
			{
				this.longValue = 0;
				return true;
			}
			else if (stringValues[0].ToLower().Trim() == "true")
			{
				longValue = 1;
				return true;
			}
			else if(stringValues[0].ToLower().Trim() == "datetime.utcnow")
			{
				longValue = DateTime.UtcNow.Ticks;
				return true;
			}
			else
			{
				return long.TryParse(stringValues[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out longValue);
			}
		}
	}

	[Serializable]
	[DataContract]	
	public class FloatPropertyValue : PropertyValue
	{
		private float floatValue;

		public FloatPropertyValue()
		{
		}

		public FloatPropertyValue(FloatPropertyValue toCopy)
		{
			this.floatValue = toCopy.floatValue;
		}

		[XmlIgnore]
		public override long LongValue
		{
			get { throw new Exception("Get of invalid value type: long; expected: float"); }
			set { throw new Exception("Set of invalid value type: long; expected: float"); }
		}

		[DataMember]		
		public override float FloatValue
		{
			get { return floatValue; }
			set { floatValue = value; }
		}

		[XmlIgnore]
		public override string StringValue
		{
			get { throw new Exception("Get of invalid value type: string; expected: float"); }
			set { throw new Exception("Set of invalid value type: string; expected: float"); }
		}

		[XmlIgnore]
		public override List<long> LongValues
		{
			get { throw new Exception("Get of invalid value type: List<long>; expected: float"); }
			set { throw new Exception("Set of invalid value type: List<long>; expected: float"); }
		}

		[XmlIgnore]
		public override List<float> FloatValues
		{
			get { throw new Exception("Get of invalid value type: List<float>; expected: float"); }
			set { throw new Exception("Set of invalid value type: List<float>; expected: float"); }
		}

		[XmlIgnore]
		public override List<string> StringValues
		{
			get { throw new Exception("Get of invalid value type: List<string>; expected: float"); }
			set { throw new Exception("Set of invalid value type: List<string>; expected: float"); }
		}

		public override int SizeOf()
		{
			return sizeof(float);
		}

		public override bool TrySetValue(string[] stringValues)
		{
			if (stringValues == null)
			{
				throw new ArgumentNullException("stringValues");
			}

			if (stringValues.Length != 1)
			{
				throw new ArgumentOutOfRangeException("stringValues");
			}

			return float.TryParse(stringValues[0], NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out floatValue);
		}
	}

	[Serializable]
	[DataContract]	
	public class DoublePropertyValue : PropertyValue
	{
		private double doubleValue;

		public DoublePropertyValue()
		{
		}

		public DoublePropertyValue(DoublePropertyValue toCopy)
		{
			this.doubleValue = toCopy.doubleValue;
		}

		[XmlIgnore]
		public override long LongValue
		{
			get { throw new Exception("Get of invalid value type: long; expected: double"); }
			set { throw new Exception("Set of invalid value type: long; expected: double"); }
		}
		
		[XmlIgnore]
		public override float FloatValue
		{
			get { throw new Exception("Get of invalid value type: float; expected: double"); }
			set { throw new Exception("Set of invalid value type: float; expected: double"); }
		}

		[DataMember]
		public override double DoubleValue
		{
			get { return doubleValue; }
			set { doubleValue = value; }
		}

		[XmlIgnore]
		public override string StringValue
		{
			get { throw new Exception("Get of invalid value type: string; expected: double"); }
			set { throw new Exception("Set of invalid value type: string; expected: double"); }
		}

		[XmlIgnore]
		public override List<long> LongValues
		{
			get { throw new Exception("Get of invalid value type: List<long>; expected: double"); }
			set { throw new Exception("Set of invalid value type: List<long>; expected: double"); }
		}

		[XmlIgnore]
		public override List<float> FloatValues
		{
			get { throw new Exception("Get of invalid value type: List<float>; expected: double"); }
			set { throw new Exception("Set of invalid value type: List<float>; expected: double"); }
		}

		[XmlIgnore]
		public override List<string> StringValues
		{
			get { throw new Exception("Get of invalid value type: List<string>; expected: double"); }
			set { throw new Exception("Set of invalid value type: List<string>; expected: double"); }
		}

		public override int SizeOf()
		{
			return sizeof(double);
		}

		public override bool TrySetValue(string[] stringValues)
		{
			if (stringValues == null)
			{
				throw new ArgumentNullException("stringValues");
			}

			if (stringValues.Length != 1)
			{
				throw new ArgumentOutOfRangeException("stringValues");
			}

			return double.TryParse(stringValues[0], NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out doubleValue);
		}
	}

	[Serializable]
	[DataContract]	
	public class StringPropertyValue : PropertyValue
	{
		private string stringValue;

		public StringPropertyValue()
		{
			stringValue = string.Empty;
		}

		public StringPropertyValue(StringPropertyValue toCopy)
		{
			this.stringValue = toCopy.stringValue;
		}

		[XmlIgnore]
		public override long LongValue
		{
			get { throw new Exception("Get of invalid value type: long; expected: string"); }
			set { throw new Exception("Set of invalid value type: long; expected: string"); }
		}

		[XmlIgnore]
		public override float FloatValue
		{
			get { throw new Exception("Get of invalid value type: float; expected: string"); }
			set { throw new Exception("Set of invalid value type: float; expected: string"); }
		}

		[DataMember]		
		public override string StringValue
		{
			get { return stringValue; }
			set { stringValue = value; }
		}

		[XmlIgnore]
		public override List<long> LongValues
		{
			get { throw new Exception("Get of invalid value type: List<long>; expected: string"); }
			set { throw new Exception("Set of invalid value type: List<long>; expected: string"); }
		}

		[XmlIgnore]
		public override List<float> FloatValues
		{
			get { throw new Exception("Get of invalid value type: List<float>; expected: string"); }
			set { throw new Exception("Set of invalid value type: List<float>; expected: string"); }
		}

		[XmlIgnore]
		public override List<string> StringValues
		{
			get { throw new Exception("Get of invalid value type: List<string>; expected: string"); }
			set { throw new Exception("Set of invalid value type: List<string>; expected: string"); }
		}

		public override int SizeOf()
		{
			// approx.
			if (stringValue != null)
			{
				return 8 + stringValue.Length * 2;
			}
			else
			{
				return 8;
			}
		}

		public override bool TrySetValue(string[] stringValues)
		{
			if (stringValues == null)
			{
				throw new ArgumentNullException("stringValues");
			}

			if (stringValues.Length != 1)
			{
				throw new ArgumentOutOfRangeException("stringValues");
			}

			this.stringValue = stringValues[0];
			return true;
		}
	}

	[Serializable]
	[DataContract]	
	public class LongPropertyValues : PropertyValue
	{
		private List<long> longValues;

		public LongPropertyValues()
		{
			longValues = new List<long>();
		}

		public LongPropertyValues(LongPropertyValues toCopy)
		{
			this.longValues = toCopy.longValues.GetRange(0, toCopy.longValues.Count);
		}

		[XmlIgnore]
		public override long LongValue
		{
			get { throw new Exception("Get of invalid value type: long; expected: List<long>"); }
			set { throw new Exception("Set of invalid value type: long; expected: List<long>"); }
		}

		[XmlIgnore]
		public override float FloatValue
		{
			get { throw new Exception("Get of invalid value type: float; expected: List<long>"); }
			set { throw new Exception("Set of invalid value type: float; expected: List<long>"); }
		}

		[XmlIgnore]
		public override string StringValue
		{
			get { throw new Exception("Get of invalid value type: string; expected: List<long>"); }
			set { throw new Exception("Set of invalid value type: string; expected: List<long>"); }
		}

		[DataMember]		
		public override List<long> LongValues
		{
			get { return longValues; }
			set { longValues = value; }
		}

		[XmlIgnore]
		public override List<float> FloatValues
		{
			get { throw new Exception("Get of invalid value type: List<float>; expected: List<long>"); }
			set { throw new Exception("Set of invalid value type: List<float>; expected: List<long>"); }
		}

		[XmlIgnore]
		public override List<string> StringValues
		{
			get { throw new Exception("Get of invalid value type: List<string>; expected: List<long>"); }
			set { throw new Exception("Set of invalid value type: List<string>; expected: List<long>"); }
		}

		public override int SizeOf()
		{
			// approx.
			return 16 + sizeof(long) * longValues.Count;
		}

		public override bool TrySetValue(string[] stringValues)
		{
			if (stringValues == null)
			{
				throw new ArgumentNullException("stringValues");
			}

			List<long> tempValues = new List<long>(stringValues.Length);
			foreach (string stringValue in stringValues)
			{
				long tempValue;
				if (long.TryParse(stringValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out tempValue))
				{
					tempValues.Add(tempValue);
				}
				else
				{
					return false;
				}
			}

			this.longValues = tempValues;
			return true;
		}
	}

	[Serializable]
	[DataContract]	
	public class FloatPropertyValues : PropertyValue
	{
		private List<float> floatValues;

		public FloatPropertyValues()
		{
			floatValues = new List<float>();
		}

		public FloatPropertyValues(FloatPropertyValues toCopy)
		{
			this.floatValues = toCopy.floatValues.GetRange(0, toCopy.floatValues.Count);
		}

		[XmlIgnore]
		public override long LongValue
		{
			get { throw new Exception("Get of invalid value type: long; expected: List<float>"); }
			set { throw new Exception("Set of invalid value type: long; expected: List<float>"); }
		}

		[XmlIgnore]
		public override float FloatValue
		{
			get { throw new Exception("Get of invalid value type: float; expected: List<float>"); }
			set { throw new Exception("Set of invalid value type: float; expected: List<float>"); }
		}

		[XmlIgnore]
		public override string StringValue
		{
			get { throw new Exception("Get of invalid value type: string; expected: List<float>"); }
			set { throw new Exception("Set of invalid value type: string; expected: List<float>"); }
		}

		[XmlIgnore]
		public override List<long> LongValues
		{
			get { throw new Exception("Get of invalid value type: List<long>; expected: List<float>"); }
			set { throw new Exception("Set of invalid value type: List<long>; expected: List<float>"); }
		}

		[DataMember]		
		public override List<float> FloatValues
		{
			get { return floatValues; }
			set { floatValues = value; }
		}

		[XmlIgnore]
		public override List<string> StringValues
		{
			get { throw new Exception("Get of invalid value type: List<string>; expected: List<float>"); }
			set { throw new Exception("Set of invalid value type: List<string>; expected: List<float>"); }
		}

		public override int SizeOf()
		{
			// approx.
			return 16 + sizeof(float) * floatValues.Count;
		}

		public override bool TrySetValue(string[] stringValues)
		{
			if (stringValues == null)
			{
				throw new ArgumentNullException("stringValues");
			}

			List<float> tempValues = new List<float>(stringValues.Length);
			foreach (string stringValue in stringValues)
			{
				float tempValue;
				if (float.TryParse(stringValue, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out tempValue))
				{
					tempValues.Add(tempValue);
				}
				else
				{
					return false;
				}
			}

			this.floatValues = tempValues;
			return true;
		}
	}

	[Serializable]
	[DataContract]	
	public class StringPropertyValues : PropertyValue
	{
		private List<string> stringValues;

		public StringPropertyValues()
		{
			stringValues = new List<string>();
		}

		public StringPropertyValues(StringPropertyValues toCopy)
		{
			this.stringValues = toCopy.stringValues.GetRange(0, toCopy.stringValues.Count);
		}

		[XmlIgnore]
		public override long LongValue
		{
			get { throw new Exception("Get of invalid value type: long; expected: List<string>"); }
			set { throw new Exception("Set of invalid value type: long; expected: List<string>"); }
		}

		[XmlIgnore]
		public override float FloatValue
		{
			get { throw new Exception("Get of invalid value type: float; expected: List<string>"); }
			set { throw new Exception("Set of invalid value type: float; expected: List<string>"); }
		}

		[XmlIgnore]
		public override string StringValue
		{
			get { throw new Exception("Get of invalid value type: string; expected: List<string>"); }
			set { throw new Exception("Set of invalid value type: string; expected: List<string>"); }
		}

		[XmlIgnore]
		public override List<long> LongValues
		{
			get { throw new Exception("Get of invalid value type: List<long>; expected: List<string>"); }
			set { throw new Exception("Set of invalid value type: List<long>; expected: List<string>"); }
		}

		[XmlIgnore]
		public override List<float> FloatValues
		{
			get { throw new Exception("Get of invalid value type: List<float>; expected: List<string>"); }
			set { throw new Exception("Set of invalid value type: List<float>; expected: List<string>"); }
		}

		[DataMember]		
		public override List<string> StringValues
		{
			get { return stringValues; }
			set { stringValues = value; }
		}

		public override int SizeOf()
		{
			// approx.
			int size = 16;
			for(int i = 0; i < stringValues.Count; i++)
			{
				size += 8;
				if (stringValues[i] != null)
				{
					size += stringValues[i].Length * 2;
				}
			}
			return size;
		}

		public override bool TrySetValue(string[] stringValues)
		{
			if (stringValues == null)
			{
				throw new ArgumentNullException("stringValues");
			}

			this.stringValues.Clear();
			this.stringValues.AddRange(stringValues);
			return true;
		}
	}	
}
