using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\veriler.accdb");



        private void Form1_Load(object sender, EventArgs e)
        {

            timer1.Interval = 840000;
            timer1.Enabled = true;

            timer2.Interval = 900000;
            timer2.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            baglantim.Open();


            Random s = new Random();
            int sayi = s.Next(1000, 70000);

            OleDbCommand listele = new OleDbCommand("select * from film where kimlik= " + sayi + "", baglantim);
            OleDbDataReader okuma = listele.ExecuteReader();
            while (okuma.Read())
            {
                textBox3.Text = okuma["filmseolink"].ToString();

            }
            baglantim.Close();



        }


        private void button3_Click(object sender, EventArgs e)
        {

            string ad = "", sifre = "", link = "";

           

            ad = "";
            sifre = "";

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.pinterest.com/login");
            Thread.Sleep(3000);



            IWebElement userName = driver.FindElement(By.Name("id"));
            IWebElement password = driver.FindElement(By.Name("password"));

            IWebElement loginBtn = driver.FindElement(By.XPath("//*[@id='__PWS_ROOT__']/div[1]/div/div/div[3]/div/div/div[3]/form/div[5]/button"));




            Thread.Sleep(2000);
            userName.SendKeys(ad);
            Thread.Sleep(2000);
            password.SendKeys(sifre);
            Thread.Sleep(2000);
            loginBtn.Click();

            Thread.Sleep(3000);




            driver.Navigate().GoToUrl("https://tr.pinterest.com/pin-builder/");

            Thread.Sleep(3000);

            IWebElement sitedenkaydetBtn = driver.FindElement(By.XPath("//*[@id='__PWS_ROOT__']/div[1]/div[3]/div/div/div/div[2]/div[1]/div/div/div/div/div/div/div[2]/div[1]/div/div/div[2]/div/div/button"));

            Thread.Sleep(1500);

            sitedenkaydetBtn.Click();

            Thread.Sleep(1500);
            

            IWebElement adres = driver.FindElement(By.Id("pin-draft-website-link"));

            Thread.Sleep(1500);

            link = textBox3.Text;

            adres.SendKeys(link);

            Thread.Sleep(1500);

            IWebElement detay = driver.FindElement(By.XPath("//*[@id='__PWS_ROOT__']/div[1]/div[3]/div/div/div/div[2]/div[1]/div/div/div/div/div/div/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]"));

            Thread.Sleep(1500);

            detay.Click();

            Thread.Sleep(8000);

            string jsCommand = "" +
                "sayfa = document.querySelector('.Jea.XbT.gjz.mQ8.ujU.zI7.iyn.Hsu');" +
                "sayfa.scrollTo(0,sayfa.scrollHeight);" +
                "var sayfaSonu = sayfa.scrollHeight;" +
                "return sayfaSonu;";

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            var sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));


            while (true)
            {
                var son = sayfaSonu;
                Thread.Sleep(1000);
                sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));
                if (son == sayfaSonu)
                {
                    break;
                }
            }

            IReadOnlyCollection<IWebElement> filmler = driver.FindElements(By.CssSelector(".Yl-.MIw.Hb7"));

            foreach (IWebElement film in filmler)
            {
                Thread.Sleep(500);
                film.Click();
            }

            Thread.Sleep(1000);

            IWebElement paslasBtn = driver.FindElement(By.XPath(" //*[@id='__PWS_ROOT__']/div[1]/div[3]/div/div/div/div[2]/div[1]/div/div/div/div/div/div/div[2]/div[2]/button"));

            Thread.Sleep(1500);

            paslasBtn.Click();

            Thread.Sleep(1500);


            int sayi = 11;

            for (int i = 1; i < sayi; i++)
            {

                IWebElement yayinla = driver.FindElement(By.XPath("//*[@id='__PWS_ROOT__']/div[1]/div[3]/div/div/div/div[2]/div[1]/div/div/div['" + i + "']/div/div/div[1]/div[1]/div/div[2]/div/div/div/button[2]/div"));

                Thread.Sleep(2000);

                yayinla.Click();

                Thread.Sleep(2000);

                IWebElement kategorisec = driver.FindElement(By.XPath("//*[@id='__PWS_ROOT__']/div[1]/div[3]/div/div/div/div[2]/div[1]/div/div/div['" + i + "']/div/div/div[1]/div[1]/div/div[2]/div/div/div[2]/div/div/div/div/div/div/div/div/div[1]/div[2]/div[4]"));


                Thread.Sleep(2000);

                kategorisec.Click();

                Thread.Sleep(2000);

                IWebElement gndrBtn = driver.FindElement(By.XPath("//*[@id='__PWS_ROOT__']/div[1]/div[3]/div/div/div/div[2]/div[1]/div/div/div['" + i + "']/div/div/div[1]/div[1]/div/div[2]/div/div/div/button[2]/div"));

                Thread.Sleep(2000);

                gndrBtn.Click();

                Thread.Sleep(5000);





            }




            driver.Close();
            driver.Quit();



        }
    }
}
