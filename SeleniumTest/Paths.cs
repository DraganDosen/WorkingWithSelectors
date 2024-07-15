using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    public static class Paths
    {
        public static string pathToDriver = "C:\\Users\\draga\\Downloads\\edgedriver_win64 (2)\\msedgedriver.exe";
        public static string footer = "//*[@id=\"ups-footer\"]/div[2]/div/p";
        public static string span= "//*[@id=\"__tealiumImplicitmodal\"]/div/button/span[1]";
        public static string trackLink = "//*[@id=\"ups-footer_thisSiteLinks\"]/li[1]/a";
        public static string shippingLink = "//*[@id=\"ups-footer_thisSiteLinks\"]/li[2]/a";
        public static string logoPath = "//*[@id=\"ups-header_logo\"]/img";
        public static string WebSitePath = "https://www.ups.com/us/en/Home.page";
        public static string LambdaSitePath = "https://www.lambdatest.com/";
        public static string platformPath = "Platform";
        public static string enterprizePath = "//*[@id=\"header\"]/nav/div/div/div[2]/div/div/div[1]/div[2]/button";
        public static string dropdownElement = "//*[@id=\"header\"]/nav/div/div/div[2]/div/div/div[1]/div[2]/div/div/div/div/div/div/ul/li[2]/a/div[2]/p[2]";
        public static string checkPlatformPage = "//*[@id=\"__next\"]/div[1]/div[1]/div/div/h1";
        public static string checkEnterprize = "//*[@id=\"__next\"]/div[1]/section[1]/div/div/div[1]/h1";
        public static string checkPlatformText = "Unified Digital Experience Testing Cloud";
        public static string checkEnterprizeText = "E\r\n3\r\n- Enterprise Execution Environment On Cloud";
        public static string alertPath = "https://www.lambdatest.com/selenium-playground/javascript-alert-box-demo ";
        public static string alerTbutton = "//*[@id=\"__next\"]/section[3]/div/div/div/div[1]/p/button";
        public static string titleHandling = "https://codepen.io/fidabrj/pen/NWYeaqG";
        public static string dropdownlink = "https://www.lambdatest.com/selenium-playground/select-dropdown-demo";
        public static string dropdown = "select-demo";
        public static string dropdown_xpath = "//*[@id=\"select-demo\"]/option[4]";
        public static string css_link = "https://bstackdemo.com/";
        public static string css_id = "#offers";
        public static string css_id_a = "a[id='offers']";//xpath ="//*[@id="offers"]";
        public static string css_class = "a[class='Navbar_logo__26S5Y']"; // or a[class^='Navbar_logo_']
    }

}