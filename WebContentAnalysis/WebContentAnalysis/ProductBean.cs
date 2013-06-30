using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebContentAnalysis
{
    class ProductBean
    {
        string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        string shop;

        public string Shop
        {
            get { return shop; }
            set { shop = value; }
        }
        string shopAddress;

        public string ShopAddress
        {
            get { return shopAddress; }
            set { shopAddress = value; }
        }
        string saleType;

        public string SaleType
        {
            get { return saleType; }
            set { saleType = value; }
        }
        int saleCount;

        public int SaleCount
        {
            get { return saleCount; }
            set { saleCount = value; }
        }
        int judgecount;

        public int Judgecount
        {
            get { return judgecount; }
            set { judgecount = value; }
        }
        float sellPrice;

        public float SellPrice
        {
            get { return sellPrice; }
            set { sellPrice = value; }
        }
        float originalPrice;

        public float OriginalPrice
        {
            get { return originalPrice; }
            set { originalPrice = value; }
        }
        string smallImageUrl;

        public string SmallImageUrl
        {
            get { return smallImageUrl; }
            set { smallImageUrl = value; }
        }
        string productUrl;

        public string ProductUrl
        {
            get { return productUrl; }
            set { productUrl = value; }
        }
        string imagesFolder;

        public string ImagesFolder
        {
            get { return imagesFolder; }
            set { imagesFolder = value; }
        }

    }
}
