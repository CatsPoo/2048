using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using System;

namespace _2048
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Image[,] Board = new Image[4, 4];
        private int[,] place = new int[4, 4];
        private Random rnd = new Random();
        private int EndRow, EndCol, mul = 1;

        private long Score = 0,BigestScore=0,StartHighScore=0;
        private bool Win = false,Connect=true;
        string Path = Environment.CurrentDirectory;     
        EnterNamexaml EN = new EnterNamexaml();
        //Client Client1 = new Client("84.108.39.139",22);

        public MainWindow()
        {
            InitializeComponent();
            Board[0, 0] = image1; //build the arry of image
            Board[0, 1] = image2;
            Board[0, 2] = image3;
            Board[0, 3] = image4;
            Board[1, 0] = image5;
            Board[1, 1] = image6;
            Board[1, 2] = image7;
            Board[1, 3] = image8;
            Board[2, 0] = image9;
            Board[2, 1] = image10;
            Board[2, 2] = image11;
            Board[2, 3] = image12;
            Board[3, 0] = image13;
            Board[3, 1] = image14;
            Board[3, 2] = image15;
            Board[3, 3] = image16;
            this.GameOn();
        }

        private string GetName()
        {
            string name = "";
            EN.ShowDialog();
            while (name == "" || name == "Enter your name")
                name = EN.GetName();
            return this.EN.GetName();
        }

        private void GameOn() //start new game
        {
            //if (this.Connect)
            //{
            //    this.Connect = false;
            //    this.Client1.ConnectToServer();
            //}
            //while (this.Client1.Recive == "") ;
            //this.BigestScore = Client1.Get_BigestScore();
            this.StartHighScore = this.BigestScore;
            this.Score = 0;
            this.mul = 1;
            this.Win = false;
            this.InitBoard(); //organize the board
            this.RandomPlace();// set an rendom place as 2 or 4
            this.RandomPlace();

            //this.Print(); //print the board
        }

        private void InitBoard() //orgnize the board
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    place[i, j] = 0; //set the vule of the place to 0 (empty image)
                }
            }
            this.Print();
        }

        private void RandomPlace() //set an rendom place
        {
            int Row, Col;
            if (this.BoardIsFull() == false && this.CanMove() == true) //if have a free place
            {
                do
                {
                    Row = rnd.Next(0, 4); //random number from 0 to 3
                    Col = rnd.Next(0, 4);
                } while (this.place[Row, Col] != 0);// until find AnchoredBlock available place
                int num = rnd.Next(0, 2); //random number form 0 to 1
                if (num == 0)
                    place[Row, Col] = 2;
                else
                    place[Row, Col] = 4;
                this.Print();
            }

        }

        private void SetImage(Image i, int x) //convert beteewn the number o the image
        {
            switch (x)
            {
                case 2:
                    i.Source = (ImageSource)Convert(Properties.Resources._2); //damn left to right
                    break;
                case 4:
                    i.Source = (ImageSource)Convert(Properties.Resources._4); //damn left to right
                    break;
                case 8:
                    i.Source = (ImageSource)Convert(Properties.Resources._8); //damn left to right
                    break;
                case 16:
                    i.Source = (ImageSource)Convert(Properties.Resources._16); //damn left to right
                    break;
                case 32:
                    i.Source = (ImageSource)Convert(Properties.Resources._32); //damn left to right
                    break;
                case 64:
                    i.Source = (ImageSource)Convert(Properties.Resources._64); //damn left to right
                    break;
                case 128:
                    i.Source = (ImageSource)Convert(Properties.Resources._128); //damn left to right
                    break;
                case 256:
                    i.Source = (ImageSource)Convert(Properties.Resources._256); //damn left to right
                    break;
                case 512:
                    i.Source = (ImageSource)Convert(Properties.Resources._512); //damn left to right
                    break;
                case 1024:
                    i.Source = (ImageSource)Convert(Properties.Resources._1024); //damn left to right
                    break;
                case 2048:
                    i.Source = (ImageSource)Convert(Properties.Resources._2048); //damn left to right
                    break;
                case 4096:
                    i.Source = (ImageSource)Convert(Properties.Resources._4096); //damn left to right
                    break;
                case 8192:
                    i.Source = (ImageSource)Convert(Properties.Resources._8192); //damn left to right
                    break;
                case -1:
                    i.Source = (ImageSource)Convert(Properties.Resources._1); //damn left to right
                    break;
                case 0:
                    i.Source = (ImageSource)Convert(Properties.Resources._2048_highscore); //damn left to right
                    break;
            }
        }

        private void Print() //print the board
        {
            Score2.Content = this.Score;
            Mul1.Content = "X" +this.mul;
            HighScore.Content = this.BigestScore;
            ///if (this.Client1.Connected())
               // label2.Content = "Connect to Server";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    SetImage(this.Board[i, j], this.place[i, j]);
                }

            }
        }

        private void RightMove()
        {
            bool AvailableRandom = false;
            for (int i = 0; i < this.place.GetLength(0); i++) //רץ על השורות במערך
            {
                for (int j = this.place.GetLength(1) - 2; j >= 0; j--) //רץ על הטורים במערך
                {
                    if (this.place[i, j] != -1)
                    {
                        if (this.place[i, j] == 0) // הקובייה ריקה
                            continue;
                        this.EndRow = i;
                        this.EndCol = j;
                        while (this.EndCol < this.place.GetLength(1) - 1 && place[EndRow, EndCol + 1] == 0)// אם בתחום המערך והקובייה ליד ריקה
                        {
                            this.EndCol++;
                            AvailableRandom = true;
                        }
                        if (this.EndCol == this.place.GetLength(1) - 1)
                            this.place[this.EndRow, this.EndCol] = this.place[i, j];

                        else if (place[this.EndRow, EndCol + 1] == -1) //אם יש קובייה חוסמת ליד
                            this.place[this.EndRow, this.EndCol] = this.place[i, j];

                        else if (place[this.EndRow, this.EndCol] != place[this.EndRow, this.EndCol + 1]) // שתי קוביות צמודות לא שוות
                            this.place[this.EndRow, this.EndCol] = this.place[i, j];

                        if (this.EndCol < this.place.GetLength(1) - 1 && place[this.EndRow, this.EndCol] == place[this.EndRow, this.EndCol + 1]) // אם שתי קוביות צמודות שוות
                        {
                            this.place[this.EndRow, this.EndCol + 1] *= 2; //מכפיל ארת הערך ב 2
                            this.place[this.EndRow, this.EndCol] = 0; // מוחק את קוביית המקור
                            Score += place[this.EndRow, this.EndCol + 1] * this.mul;
                            if (this.BigestScore < this.Score)
                                this.BigestScore = this.Score;
                            this.place[i, j] = 0;
                            AvailableRandom = true;
                            if (this.CheckFor2048())
                                this.WiningPage();
                        }
                        if (j != this.EndCol)
                            this.place[i, j] = 0;

                    }

                }
            }
            if (AvailableRandom)
            {
                this.Print();
                this.RandomPlace();
            }
        }

        private void LeftMove()
        {
            bool AvailableRandom = false ;
            for (int i = 0; i < this.place.GetLength(0); i++)
            {
                for (int j = 1; j <= this.place.GetLength(1) - 1; j++)
                {
                    if (this.place[i, j] != -1)
                    {
                        if (this.place[i, j] == 0)
                            continue;
                        this.EndRow = i;
                        this.EndCol = j;
                        while (this.EndCol > 0 && place[EndRow, EndCol - 1] == 0)
                        {
                            this.EndCol--;
                            AvailableRandom = true;
                        }
                        if (this.EndCol == 0)
                            this.place[this.EndRow, this.EndCol] = this.place[i, j];

                        else if (place[this.EndRow, EndCol - 1] == -1) //אם יש קובייה חוסמת ליד
                            this.place[this.EndRow, this.EndCol] = this.place[i, j];

                        else if (place[this.EndRow, this.EndCol] != place[this.EndRow, this.EndCol - 1])
                            this.place[this.EndRow, this.EndCol] = this.place[i, j];

                        if (this.EndCol > 0 && place[this.EndRow, this.EndCol] == place[this.EndRow, this.EndCol - 1])
                        {
                            this.place[this.EndRow, this.EndCol - 1] *= 2;
                            Score += place[this.EndRow, this.EndCol - 1] * this.mul;
                            if (this.BigestScore < this.Score)
                                this.BigestScore = this.Score;
                            this.place[this.EndRow, this.EndCol] = 0;
                            this.place[i, j] = 0;
                            AvailableRandom = true;
                            if (this.CheckFor2048())
                                this.WiningPage();
                        }
                        if (j != this.EndCol)
                            this.place[i, j] = 0;

                    }

                }
            }
            if (AvailableRandom)
            {
                this.Print();
                this.RandomPlace();
            }
        }

        private void DownMove()
        {
            bool AvailableRandom = false;
            for (int i = this.place.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = 0; j < this.place.GetLength(1); j++)
                {
                    if (this.place[i, j] != -1)
                    {
                        if (this.place[i, j] == 0)
                            continue;
                        this.EndRow = i;
                        this.EndCol = j;
                        while (this.EndRow < this.place.GetLength(0) - 1 && place[EndRow + 1, EndCol] == 0)
                        {
                            this.EndRow++;
                            AvailableRandom = true;
                        }
                        if (this.EndRow == this.place.GetLength(1) - 1)
                            this.place[this.EndRow, this.EndCol] = this.place[i, j];

                        else if (place[this.EndRow + 1, EndCol] == -1) //אם יש קובייה חוסמת ליד
                            this.place[this.EndRow, this.EndCol] = this.place[i, j];

                        else if (place[this.EndRow, this.EndCol] != place[this.EndRow + 1, this.EndCol])
                            this.place[this.EndRow, this.EndCol] = this.place[i, j];

                        if (this.EndRow < this.place.GetLength(0) - 1 && place[this.EndRow, this.EndCol] == place[this.EndRow + 1, this.EndCol])
                        {
                            this.place[this.EndRow + 1, this.EndCol] *= 2;
                            Score += place[this.EndRow + 1, this.EndCol] * this.mul;
                            if (this.BigestScore < this.Score)
                                this.BigestScore = this.Score;
                            this.place[this.EndRow, this.EndCol] = 0;
                            this.place[i, j] = 0;
                            AvailableRandom = true;
                            if (this.CheckFor2048())
                                this.WiningPage();
                        }
                        if (i != this.EndRow)
                            this.place[i, j] = 0;

                    }

                }
            }
            if (AvailableRandom)
            {
                this.Print();
                this.RandomPlace();
            }
        }

        private void UpMove()
        {
            bool AvailableRandom = false;
            for (int i = 1; i <= this.place.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < this.place.GetLength(1); j++)
                {
                    if (this.place[i, j] != -1)
                    {
                        if (this.place[i, j] == 0)
                            continue;
                        this.EndRow = i;
                        this.EndCol = j;
                        while (this.EndRow > 0 && place[EndRow - 1, EndCol] == 0)
                        {
                            this.EndRow--;
                            AvailableRandom = true;
                        }
                        if (this.EndRow == 0)
                            this.place[this.EndRow, this.EndCol] = this.place[i, j];

                        else if (place[this.EndRow - 1, EndCol] == -1) //אם יש קובייה חוסמת ליד
                            this.place[this.EndRow, this.EndCol] = this.place[i, j];

                        else if (place[this.EndRow, this.EndCol] != place[this.EndRow - 1, this.EndCol])
                            this.place[this.EndRow, this.EndCol] = this.place[i, j];

                        if (this.EndRow > 0 && place[this.EndRow, this.EndCol] == place[this.EndRow - 1, this.EndCol])
                        {
                            this.place[this.EndRow - 1, this.EndCol] *= 2;
                            Score += place[this.EndRow - 1, this.EndCol] * this.mul;
                            if (this.BigestScore < this.Score)
                                this.BigestScore = this.Score;
                            this.place[this.EndRow, this.EndCol] = 0;
                            this.place[i, j] = 0;
                            AvailableRandom = true;
                            if (this.CheckFor2048())
                                this.WiningPage();
                        }
                        if (i != this.EndRow)
                            this.place[i, j] = 0;

                    }

                }
            }
            if (AvailableRandom)
            {
                this.Print();
                this.RandomPlace();
            }
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            if (BoardIsFull() == false || this.CanMove() == true)
                this.RightMove();
            if (this.CheckFor2048() == true)
                this.WiningPage();
            if (this.CanMove() == false && this.BoardIsFull() == true)
                this.LosePage();
        }

        private void left_Click(object sender, RoutedEventArgs e)
        {
            if (BoardIsFull() == false || this.CanMove() == true)
                this.LeftMove();
            if (this.CheckFor2048() == true)
                this.WiningPage();
            if (this.CanMove() == false && this.BoardIsFull() == true)
                this.LosePage();
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (BoardIsFull() == false || this.CanMove() == true)
                this.DownMove();
            if (this.CheckFor2048() == true)
                this.WiningPage();
            if (this.CanMove() == false && this.BoardIsFull() == true)
                this.LosePage();
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (BoardIsFull() == false || this.CanMove() == true)
                this.UpMove();
            if (this.CheckFor2048() == true)
                this.WiningPage();
            if (this.CanMove() == false && this.BoardIsFull() == true)
                this.LosePage();
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Down))
                this.DownMove();
            if (Keyboard.IsKeyDown(Key.Up))
                this.UpMove();
            if (Keyboard.IsKeyDown(Key.Left))
                this.LeftMove();
            if (Keyboard.IsKeyDown(Key.Right))
                this.RightMove();
            if (this.CheckFor2048() == true)
                this.WiningPage();
            if (this.CanMove() == false && this.BoardIsFull() == true)
                this.LosePage();
        }

       private void button1_Click(object sender, RoutedEventArgs e)
        {
            int row, col, c = 0;
            this.mul++;
            do
            {
                row = rnd.Next(0, 4);
                col = rnd.Next(0, 4);
                c++;
            } while (this.place[row, col] != 0 && c < 16);
            if (c < 16)
            {
                this.place[row, col] = -1;
            }
            this.Print();
            if (this.CanMove() == false && this.BoardIsFull() == true)
                this.LosePage();

        }

        private bool BoardIsFull()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (this.place[i, j] == 0)
                        return false;
                }
            }
            return true;
        }

        private bool CanMove()
        {
            for (int i = 0; i < this.place.GetLength(0); i++)
            {
                for (int j = 1; j < this.place.GetLength(1); j++)
                {
                    if ((place[i, j] == place[i, j - 1] || place[i, j - 1] == 0) && place[i, j] != -1)
                        return true;
                }
            }
            for (int x = 0; x < this.place.GetLength(0) - 1; x++)
            {
                for (int y = 0; y < this.place.GetLength(1); y++)
                {
                    if ((place[x, y] == place[x + 1, y] || place[x + 1, y] == 0) && place[x, y] != -1)
                        return true;
                }
            }
            return false;
        }

        private bool CheckFor2048()
        {
            for (int i = 0; i < this.place.GetLength(0); i++)
            {
                for (int j = 0; j < this.place.GetLength(1); j++)
                {
                    if (this.place[i, j] == 2048 && this.Win == false)
                    {
                        this.Win = true;
                        return true;
                    }
                }

            }
            return false;
        }

        private void WiningPage()
        {
            image18.Visibility = Visibility.Visible;
            if (MessageBox.Show("Contnue play?", "You Win!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                image18.Visibility = Visibility.Hidden;
            else
            {
                if (MessageBox.Show("Want to play again?", "New Game?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    image18.Visibility = Visibility.Hidden;
                    this.GameOn();
                }
                else
                {
                    image18.Visibility = Visibility.Hidden;
                    Application.Current.Shutdown();
                }
            }
        }

        private void LosePage()
        {
            image19.Visibility = Visibility.Visible;
            if (this.StartHighScore < this.Score)
            {
                this.PassScoreToServer();

            }
            if (MessageBox.Show("Want to play again?", "New Game?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                image19.Visibility = Visibility.Hidden;
                this.GameOn();
            }
            else
            {
                image19.Visibility = Visibility.Hidden;
                Application.Current.Shutdown();
            }
        }

        public object Convert(object value)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)value).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            return image;
        }

        private void Window_Closed(object sender, EventArgs e)////////////////
        {
            if (this.StartHighScore < this.Score)
            {
                this.PassScoreToServer();
            }
            this.EN.Close();
            //this.Client1.Stop();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void  PassScoreToServer()
        {
            //this.Client1.Writer.WriteLine(this.BigestScore);
            //this.Client1.Writer.WriteLine(this.GetName());
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            this.GameOn();
        }

        private void ExitGame(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HighScoreClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming Soon...");
        }


    }
}
