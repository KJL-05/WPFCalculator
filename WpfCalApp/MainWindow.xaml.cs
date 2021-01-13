using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfCalApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string ope = null;
        double opeNum1 = 0.0;
        double opeNum2 = 0.0;
        string opeStrF = null;
        string opeStrS = null;
        bool btnE_Clicked = false;

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += timer_Tick;

        }

        void timer_Tick(object sender, EventArgs e)//时间显示
        {
            labShowTime.Content = DateTime.Now.ToString("yyyy年MM月dd日 dddd tt hh:mm:ss");
        }

        private void OpeInput(string str)//操作符输入
        {
            if (ope!=null)
            {
                Form form = new Form();
                form.Text = "操作符输入错误，计算器重启！";
                form.Width = 600;
                form.Show();
                ope = null;
                TextShowNum.Text = "";
                labHistory.Content = "";
            }
            if (TextShowNum.Text == "")
            {
                return;
            }
            opeStrF = TextShowNum.Text;
            TextShowNum.Text = "";
            labHistory.Content += str;
            ope = str;
        }

        private void Equal()//等于号输入
        {
            opeStrS = TextShowNum.Text;
            if (opeStrF != null && opeStrS != null && ope != null)
            {
                try
                {
                    opeNum1 = double.Parse(opeStrF);
                    opeNum2 = double.Parse(opeStrS);

                }
                catch
                {
                    Form form = new Form();
                    form.Text = "数字输入错误，计算器重启！";
                    form.Width = 600;
                    form.Show();
                    ope = null;
                    TextShowNum.Text = "";
                    labHistory.Content = "";

                }

                switch (ope)
                {
                    case "+":
                        TextShowNum.Text = (opeNum1 + opeNum2).ToString();
                        break;
                    case "-":
                        {
                            string temp = "";
                            temp = (opeNum1 - opeNum2).ToString();
                            double x_temp = double.Parse(temp);
                            if (x_temp < 0)
                            {
                                temp = temp.Replace("-", "");
                                temp += "-";
                            }

                            TextShowNum.Text = temp;

                        }
                        break;
                    case "*":
                        TextShowNum.Text = (opeNum1 * opeNum2).ToString();
                        break;
                    case "/":
                        TextShowNum.Text = (opeNum1 / opeNum2).ToString();
                        break;
                    case"^":
                        {
                            double result = 1;
                            for (int q = 0; q < opeNum2; q++)
                            {
                                result = result * opeNum1;
                            }
                            TextShowNum.Text = result.ToString();
                        }
                        break;
                }
            }
            btnE_Clicked = true;
            ope = null;
        }

        private void NumInput(string str)//数字输入
        {
            if (btnE_Clicked)
            {
                TextShowNum.Text = "";
                labHistory.Content = "";
            }
            if (ope != "")
            {
                string strNum = TextShowNum.Text.ToString();
                string strHistory = labHistory.Content.ToString();

                strNum += str;
                strHistory += str;

                TextShowNum.Text = strNum;
                labHistory.Content = strHistory;

            }
            else
            {
                return;
            }
            btnE_Clicked = false;
        }

        private void btnNum_Click(object sender, RoutedEventArgs e)//数字点击事件
        {
            var num = sender as System.Windows.Controls.Button;
            string str = num.Content.ToString();
            NumInput(str);
        }

        private void btnOpe_Click(object sender, RoutedEventArgs e)//操作符点击事件
        {
            var num = sender as System.Windows.Controls.Button;
            var str = num.Content.ToString();
            str = str.Replace("x", "");
            str = str.Replace("y", "");
            OpeInput(str);
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)//等于号点击事件
        {
            Equal();
        }

        private void btnC_Click(object sender, RoutedEventArgs e)//清除号点击事件
        {
            TextShowNum.Text = "";
            labHistory.Content = "";
        }

        private void btnTakeOpp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                opeStrF = TextShowNum.Text;
                opeNum1 = double.Parse(opeStrF);

            }
            catch
            {
                Form form = new Form();
                form.Text = "数字输入错误，计算器重启！";
                form.Width = 600;
                form.Show();
                ope = null;
                TextShowNum.Text = "";
                labHistory.Content = "";

            }
            string temp = "";
            temp = (-(opeNum1)).ToString();
            double x_temp = double.Parse(temp);
            if (x_temp < 0)
            {
                temp = temp.Replace("-", "");
                temp += "-";
            }

            TextShowNum.Text = temp;
            btnE_Clicked = true;

        }

        private void btnSquare_Click(object sender, RoutedEventArgs e)//求平方点击事件
        {
            try
            {
                opeStrF = TextShowNum.Text;
                opeNum1 = double.Parse(opeStrF);

            }
            catch
            {
                Form form = new Form();
                form.Text = "数字输入错误，计算器重启！";
                form.Width = 600;
                form.Show();
                ope = null;
                TextShowNum.Text = "";
                labHistory.Content = "";

            }
            string temp = "";
            temp = (opeNum1*opeNum1).ToString();
            TextShowNum.Text = temp;
            btnE_Clicked = true;
        }

        private void btnBinary_Click(object sender, RoutedEventArgs e)//转二进制点击事件
        {
            try
            {
                opeStrF = TextShowNum.Text;
                int opeNum1 = int.Parse(opeStrF);
                var str = Convert.ToString(opeNum1, 2);
                TextShowNum.Text = str;
            }
            catch
            {
                Form form = new Form();
                form.Text = "数字输入错误，计算器重启！";
                form.Width = 600;
                form.Show();
                ope = null;
                TextShowNum.Text = "";
                labHistory.Content = "";

            }
            btnE_Clicked = true;

        }

    }
}
