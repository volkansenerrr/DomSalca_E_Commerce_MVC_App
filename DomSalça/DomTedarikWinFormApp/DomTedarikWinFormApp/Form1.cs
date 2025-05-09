using DomTedarikWinFormApp.Models;
using DomTedarikWinFormApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DomTedarikWinFormApp
{

    public partial class Form1 : Form
    {
        private ProductService _productService = new ProductService();



        public Form1()
        {
            InitializeComponent();
            _productService = new ProductService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Örnek ürünleri ekle
            _productService.Add(new Product { ProductName = "Kalem", Price = 10.5m, Quantity = 100 });
            _productService.Add(new Product { ProductName = "Defter", Price = 20m, Quantity = 50 });
            _productService.Add(new Product { ProductName = "Silgi", Price = 5m, Quantity = 200 });


            ListeyiYenile();
        }



        private void RefreshProductList()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _productService.GetAll();
        }

        private void btn_urunEkle_Click(object sender, EventArgs e)
        {
            string name = tb_urunAdi.Text;
            decimal price = nud_fiyat.Value;
            int quantity = (int)nud_miktar.Value;

            Product newProduct = new Product
            {
                ProductName = name,
                Price = price,
                Quantity = quantity
            };

            _productService.Add(newProduct);
            ListeyiYenile(); // Bu metodu aşağıda yazacağız

            // Kutuları temizle
            tb_urunAdi.Clear();
            nud_fiyat.Value = 0;
            nud_miktar.Value = 0;
        }

        private void ListeyiYenile()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _productService.GetAll();
        }

        private void btn_listeyiYenile_Click(object sender, EventArgs e)
        {
            ListeyiYenile();
        }

        private void btn_seciliUrunuSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                _productService.Delete(index);
                ListeyiYenile();
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir ürün seçin.");
            }
        }

        private void btn_seciliUrunuGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;

                Product updatedProduct = new Product
                {
                    ProductName = tb_urunAdi.Text,
                    Price = nud_fiyat.Value,
                    Quantity = (int)nud_miktar.Value
                };

                _productService.Update(index, updatedProduct);
                ListeyiYenile();
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek bir ürün seçin.");
            }
        }

        private void btn_xmlAktar_Click(object sender, EventArgs e)
        {

            try
            {
                // Hedef yolu manuel belirtiyoruz — buraya web projenin App_Data yolu gelecek
                string hedefKlasor = @"C:\Users\I-Life\OneDrive\Desktop\Dosyalar\DomSalça\DomSalca_E_Commerce_MVC_App\DomSalca_E_Commerce_MVC_App\App_Data\";
                string hedefXmlDosyasi = Path.Combine(hedefKlasor, "urunler.xml");

                // Eğer App_Data klasörü yoksa oluştur
                if (!Directory.Exists(hedefKlasor))
                {
                    Directory.CreateDirectory(hedefKlasor);
                }

                // XML dışa aktarma işlemi
                _productService.ExportToXml(hedefXmlDosyasi);

                MessageBox.Show("Ürünler başarıyla App_Data klasörüne aktarıldı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

    }
}
