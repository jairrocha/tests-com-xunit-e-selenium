﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class TestFixture:IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public TestFixture()
        {
            Driver = new ChromeDriver(".");
        }
        
        //TearDown
        public void Dispose()
        {
            Driver.Close();
        }
    }
}
