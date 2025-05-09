using DomTedarikWinFormApp.Models;
using System;
using System.Collections.Generic;
using System.Xml;

namespace DomTedarikWinFormApp.Services
{
    public class ProductService
    {
        private List<Product> _products;

        
        public ProductService()
        {
            _products = new List<Product>();
        }

        
        /// <returns>Product listesi.</returns>
        public List<Product> GetAll()
        {
            return _products;
        }

        
        /// <param name="product">Eklenecek ürün.</param>
        public void Add(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _products.Add(product);
        }

        
        /// <param name="index">List içindeki indeks.</param>
        /// <param name="product">Güncellenmiş ürün.</param>
        public void Update(int index, Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (index < 0 || index >= _products.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _products[index] = product;
        }

        /// <param name="index">List içindeki indeks.</param>
        public void Delete(int index)
        {
            if (index < 0 || index >= _products.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _products.RemoveAt(index);
        }

        
        /// <param name="filePath">XML dosyası için tam yol.</param>
        public void ExportToXml(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Geçerli bir dosya yolu belirtin.", nameof(filePath));

            var settings = new XmlWriterSettings
            {
                Indent = true,
                NewLineOnAttributes = false
            };

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Products");

                foreach (var product in _products)
                {
                    writer.WriteStartElement("Product");
                    writer.WriteElementString("ProductName", product.ProductName);
                    writer.WriteElementString("Price", product.Price.ToString("F2"));
                    writer.WriteElementString("Quantity", product.Quantity.ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public void AddProduct(Product product)
        {
            Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return GetAll();
        }
    }
}
