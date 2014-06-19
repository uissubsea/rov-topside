using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UisSubsea.IdentifyTheShipWreck
{
    public partial class IdentifyTheShipWreckView : Form
    {
        private List<String> selected;
        private String[,] ship;
        private int count0, count1, count2, count3, count4, count5, count6, count7, count8, count9, count10, count11,
              count12, count13, count14, count15, count16, count17, count18, count19, count20, count21, count22, count23;
        private Boolean hit;
        private int i = 4;
        private List<Int32> ok;
        private int count = 1;
        private int selectedCount;

        private String sault = "Sault Ste. Marie, Canada";
        private String detroit = "Detroit, Michigan";
        private String prop = "Propeller-driven bulk freighter";
        private String steam = "Steam-driven paddlewheel ship";
        private String wood = "Wooden sailing schooner";

        public IdentifyTheShipWreckView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           selected = new List<String>();
           addShipWreck();
           ok = new List<Int32>();
        }

        private void GetTypeOfShipwreck()
        {
            try
            {
                var button = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                selected.Add(button.Text.ToString());
            }
            catch (NullReferenceException) { }
             
        }
        private void GetCargo()
        {
            try
            {
                var button = groupBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                selected.Add(button.Text.ToString());
            }
            catch (NullReferenceException) { }
            
        }
        private void GetDate()
        {
            try
            {
                var button = groupBox3.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                selected.Add(button.Text.ToString());
            }
            catch (NullReferenceException) { }
           
        }
        private void GetHomePort()
        {
            try
            {
                var button = groupBox4.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                selected.Add(button.Text.ToString());
            }
            catch (NullReferenceException) { }
            
        }

        private void CheckSelectedValues()
        {
            try
            {
                for(int i = 0; i< selected.Count; i++)
                {
                    for(int j = 0; j<ship.Length/5; j++)
                    {                  
                        if (selected[i].Equals(ship[j, count].ToString()))
                        {
                        ok.Add(j);                       
                        }                                         
                    }
                    count++;
                }             
            
            ok.Sort();
            
            for( int i = 0; i<ok.Count; i++)
            {
                if(ok.ElementAt(i)==0)
                    count0++; 
                else if(ok.ElementAt(i)==1)
                    count1++;
                else if(ok.ElementAt(i)==2)
                    count2++;
                else if(ok.ElementAt(i)==3)
                    count3++;
                else if(ok.ElementAt(i)==4)
                    count4++;
                else if(ok.ElementAt(i)==5)
                    count5++;
                else if(ok.ElementAt(i)==6)
                    count6++;
                else if(ok.ElementAt(i)==7)
                    count7++;
                else if(ok.ElementAt(i)==8)
                    count8++;
                else if(ok.ElementAt(i)==9)
                    count9++;
                else if(ok.ElementAt(i)==10)
                    count10++;
                else if(ok.ElementAt(i)==11)
                    count11++;
                else if(ok.ElementAt(i)==12)
                    count12++;
                else if(ok.ElementAt(i)==13)
                    count13++;
                else if(ok.ElementAt(i)==14)
                    count14++;
                else if(ok.ElementAt(i)==15)
                    count15++;
                else if(ok.ElementAt(i)==16)
                    count16++;
                else if(ok.ElementAt(i)==17)
                    count17++;
                else if(ok.ElementAt(i)==18)
                    count18++;
                else if(ok.ElementAt(i)==19)
                    count19++;
                else if(ok.ElementAt(i)==20)
                    count20++;
                else if(ok.ElementAt(i)==21)
                    count21++;
                else if(ok.ElementAt(i)==22)
                    count22++;
                else if(ok.ElementAt(i)==23)
                    count23++;             
            }
            }
            catch (Exception) { }  

            checkResult();
        }

        private void checkResult()
        {    
            while(!hit)
            {
                    if (count0 == i)
                    {
                        for (int j = 0; j < 5; j++)
                        resulttxt.AppendText(ship[0, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }

                    if (count1 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[1, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count2 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[2, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count3 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[3, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count4 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[4, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count5 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[5, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count6 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[6, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count7 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[7, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count8 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[8, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count9 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[9, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count10 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[10, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count11 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[11, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count12 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[12, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count13 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[13, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count14 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[14, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }

                    if (count15 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[15, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }

                    if (count16 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[16, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count17 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[17, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }

                    if (count18 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[18, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count19 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[19, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count20 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[20, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count21 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[21, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count22 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[22, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                    if (count23 == i)
                    {
                        for (int j = 0; j < 5; j++)
                            resulttxt.AppendText(ship[23, j] + " ");
                        resulttxt.AppendText("\r\n");
                        hit = true;
                    }
                i--;
            }          
        }

        private void addShipWreck()
        {
            ship = new String[24, 5] 
            { {"A empleo", prop,"Grain","1912",detroit},
            {"Addison W", prop, "Coal", "1912", detroit},
            {"D Breaux", steam, "Coal", "1881", sault},
            {"Deidre E Sullivan", wood, "Coal", "1854",sault},
            {"Double R Rupan", steam, "Grain", "1873", sault},
            {"Erica Moulton", steam, "Grain", "1873", detroit},
            {"Fraser", prop, "Coal", "1909", sault},
            {"Gordon G", steam, "Coal", "1881", detroit},
            {"J Gray", wood,"Grain", "1854", detroit},
            {"J Hertzberg",prop,"Grain", "1912", sault},
            {"Jann Hooyer", wood, "Grain", "1854", sault},
            {"Jill M Zande", steam, "Coal", "1873", detroit},
            {"Justin M",prop, "Coal", "1912", sault},
            {"Kathryn L", steam,"Grain", "1881", sault},
            {"L Hebert", wood, "Coal", "1873", detroit},
            {"T Lunsford",prop, "Grain", "1909", detroit},
            {"Matthew E", steam, "Coal", "1873", sault},
            {"Rachel G", wood, "Grain", "1873", sault},
            {"S Gandulla", prop, "Coal", "1909", detroit},
            {"Sarah W", steam, "Grain", "1881", detroit},
            {"Stahr Liner", prop, "Grain", "1909", sault},
            {"T Sinclair", wood, "Coal", "1873", sault},
            {"Tony S", wood, "Coal", "1854", detroit},
            {"W Thompson", wood, "Grain", "1873", detroit}
            };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetTypeOfShipwreck();
            GetCargo();
            GetDate();
            GetHomePort();
            CheckSelectedValues();

            button1.Enabled = false;
            button2.Enabled = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetLists();
            resetHitsCount();
            
            hit = false;
            count = 1;
            i = 4;
            resulttxt.Clear();
            button1.Enabled = true;
            button2.Enabled = false;

                

        }
        private void resetLists()
        {

            if (ok.Count > 0)
                ok.RemoveRange(0, ok.Count);

            if (selected.Count > 0)
                selected.RemoveRange(0, selected.Count);

        }

        private void resetHitsCount()
        {
            count0 = count1 = count2 = count3 = count4 = count5 = count6 = count7 = count8 = count9 = count10 = count11 =
            count12 = count13 = count14 = count15 = count16 = count17 = count18 = count19 = count20 = count21 = count22 = count23 = 0;
        }
    }
}
