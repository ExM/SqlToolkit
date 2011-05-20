using System;
using System.Data.Common;
namespace SqlToolkit.Test
{
	public class DataReaderCap: DbDataReader
	{
		private object[] _row;
		
		public DataReaderCap(params object[] row)
		{
			_row = row;
		}
		
		
		public override int Depth
		{
			get
			{
				throw new System.NotImplementedException();
			}
		}
		
		
		public override int FieldCount
		{
			get
			{
				return _row.Length;
			}
		}
		
		
		public override bool HasRows
		{
			get
			{
				throw new System.NotImplementedException();
			}
		}
		
		
		public override bool IsClosed
		{
			get
			{
				throw new System.NotImplementedException();
			}
		}
		
		
		public override object this[int index]
		{
			get
			{
				throw new System.NotImplementedException();
			}
		}
		
		
		public override object this[string name]
		{
			get
			{
				throw new System.NotImplementedException();
			}
		}
		
		
		public override int RecordsAffected
		{
			get
			{
				throw new System.NotImplementedException();
			}
		}
		
		
		public override void Close()
		{
			throw new System.NotImplementedException();
		}
		
		
		public override bool GetBoolean (int i)
		{
			return Convert.ToBoolean(_row[i]);
		}
		
		
		public override byte GetByte (int i)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override long GetBytes (int i, long fieldOffset, byte[] buffer, int bufferOffset, int length)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override char GetChar (int i)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override long GetChars (int i, long dataIndex, char[] buffer, int bufferIndex, int length)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override string GetDataTypeName (int i)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override DateTime GetDateTime (int i)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override decimal GetDecimal (int i)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override double GetDouble (int i)
		{
			return Convert.ToDouble(_row[i]);
		}
		
		
		public override System.Collections.IEnumerator GetEnumerator ()
		{
			throw new System.NotImplementedException();
		}
		
		
		public override Type GetFieldType (int i)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override float GetFloat (int i)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override Guid GetGuid (int i)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override short GetInt16 (int i)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override int GetInt32 (int i)
		{
			return Convert.ToInt32(_row[i]);
		}
		
		
		public override long GetInt64 (int i)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override string GetName (int i)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override int GetOrdinal (string name)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override System.Data.DataTable GetSchemaTable ()
		{
			throw new System.NotImplementedException();
		}
		
		
		public override string GetString (int i)
		{
			return Convert.ToString(_row[i]);
		}
		
		
		public override object GetValue (int i)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override int GetValues (object[] values)
		{
			throw new System.NotImplementedException();
		}
		
		
		public override bool IsDBNull (int i)
		{
			return _row[i] == null;
		}
		
		
		public override bool NextResult ()
		{
			throw new System.NotImplementedException();
		}
		
		
		public override bool Read ()
		{
			throw new System.NotImplementedException();
		}
	}
}

