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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace _3_laba
{
    public partial class MainWindow : Window
    {
        public int[] Lvl_1;
        public int[] Lvl_2;
        public int[] Lvl_3;
        public int[] Lvl_4;
        public int[] Lvl_5;
        public bool f;
        public int imin, imax;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private double GetY(TextBlock textBlock)
        {
            textBlock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            textBlock.Arrange(new Rect(0, 0, textBlock.DesiredSize.Width, textBlock.DesiredSize.Height));
            var position = textBlock.TransformToAncestor(MyGrid).Transform(new Point(0, 0));
            double centerY = position.Y + textBlock.ActualHeight / 2;
            return centerY;
        }
        private double GetX(TextBlock textBlock)
        {
            textBlock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            textBlock.Arrange(new Rect(0, 0, textBlock.DesiredSize.Width, textBlock.DesiredSize.Height));
            var position = textBlock.TransformToAncestor(MyGrid).Transform(new Point(0, 0));
            double centerX = position.X + textBlock.ActualWidth / 2;
            return centerX;
        }

       public void CreateMas()
        {
            Lvl_5 = new int[36];
            for (int i = 0; i < Lvl_5.Length ; i++){
                f = false;
                TextBox textBox = (TextBox)table.Children[i + 38];
                string input = textBox.Text;
                if (string.IsNullOrWhiteSpace(input)){return;}
                if (!int.TryParse(input, out int number)){return;}
                Lvl_5[i] = number;
                f = true;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Lvl_1 = new int[1];
            Lvl_2 = new int[3];
            Lvl_3 = new int[7];// вот здесь количество меняла
            Lvl_4 = new int[15];
            f = false;
            CreateMas();
            if (f == false)
            {
                MessageBox.Show("Поля должны быть заполнены числами");
                return;
            }
            else
            {
                Clear();
                int a;
                int.TryParse(vetvlenie.Text, out a);
                int b;
                int.TryParse(glubina.Text, out b);
                if (ask1.Text == "MIN" && ask2.Text == "слева-направо" && ask3.Text == "обычный")
                    MinMaxL();
                else if (ask1.Text == "MIN" && ask2.Text == "справа-налево" && ask3.Text == "обычный")
                    MinMaxP();
                else if (ask1.Text == "MAX" && ask2.Text == "слева-направо" && ask3.Text == "обычный")
                    MaxMinL();
                else if (ask1.Text == "MAX" && ask2.Text == "справа-налево" && ask3.Text == "обычный")
                    MaxMinP();
                else if (ask3.Text == "с отсечениями" && vetvlenie.Text != null && glubina.Text != null)
                {
                    if (a == 0 || b == 0) { MessageBox.Show("Ветвление и глубина должны быть выбраны"); return; }
                    
                    if (ask1.Text == "MIN" && ask2.Text == "слева-направо")
                    {
                        var newWindow = new Window1(a, b, 1);
                        newWindow.ShowDialog();
                    }
                    else if (ask1.Text == "MIN" && ask2.Text == "справа-налево")
                    {
                        var newWindow = new Window1(a, b, 2);
                        newWindow.ShowDialog();
                    }
                    else if (ask1.Text == "MAX" && ask2.Text == "слева-направо")
                    {
                        var newWindow = new Window1(a, b, 3);
                        newWindow.ShowDialog();
                    }
                    else if (ask1.Text == "MAX" && ask2.Text == "справа-налево")
                    {
                        var newWindow = new Window1(a, b, 4);
                        newWindow.ShowDialog();
                    }
                }
                return;
            }
            
        }

        public void Clear()
        {
            for (int i = 0; i < Lvl_5.Length; i++)
            {
            TextBox textBox = (TextBox)table.Children[i + 38];
            textBox.Foreground = Brushes.Black;
            }
            for (int i = 0; i < Lvl_1.Length; i++)
            {
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_1_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Black;
            }
            for (int i = 0; i < Lvl_2.Length; i++)
            {
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_2_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Black;
            }
            for (int i = 0; i < Lvl_3.Length; i++)
            {
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_3_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Black;
            }
            for (int i = 0; i < Lvl_4.Length; i++)
            {
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_4_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Black;
            }
        }

        public void MakeMas()
        {
            int a;
            int.TryParse(vetvlenie.Text, out a);
            int b;
            int.TryParse(glubina.Text, out b);
           
        }

        public void MaxMinL()//смотри МИНМАКС в MinMaxP()
        {
            TextBlock_1_0.Text = "MAX";
            TextBlock_2_0.Text = "MIN";
            TextBlock_3_0.Text = "MAX";
            TextBlock_4_0.Text = "MIN";

            Lvl_4[0] = Math.Min(Lvl_5[0], Lvl_5[1]);
            TextBlock_4_1.Text = (Lvl_4[0]).ToString();
            Lvl_4[1] = Math.Min(Lvl_5[2], Lvl_5[3]);
            TextBlock_4_2.Text = (Lvl_4[1]).ToString();
            Lvl_4[2] = Math.Min(Math.Min(Lvl_5[4], Lvl_5[5]), Lvl_5[6]);
            TextBlock_4_3.Text = (Lvl_4[2]).ToString();
            Lvl_4[3] = Math.Min(Lvl_5[7], Lvl_5[8]);
            TextBlock_4_4.Text = (Lvl_4[3]).ToString();
            Lvl_4[4] = Math.Min(Math.Min(Lvl_5[9], Lvl_5[10]), Lvl_5[11]);
            TextBlock_4_5.Text = (Lvl_4[4]).ToString();
            Lvl_4[5] = Math.Min(Math.Min(Lvl_5[12], Lvl_5[13]), Lvl_5[14]);
            TextBlock_4_6.Text = (Lvl_4[5]).ToString();
            Lvl_4[6] = Math.Min(Lvl_5[15], Lvl_5[16]);
            TextBlock_4_7.Text = (Lvl_4[6]).ToString();
            Lvl_4[7] = Math.Min(Lvl_5[17], Lvl_5[18]);
            TextBlock_4_8.Text = (Lvl_4[7]).ToString();
            Lvl_4[8] = Math.Min(Lvl_5[19], Lvl_5[20]);
            TextBlock_4_9.Text = (Lvl_4[8]).ToString();
            Lvl_4[9] = Math.Min(Math.Min(Lvl_5[21], Lvl_5[22]), Lvl_5[23]);
            TextBlock_4_10.Text = (Lvl_4[9]).ToString();
            Lvl_4[10] = Math.Min(Lvl_5[24], Lvl_5[25]);
            TextBlock_4_11.Text = (Lvl_4[10]).ToString();
            Lvl_4[11] = Math.Min(Math.Min(Lvl_5[26], Lvl_5[27]), Lvl_5[28]);
            TextBlock_4_12.Text = (Lvl_4[11]).ToString();
            Lvl_4[12] = Math.Min(Lvl_5[29], Lvl_5[30]);
            TextBlock_4_13.Text = (Lvl_4[12]).ToString();
            Lvl_4[13] = Math.Min(Lvl_5[31], Lvl_5[32]);
            TextBlock_4_14.Text = (Lvl_4[13]).ToString();
            Lvl_4[14] = Math.Min(Math.Min(Lvl_5[33], Lvl_5[34]), Lvl_5[35]);
            TextBlock_4_15.Text = (Lvl_4[14]).ToString();

            Lvl_3[0] = Math.Max(Math.Max(Lvl_4[0], Lvl_4[1]), Lvl_4[2]);
            TextBlock_3_1.Text = (Lvl_3[0]).ToString();
            Lvl_3[1] = Math.Max(Math.Max(Lvl_4[3], Lvl_4[4]), Lvl_4[5]);
            TextBlock_3_2.Text = (Lvl_3[1]).ToString();
            Lvl_3[2] = Math.Max(Lvl_4[6], Lvl_4[7]);
            TextBlock_3_3.Text = (Lvl_3[2]).ToString();
            Lvl_3[3] = Math.Max(Lvl_4[8], Lvl_4[9]);
            TextBlock_3_4.Text = (Lvl_3[3]).ToString();
            Lvl_3[4] = Math.Max(Lvl_4[10], Lvl_4[11]);
            TextBlock_3_5.Text = (Lvl_3[4]).ToString();
            Lvl_3[5] = Math.Max(Lvl_4[12], Lvl_4[13]);
            TextBlock_3_6.Text = (Lvl_3[5]).ToString();
            Lvl_3[6] = Lvl_4[14];
            TextBlock_3_7.Text = (Lvl_3[6]).ToString();


            Lvl_2[0] = Math.Min(Lvl_3[0], Lvl_3[1]);
            TextBlock_2_1.Text = (Lvl_2[0]).ToString();
            Lvl_2[1] = Math.Min(Lvl_3[2], Lvl_3[3]);
            TextBlock_2_2.Text = (Lvl_2[1]).ToString();
            Lvl_2[2] = Math.Min(Lvl_3[4], Lvl_3[5]);
            TextBlock_2_3.Text = (Lvl_2[2]).ToString();

            Lvl_1[0] = Math.Max(Math.Max(Lvl_2[0], Lvl_2[1]), Lvl_2[2]);
            TextBlock_1_1.Text = (Lvl_1[0]).ToString();

            TextBlock_1_1.Foreground = Brushes.Red;
            int c1 = 0, c2 = 0, c3 = 0;
            for (int i = 0; i < Lvl_2.Length; i++)
            {
                if (Lvl_2[i] == Lvl_1[0])
                {
                    c1 = i;
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_2_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Red;
                    break;
                }
            }
            int[]a = new int[2];
            a = Chose_c2(c1);
            imin = a[0];
            imax = a[1];
            for (int i = imin; i < imax + 1 ; i++)
            {
                if (Lvl_3[i] == Lvl_1[0])
                {
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_3_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Red;
                    c2 = i;
                    break;
                }
            }
            a = Chose_c3(c2);
            imin = a[0];
            imax = a[1];
            for (int i = imin; i < imax + 1; i++)
            {
                if (Lvl_4[i] == Lvl_1[0])
                {
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_4_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Red;
                    c3 = i;
                    break ;
                }
            }
            a = Chose_c4(c3);
            imin = a[0];
            imax = a[1];
            for (int i = imin; i < imax + 1; i++)
            {
                if (Lvl_5[i] == Lvl_1[0])
                {
                    TextBox textBox = (TextBox)table.Children[i + 38];
                    textBox.Foreground = Brushes.Red;
                    break;
                }
            }
        }

         public void MaxMinP()//смотри МИНМАКС в MinMaxP()
        {
            TextBlock_1_0.Text = "MAX";
            TextBlock_2_0.Text = "MIN";
            TextBlock_3_0.Text = "MAX";
            TextBlock_4_0.Text = "MIN";

            Lvl_4[0] = Math.Min(Lvl_5[0], Lvl_5[1]);
            TextBlock_4_1.Text = (Lvl_4[0]).ToString();
            Lvl_4[1] = Math.Min(Lvl_5[2], Lvl_5[3]);
            TextBlock_4_2.Text = (Lvl_4[1]).ToString();
            Lvl_4[2] = Math.Min(Math.Min(Lvl_5[4], Lvl_5[5]), Lvl_5[6]);
            TextBlock_4_3.Text = (Lvl_4[2]).ToString();
            Lvl_4[3] = Math.Min(Lvl_5[7], Lvl_5[8]);
            TextBlock_4_4.Text = (Lvl_4[3]).ToString();
            Lvl_4[4] = Math.Min(Math.Min(Lvl_5[9], Lvl_5[10]), Lvl_5[11]);
            TextBlock_4_5.Text = (Lvl_4[4]).ToString();
            Lvl_4[5] = Math.Min(Math.Min(Lvl_5[12], Lvl_5[13]), Lvl_5[14]);
            TextBlock_4_6.Text = (Lvl_4[5]).ToString();
            Lvl_4[6] = Math.Min(Lvl_5[15], Lvl_5[16]);
            TextBlock_4_7.Text = (Lvl_4[6]).ToString();
            Lvl_4[7] = Math.Min(Lvl_5[17], Lvl_5[18]);
            TextBlock_4_8.Text = (Lvl_4[7]).ToString();
            Lvl_4[8] = Math.Min(Lvl_5[19], Lvl_5[20]);
            TextBlock_4_9.Text = (Lvl_4[8]).ToString();
            Lvl_4[9] = Math.Min(Math.Min(Lvl_5[21], Lvl_5[22]), Lvl_5[23]);
            TextBlock_4_10.Text = (Lvl_4[9]).ToString();
            Lvl_4[10] = Math.Min(Lvl_5[24], Lvl_5[25]);
            TextBlock_4_11.Text = (Lvl_4[10]).ToString();
            Lvl_4[11] = Math.Min(Math.Min(Lvl_5[26], Lvl_5[27]), Lvl_5[28]);
            TextBlock_4_12.Text = (Lvl_4[11]).ToString();
            Lvl_4[12] = Math.Min(Lvl_5[29], Lvl_5[30]);
            TextBlock_4_13.Text = (Lvl_4[12]).ToString();
            Lvl_4[13] = Math.Min(Lvl_5[31], Lvl_5[32]);
            TextBlock_4_14.Text = (Lvl_4[13]).ToString();
            Lvl_4[14] = Math.Min(Math.Min(Lvl_5[33], Lvl_5[34]), Lvl_5[35]);
            TextBlock_4_15.Text = (Lvl_4[14]).ToString();


            Lvl_3[0] = Math.Max(Math.Max(Lvl_4[0], Lvl_4[1]), Lvl_4[2]);
            TextBlock_3_1.Text = (Lvl_3[0]).ToString();
            Lvl_3[1] = Math.Max(Math.Max(Lvl_4[3], Lvl_4[4]), Lvl_4[5]);
            TextBlock_3_2.Text = (Lvl_3[1]).ToString();
            Lvl_3[2] = Math.Max(Lvl_4[6], Lvl_4[7]);
            TextBlock_3_3.Text = (Lvl_3[2]).ToString();
            Lvl_3[3] = Math.Max(Lvl_4[8], Lvl_4[9]);
            TextBlock_3_4.Text = (Lvl_3[3]).ToString();
            Lvl_3[4] = Math.Max(Lvl_4[10], Lvl_4[11]);
            TextBlock_3_5.Text = (Lvl_3[4]).ToString();
            Lvl_3[5] = Math.Max(Lvl_4[12], Lvl_4[13]);
            TextBlock_3_6.Text = (Lvl_3[5]).ToString();
            Lvl_3[6] = Lvl_4[14];
            TextBlock_3_7.Text = (Lvl_3[6]).ToString();


            Lvl_2[0] = Math.Min(Lvl_3[0], Lvl_3[1]);
            TextBlock_2_1.Text = (Lvl_2[0]).ToString();
            Lvl_2[1] = Math.Min(Lvl_3[2], Lvl_3[3]);
            TextBlock_2_2.Text = (Lvl_2[1]).ToString();
            Lvl_2[2] = Math.Min(Lvl_3[4], Lvl_3[5]);
            TextBlock_2_3.Text = (Lvl_2[2]).ToString();

            Lvl_1[0] = Math.Max(Math.Max(Lvl_2[0], Lvl_2[1]), Lvl_2[2]);
            TextBlock_1_1.Text = (Lvl_1[0]).ToString();

            TextBlock_1_1.Foreground = Brushes.Red;
            int c1 = 0, c2 = 0, c3 = 0;
            for (int i = Lvl_2.Length - 1 ; i > 0; i--)
            {
                if (Lvl_2[i] == Lvl_1[0])
                {
                    c1 = i;
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_2_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Red;
                    break;
                }
            }
            int[]a = new int[2];
            a = Chose_c2(c1);
            imin = a[0];
            imax = a[1];
            for (int i = imax; i > imin - 1 ; i--)
            {
                if (Lvl_3[i] == Lvl_1[0])
                {
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_3_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Red;
                    c2 = i;
                    break;
                }
            }
            a = Chose_c3(c2);
            imin = a[0];
            imax = a[1];
            for (int i = imax; i > imin - 1; i--)
            {
                if (Lvl_4[i] == Lvl_1[0])
                {
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_4_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Red;
                    c3 = i;
                    break ;
                }
            }
            a = Chose_c4(c3);
            imin = a[0];
            imax = a[1];
            for (int i = imax; i > imin - 1; i--)
            {
                if (Lvl_5[i] == Lvl_1[0])
                {
                    TextBox textBox = (TextBox)table.Children[i + 38];
                    textBox.Foreground = Brushes.Red;
                    break;
                }
            }
        }

        public void MinMaxL() //смотри МИНМАКС в MinMaxP()
        {
            TextBlock_1_0.Text = "MIN";
            TextBlock_2_0.Text = "MAX";
            TextBlock_3_0.Text = "MIN";
            TextBlock_4_0.Text = "MAX";

            Lvl_4[0] = Math.Max(Lvl_5[0], Lvl_5[1]);
            TextBlock_4_1.Text = (Lvl_4[0]).ToString();
            Lvl_4[1] = Math.Max(Lvl_5[2], Lvl_5[3]);
            TextBlock_4_2.Text = (Lvl_4[1]).ToString();
            Lvl_4[2] = Math.Max(Math.Max(Lvl_5[4], Lvl_5[5]), Lvl_5[6]);
            TextBlock_4_3.Text = (Lvl_4[2]).ToString();
            Lvl_4[3] = Math.Max(Lvl_5[7], Lvl_5[8]);
            TextBlock_4_4.Text = (Lvl_4[3]).ToString();
            Lvl_4[4] = Math.Max(Math.Max(Lvl_5[9], Lvl_5[10]), Lvl_5[11]);
            TextBlock_4_5.Text = (Lvl_4[4]).ToString();
            Lvl_4[5] = Math.Max(Math.Max(Lvl_5[12], Lvl_5[13]), Lvl_5[14]);
            TextBlock_4_6.Text = (Lvl_4[5]).ToString();
            Lvl_4[6] = Math.Max(Lvl_5[15], Lvl_5[16]);
            TextBlock_4_7.Text = (Lvl_4[6]).ToString();
            Lvl_4[7] = Math.Max(Lvl_5[17], Lvl_5[18]);
            TextBlock_4_8.Text = (Lvl_4[7]).ToString();
            Lvl_4[8] = Math.Max(Lvl_5[19], Lvl_5[20]);
            TextBlock_4_9.Text = (Lvl_4[8]).ToString();
            Lvl_4[9] = Math.Max(Math.Max(Lvl_5[21], Lvl_5[22]), Lvl_5[23]);
            TextBlock_4_10.Text = (Lvl_4[9]).ToString();
            Lvl_4[10] = Math.Max(Lvl_5[24], Lvl_5[25]);
            TextBlock_4_11.Text = (Lvl_4[10]).ToString();
            Lvl_4[11] = Math.Max(Math.Max(Lvl_5[26], Lvl_5[27]), Lvl_5[28]);
            TextBlock_4_12.Text = (Lvl_4[11]).ToString();
            Lvl_4[12] = Math.Max(Lvl_5[29], Lvl_5[30]);
            TextBlock_4_13.Text = (Lvl_4[12]).ToString();
            Lvl_4[13] = Math.Max(Lvl_5[31], Lvl_5[32]);
            TextBlock_4_14.Text = (Lvl_4[13]).ToString();
            Lvl_4[14] = Math.Max(Math.Max(Lvl_5[33], Lvl_5[34]), Lvl_5[35]);
            TextBlock_4_15.Text = (Lvl_4[14]).ToString();

            Lvl_3[0] = Math.Min(Math.Min(Lvl_4[0], Lvl_4[1]), Lvl_4[2]);
            TextBlock_3_1.Text = (Lvl_3[0]).ToString();
            Lvl_3[1] = Math.Min(Math.Min(Lvl_4[3], Lvl_4[4]), Lvl_4[5]);
            TextBlock_3_2.Text = (Lvl_3[1]).ToString();
            Lvl_3[2] = Math.Min(Lvl_4[6], Lvl_4[7]);
            TextBlock_3_3.Text = (Lvl_3[2]).ToString();
            Lvl_3[3] = Math.Min(Lvl_4[8], Lvl_4[9]);
            TextBlock_3_4.Text = (Lvl_3[3]).ToString();
            Lvl_3[4] = Math.Min(Lvl_4[10], Lvl_4[11]);
            TextBlock_3_5.Text = (Lvl_3[4]).ToString();
            Lvl_3[5] = Math.Min(Lvl_4[12], Lvl_4[13]);
            TextBlock_3_6.Text = (Lvl_3[5]).ToString();
            Lvl_3[6] = Lvl_4[14];
            TextBlock_3_7.Text = (Lvl_3[6]).ToString();

            Lvl_2[0] = Math.Max(Lvl_3[0], Lvl_3[1]);
            TextBlock_2_1.Text = (Lvl_2[0]).ToString();
            Lvl_2[1] = Math.Max(Lvl_3[2], Lvl_3[3]);
            TextBlock_2_2.Text = (Lvl_2[1]).ToString();
            Lvl_2[2] = Math.Max(Lvl_3[4], Lvl_3[5]);
            TextBlock_2_3.Text = (Lvl_2[2]).ToString();

            Lvl_1[0] = Math.Min(Math.Min(Lvl_2[0], Lvl_2[1]), Lvl_2[2]);
            TextBlock_1_1.Text = (Lvl_1[0]).ToString();

            TextBlock_1_1.Foreground = Brushes.Red;
            int c1 = 0, c2 = 0, c3 = 0;
            for (int i = 0; i < Lvl_2.Length; i++)
            {
                if (Lvl_2[i] == Lvl_1[0])
                {
                    c1 = i;
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_2_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Red;
                    break;
                }
            }
            int[]a = new int[2];
            a = Chose_c2(c1);
            imin = a[0];
            imax = a[1];
            for (int i = imin; i < imax + 1 ; i++)
            {
                if (Lvl_3[i] == Lvl_1[0])
                {
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_3_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Red;
                    c2 = i;
                    break;
                }
            }
            a = Chose_c3(c2);
            imin = a[0];
            imax = a[1];
            for (int i = imin; i < imax + 1; i++)
            {
                if (Lvl_4[i] == Lvl_1[0])
                {
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_4_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Red;
                    c3 = i;
                    break ;
                }
            }
            a = Chose_c4(c3);
            imin = a[0];
            imax = a[1];
            for (int i = imin; i < imax + 1; i++)
            {
                if (Lvl_5[i] == Lvl_1[0])
                {
                    TextBox textBox = (TextBox)table.Children[i + 38];
                    textBox.Foreground = Brushes.Red;
                    break;
                }
            }
        }

        public void MinMaxP()// меняем все 4 MINMAX, только эти блоки. Обычно это несколько строк - это различия в ветвях
        {
            TextBlock_1_0.Text = "MIN";
            TextBlock_2_0.Text = "MAX";
            TextBlock_3_0.Text = "MIN";
            TextBlock_4_0.Text = "MAX";
////////////////////////////////////////////////////////////////////////////////////////
            Lvl_4[0] = Math.Max(Lvl_5[0], Lvl_5[1]);
            TextBlock_4_1.Text = (Lvl_4[0]).ToString();
            Lvl_4[1] = Math.Max(Lvl_5[2], Lvl_5[3]);
            TextBlock_4_2.Text = (Lvl_4[1]).ToString();
            Lvl_4[2] = Math.Max(Math.Max(Lvl_5[4], Lvl_5[5]), Lvl_5[6]);
            TextBlock_4_3.Text = (Lvl_4[2]).ToString();
            Lvl_4[3] = Math.Max(Lvl_5[7], Lvl_5[8]);
            TextBlock_4_4.Text = (Lvl_4[3]).ToString();
            Lvl_4[4] = Math.Max(Math.Max(Lvl_5[9], Lvl_5[10]), Lvl_5[11]);
            TextBlock_4_5.Text = (Lvl_4[4]).ToString();
            Lvl_4[5] = Math.Max(Math.Max(Lvl_5[12], Lvl_5[13]), Lvl_5[14]);
            TextBlock_4_6.Text = (Lvl_4[5]).ToString();
            Lvl_4[6] = Math.Max(Lvl_5[15], Lvl_5[16]);
            TextBlock_4_7.Text = (Lvl_4[6]).ToString();
            Lvl_4[7] = Math.Max(Lvl_5[17], Lvl_5[18]);
            TextBlock_4_8.Text = (Lvl_4[7]).ToString();
            Lvl_4[8] = Math.Max(Lvl_5[19], Lvl_5[20]);
            TextBlock_4_9.Text = (Lvl_4[8]).ToString();
            Lvl_4[9] = Math.Max(Math.Max(Lvl_5[21], Lvl_5[22]), Lvl_5[23]);
            TextBlock_4_10.Text = (Lvl_4[9]).ToString();
            Lvl_4[10] = Math.Max(Lvl_5[24], Lvl_5[25]);
            TextBlock_4_11.Text = (Lvl_4[10]).ToString();
            Lvl_4[11] = Math.Max(Math.Max(Lvl_5[26], Lvl_5[27]), Lvl_5[28]);
            TextBlock_4_12.Text = (Lvl_4[11]).ToString();
            Lvl_4[12] = Math.Max(Lvl_5[29], Lvl_5[30]);
            TextBlock_4_13.Text = (Lvl_4[12]).ToString();
            Lvl_4[13] = Math.Max(Lvl_5[31], Lvl_5[32]);
            TextBlock_4_14.Text = (Lvl_4[13]).ToString();
            Lvl_4[14] = Math.Max(Math.Max(Lvl_5[33], Lvl_5[34]), Lvl_5[35]);
            TextBlock_4_15.Text = (Lvl_4[14]).ToString();

            Lvl_3[0] = Math.Min(Math.Min(Lvl_4[0], Lvl_4[1]), Lvl_4[2]);
            TextBlock_3_1.Text = (Lvl_3[0]).ToString();
            Lvl_3[1] = Math.Min(Math.Min(Lvl_4[3], Lvl_4[4]), Lvl_4[5]);
            TextBlock_3_2.Text = (Lvl_3[1]).ToString();
            Lvl_3[2] = Math.Min(Lvl_4[6], Lvl_4[7]);
            TextBlock_3_3.Text = (Lvl_3[2]).ToString();
            Lvl_3[3] = Math.Min(Lvl_4[8], Lvl_4[9]);
            TextBlock_3_4.Text = (Lvl_3[3]).ToString();
            Lvl_3[4] = Math.Min(Lvl_4[10], Lvl_4[11]);
            TextBlock_3_5.Text = (Lvl_3[4]).ToString();
            Lvl_3[5] = Math.Min(Lvl_4[12], Lvl_4[13]);
            TextBlock_3_6.Text = (Lvl_3[5]).ToString();
            Lvl_3[6] = Lvl_4[14];
            TextBlock_3_7.Text = (Lvl_3[6]).ToString();

            Lvl_2[0] = Math.Max(Lvl_3[0], Lvl_3[1]);
            TextBlock_2_1.Text = (Lvl_2[0]).ToString();
            Lvl_2[1] = Math.Max(Lvl_3[2], Lvl_3[3]);
            TextBlock_2_2.Text = (Lvl_2[1]).ToString();
            Lvl_2[2] = Math.Max(Lvl_3[4], Lvl_3[5]);
            TextBlock_2_3.Text = (Lvl_2[2]).ToString();
//////////////////////////////////////////////////////////////////////////
            Lvl_1[0] = Math.Min(Math.Min(Lvl_2[0], Lvl_2[1]), Lvl_2[2]);
            TextBlock_1_1.Text = (Lvl_1[0]).ToString();

            TextBlock_1_1.Foreground = Brushes.Red;
            int c1 = 0, c2 = 0, c3 = 0;
            for (int i = Lvl_2.Length - 1 ; i > 0; i--)
            {
                if (Lvl_2[i] == Lvl_1[0])
                {
                    c1 = i;
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_2_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Red;
                    break;
                }
            }
            int[]a = new int[2];
            a = Chose_c2(c1);
            imin = a[0];
            imax = a[1];
            for (int i = imax; i > imin - 1 ; i--)
            {
                if (Lvl_3[i] == Lvl_1[0])
                {
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_3_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Red;
                    c2 = i;
                    break;
                }
            }
            a = Chose_c3(c2);
            imin = a[0];
            imax = a[1];
            for (int i = imax; i > imin - 1; i--)
            {
                if (Lvl_4[i] == Lvl_1[0])
                {
                    TextBlock currentTextBlock = (TextBlock)FindName($"TextBlock_4_{i + 1}");
                    currentTextBlock.Foreground = Brushes.Red;
                    c3 = i;
                    break ;
                }
            }
            a = Chose_c4(c3);
            imin = a[0];
            imax = a[1];
            for (int i = imax; i > imin - 1; i--)
            {
                if (Lvl_5[i] == Lvl_1[0])
                {
                    TextBox textBox = (TextBox)table.Children[i + 38];
                    textBox.Foreground = Brushes.Red;
                    break;
                }
            }
        }

        public int[] Chose_c2(int c1) // меняем это, по способу ниже в Chose_c3(int c2)
        {
            if (c1 == 0) {
                imin = 0;
                imax = 1;
            }
            if (c1 == 1) {
                imin = 2;
                imax = 3;
            }
            if (c1 == 2) {
                imin = 4;
                imax = 5;
            }
            int[]a = new int[2];
            a[0] = imin;
            a[1] = imax;
            return a;
        }

        public int[] Chose_c3(int c2)// меняем это
        {
            if (c2 == 0) {
                imin = 0;//3 ветви 0 1 2
                imax = 2;
            }
            if (c2 == 1) {// 3 ветви 3 4 5
                imin = 3;
                imax = 5;
            }
            if (c2 == 2) {// 2 ветви 6 7
                imin = 6;// и так далее
                imax = 7;
            }
            if (c2 == 3) {
                imin = 8;
                imax = 9;
            }
            if (c2 == 4)
            {
                imin = 10;
                imax = 11;
            }
            if (c2 == 5) {
                imin = 12;
                imax = 13;
            }
            if (c2 == 6) {
                imin = 14;
                imax = 14;
            }


            int[]a = new int[2];
            a[0] = imin;
            a[1] = imax;
            return a;
        }
        public int[] Chose_c4(int c3)// меняем это по предыдущему методу
        {
            if (c3 == 0) {
                imin = 0;
                imax = 1;
            }
            if (c3 == 1) {
                imin = 2;
                imax = 3;
            }
            if (c3 == 2) {
                imin = 4;
                imax = 6;
            }
            if (c3 == 3) {
                imin = 7;
                imax = 8;
            }
            if (c3 == 4) {
                imin = 9;
                imax = 11;
            }
            if (c3 == 5) {
                imin = 12;
                imax = 14;
            }
            if (c3 == 6) {
                imin = 15;
                imax = 16;
            }
            if (c3 == 7) {
                imin = 17;
                imax = 18;
            }
            if (c3 == 8) {
                imin = 19;
                imax = 20;
            }
            if (c3 == 9) {
                imin = 21;
                imax = 23;
            }
            if (c3 == 10) {
                imin = 24;
                imax = 25;
            }
            if (c3 == 11) {
                imin = 26;
                imax = 28;
            }
            if (c3 == 12) {
                imin = 29;
                imax = 30;
            }
            if (c3 == 13) {
                imin = 31;
                imax = 32;
            }
            if (c3 == 14) {
                imin = 33;
                imax = 35;
            }
            int[]a = new int[2];
            a[0] = imin;
            a[1] = imax;
            return a;
        }
    }
}