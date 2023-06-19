using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_AuE_Solucoes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public object Response { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=MICHEL;Initial Catalog=Cadastro_AuE_Solucoes;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Usuario values(@codContato,@nome,@sexo,@cidade,@data)", con);
            cmd.Parameters.AddWithValue("@codContato", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@nome", textBox2.Text);
            cmd.Parameters.AddWithValue("@cidade", textBox3.Text);
            cmd.Parameters.AddWithValue("@sexo", checkBox1.Checked);
            cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Cadastro salvo com sucesso!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=MICHEL;Initial Catalog=Cadastro_AuE_Solucoes;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Usuario set nome=@nome,sexo=@sexo,cidade=@cidade,data=@data where codContato=@codContato", con);
            cmd.Parameters.AddWithValue("@codContato", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@nome", textBox2.Text);
            cmd.Parameters.AddWithValue("@cidade", textBox3.Text);
            cmd.Parameters.AddWithValue("@sexo", checkBox1.Checked);
            cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Cadastro atualizado com sucesso!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=MICHEL;Initial Catalog=Cadastro_AuE_Solucoes;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete Usuario where codContato=@codContato", con);
            cmd.Parameters.AddWithValue("@codContato", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Cadastro deletado com sucesso!!");
        }

    }    

}
