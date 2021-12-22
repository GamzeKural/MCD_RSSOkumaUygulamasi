using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MCD_RSSOkumaUygulamasi
{
    public partial class btn_getir : Form
    {
        public btn_getir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<Haber>
            List<Haber> Kayitlar = XMLCevir();
            lst_baslik.DataSource = Kayitlar;
        }

        private List<Haber> XMLCevir()
        {
            List<Haber> HaberKayitlari = new List<Haber>();
            XDocument XMLKaynak = XDocument.Load(txt_rssurl.Text);
            List<XElement> Rows = XMLKaynak.Descendants("item").ToList();
            foreach (XElement item in Rows)
            {
                Haber temp = new Haber();
                temp.Baslik = item.Element("title").Value;
                temp.Link = item.Element("link").Value;
                temp.Aciklama = item.Element("description").Value;
                HaberKayitlari.Add(temp);
            }
            return HaberKayitlari;
        }

        private void lst_baslik_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox SecilenDeger = (ListBox)sender;
            Haber SecilenHaber = (Haber)SecilenDeger.SelectedItem;
            web_browser.DocumentText = SecilenHaber.Aciklama;
        }
    }
}
