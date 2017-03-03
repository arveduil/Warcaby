using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;



namespace Warcaby
{
    public class Game 
    {
        public bool tura;
        public MainWindow o;
        public int selectedW;
        public int selectedK;
        public bool selectedQ;
        public Game(MainWindow win)
        {
            this.o = win;
            selectedK = -1;
            selectedW = -1;
            tura = new bool();
            tura = true;
            selectedQ = false;
           
           
        }

        public void click(int w, int k)
        {
            
            if (o.pos[w, k] == -1)
                return;
            
            
           
            
            if(tura)
            {
                //wybor czarnych powoduje return;
                if(o.pos[w,k]==2  || o.pos[w,k]==4)
                {
                    return;
                }

                //select
                if(o.pos[w,k]==1 || o.pos[w,k]==3)
                {
                    selectedW = w;
                    selectedK = k;
                    if (o.pos[w, k] == 3)
                    selectedQ = true;
                    return;

                }
              
                //dzialanie damki
                if (selectedQ)
                {
                    whiteQSelected(w, k);
                    return;
                }
                //normalne przesuniecie
                if (((w==selectedW-1 && k==selectedK-1) ||(w==selectedW-1 && k==selectedK+1)  ) && o.pos[w,k]==0 && o.pos[selectedW,selectedK]!=0)
                {
                    move(selectedW, selectedK, w, k);
                    selectedK = -1;
                    selectedW = -1;
                    tura = false;
                    finish();
                    return;
                }

                //bicie
                if((w == selectedW - 2 && k == selectedK - 2) &&( o.pos[selectedW-1,selectedK-1]==2 || o.pos[selectedW - 1, selectedK - 1] == 4))
                {
                    move(selectedW, selectedK, w, k);
                    beat(selectedW - 1, selectedK - 1);
                    selectedK = -1;
                    selectedW = -1;
                    tura = false;
                    finish();
                    return;
                }
                //bicie2
                if ((w == selectedW - 2 && k == selectedK +2) && (o.pos[selectedW - 1, selectedK +1] == 2 || o.pos[selectedW - 1, selectedK + 1] == 4))
                {
                    move(selectedW, selectedK, w, k);
                    beat(selectedW - 1, selectedK+1);
                    selectedK = -1;
                    selectedW = -1;
                    tura = false;
                    finish();
                    return;
                }

                //bicie3
                if ((w == selectedW + 2 && k == selectedK + 2) && (o.pos[selectedW + 1, selectedK + 1] == 2 || o.pos[selectedW + 1, selectedK + 1] == 4))
                {
                    move(selectedW, selectedK, w, k);
                    beat(selectedW + 1, selectedK + 1);
                    selectedK = -1;
                    selectedW = -1;
                    tura = false;
                    finish();
                    return;
                }
                //bicie4
                if ((w == selectedW + 2 && k == selectedK - 2) && (o.pos[selectedW + 1, selectedK - 1] == 2 || o.pos[selectedW + 1, selectedK - 1] == 4))
                {
                    move(selectedW, selectedK, w, k);
                    beat(selectedW + 1, selectedK - 1);
                    selectedK = -1;
                    selectedW = -1;
                    tura = false;
                    finish();
                    return;
                }


            }
            //czarni
            if (!tura)
            {
                //klik na biale
                if (o.pos[w, k] == 1 || o.pos[w, k] == 3)
                {
                    return;
                }

                //select
                if (o.pos[w, k] == 2 || o.pos[w, k] == 4)
                {
                    selectedW = w;
                    selectedK = k;
                    if (o.pos[w, k] == 4)
                        selectedQ = true;
                    return;

                }
             
                //zaznaczanie
                if (selectedK == -1 && selectedW == -1)
                {
                    selectedW = w;
                    selectedK = k;
                    return;
                }
                //ruch
                if (((w == selectedW +1 && k == selectedK +1) || (w == selectedW + 1 && k == selectedK - 1)) && ( o.pos[w, k] == 0 && o.pos[selectedW,selectedK]!=0))
                {
                    move(selectedW, selectedK, w, k);
                    selectedK = -1;
                    selectedW = -1;
                    tura = true;
                    finish();
                    return;
                }
                //dzialanie damki w drugiej metodzie
                if (selectedQ)
                {
                    blackQSelected(w,k);
                    return;
                }


                //zbijanie bialych
                if ((w == selectedW + 2 && k == selectedK + 2) &&( o.pos[selectedW + 1, selectedK + 1] == 1 || o.pos[selectedW + 1, selectedK + 1] == 3))
                {
                    move(selectedW, selectedK, w, k);
                    beat(selectedW +1, selectedK + 1);
                    selectedK = -1;
                    selectedW = -1;
                    tura = true;
                    finish();
                    return;
                }
                //bicie2
                if ((w == selectedW + 2 && k == selectedK - 2) && (o.pos[selectedW + 1, selectedK - 1] == 1 || o.pos[selectedW + 1, selectedK - 1] == 3))
                {
                    move(selectedW, selectedK, w, k);
                    beat(selectedW + 1, selectedK - 1);
                    selectedK = -1;
                    selectedW = -1;
                    tura = true;
                    finish();
                    return;
                }

                //bicie3
                if ((w == selectedW - 2 && k == selectedK - 2) && (o.pos[selectedW - 1, selectedK - 1] == 1 || o.pos[selectedW - 1, selectedK - 1] == 3))
                {
                    move(selectedW, selectedK, w, k);
                    beat(selectedW - 1, selectedK - 1);
                    selectedK = -1;
                    selectedW = -1;
                    tura = true;
                    finish();
                    return;
                }
                //bicie4
                if ((w == selectedW - 2 && k == selectedK + 2) && (o.pos[selectedW - 1, selectedK + 1] == 1|| o.pos[selectedW - 1, selectedK + 1] == 3))
                {
                    move(selectedW, selectedK, w, k);
                    beat(selectedW - 1, selectedK + 1);
                    selectedK = -1;
                    selectedW = -1;
                    tura = true;
                    finish();
                    return;
                }


            }



        }

        public void whiteQSelected(int w, int k)
        {
            bool isEnenmy = false;
            //wspolrzedne przeciwnika (jezeli to bicie)
            int enW, enK;
            enW = 0;
            enK = 0;
            int i = 0;

            //aby zablokować ruchy poziome i pionowe
            if (selectedW == w || selectedK == k)
                return;

            //decyzja co zrobic z ruchem
            if (w<selectedW && k<selectedK)
                   while(true) 
                {
                    i++;
                    if (o.pos[selectedW - i, selectedK - i] == 1 || o.pos[selectedW - i, selectedK - i] == 3)
                        return;
                    if(o.pos[selectedW - i, selectedK - i] ==2|| o.pos[selectedW - i, selectedK - i] ==4)
                    {
                        if (isEnenmy) return;
                        isEnenmy = true;
                        enW = selectedW - i;
                        enK = selectedK - i;
                    }
                    if (selectedW - i == w && selectedK -i == k)
                        break;

                }
            if (w > selectedW && k < selectedK)
                while (true)
                {
                    i++;
                    if (o.pos[selectedW + i, selectedK - i] == 1 || o.pos[selectedW + i, selectedK - i] == 3)
                        return;
                    if (o.pos[selectedW + i, selectedK - i] == 2 || o.pos[selectedW + i, selectedK - i] == 4)
                    {
                        if (isEnenmy) return;
                        isEnenmy = true;
                        enW = selectedW +i;
                        enK = selectedK - i;
                    }
                    if (selectedW + i == w && selectedK - i == k)
                        break;

                }
            if (w > selectedW && k > selectedK)
                while (true)
                {
                    i++;
                    if (o.pos[selectedW + i, selectedK + i] == 1 || o.pos[selectedW + i, selectedK + i] == 3)
                        return;
                    if (o.pos[selectedW + i, selectedK + i] == 2 || o.pos[selectedW + i, selectedK + i] == 4)
                    {
                        if (isEnenmy) return;
                        isEnenmy = true;
                        enW = selectedW + i;
                        enK = selectedK + i;
                    }
                    if (selectedW + i == w && selectedK + i == k)
                        break;

                }
            if (w <selectedW && k > selectedK)
                while (true)
                {
                    i++;
                    if (o.pos[selectedW - i, selectedK + i] == 1 || o.pos[selectedW - i, selectedK +i] == 3)
                        return;
                    if (o.pos[selectedW - i, selectedK + i] == 2 || o.pos[selectedW - i, selectedK +i] == 4)
                    {
                        if (isEnenmy) return;
                        isEnenmy = true;
                        enW = selectedW - i;
                        enK = selectedK + i;
                    }
                    if (selectedW - i == w && selectedK + i == k)
                        break;

                }

            if (isEnenmy)
            {
                beat(enW, enK);
                
            }
            move(selectedW, selectedK, w, k);
            selectedQ = false;
            selectedW = -1;
            selectedK = -1;
           
            tura = false;
            finish();
            
        }

        //analogicznie do bialej
        public void blackQSelected(int w, int k)
        {
            bool isEnenmy = false;
            int enW, enK;
            enW = 0;
            enK = 0;
            int i = 0;

            //aby zablokować ruchy poziome i pionowe
            if (selectedW == w || selectedK == k)
                return;

            //poszukiwania cwiartki
            if (w < selectedW && k < selectedK)
                while (true)
                {
                    i++;
                    
                    if (o.pos[selectedW - i, selectedK - i] == 2 || o.pos[selectedW - i, selectedK - i] == 4)
                        return;
                    if (o.pos[selectedW - i, selectedK - i] == 1 || o.pos[selectedW - i, selectedK - i] == 3)
                    {
                        if (isEnenmy) return;
                        isEnenmy = true;
                        enW = selectedW - i;
                        enK = selectedK - i;
                    }
                    if (selectedW - i == w && selectedK - i == k)
                        break;

                }
            if (w > selectedW && k < selectedK)
                while (true)
                {
                    i++;
                    if (o.pos[selectedW + i, selectedK - i] == 2|| o.pos[selectedW + i, selectedK - i] == 4)
                        return;
                    if (o.pos[selectedW + i, selectedK - i] == 1 || o.pos[selectedW + i, selectedK - i] == 3)
                    {
                        if (isEnenmy) return;
                        isEnenmy = true;
                        enW = selectedW + i;
                        enK = selectedK - i;
                    }
                    if (selectedW + i == w && selectedK - i == k)
                        break;

                }
            if (w > selectedW && k > selectedK)
                while (true)
                {
                    i++;
                    if (o.pos[selectedW + i, selectedK + i] == 2 || o.pos[selectedW + i, selectedK + i] == 4)
                        return;
                    if (o.pos[selectedW + i, selectedK + i] == 1|| o.pos[selectedW + i, selectedK + i] == 3)
                    {
                        if (isEnenmy) return;
                        isEnenmy = true;
                        enW = selectedW + i;
                        enK = selectedK + i;
                    }
                    if (selectedW + i == w && selectedK + i == k)
                        break;

                }
            if (w < selectedW && k > selectedK)
                while (true)
                {
                    i++;
                    if (o.pos[selectedW - i, selectedK + i] == 2 || o.pos[selectedW - i, selectedK + i] == 4)
                        return;
                    if (o.pos[selectedW - i, selectedK + i] == 1 || o.pos[selectedW - i, selectedK + i] == 3)
                    {
                        if (isEnenmy) return;
                        isEnenmy = true;
                        enW = selectedW - i;
                        enK = selectedK + i;
                    }
                    if (selectedW - i == w && selectedK + i == k)
                        break;

                }

            if (isEnenmy)
            {
                beat(enW, enK);

            }
            move(selectedW, selectedK, w, k);
            selectedQ = false;
            selectedW = -1;
            selectedK = -1;
         
            tura = true;
            finish();

        }


        //przenies figurem i zmien tlo
        public void move(int prevW, int prevK, int curW, int curK)
        {
            int what = o.pos[prevW, prevK];
            o.pos[prevW, prevK] = 0;
            o.makeEmpty(prevW, prevK);
            // selectedK = -1;
            //selectedW = -1;
            o.pos[curW, curK] = what;
            if(what==1)
            o.makeWhiteP(curW, curK);
            if (what == 2)
                o.makeBlackP(curW, curK);
            if (what == 3)
                o.makeWhiteQ(curW, curK);
            if (what == 4)
                o.makeBlackQ(curW, curK);
        }
        //zbij
        public void beat(int W,int K)
        {
            o.pos[W, K] = 0;
            o.makeEmpty(W, K);
        }


        
        public void finish()
        {
            int whiteCounter = 0;
            int blackCounter = 0;
            //sprawdza czy dodac damke
            for(int i=0;i<8;i++)
                for(int j=0;j<8;j++)
                {
                    if (o.pos[i, j] == 1 || o.pos[i, j] == 3)
                        whiteCounter++;
                    if (o.pos[i, j] == 2 || o.pos[i, j] == 4)
                        blackCounter++;
                }
            

            for (int i = 0; i < 8; i++)
            {
                if (o.pos[0, i] == 1)
                {
                    o.pos[0, i] = 3;
                    o.makeWhiteQ(0,i);
                }

                if (o.pos[7,i] == 2)
                {
                    o.pos[7, i] = 4;
                    o.makeBlackQ(7, i);
                }
            }
            if (tura)
                o.lab.Content = "Teraz ruch białych.";
            else
                o.lab.Content = "Teraz ruch czarnych.";

if (whiteCounter == 0)
                o.lab.Content = "CZARNI WYGRALI!!!";

            if (blackCounter == 0)
                o.lab.Content = "BIALI WYGRALI!!!";
        }
    }
}
