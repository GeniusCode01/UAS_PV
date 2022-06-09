/*
 * Created by SharpDevelop.
 * User: Windows 10
 * Date: 09/06/2022
 * Time: 12:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SalesMobil
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private SqlCommand cmd;
		private DataSet ds;
		private SqlDataAdapter da;
		
		Koneksi Konn = new Koneksi();
		
		String Brand, Color;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BersihkanData()
		{
			textBox1.Text="";
			textBox2.Text="";
			textBox3.Text="";
			textBox4.Text="0";
			DisplayData();
		}
		
		void Tipenya()
		{
			comboBox1.Items.Add("Sedan");
			comboBox1.Items.Add("Sport");
			comboBox1.Items.Add("Mini Bus");
			comboBox1.Items.Add("SUV");
		}
 
		
		private void MainFormLoad(object sender, EventArgs e)
		{
			DisplayData();
			Tipenya();
			
		}
 
		void DisplayData()
		{
			SqlConnection conn = Konn.GetConn();
			try{
				conn.Open();
				cmd = new SqlCommand("Select * from TBL_PEMESANAN", conn);
				ds = new DataSet();
				da = new SqlDataAdapter(cmd);
				da.Fill(ds, "TBL_PEMESANAN");
				dataGridView1.DataSource = ds;
				dataGridView1.DataMember = "TBL_PEMESANAN";
				dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			}
 
			catch(Exception G){
				MessageBox.Show(G.ToString());
			}
 
			finally{
				conn.Close();
			}	
		}
		
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try{
				DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
				textBox1.Text = row.Cells["NoPemesanan"].Value.ToString();
				textBox2.Text = row.Cells["NamaPembeli"].Value.ToString();
				textBox3.Text = row.Cells["Alamat"].Value.ToString();
				textBox4.Text = row.Cells["Harga"].Value.ToString();
				comboBox1.Text = row.Cells["TipeMobil"].Value.ToString();
			}
 
			catch(Exception e1){
				MessageBox.Show(e1.ToString());
			}
		}
		
		//update Data
		void Button1Click(object sender, EventArgs e)
		{
			if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
			{
				MessageBox.Show("Mohon isikan terlebih dahulu  kolom kolom yang tersedia");
			}
			
			else{
				/*****************************************************
 				 *                   simpan data 
				 *****************************************************/
				SqlConnection conn = Konn.GetConn();
 
				try
				{
					cmd = new SqlCommand("UPDATE TBL_PEMESANAN SET NamaPembeli='"+textBox2.Text+"',Alamat='"+textBox3.Text+"',Harga='"+textBox4.Text+"',Merek='"+textBox5.Text+"',Warna1='"+textBox6.Text+"',Warna2='"+textBox7.Text+"',Warna3='"+textBox8.Text+"',Warna4='"+textBox9.Text+"',TipeMobil='"+comboBox1.Text+"'WHERE NoPemesanan='"+textBox1.Text+"'", conn);
					conn.Open();
					cmd.ExecuteNonQuery();
					MessageBox.Show("Update data berhasil!");
					DisplayData();
					BersihkanData();
				}

				catch(Exception) {
					MessageBox.Show("Tidak dapat menyimpan data");
				}
			}
		}
		
		//InsertData
		void Button2Click(object sender, EventArgs e)
		{
			if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
			{
				MessageBox.Show("Mohon isikan terlebih dahulu  kolom kolom yang tersedia");
			}
 
			else{
				/*****************************************************
 				 *                   simpan data 
				 *****************************************************/
				SqlConnection conn = Konn.GetConn();
 
				try
				{
					cmd = new SqlCommand("INSERT INTO TBL_PEMESANAN VALUES ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+textBox7.Text+"','"+textBox8.Text+"','"+textBox9.Text+"','"+comboBox1.Text+"')", conn);
					conn.Open();
					cmd.ExecuteNonQuery();
					MessageBox.Show("Insert data berhasil!");
					DisplayData();
					BersihkanData();
				}
 
				catch(Exception ) {
					MessageBox.Show("Tidak dapat menyimpan data");
				}
			}
		}
	//'"+textBox6.Text+"','"+textBox7.Text+"','"+textBox8.Text+"','"+textBox9.Text+"',	
		//Delete Data
		void Button3Click(object sender, EventArgs e)
		{
			if(MessageBox.Show(textBox2.Text+", Yakin ingin dihapus?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
			
				SqlConnection conn = Konn.GetConn();
					cmd = new SqlCommand("DELETE TBL_PEMESANAN WHERE NoPemesanan='"+textBox1.Text+"'", conn);
					conn.Open();
					cmd.ExecuteNonQuery();
					MessageBox.Show("Hapus data berhasil!");
					DisplayData();
					BersihkanData();
			}
		}
		
		//radio button
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			Brand = "Toyota";
			textBox5.Text = Brand;
		}
		void RadioButton2CheckedChanged(object sender, EventArgs e)
		{
			Brand = "Honda";
			textBox5.Text = Brand;
		}
		void RadioButton3CheckedChanged(object sender, EventArgs e)
		{
			Brand = "BMW";
			textBox5.Text = Brand;
		}
		void RadioButton4CheckedChanged(object sender, EventArgs e)
		{
			Brand = "Ford";
			textBox5.Text = Brand;
		}
		
		//checkbox
		void CheckBox6CheckedChanged(object sender, EventArgs e)
		{
			Color = "Merah";
			textBox6.Text = Color;
		}
		void CheckBox8CheckedChanged(object sender, EventArgs e)
		{
			Color = "Biru";
			textBox7.Text = Color;
		}
		void CheckBox7CheckedChanged(object sender, EventArgs e)
		{
			Color = "Putih";
			textBox8.Text = Color;
		}
		void CheckBox5CheckedChanged(object sender, EventArgs e)
		{
			Color = "Hitam";
			textBox9.Text = Color;
		}
		
		
		
	}
}
