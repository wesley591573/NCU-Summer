using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web;
using System.Windows.Navigation;



namespace WpfApp1
{
    /// <summary>
    /// Queue.xaml 的互動邏輯
    /// </summary>
    /// 
    class Data
    {
        public string Inorder = "";
        public string Preorder = "";
        public string Postorder = "";
        public string Binary = "";
        public string Decimal = "";
        public string button = "";

    }

    public partial class Queue : Window
    {
        public Queue()
        {
            InitializeComponent();

            ShowQueue();
        }

        void Button_Click_Delete(object sender, RoutedEventArgs e)
        {

            TextBlock x = dataGrid.Columns[1].GetCellContent(dataGrid.Items[dataGrid.SelectedIndex]) as TextBlock;

            /*
            if (x != null)
                MessageBox.Show(x.Text);
            else
                MessageBox.Show("It is null!");

            */
            
            var selectedRow = dataGrid.SelectedIndex;

            Data d = new Data();

            string connString = "data source=localhost;port=3306;database=Mydatabase;user id=root;password=;charset=utf8";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;

            string query = "";


            conn.Open();

            query = "Delete from `result` where `Inorder` ='" + x.Text + "';";

            MySqlCommand cmd = new MySqlCommand(query, conn);  

            cmd.ExecuteNonQuery();

            conn.Close();


            

            MessageBox.Show("成功刪除");

            ShowQueue();

        }



        void ShowQueue()
        {
            string connString = "data source=localhost;port=3306;database=Mydatabase;user id=root;password=;charset=utf8";
            MySqlConnection conn = new MySqlConnection();
            string Query = ""; // MySQL command

            conn.ConnectionString = connString;

            Query = "select `Index`, `Inorder`, `Preorder`, `Postorder`, `Binary`, `Decimal` from `result`;";

            conn.Open();

            MySqlCommand cmd = new MySqlCommand(Query, conn);

            MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd);

            DataSet dataset = new DataSet();

            MyAdapter.Fill(dataset, "LoadDataBinding");
            dataGrid.DataContext = dataset;


            conn.Close();

        }

    }
}
