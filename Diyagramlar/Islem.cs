using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FlowChartV3.Diyagramlar
{
    class Islem:INesneler
    {
        Kontroller kontroller = new Kontroller();
        public PictureBox Ekle()
        {
            PictureBox diyagram = new PictureBox();
            diyagram.Width = 75;
            diyagram.Height = 75;
            diyagram.Location = new Point(250, 250);
            diyagram.Image = Image.FromFile("..\\..\\Resimler\\Diyagramlar\\islem.png");
            diyagram.Tag = "islem";
            diyagram.MouseDown += kontroller.MouseDown;
            diyagram.MouseMove += kontroller.MouseMove;
            diyagram.MouseUp += kontroller.MouseUp;
            diyagram.MouseClick += kontroller.MouseClick;
            diyagram.MouseDoubleClick += kontroller.MouseDoubleClick;
            kontroller.diyagram = diyagram;
            return diyagram;
            
        }

        public PictureBox Sil()
        {
            throw new NotImplementedException();
        }
    }
}
