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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    class Calculator
    {
        private string input = ""; // The original formula, include nums and symbol
        private string subInput = ""; // Only nums in the formula in order to get nums

        
        public string Input { get { return input; } set { input = value; } }

        
        public string SubInput { get { return subInput; } set { subInput = value; } }


    }

    public partial class MainWindow : Window
    {

        Calculator myCal = new Calculator();
        // Save original each number
        List<int> nums = new List<int>();
        // Save original each symbol
        List<char> symbol = new List<char>();

        bool error_divideByZero = false;

        public MainWindow()
        {
            InitializeComponent();

            inputScreen.Text = myCal.Input.ToString() ;

        }


        


        void Button_Click1(object sender, RoutedEventArgs e)
        {

            myCal.Input = myCal.Input.ToString() + "1";

            myCal.SubInput = myCal.SubInput.ToString() + "1";

            
            
            inputScreen.Text = myCal.Input.ToString();

        }

        void Button_Click2(object sender, RoutedEventArgs e)
        {
            myCal.Input = myCal.Input.ToString() + "2";

            myCal.SubInput = myCal.SubInput.ToString() + "2";

            inputScreen.Text = myCal.Input.ToString();

        }

        void Button_Click3(object sender, RoutedEventArgs e)
        {
            myCal.Input = myCal.Input.ToString() + "3";

            myCal.SubInput = myCal.SubInput.ToString() + "3";

            inputScreen.Text = myCal.Input.ToString();

        }

        void Button_Click4(object sender, RoutedEventArgs e)
        {
            myCal.Input = myCal.Input.ToString() + "4";

            myCal.SubInput = myCal.SubInput.ToString() + "4";

            inputScreen.Text = myCal.Input.ToString();

        }

        void Button_Click5(object sender, RoutedEventArgs e)
        {
            myCal.Input = myCal.Input.ToString() + "5";

            myCal.SubInput = myCal.SubInput.ToString() + "5";

            inputScreen.Text = myCal.Input.ToString();

        }

        void Button_Click6(object sender, RoutedEventArgs e)
        {
            myCal.Input = myCal.Input.ToString() + "6";

            myCal.SubInput = myCal.SubInput.ToString() + "6";

            inputScreen.Text = myCal.Input.ToString();

        }

        void Button_Click7(object sender, RoutedEventArgs e)
        {
            myCal.Input = myCal.Input.ToString() + "7";

            myCal.SubInput = myCal.SubInput.ToString() + "7";

            inputScreen.Text = myCal.Input.ToString();

        }

        void Button_Click8(object sender, RoutedEventArgs e)
        {
            myCal.Input = myCal.Input.ToString() + "8";

            myCal.SubInput = myCal.SubInput.ToString() + "8";

            inputScreen.Text = myCal.Input.ToString();

        }

        void Button_Click9(object sender, RoutedEventArgs e)
        {
            myCal.Input = myCal.Input.ToString() + "9";

            myCal.SubInput = myCal.SubInput.ToString() + "9";

            inputScreen.Text = myCal.Input.ToString();

        }

        void Button_Click0(object sender, RoutedEventArgs e)
        {
            if (myCal.SubInput.ToString() == "" || (myCal.SubInput.ToString() != "" && int.Parse(myCal.SubInput.ToString()) != 0))
            {
                myCal.Input = myCal.Input.ToString() + "0";

                myCal.SubInput = myCal.SubInput.ToString() + "0";

                inputScreen.Text = myCal.Input.ToString();


            }

        }


        // 特殊符號
        // After pressing +-*/
        // input the num into nums
        void Button_Click_Addition(object sender, RoutedEventArgs e)
        {
            // 前一個是nums
            if (myCal.Input[myCal.Input.Length - 1] <= '9' && myCal.Input[myCal.Input.Length - 1] >= '0')
            {
                nums.Add(int.Parse(myCal.SubInput));

                symbol.Add('+');

                myCal.SubInput = "";

                myCal.Input = myCal.Input.ToString() + "+";

            }
            // 前一個是symbol
            else
            {
                myCal.Input = myCal.Input.Remove(myCal.Input.Length - 1);

                myCal.Input = myCal.Input.ToString() + "+";
            }


            inputScreen.Text = myCal.Input.ToString();

        }

        void Button_Click_Subtraction(object sender, RoutedEventArgs e)
        {
            // 前一個是nums
            if (myCal.Input[myCal.Input.Length - 1] <= '9' && myCal.Input[myCal.Input.Length - 1] >= '0')
            {
                nums.Add(int.Parse(myCal.SubInput));

                symbol.Add('-');

                myCal.SubInput = "";

                myCal.Input = myCal.Input.ToString() + "-";

            }
            // 前一個是symbol
            else
            {
                myCal.Input = myCal.Input.Remove(myCal.Input.Length - 1);

                myCal.Input = myCal.Input.ToString() + "-";
            }


            inputScreen.Text = myCal.Input.ToString();

        }

        void Button_Click_Multiplication(object sender, RoutedEventArgs e)
        {
            // 前一個是nums
            if (myCal.Input[myCal.Input.Length - 1] <= '9' && myCal.Input[myCal.Input.Length - 1] >= '0')
            {
                nums.Add(int.Parse(myCal.SubInput));

                symbol.Add('*');

                myCal.SubInput = "";

                myCal.Input = myCal.Input.ToString() + "*";

            }

            // 前一個是symbol
            else
            {
                myCal.Input = myCal.Input.Remove(myCal.Input.Length - 1);

                myCal.Input = myCal.Input.ToString() + "*";
            }


            inputScreen.Text = myCal.Input.ToString();

        }

        void Button_Click_Division(object sender, RoutedEventArgs e)
        {
            // 前一個是nums
            if (myCal.Input[myCal.Input.Length - 1] <= '9' && myCal.Input[myCal.Input.Length - 1] >= '0')
            {
                nums.Add(int.Parse(myCal.SubInput));

                symbol.Add('/');

                myCal.SubInput = "";

                myCal.Input = myCal.Input.ToString() + "/";

            }

            // 前一個是symbol
            else
            {
                myCal.Input = myCal.Input.Remove(myCal.Input.Length - 1);

                myCal.Input = myCal.Input.ToString() + "/";
            }


            inputScreen.Text = myCal.Input.ToString();

        }

        string PreorderString()
        {
            List<string> nums_str = new List<string>();
            List<char> symbol_temp = new List<char>(symbol);


            for ( int i = 0; i < nums.Count;i++ )
            {
                nums_str.Add(nums[i].ToString() );

                if (nums_str[i].Length > 1)
                {
                    nums_str[i] = "(" + nums_str[i] + ")";

                }

            } // for()

            for ( int i = 0; i < symbol_temp.Count; i++)
            {
                if (symbol_temp[i] == '*' || symbol_temp[i] == '/')
                {
                    nums_str[i] = symbol_temp[i] + nums_str[i] + nums_str[i + 1];

                    nums_str.RemoveAt(i + 1);
                    symbol_temp.RemoveAt(i);

                    i--;

                } // if()

            } // for()

            for (int i = 0; i < symbol_temp.Count; i++)
            {
                if (symbol_temp[i] == '+' || symbol_temp[i] == '-')
                {
                    nums_str[i] = symbol_temp[i] + nums_str[i] + nums_str[i + 1];

                    nums_str.RemoveAt(i + 1);
                    symbol_temp.RemoveAt(i);

                    i--;

                } // if()

            } // for()

            return nums_str[0];

        }

        string PostorderString()
        {
            List<string> nums_str = new List<string>();
            List<char> symbol_temp = new List<char>(symbol);


            for (int i = 0; i < nums.Count; i++)
            {
                nums_str.Add(nums[i].ToString());

                if (nums_str[i].Length > 1)
                {
                    nums_str[i] = "(" + nums_str[i] + ")";

                }

            } // for()

            for (int i = 0; i < symbol_temp.Count; i++)
            {
                if (symbol_temp[i] == '*' || symbol_temp[i] == '/')
                {
                    nums_str[i] =  nums_str[i] + nums_str[i + 1] + symbol_temp[i];

                    nums_str.RemoveAt(i + 1);
                    symbol_temp.RemoveAt(i);

                    i--;

                } // if()

            } // for()

            for (int i = 0; i < symbol_temp.Count; i++)
            {
                if (symbol_temp[i] == '+' || symbol_temp[i] == '-')
                {
                    nums_str[i] =  nums_str[i] + nums_str[i + 1] + symbol_temp[i];

                    nums_str.RemoveAt(i + 1);
                    symbol_temp.RemoveAt(i);

                    i--;

                } // if()

            } // for()

            return nums_str[0];

        }

        int CalculateResult()
        {
            // Defined Variable
            List<char> symbol_temp = new List<char>(symbol);
            List<int> nums_temp = new List<int>(nums);

            for (int i = 0; i < symbol_temp.Count && !error_divideByZero; i++)
            {
                if (symbol_temp[i] == '*')
                {
                    nums_temp[i] = nums_temp[i] * nums_temp[i + 1];

                    symbol_temp.RemoveAt(i);
                    nums_temp.RemoveAt(i + 1);
                    i--;


                } // if()

                else if (symbol_temp[i] == '/')
                {
                    if (nums_temp[i + 1] != 0 )
                    {
                        nums_temp[i] = nums_temp[i] / nums_temp[i + 1];

                        symbol_temp.RemoveAt(i);
                        nums_temp.RemoveAt(i + 1);
                        i--;

                    }
                    else
                    {
                        error_divideByZero = true;

                    }

                } // else if()

            } // for()

            for (int i = 0; i < symbol_temp.Count && !error_divideByZero; i++)
            {
                if (symbol_temp[i] == '+')
                {
                    nums_temp[i] = nums_temp[i] + nums_temp[i + 1];

                    symbol_temp.RemoveAt(i);
                    nums_temp.RemoveAt(i + 1);
                    i--;


                } // if()

                else if (symbol_temp[i] == '-')
                {
                    nums_temp[i] = nums_temp[i] - nums_temp[i + 1];

                    symbol_temp.RemoveAt(i);
                    nums_temp.RemoveAt(i + 1);
                    i--;

                } // else if()

            } // for()

            return nums_temp[0];

        }

        void Button_Click_Equal(object sender, RoutedEventArgs e)
        {
            // Equal is a symbol too
            // 前一個是nums
            if (myCal.Input[myCal.Input.Length - 1] <= '9' && myCal.Input[myCal.Input.Length - 1] >= '0')
            {
                if (myCal.SubInput != "")
                {
                    nums.Add(int.Parse(myCal.SubInput));

                    myCal.SubInput = "";

                }
                

            }
            // 前一個是symbol
            else
            {
                myCal.Input = myCal.Input.Remove(myCal.Input.Length - 1);

            }

            CalculateResult();

            if (!error_divideByZero)
            {
                outputDecimal.Text = CalculateResult().ToString();

                outputBinary.Text = Convert.ToString(CalculateResult(), 2);

                outputPreorder.Text = PreorderString();

                outputPostorder.Text = PostorderString();
            }
            else
            {
                MessageBox.Show("不可以除以零");
                error_divideByZero = false;
            }

        }


        void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            myCal.Input = "";

            inputScreen.Text = myCal.Input.ToString();

            nums.Clear();

            symbol.Clear();

            outputDecimal.Text = "";

            outputBinary.Text = "";

            outputPreorder.Text = "";

            outputPostorder.Text = "";

        }

        void Button_Click_Insert(object sender, RoutedEventArgs e)
        {

            string connString = "data source=localhost;port=3306;database=Mydatabase;user id=root;password=;charset=utf8";
            MySqlConnection conn = new MySqlConnection();
            string Query = ""; // MySQL command

            conn.ConnectionString = connString;


            Query = "select * from `result` where `Inorder` = '" + myCal.Input.ToString() + "';";

            MySqlCommand cmd = new MySqlCommand(Query, conn);

            if ( conn.State != ConnectionState.Open )
            {
                conn.Open();
            }


            MySqlDataReader reader = cmd.ExecuteReader();


            if ( reader.HasRows )
            {
                MessageBox.Show("資料已存在");

                conn.Close();
            }
            else
            {
                conn.Close();
                conn.Open();

                Query = "insert into `result` (`Inorder`, `Preorder`, `Postorder`, `Binary`, `Decimal`) values('" + myCal.Input.ToString() + "', '"
                                + PreorderString() + "', '" + PostorderString() + "', '" + Convert.ToString(CalculateResult(), 2) + "', '" + CalculateResult().ToString() + "');";

                cmd = new MySqlCommand(Query, conn);

                reader = cmd.ExecuteReader();

                MessageBox.Show("資料存入成功");

                conn.Close();
            }


        }


        void Button_Click_Query(object sender, RoutedEventArgs e)
        {
            // Display new window
            Queue queue = new Queue();
            queue.ShowDialog();

        }


    }
}
