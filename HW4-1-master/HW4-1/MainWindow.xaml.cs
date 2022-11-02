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

namespace HW4_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, int> food = new Dictionary<string, int>();
        int[] order = new int[6];
        public MainWindow()
        {

            InitializeComponent();
            AddNewFood(food);
        }
        private void AddNewFood(Dictionary<string, int> myfood)
        {
            myfood.Add("大麥克漢堡(套餐)", 150);
            myfood.Add("大麥克漢堡(單點)", 90);
            myfood.Add("麥香雞漢堡(套餐)", 140);
            myfood.Add("麥香雞漢堡(單點)", 80);
            myfood.Add("雙層牛肉堡(套餐)", 160);
            myfood.Add("雙層牛肉堡(單點)", 100);
        }

        private void Button()
        {
            bool success = int.TryParse(textbox1.Text, out order[0]);
            success = int.TryParse((textbox2.Text), out order[1]);
            success = int.TryParse((textbox3.Text), out order[2]);
            success = int.TryParse((textbox4.Text), out order[3]);
            success = int.TryParse((textbox5.Text), out order[4]);
            success = int.TryParse((textbox6.Text), out order[5]);
        }
        private void PlaceOrder(object sender, TextChangedEventArgs e)
        {
            var targetTextbox = sender as TextBox;
            bool success = int.TryParse(targetTextbox.Text, out int count);
            if (!success)
            {
                MessageBox.Show("請輸入整數", "輸入錯誤");
            }
            else if (count <= 0)
            {
                MessageBox.Show("請輸入整數", "輸入錯誤");
            }
            else
            {

            }
        }
        int total = 0, i = 0, sym = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button();
            textbox7.Text = "";
            textbox7.Text += $"訂購清單如下:\n";
            foreach (var item in food)
            {
                if (order[i] > 0)
                {
                    textbox7.Text += $"{item.Key} X {order[i]}，每份{item.Value}元，總共{order[i] * item.Value}元\n";
                    total = total + (order[i] * item.Value);
                }
                i++;
            }
            textbox7.Text += $"\n";
            textbox7.Text += $"本次訂單彙總如下:\n";
            if (total >= 1000)
            {
                sym = (int)(total * 0.85);
                textbox7.Text += $"原價{total}元，訂購總額滿1000元以上，售價為85折，售價{sym}元\n";
            }
            else if (total >= 500)
            {
                sym = (int)(total * 0.9);
                textbox7.Text += $"原價{total}元，訂購總額滿500元以上，售價為9折，售價{sym}元\n";
            }
            else
            {
                textbox7.Text += "\n";
            }
            textbox7.Text += $"本次訂購獲得回饋點數{(int)(total * 0.1)}點\n";
        }
    }
}
