using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowChartV3.DiyagramVerileri;
using FlowChartV3.Exceptions;

namespace FlowChartV3
{

    class DiyagramKontrolleri
    {
        NesneYonetimi nesneYonetimi = new NesneYonetimi();
        VeriTabaniYonetimi veriTabaniYonetimi = new VeriTabaniYonetimi();

        private IVeriTabani[] tablolar = new IVeriTabani[5]
        {
            new Degiskenler(),
            new Islem(),
            new Pencere(),
            new Giris(),
            new Karar()
        };

        public DiyagramKontrolleri()
        {
            foreach (var diyagram in nesneYonetimi.GetDiyagramlar())
            {
                if (!string.IsNullOrEmpty(diyagram.Name) && ((string)diyagram.Tag != "basla" || (string)diyagram.Tag != "bitir"))
                {
                    Tip(diyagram.Tag.ToString(), diyagram.Name);
                }
            }
            StackOverFlowExceptionAra();
        }

        private void StackOverFlowExceptionAra()
        {
            foreach (var ok1 in nesneYonetimi.GetOklar())
            {
                if (!string.IsNullOrEmpty(ok1.Name))
                {
                    int sub;
                    sub = ok1.Name.IndexOf(" ");
                    string parca1 = ok1.Name.Substring(0, sub);
                    foreach (var ok2 in nesneYonetimi.GetOklar())
                    {
                        if (!string.IsNullOrEmpty(ok2.Name))
                        {
                            int sub2 = ok2.Name.IndexOf(" ");
                            string parca2 = ok2.Name.Substring(0, sub2);
                            if (ok1.Name != ok2.Name)
                            {
                                if (parca1.Equals(parca2))
                                {
                                    foreach (var diyagram in nesneYonetimi.GetDiyagramlar())
                                    {
                                        if (!string.IsNullOrEmpty(diyagram.Name))
                                        {
                                            if (parca1 == diyagram.Name)
                                            {
                                                if (diyagram.Tag.ToString() != "karar")
                                                {
                                                    throw new StackOverFlowException();
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Tip(string tip, string nesneNumarasi)
        {
            switch (tip)
            {
                case "islem":
                    VeriAl(tip, nesneNumarasi);
                    break;
                case "karar":
                    VeriAl(tip, nesneNumarasi);
                    break;
                case "pencere":
                    VeriAl(tip, nesneNumarasi);
                    break;


            }
        }
        private void VeriAl(string veriTipi, string nesneNumarasi)
        {
            int sayac = 0;
            switch (veriTipi)
            {
                case "islem":
                    veriTabaniYonetimi.veriTabani = new Islem { nesneNumarasi = nesneNumarasi };
                    var sonuc = veriTabaniYonetimi.Al();
                    if (sonuc.Any())
                    {
                        break;
                    }
                    veriTabaniYonetimi.veriTabani = new Degiskenler { nesneNumarasi = nesneNumarasi };
                    var sonuc2 = veriTabaniYonetimi.Al();
                    if (sonuc2.Any())
                    {
                        break;
                    }
                    else
                    {
                        throw new BosVeriException();
                    }    
                case "karar":
                    veriTabaniYonetimi.veriTabani = new Karar { nesneNumarasi = nesneNumarasi };
                    if (!veriTabaniYonetimi.Al().Any())
                    {
                        throw new BosVeriException();
                    }
                    break;
                case "pencere":
                    veriTabaniYonetimi.veriTabani = new Pencere { nesneNumarasi = nesneNumarasi };
                    if (!veriTabaniYonetimi.Al().Any())
                    {
                        throw new BosVeriException();
                    }
                    break;
            }
        }
    }
}
