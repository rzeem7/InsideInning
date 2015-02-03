using System;
using System.Configuration;

namespace InsideInning.DAL
{

  /// <summary>
  /// The InsideInningDB class. The class contains the DAL connectionstring information
  /// </summary>
  public sealed class InsideInningDB
  {

      public static string InsideInning_CONNECTIONSTRING = @"Data Source=192.168.0.133\iiSqlServer;User Id=sa;Password=IAm7MOM;Initial Catalog=InsideInning;";


      //public static string InsideInning_CONNECTIONSTRING
      //{
          //get { return ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString; }
      //}
  }

}
