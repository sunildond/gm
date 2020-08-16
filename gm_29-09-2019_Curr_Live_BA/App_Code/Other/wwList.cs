using System;
using System.Collections.Generic;
using System.Data;

namespace ww_lib
{
   public class wwList<T> : List<T>
   {
      private static bool m_enforceKeysInDataTableConversion;

      public wwList()
      {
         m_enforceKeysInDataTableConversion = false;
      }

      public bool EnforceKeysInDataTableConversion
      {
         get { return m_enforceKeysInDataTableConversion; }
         set { m_enforceKeysInDataTableConversion = value; }
      }

      public static explicit operator DataTable(wwList<T> list)
      {
         IDataTableConverter<T> converter = new DataTableConverter<T>(m_enforceKeysInDataTableConversion);
         return converter.GetDataTable(list);
      }

      //public DataTable Select(wwList<ArtisteMoviesBroadbandClass> NewMovieList, string p)
      //{
      //    throw new NotImplementedException();
      //}
   }
}
