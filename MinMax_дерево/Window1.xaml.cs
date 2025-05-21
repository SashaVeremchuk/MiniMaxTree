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

namespace _3_laba
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public int[] arr;
        public int k = 0;
        public int a;
        public int b;
        public int f;
        public TextBlock currentTextBlock;
        public Window1( int a, int b, int f)
        {
            InitializeComponent();
            int[][] arrays = new int[b][];
            for(int i = 0; i < b ; i++)
            {
                arrays[i] = new int[(int)Math.Pow(a, i)];
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    arrays[i][j] = 0;
                }
            }
            this.a = a;
            this.b = b;
            this.f = f;
            arrays = Sokrutie(arrays);
            if (f == 1)
            { MinMaxL(arrays); FindpathL(arrays); }
            else if (f == 2)
            { MinMaxP(arrays); FindpathP(arrays); }
            else if (f == 3)
            { MaxMinL(arrays); FindpathL(arrays); }
            else if (f == 4)
            { MaxMinP(arrays); FindpathP(arrays); }
            
        }

        public int[][] Sokrutie(int[][] arrays)
        {
            int x;
            Random random = new Random();
            for (int i = 0; i < 4; i++) {
                int c = 0;
                for (int j = 0; j < Math.Pow(4, i); j++)
                {
                    if (a == 2) {
                        if (j % 4 == 2 || j % 4 == 3 || c > Math.Pow(a, i) || (j >= 8 && j <= 15) || j >= 24)
                        {
                            currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1}");
                            if (currentTextBlock != null )
                                currentTextBlock.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            x = random.Next(0, 100);
                            currentTextBlock = (TextBlock)FindName($"t{b}_{j + 1}");
                            if (currentTextBlock != null)
                            {
                                c++;
                                if(i == b-1)
                                {
                                    currentTextBlock.Text = x.ToString();
                                    arrays[b-1][k] = x;
                                    k++;
                                }
                            }
                        }
                    }
                    if (a == 3) {
                        if (j % 4 == 3 || c > Math.Pow(a, i) || (j >= 12 && j <= 15) || (j >= 28 && j <= 31) || j >= 44)
                        {
                            currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1}");
                            if (currentTextBlock != null )
                                currentTextBlock.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            x = random.Next(0, 100);
                            currentTextBlock = (TextBlock)FindName($"t{b}_{j + 1}");
                            if (currentTextBlock != null)
                            {
                                c++;
                                if(i == b-1)
                                {
                                    currentTextBlock.Text = x.ToString();
                                    arrays[b-1][k] = x;
                                    k++;
                                }
                            }
                        }
                    }
                    if(a == 4)
                    {
                        x = random.Next(0, 100);
                            currentTextBlock = (TextBlock)FindName($"t{b}_{j + 1}");
                            if (currentTextBlock != null)
                            {
                                c++;    
                                if(i == b-1)
                                {
                                    currentTextBlock.Text = x.ToString();
                                    arrays[b-1][k] = x;
                                    k++;
                                }
                            }
                    }
                }
            }
            
            for (int i = 4; i > b; i--) {
                for (int j = 0; j < Math.Pow(4, i-1); j++)
                {
                    currentTextBlock = (TextBlock)FindName($"t{i}_{j + 1}");
                    if (currentTextBlock != null )
                        currentTextBlock.Visibility = Visibility.Hidden;
                }
            }
            return arrays;
        }

        public void FindpathP(int[][] arrays)
        {
            int best = arrays[0][0];
            currentTextBlock = (TextBlock)FindName($"t1_1");
            currentTextBlock.Foreground = Brushes.Blue;
            int index1=0, index2=0;
            for (int i = 1; i < b; i++)
            {
                if(a == 4) //a vetvlenie
                {
                    if (i == 1)
                    {
                        for (int j = (int)Math.Pow(a, i) - 1; j >=0 ; j--)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1}");
                                currentTextBlock.Foreground = Brushes.Blue;
                                index1 = j;
                                break;
                            }
                        }
                    }
                    if (i == 2)
                    {
                        for (int j = (index1+1) * 4 - 1 ; j >= index1 * 4  ; j--)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1}");
                                if (currentTextBlock.Foreground != Brushes.MediumSpringGreen)
                                {
                                    currentTextBlock.Foreground = Brushes.Blue;
                                    index2 = j;
                                    break;
                                }
                            }
                        }
                    }
                    if (i == 3)
                    {
                        for (int j = (index2+1) * 4 - 1 ; j >= index2 * 4  ; j--)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1}");
                                if (currentTextBlock.Foreground != Brushes.MediumSpringGreen)
                                {
                                    currentTextBlock.Foreground = Brushes.Blue;
                                    break;
                                }
                            }
                        }
                    }
                }

                if(a == 3)
                {
                    if (i == 1)
                    {
                        for (int j = (int)Math.Pow(a, i) - 1; j >=0 ; j--)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1+j/a}");
                                currentTextBlock.Foreground = Brushes.Blue;
                                index1 = j;
                                break;
                            }
                        }
                    }
                    if (i == 2)
                    {
                        for (int j = (index1+1) * 3 - 1 ; j >= index1 * 3  ; j--)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1+j/a}");
                                if (currentTextBlock.Foreground != Brushes.MediumSpringGreen)
                                {
                                    currentTextBlock.Foreground = Brushes.Blue;
                                    index2 = j;
                                    break;
                                }
                            }
                        }
                    }
                    if (i == 3)
                    {
                        for (int j = (index2+1) * 3  - 1 ; j >= index2 * 3; j--)
                        {
                            if (arrays[i][j] == best)
                            {
                                if(j/9 == 0) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a }");
                                if(j/9 ==1) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a + 4}");
                                if(j/9 ==2) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a + 8}");
                                if (currentTextBlock.Foreground != Brushes.MediumSpringGreen) 
                                {
                                    currentTextBlock.Foreground = Brushes.Blue;
                                    break;
                                }
                            }
                        }
                    }
                }
                if(a == 2)
                {
                    if (i == 1)
                    {
                        for (int j =(int) Math.Pow(a, i) - 1; j >=0; j--)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1+2*(j/a)}");
                                currentTextBlock.Foreground = Brushes.Blue;
                                index1 = j;
                                break;
                            }
                        }
                    }
                    if (i == 2)
                    {
                        for (int j = (index1+1) * 2 - 1; j >=  index1 * 2 ; j--)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1+2*(j/a)}");
                                if (currentTextBlock.Foreground != Brushes.MediumSpringGreen)
                                {
                                    currentTextBlock.Foreground = Brushes.Blue;
                                    index2 = j;
                                    break;
                                }
                            }
                        }
                    }
                    if (i == 3)
                    {
                        for (int j =(index2+1) * 2 - 1 ; j >= index2 * 2 ; j--)
                        {
                            if (arrays[i][j] == best)
                            {
                                if(index2%4 == 0) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a }");
                                else if(index2%4 ==1) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a + 1}");
                                else if(index2%4 ==2) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a + 10}");
                                else if(index2%4 ==3) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a + 11}");
                                if (currentTextBlock.Foreground != Brushes.MediumSpringGreen) 
                                {
                                    currentTextBlock.Foreground = Brushes.Blue;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void FindpathL(int[][] arrays)
        {
            int best = arrays[0][0];
            currentTextBlock = (TextBlock)FindName($"t1_1");
            currentTextBlock.Foreground = Brushes.Blue;
            int index1=0, index2=0;
            for (int i = 1; i < b; i++)
            {
                if(a == 4) //a vetvlenie
                {
                    if (i == 1)
                    {
                        for (int j = 0; j < Math.Pow(a, i); j++)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1}");
                                currentTextBlock.Foreground = Brushes.Blue;
                                index1 = j;
                                break;
                            }
                        }
                    }
                    if (i == 2)
                    {
                        for (int j = index1 * 4; j < (index1+1) * 4 ; j++)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1}");
                                if (currentTextBlock.Foreground != Brushes.MediumSpringGreen)
                                {
                                    currentTextBlock.Foreground = Brushes.Blue;
                                    index2 = j;
                                    break;
                                }
                            }
                        }
                    }
                    if (i == 3)
                    {
                        for (int j = index2 * 4; j < (index2+1) * 4 ; j++)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1}");
                                if (currentTextBlock.Foreground != Brushes.MediumSpringGreen)
                                {
                                    currentTextBlock.Foreground = Brushes.Blue;
                                    break;
                                }
                            }
                        }
                    }
                }

                if(a == 3)
                {
                    if (i == 1)
                    {
                        for (int j = 0; j < Math.Pow(a, i); j++)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1+j/a}");
                                currentTextBlock.Foreground = Brushes.Blue;
                                index1 = j;
                                break;
                            }
                        }
                    }
                    if (i == 2)
                    {
                        for (int j = index1 * 3; j < (index1+1) * 3 ; j++)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1+j/a}");
                                if (currentTextBlock.Foreground != Brushes.MediumSpringGreen)
                                {
                                    currentTextBlock.Foreground = Brushes.Blue;
                                    index2 = j;
                                    break;
                                }
                            }
                        }
                    }
                    if (i == 3)
                    {
                        for (int j = index2 * 3; j < (index2+1) * 3 ; j++)
                        {
                            if (arrays[i][j] == best)
                            {
                                if(j/9 == 0) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a }");
                                if(j/9 ==1) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a + 4}");
                                if(j/9 ==2) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a + 8}");
                                if (currentTextBlock.Foreground != Brushes.MediumSpringGreen) 
                                {
                                    currentTextBlock.Foreground = Brushes.Blue;
                                    break;
                                }
                            }
                        }
                    }
                }
                if(a == 2)
                {
                    if (i == 1)
                    {
                        for (int j = 0; j < Math.Pow(a, i); j++)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1+2*(j/a)}");
                                currentTextBlock.Foreground = Brushes.Blue;
                                index1 = j;
                                break;
                            }
                        }
                    }
                    if (i == 2)
                    {
                        for (int j = index1 * 2; j < (index1+1) * 2; j++)
                        {
                            if (arrays[i][j] == best)
                            {
                                currentTextBlock = (TextBlock)FindName($"t{i+1}_{j + 1+2*(j/a)}");
                                if (currentTextBlock.Foreground != Brushes.MediumSpringGreen)
                                {
                                    currentTextBlock.Foreground = Brushes.Blue;
                                    index2 = j;
                                    break;
                                }
                            }
                        }
                    }
                    if (i == 3)
                    {
                        for (int j = index2 * 2; j < (index2+1) * 2; j++)
                        {
                            if (arrays[i][j] == best)
                            {
                                if(index2%4 == 0) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a }");
                                else if(index2%4 ==1) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a + 1}");
                                else if(index2%4 ==2) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a + 10}");
                                else if(index2%4 ==3) currentTextBlock = (TextBlock)FindName($"t{i + 1}_{j + 1 + j / a + 11}");
                                if (currentTextBlock.Foreground != Brushes.MediumSpringGreen) 
                                {
                                    currentTextBlock.Foreground = Brushes.Blue;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void MaxMinL(int[][] arrays)
        {
            _1.Text = "MAX";
            _2.Text = "MIN z<a";
            _3.Text = "MAX z>b";
            if(b == 2)
            {
                _2.Visibility = Visibility.Hidden;
                _3.Visibility = Visibility.Hidden;
            }
            if(b == 3)
            {
                _3.Visibility = Visibility.Hidden;
            }
            for (int k = b-1; k >= 1; k--)
            {
                if (k % 2 == 1)
                {
                    for (int i = 0; i < Math.Pow(a, k - 1); i++)
                    {
                        for (int j = i * a; j < (i + 1) * a; j += a)
                        {
                            if (i % a == 0)
                            {
                                int y = 0;
                                for (int n = i * a; n < (i + 1) * a; n++)
                                {
                                    y = Math.Max(arrays[k][n], y);
                                }
                                arrays[k - 1][i] = y;
                                if(a==4 || i==0)
                                    currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                else if(a==3)
                                    currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                else if(a==2)
                                    currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                currentTextBlock.Text = arrays[k - 1][i].ToString();
                            }
                            else
                            {
                                if (arrays[k - 1][i - 1] < arrays[k][j])
                                {
                                    arrays[k - 1][i] = arrays[k][j];
                                    if(a==4 || i==0)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                    else if(a==3)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                    else if(a==2)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                    currentTextBlock.Text = arrays[k - 1][i].ToString();
                                    currentTextBlock.Foreground = Brushes.Red;
                                    for (int n = i * a + 1 ; n < (i + 1) * a; n++)
                                    {
                                        if (a == 4 )
                                            currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1}");
                                        else if (a == 3)
                                        {
                                            if(n/9 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a }");
                                            if(n/9 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 4}");
                                            if(n/9 ==2) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 8}");
                                        }
                                        else if (a == 2)
                                        {
                                            if(n/4 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 1}");
                                            if(n/4 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 11}");
                                        }
                                        if (currentTextBlock != null)
                                            currentTextBlock.Foreground = Brushes.MediumSpringGreen;
                                    }
                                }
                                else
                                {
                                    int y = 0;
                                    for (int n = i * a; n < (i + 1) * a; n++)
                                    {
                                        y = Math.Max(arrays[k][n], y);
                                    }
                                    arrays[k - 1][i] = y;
                                    if(a==4 || i==0)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                    else if(a==3)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                    else if(a==2)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2 * (i / a)}");
                                    currentTextBlock.Text = arrays[k - 1][i].ToString();
                                }
                            }
                        }
                    }
                }
                else if (k % 2 == 0)
                { 
                    
                    for (int i = 0; i < Math.Pow(a, k - 1); i++)
                        {
                            for (int j = i * a; j < (i + 1) * a; j += a)
                            {
                                if (i % a == 0)
                                {
                                    int y = 100;
                                    for (int n = i * a; n < (i + 1) * a; n++)
                                    {
                                        y = Math.Min(arrays[k][n], y);
                                    }
                                    arrays[k - 1][i] = y;
                                    if(a==4 || i==0)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                    else if(a==3)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                    else if(a==2)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2 * (i / a)}");
                                    currentTextBlock.Text = arrays[k - 1][i].ToString();
                                    
                                }
                                else
                                {
                                    if (arrays[k - 1][i - 1] > arrays[k][j])
                                    {
                                        arrays[k - 1][i] = arrays[k][j];
                                        if(a==4 || i==0)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                        else if(a==3)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                        else if(a==2)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                        currentTextBlock.Text = arrays[k - 1][i].ToString();
                                        currentTextBlock.Foreground = Brushes.Red;
                                        for (int n = i * a + 1 ; n < (i + 1) * a; n++)
                                        {
                                            if (a == 4)
                                                currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1}");
                                            else if (a == 3)
                                            {
                                                if(n/9 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a }");
                                                if(n/9 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 4}");
                                                if(n/9 ==2) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 8}");
                                            }
                                            else if (a == 2)
                                            {
                                                if(n/4 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a +1}");
                                                if(n/4 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a +11}");
                                            }
                                            if (currentTextBlock != null)
                                                currentTextBlock.Foreground = Brushes.MediumSpringGreen;
                                        }
                                    }
                                    else
                                    {
                                        int y = 100;
                                        for (int n = i * a; n < (i + 1) * a; n++)
                                        {
                                            y = Math.Min(arrays[k][n], y);
                                        }
                                        arrays[k - 1][i] = y;   
                                        if(a==4 || i==0)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                        else if(a==3)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                        else if(a==2)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                        currentTextBlock.Text = arrays[k - 1][i].ToString();
                                    }
                                }
                            }
                        }
                    }
            }
        }

        public void MinMaxL(int[][] arrays)
        {
            _1.Text = "MIN";
            _2.Text = "MAX z>b";
            _3.Text = "MIN z<a";
            if(b == 2)
            {
                _2.Visibility = Visibility.Hidden;
                _3.Visibility = Visibility.Hidden;
            }
            if(b == 3)
            {
                _3.Visibility = Visibility.Hidden;
            }
            for (int k = b-1; k >= 1; k--)
            {
                if (k % 2 == 0)
                {
                    for (int i = 0; i < Math.Pow(a, k - 1); i++)
                    {
                        for (int j = i * a; j < (i + 1) * a; j += a)
                        {
                            if (i % a == 0)
                            {
                                int y = 0;
                                for (int n = i * a; n < (i + 1) * a; n++)
                                {
                                    y = Math.Max(arrays[k][n], y);
                                }
                                arrays[k - 1][i] = y;
                                if(a==4 || i==0)
                                    currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                else if(a==3)
                                    currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                else if(a==2)
                                    currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                currentTextBlock.Text = arrays[k - 1][i].ToString();
                            }
                            else
                            {
                                if (arrays[k - 1][i - 1] < arrays[k][j])
                                {
                                    arrays[k - 1][i] = arrays[k][j];
                                    if(a==4 || i==0)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                    else if(a==3)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                    else if(a==2)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                    currentTextBlock.Text = arrays[k - 1][i].ToString();
                                    currentTextBlock.Foreground = Brushes.Red;
                                    for (int n = i * a + 1 ; n < (i + 1) * a; n++)
                                        {
                                            if (a == 4)
                                                currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1}");
                                            else if (a == 3)
                                            {
                                                if(n/9 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a }");
                                                if(n/9 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 4}");
                                                if(n/9 ==2) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 8}");
                                            }
                                            else if (a == 2)
                                            {
                                                if(n/4 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a +1}");
                                                if(n/4 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a +11}");
                                            }
                                            if (currentTextBlock != null)
                                                currentTextBlock.Foreground = Brushes.MediumSpringGreen;
                                        }
                                }
                                else
                                {
                                    int y = 0;
                                    for (int n = i * a; n < (i + 1) * a; n++)
                                    {
                                        y = Math.Max(arrays[k][n], y);
                                    }
                                    arrays[k - 1][i] = y;
                                    if(a==4 || i==0)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                    else if(a==3)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                    else if(a==2)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2 * (i / a)}");
                                    currentTextBlock.Text = arrays[k - 1][i].ToString();
                                }
                            }
                        }
                    }
                }
                else if (k % 2 == 1)
                { 
                    
                    for (int i = 0; i < Math.Pow(a, k - 1); i++)
                        {
                            for (int j = i * a; j < (i + 1) * a; j += a)
                            {
                                if (i % a == 0)
                                {
                                    int y = 100;
                                    for (int n = i * a; n < (i + 1) * a; n++)
                                    {
                                        y = Math.Min(arrays[k][n], y);
                                    }
                                    arrays[k - 1][i] = y;
                                    if(a==4 || i==0)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                    else if(a==3)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                    else if(a==2)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2 * (i / a)}");
                                    currentTextBlock.Text = arrays[k - 1][i].ToString();
                                    
                                }
                                else
                                {
                                    if (arrays[k - 1][i - 1] > arrays[k][j])
                                    {
                                        arrays[k - 1][i] = arrays[k][j];
                                        if(a==4 || i==0)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                        else if(a==3)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                        else if(a==2)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                        currentTextBlock.Text = arrays[k - 1][i].ToString();
                                        currentTextBlock.Foreground = Brushes.Red;
                                        for (int n = i * a + 1 ; n < (i + 1) * a; n++)
                                        {
                                            if (a == 4)
                                                currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1}");
                                            else if (a == 3)
                                            {
                                                if(n/9 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a }");
                                                if(n/9 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 4}");
                                                if(n/9 ==2) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 8}");
                                            }
                                            else if (a == 2)
                                            {
                                                if(n/4 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a +1}");
                                                if(n/4 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a +11}");
                                            }
                                            if (currentTextBlock != null)
                                                currentTextBlock.Foreground = Brushes.MediumSpringGreen;
                                        }
                                    }
                                    else
                                    {
                                        int y = 100;
                                        for (int n = i * a; n < (i + 1) * a; n++)
                                        {
                                            y = Math.Min(arrays[k][n], y);
                                        }
                                        arrays[k - 1][i] = y;   
                                        if(a==4 || i==0)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                        else if(a==3)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                        else if(a==2)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                        currentTextBlock.Text = arrays[k - 1][i].ToString();
                                    }
                                }
                            }
                        }
                    }
            }
        }

        public void MaxMinP(int[][] arrays)
        {
            _1.Text = "MAX";
            _2.Text = "MIN z<a";
            _3.Text = "MAX z>b";
            if(b == 2)
            {
                _2.Visibility = Visibility.Hidden;
                _3.Visibility = Visibility.Hidden;
            }
            if(b == 3)
            {
                _3.Visibility = Visibility.Hidden;
            }
            for (int k = b-1; k >= 1; k--)
            {
                if (k % 2 == 1)
                {
                    for (int i = (int)Math.Pow(a, k - 1) - 1; i >= 0; i--)
                    {
                        for (int j = (i + 1) * a - 1; j >= i * a; j -= a)
                        {
                            if (i % a == a-1)
                            {
                                int y = 0;
                                for (int n = (i + 1) * a - 1; n >= i * a ; n--)
                                {
                                    y = Math.Max(arrays[k][n], y);
                                }
                                arrays[k - 1][i] = y;
                                if(a==4 || i==0)
                                    currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                else if(a==3)
                                    currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                else if(a==2)
                                    currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                currentTextBlock.Text = arrays[k - 1][i].ToString();
                            }
                            else
                            {
                                if(i+1 < arrays[k - 1].Length && arrays[k - 1][i + 1] < arrays[k][j]) 
                                {
                                    arrays[k - 1][i] = arrays[k][j];
                                    if(a==4 || i==0)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                    else if(a==3)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                    else if(a==2)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                    currentTextBlock.Text = arrays[k - 1][i].ToString();
                                    currentTextBlock.Foreground = Brushes.Red;
                                    for (int n = (i + 1) * a - 2  ; n >= i * a; n--)
                                    {
                                        if (a == 4 )
                                            currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1}");
                                        else if (a == 3)
                                        {
                                            if(n/9 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a }");
                                            if(n/9 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 4}");
                                            if(n/9 ==2) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 8}");
                                        }
                                        else if (a == 2)
                                        {
                                            if(n/4 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 1}");
                                            if(n/4 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 11}");
                                        }
                                        if (currentTextBlock != null)
                                            currentTextBlock.Foreground = Brushes.MediumSpringGreen;
                                    }
                                }
                                else
                                {
                                    int y = 0;
                                    for (int n =(i + 1) * a - 1 ; n >= i * a; n--)
                                    {
                                        y = Math.Max(arrays[k][n], y);
                                    }
                                    arrays[k - 1][i] = y;
                                    if(a==4 || i==0)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                    else if(a==3)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                    else if(a==2)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2 * (i / a)}");
                                    currentTextBlock.Text = arrays[k - 1][i].ToString();
                                }
                            }
                        }
                    }
                }
                else if (k % 2 == 0)
                { 
                    
                    for (int i = (int)Math.Pow(a, k - 1) - 1 ; i >=0 ; i--)
                        {
                            for (int j = (i + 1) * a - 1 ; j >= i * a; j -= a)
                            {
                                if (i % a == a-1)
                                {
                                    int y = 100;
                                    for (int n = (i + 1) * a - 1; n >= i * a; n--)
                                    {
                                        y = Math.Min(arrays[k][n], y);
                                    }
                                    arrays[k - 1][i] = y;
                                    if(a==4 || i==0)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                    else if(a==3)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                    else if(a==2)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2 * (i / a)}");
                                    currentTextBlock.Text = arrays[k - 1][i].ToString();
                                    
                                }
                                else
                                {
                                    if(i+1 < arrays[k - 1].Length && arrays[k - 1][i + 1] > arrays[k][j]) 
                                    {
                                        arrays[k - 1][i] = arrays[k][j];
                                        if(a==4 || i==0)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                        else if(a==3)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                        else if(a==2)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                        currentTextBlock.Text = arrays[k - 1][i].ToString();
                                        currentTextBlock.Foreground = Brushes.Red;
                                        for (int n = (i + 1) * a - 2  ; n >= i * a; n--)
                                        {
                                            if (a == 4)
                                                currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1}");
                                            else if (a == 3)
                                            {
                                                if(n/9 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a }");
                                                if(n/9 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 4}");
                                                if(n/9 ==2) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 8}");
                                            }
                                            else if (a == 2)
                                            {
                                                if(n/4 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a +1}");
                                                if(n/4 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a +11}");
                                            }
                                            if (currentTextBlock != null)
                                                currentTextBlock.Foreground = Brushes.MediumSpringGreen;
                                        }
                                    }
                                    else
                                    {
                                        int y = 100;
                                        for (int n = (i + 1) * a - 1 ; n >= i * a; n--)
                                        {
                                            y = Math.Min(arrays[k][n], y);
                                        }
                                        arrays[k - 1][i] = y;   
                                        if(a==4 || i==0)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                        else if(a==3)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                        else if(a==2)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                        currentTextBlock.Text = arrays[k - 1][i].ToString();
                                    }
                                }
                            }
                        }
                    }
            }
        }

        public void MinMaxP(int[][] arrays)
        {
            _1.Text = "MIN";
            _2.Text = "MAX z>b";
            _3.Text = "MIN z<a";
            if(b == 2)
            {
                _2.Visibility = Visibility.Hidden;
                _3.Visibility = Visibility.Hidden;
            }
            if(b == 3)
            {
                _3.Visibility = Visibility.Hidden;
            }
            for (int k = b-1; k >= 1; k--)
            {
                if (k % 2 == 0)
                {
                    for (int i = (int)Math.Pow(a, k - 1) - 1 ; i >=0 ; i--)
                    {
                        for (int j = (i + 1) * a - 1; j >= i * a; j -= a)
                        {
                            if (i % a == a - 1)
                            {
                                int y = 0;
                                for (int n = (i + 1) * a - 1 ; n >= i * a; n--)
                                {
                                    y = Math.Max(arrays[k][n], y);
                                }
                                arrays[k - 1][i] = y;
                                if(a==4 || i==0)
                                    currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                else if(a==3)
                                    currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                else if(a==2)
                                    currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                currentTextBlock.Text = arrays[k - 1][i].ToString();
                            }
                            else
                            {
                                if(i+1 < arrays[k - 1].Length && arrays[k - 1][i + 1] < arrays[k][j]) 
                                {
                                    arrays[k - 1][i] = arrays[k][j];
                                    if(a==4 || i==0)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                    else if(a==3)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                    else if(a==2)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                    currentTextBlock.Text = arrays[k - 1][i].ToString();
                                    currentTextBlock.Foreground = Brushes.Red;
                                    for (int n = (i + 1) * a - 2  ; n >= i * a; n--)
                                        {
                                            if (a == 4)
                                                currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1}");
                                            else if (a == 3)
                                            {
                                                if(n/9 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a }");
                                                if(n/9 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 4}");
                                                if(n/9 ==2) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 8}");
                                            }
                                            else if (a == 2)
                                            {
                                                if(n/4 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a +1}");
                                                if(n/4 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a +11}");
                                            }
                                            if (currentTextBlock != null)
                                                currentTextBlock.Foreground = Brushes.MediumSpringGreen;
                                        }
                                }
                                else
                                {
                                    int y = 0;
                                    for (int n = (i + 1) * a; n >=i * a ; n--)
                                    {
                                        y = Math.Max(arrays[k][n], y);
                                    }
                                    arrays[k - 1][i] = y;
                                    if(a==4 || i==0)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                    else if(a==3)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                    else if(a==2)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2 * (i / a)}");
                                    currentTextBlock.Text = arrays[k - 1][i].ToString();
                                }
                            }
                        }
                    }
                }
                else if (k % 2 == 1)
                { 
                    
                    for (int i = (int)Math.Pow(a, k - 1) -1 ; i >=0; i--)
                        {
                            for (int j = (i + 1) * a - 1; j >=i * a ; j -= a)
                            {
                                if (i % a == a-1)
                                {
                                    int y = 100;
                                    for (int n = (i + 1) * a - 1; n >=i * a ; n--)
                                    {
                                        y = Math.Min(arrays[k][n], y);
                                    }
                                    arrays[k - 1][i] = y;
                                    if(a==4 || i==0)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                    else if(a==3)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                    else if(a==2)
                                        currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2 * (i / a)}");
                                    currentTextBlock.Text = arrays[k - 1][i].ToString();
                                    
                                }
                                else
                                {
                                if(i+1 < arrays[k - 1].Length && arrays[k - 1][i + 1] > arrays[k][j]) 
                                    {
                                        arrays[k - 1][i] = arrays[k][j];
                                        if(a==4 || i==0)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                        else if(a==3)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                        else if(a==2)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                        currentTextBlock.Text = arrays[k - 1][i].ToString();
                                        currentTextBlock.Foreground = Brushes.Red;
                                        for (int n = (i + 1) * a - 2  ; n >= i * a; n--)
                                        {
                                            if (a == 4)
                                                currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1}");
                                            else if (a == 3)
                                            {
                                                if(n/9 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a }");
                                                if(n/9 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 4}");
                                                if(n/9 ==2) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a + 8}");
                                            }
                                            else if (a == 2)
                                            {
                                                if(n/4 == 0) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a +1}");
                                                if(n/4 ==1) currentTextBlock = (TextBlock)FindName($"t{k + 1}_{n + 1 + n / a +11}");
                                            }
                                            if (currentTextBlock != null)
                                                currentTextBlock.Foreground = Brushes.MediumSpringGreen;
                                        }
                                    }
                                    else
                                    {
                                        int y = 100;
                                        for (int n = (i + 1) * a - 1; n >=i * a ; n--)
                                        {
                                            y = Math.Min(arrays[k][n], y);
                                        }
                                        arrays[k - 1][i] = y;   
                                        if(a==4 || i==0)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1}");
                                        else if(a==3)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+i/a}");
                                        else if(a==2)
                                            currentTextBlock = (TextBlock)FindName($"t{k}_{i + 1+2*(i/a)}");
                                        currentTextBlock.Text = arrays[k - 1][i].ToString();
                                    }
                                }
                            }
                        }
                    }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
