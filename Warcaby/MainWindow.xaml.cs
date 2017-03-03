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

namespace Warcaby
{
    //Wartosc pol:
    //-1 pole biale
    //0 puste pole czarne
    //1 bialy pion
    //2 czarny pion
    //3 biala damka
    //4 czarna damka
 
    //Ja jestem ta osoba co sie pytala o tlo buttonow, dlatego u mmnie jest ta glupia zamiana  na niebieskie tlo
    public partial class MainWindow : Window
    {
       
        public int[,] pos;
        public Button[,] fields;
        public Label lab;
        public SolidColorBrush blackBrush= new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        public Game game;

        public MainWindow()
        {
            InitializeComponent();
            //Wczytuje pola
            fields = new Button[8,8] {
                { field00,  field01, field02, field03, field04, field05, field06, field07},
                { field10,  field11, field12, field13, field14, field15, field16, field17},
                { field20,  field21, field22, field23, field24, field25, field26, field27},
                { field30,  field31, field32, field33, field34, field35, field36, field37},
                { field40,  field41, field42, field43, field44, field45, field46, field47},
                { field50,  field51, field52, field53, field54, field55, field56, field57},
                { field60,  field61, field62, field63, field64, field65, field66, field67},
                { field70,  field71, field72, field73, field74, field75, field76, field77},
            };
         
            pos = new int[8, 8];
            //zeruje pozycje wszystkich
            for(int i=0;i<8;i++)
                for(int j=0;j<8;j++)
                {
                
                    pos[i, j] = -1;
                }
            placeBlack();
            placeWhite();
            makeBlackFields();
            lab = label;
            game = new Game(this);


        }



        private void buttonClick(object sender, RoutedEventArgs e)
        {
            Button chosen = (Button)sender;
          

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (chosen == fields[i, j]) game.click(i, j);

       }

       
        
        public void placeBlack()
        {
            for(int i=0;i<3;i++)
                for(int j=0;j<8;j++)
                {
                    if(i%2==0)
                    {
                        if (j % 2 == 0)
                        {
                            fields[i, j].Background = blackPawn();
                        
                            pos[i, j] = 2;
                           // pos[i, j] = blackP;

                        }
                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            fields[i, j].Background = blackPawn();
                            // blackPos[i, j] = blackP;
                            pos[i, j] = 2;
                        }
                    }
                }
        }
        //zrob czarne pola posrodku
        public void makeBlackFields()
        {
            for (int i = 3; i < 5; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            fields[i, j].Background = blackBrush;
                            pos[i, j] = 0;
                        }
                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            fields[i, j].Background = blackBrush;
                            pos[i, j] = 0;
                        }
                    }
                }
        }
        
        public void placeWhite()
        {
            for (int i = 5; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            fields[i, j].Background = whitePawn();
                           
                            pos[i, j] = 1;
                        }
                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            fields[i, j].Background = whitePawn();
                         
                            pos[i, j] = 1;
                        }
                    }
                }
        }

        public ImageBrush blackPawn()
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "\\images\\czarPion.png"));
            return myBrush;
        }

        public ImageBrush whitePawn()
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "\\images\\bialpion.png"));
            return myBrush;
        }
        public ImageBrush czarQueen()
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "\\images\\czarqueen.png"));
            return myBrush;
        }
        public ImageBrush whiteQueen()
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "\\images\\bialqueen.png"));
            return myBrush;
        }


        //metody ponizej zmieniaja tla buttonow
        public void makeEmpty(int i, int j)
        {
            fields[i, j].Background = blackBrush;
        }
        public void makeWhiteP(int i, int j)
        {
            fields[i, j].Background = whitePawn();
        }
        public void makeBlackP(int i, int j)
        {
            fields[i, j].Background = blackPawn();
        }
        public void makeWhiteQ(int i, int j)
        {
            fields[i, j].Background = whiteQueen();
        }
        public void makeBlackQ(int i, int j)
        {
            fields[i, j].Background = czarQueen();
        }

        private void mouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
