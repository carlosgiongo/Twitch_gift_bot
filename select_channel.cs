using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;


namespace Twitch_Bot 
{
    public partial class select_channel : Form
    {
        public select_channel()
        {
            InitializeComponent();
        }

        private bool IsElementPresent(By by, IWebDriver driver)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            IWebDriver driver;
            driver = new FirefoxDriver();
            driver.Url = "https://twitch.tv/" + canal_box.Text;
            driver.FindElement(By.CssSelector("button[class='tw-align-items-center tw-align-middle tw-border-bottom-left-radius-medium tw-border-bottom-right-radius-medium tw-border-top-left-radius-medium tw-border-top-right-radius-medium tw-core-button tw-core-button--secondary tw-inline-flex tw-interactive tw-justify-content-center tw-overflow-hidden tw-relative']")).Click();
            driver.FindElement(By.Id("login-username")).SendKeys(textBox1.Text);
            driver.FindElement(By.Id("password-input")).SendKeys(textBox2.Text);
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div/div/div[1]/div/div/div[3]/form/div/div[3]/button")).Click();

            while (true)
            {
                if (IsElementPresent(By.ClassName("claimable-bonus__icon"), driver))
                {
                    driver.FindElement(By.ClassName("claimable-bonus__icon")).Click();
                }
                else
                {
                    System.Threading.Thread.Sleep(3000);
                }   
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}