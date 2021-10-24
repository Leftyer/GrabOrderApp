using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrabOrderApp
{
    public partial class AppMain : Form
    {
        public AppMain()
        {
            InitializeComponent();
            InitBrowser();
        }
        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            try
            {
                Cef.Initialize(new CefSettings());

                browser = new ChromiumWebBrowser("https://client.westcoal.com.cn")
                {
                    Parent = panel1,
                    Dock = DockStyle.Fill
                };
                browser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>(FrameEndFunc);
            }
            catch (Exception ex)
            {

            }
        }
        private void FrameEndFunc(object sender, FrameLoadEndEventArgs e)
        {
            //"document.getElementsByClassName('pa-1')[0].click();"

            //下面替换成你要调用html JS 方法的算法过程。 其中EvaluateScriptAsync为调用JS的方法
            //v-data-table__wrapper
            //string data = "参数";
            //string info = "test0624()"; //我的JS 方法是initValue
            //this.browser.EvaluateScriptAsync("document.getElementsByClassName('input-945').innerHTML=\"zxl\";document.getElementById('su').onclick = function(){}; "); 
            this.browser.EvaluateScriptAsync("var n=0;while (n<10){document.getElementsByClassName('pa-1')[0].click();n++;}");
        }
    }
}
