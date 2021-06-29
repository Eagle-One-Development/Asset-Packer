using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapPacker
{

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            AppForm app = new AppForm();
            DialogResult result = app.ShowDialog();
            
            if (app == null || result == DialogResult.Cancel)
            {
                System.Windows.Forms.Application.Exit();
            }


        }
    }
}
