using System;
using System.Data.Common;

namespace ExM.SqlToolkit
{
	public static class NullableReader
	{
		
		public static bool? GetBoolean(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetBoolean(index);
		}
		
		public static Int16? GetInt16(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetInt16(index);
		}
		
		public static Int32? GetInt32(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetInt32(index);
		}
		
		public static Int64? GetInt64(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetInt64(index);
		}
		
		public static byte? GetByte(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetByte(index);
		}
		
		public static char? GetChar(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetChar(index);
		}
		
		public static DateTime? GetDateTime(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetDateTime(index);
		}
		
		public static decimal? GetDecimal(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetDecimal(index);
		}
		
		public static double? GetDouble(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetDouble(index);
		}
		
		public static float? GetFloat(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetFloat(index);
		}
		
		public static Guid? GetGuid(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetGuid(index);
		}
	}
}
