using System;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;

namespace SqlToolkit
{
	internal static partial class DbDataReaderHelper
	{
		
		public static MethodCallExpression CreateReader(ParameterExpression reader, Type columnType, int index)
		{
			if(columnType == typeof(string))
			{
				MethodInfo mi = typeof(DbDataReader).GetMethod("GetString", new Type[]{ typeof(Int32)});
				return	Expression.Call(reader, mi, Expression.Constant(index));
			}
			else if(columnType == typeof(Boolean))
			{
				MethodInfo mi = typeof(DbDataReader).GetMethod("GetBoolean", new Type[]{ typeof(Int32)});
				return	Expression.Call(reader, mi, Expression.Constant(index));
			}
			else if(columnType == typeof(Boolean?))
			{
				MethodInfo mi = typeof(DbDataReaderHelper).GetMethod("GetBoolean",
					BindingFlags.NonPublic | BindingFlags.Static, null, new Type[]{ typeof(DbDataReader), typeof(Int32)}, null);
				return	Expression.Call(mi, reader, Expression.Constant(index));
			}
			else if(columnType == typeof(Int16))
			{
				MethodInfo mi = typeof(DbDataReader).GetMethod("GetInt16", new Type[]{ typeof(Int32)});
				return	Expression.Call(reader, mi, Expression.Constant(index));
			}
			else if(columnType == typeof(Int16?))
			{
				MethodInfo mi = typeof(DbDataReaderHelper).GetMethod("GetInt16",
					BindingFlags.NonPublic | BindingFlags.Static, null, new Type[]{ typeof(DbDataReader), typeof(Int32)}, null);
				return	Expression.Call(mi, reader, Expression.Constant(index));
			}
			else if(columnType == typeof(Int32))
			{
				MethodInfo mi = typeof(DbDataReader).GetMethod("GetInt32", new Type[]{ typeof(Int32)});
				return	Expression.Call(reader, mi, Expression.Constant(index));
			}
			else if(columnType == typeof(Int32?))
			{
				MethodInfo mi = typeof(DbDataReaderHelper).GetMethod("GetInt32",
					BindingFlags.NonPublic | BindingFlags.Static, null, new Type[]{ typeof(DbDataReader), typeof(Int32)}, null);
				return	Expression.Call(mi, reader, Expression.Constant(index));
			}
			else if(columnType == typeof(Int64))
			{
				MethodInfo mi = typeof(DbDataReader).GetMethod("GetInt64", new Type[]{ typeof(Int32)});
				return	Expression.Call(reader, mi, Expression.Constant(index));
			}
			else if(columnType == typeof(Int64?))
			{
				MethodInfo mi = typeof(DbDataReaderHelper).GetMethod("GetInt64",
					BindingFlags.NonPublic | BindingFlags.Static, null, new Type[]{ typeof(DbDataReader), typeof(Int32)}, null);
				return	Expression.Call(mi, reader, Expression.Constant(index));
			}
			else if(columnType == typeof(Byte))
			{
				MethodInfo mi = typeof(DbDataReader).GetMethod("GetByte", new Type[]{ typeof(Int32)});
				return	Expression.Call(reader, mi, Expression.Constant(index));
			}
			else if(columnType == typeof(Byte?))
			{
				MethodInfo mi = typeof(DbDataReaderHelper).GetMethod("GetByte",
					BindingFlags.NonPublic | BindingFlags.Static, null, new Type[]{ typeof(DbDataReader), typeof(Int32)}, null);
				return	Expression.Call(mi, reader, Expression.Constant(index));
			}
			else if(columnType == typeof(Char))
			{
				MethodInfo mi = typeof(DbDataReader).GetMethod("GetChar", new Type[]{ typeof(Int32)});
				return	Expression.Call(reader, mi, Expression.Constant(index));
			}
			else if(columnType == typeof(Char?))
			{
				MethodInfo mi = typeof(DbDataReaderHelper).GetMethod("GetChar",
					BindingFlags.NonPublic | BindingFlags.Static, null, new Type[]{ typeof(DbDataReader), typeof(Int32)}, null);
				return	Expression.Call(mi, reader, Expression.Constant(index));
			}
			else if(columnType == typeof(DateTime))
			{
				MethodInfo mi = typeof(DbDataReader).GetMethod("GetDateTime", new Type[]{ typeof(Int32)});
				return	Expression.Call(reader, mi, Expression.Constant(index));
			}
			else if(columnType == typeof(DateTime?))
			{
				MethodInfo mi = typeof(DbDataReaderHelper).GetMethod("GetDateTime",
					BindingFlags.NonPublic | BindingFlags.Static, null, new Type[]{ typeof(DbDataReader), typeof(Int32)}, null);
				return	Expression.Call(mi, reader, Expression.Constant(index));
			}
			else if(columnType == typeof(Decimal))
			{
				MethodInfo mi = typeof(DbDataReader).GetMethod("GetDecimal", new Type[]{ typeof(Int32)});
				return	Expression.Call(reader, mi, Expression.Constant(index));
			}
			else if(columnType == typeof(Decimal?))
			{
				MethodInfo mi = typeof(DbDataReaderHelper).GetMethod("GetDecimal",
					BindingFlags.NonPublic | BindingFlags.Static, null, new Type[]{ typeof(DbDataReader), typeof(Int32)}, null);
				return	Expression.Call(mi, reader, Expression.Constant(index));
			}
			else if(columnType == typeof(Double))
			{
				MethodInfo mi = typeof(DbDataReader).GetMethod("GetDouble", new Type[]{ typeof(Int32)});
				return	Expression.Call(reader, mi, Expression.Constant(index));
			}
			else if(columnType == typeof(Double?))
			{
				MethodInfo mi = typeof(DbDataReaderHelper).GetMethod("GetDouble",
					BindingFlags.NonPublic | BindingFlags.Static, null, new Type[]{ typeof(DbDataReader), typeof(Int32)}, null);
				return	Expression.Call(mi, reader, Expression.Constant(index));
			}
			else if(columnType == typeof(Single))
			{
				MethodInfo mi = typeof(DbDataReader).GetMethod("GetFloat", new Type[]{ typeof(Int32)});
				return	Expression.Call(reader, mi, Expression.Constant(index));
			}
			else if(columnType == typeof(Single?))
			{
				MethodInfo mi = typeof(DbDataReaderHelper).GetMethod("GetFloat",
					BindingFlags.NonPublic | BindingFlags.Static, null, new Type[]{ typeof(DbDataReader), typeof(Int32)}, null);
				return	Expression.Call(mi, reader, Expression.Constant(index));
			}
			else if(columnType == typeof(Guid))
			{
				MethodInfo mi = typeof(DbDataReader).GetMethod("GetGuid", new Type[]{ typeof(Int32)});
				return	Expression.Call(reader, mi, Expression.Constant(index));
			}
			else if(columnType == typeof(Guid?))
			{
				MethodInfo mi = typeof(DbDataReaderHelper).GetMethod("GetGuid",
					BindingFlags.NonPublic | BindingFlags.Static, null, new Type[]{ typeof(DbDataReader), typeof(Int32)}, null);
				return	Expression.Call(mi, reader, Expression.Constant(index));
			}
			else
				throw new InvalidOperationException(string.Format("unknown type `{0}'", columnType.FullName));
		}
		
		private static Boolean? GetBoolean(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetBoolean(index);
		}
		
		private static Int16? GetInt16(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetInt16(index);
		}
		
		private static Int32? GetInt32(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetInt32(index);
		}
		
		private static Int64? GetInt64(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetInt64(index);
		}
		
		private static Byte? GetByte(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetByte(index);
		}
		
		private static Char? GetChar(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetChar(index);
		}
		
		private static DateTime? GetDateTime(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetDateTime(index);
		}
		
		private static Decimal? GetDecimal(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetDecimal(index);
		}
		
		private static Double? GetDouble(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetDouble(index);
		}
		
		private static Single? GetFloat(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetFloat(index);
		}
		
		private static Guid? GetGuid(DbDataReader reader, int index)
		{
			if (reader.IsDBNull(index))
				return null;
			else
				return reader.GetGuid(index);
		}
	}
}
