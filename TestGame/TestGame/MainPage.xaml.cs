using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestGame
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int nNowStage;
        public MainPage()
        {
            InitializeComponent();

            nNowStage = 0;
        }

        public void SetGrid(int stage)
        {
            nNowStage = stage;
            StackGameGird.Children.Clear();

            Grid makegrid = new Grid();
            //칸 사이의 공간을 없애려면 
            //makegrid.RowSpacing = 0;
            //makegrid.ColumnSpacing = 0;
            //makegrid.Padding = new Thickness(0, 0, 0, 0);
            //makegrid.Margin = new Thickness(0, 0, 0, 0);

            makegrid.VerticalOptions = LayoutOptions.FillAndExpand;
            
            int nGridFinition = (stage / 3) + 2;

            if (nGridFinition > 5)
            {
                nGridFinition = 5;
            }

            for (int i = 0; i < nGridFinition; ++i)
            {
                makegrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                makegrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            Random random = new Random();

            int nRendom = random.Next(nGridFinition * nGridFinition);

            Color color = GetMakeColor();

            double dc = 0;
            dc = 255 * color.R;
            int nR = GetChageColor((int)dc);

            dc = 255 * color.G;
            int nG = GetChageColor((int)dc);

            dc = 255 * color.B;
            int nB = GetChageColor((int)dc);

            Color cColor = Color.FromRgb(nR, nG, nB);


            for (int i = 0; i < nGridFinition; ++i)
            {
                for (int j = 0; j < nGridFinition; ++j)
                {
                    Button button = new Button();

                    button.HorizontalOptions = LayoutOptions.FillAndExpand;

                    if (nRendom == (nGridFinition * i) + j)
                    {
                        button.BackgroundColor = cColor;
                    }
                    else
                    {
                        button.BackgroundColor = color;
                    }

                    makegrid.Children.Add(button, i, j);
                }
            }

            StackGameGird.Children.Add(makegrid);
        }

        Color GetMakeColor()
        {
            Random random = new Random();

            int nR = random.Next(255);
            int nG = random.Next(255);
            int nB = random.Next(255);

            Color color = Color.FromRgb(nR, nG, nB);

            return color;
        }

        int GetChageColor(int c)
        {
            int rate = 50 - nNowStage;

            if (rate <= 2)
            {
                rate = 2;
            }

            int dC = c;

            int min = 0;
            int max = 255;

            int rateC = dC * rate / 100;

            min = dC - rateC;
            max = dC + rateC;

            if (min < 0)
            {
                min = 0;
            }

            if (max > 255)
            {
                max = 255;
            }

            Random random = new Random();

            int nR = random.Next(255);

            return random.Next(min, max);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            lbl_text.Text = "색이 다른 블록을 찾으세요";
            SetGrid(++nNowStage);
        }
    }
}
