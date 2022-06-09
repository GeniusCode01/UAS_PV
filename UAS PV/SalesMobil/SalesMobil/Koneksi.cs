/*
 * Created by SharpDevelop.
 * User: Windows 10
 * Date: 09/06/2022
 * Time: 14:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//1
using System.Data.SqlClient;


namespace SalesMobil
{
	class Koneksi
	{
		//2
		public SqlConnection GetConn()
		{
			SqlConnection Conn = new SqlConnection();
			Conn.ConnectionString = @"Data Source=DESKTOP-KRLI98N; initial catalog = SalesMobil; integrated security = True";
			return Conn;
		}
	}
}
