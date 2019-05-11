using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using Devdog.General.ThirdParty.UniLinq;
using UnityEditor;
using UnityEngine.Assertions;

namespace Devdog.General.Editors
{
    public static class ProductRatingUtility
    {
        private const string ProductWebRequestUri = "http://devdog.io/unity/ratingfeedback.php";
        private const string RootPath = "Assets/Devdog/";

        public static ProductLookup[] GetAllProducts()
        {
            var folders = Directory.GetDirectories(RootPath).ToList();
            folders.Remove(RootPath + "General");
            folders.Remove(RootPath + "Internal");

            var installedProductNames = new List<ProductLookup>();
            foreach (var folder in folders)
            {
                installedProductNames.Add(new ProductLookup()
                {
                    name = folder.Replace(RootPath, ""),
                    niceName = ObjectNames.NicifyVariableName(folder.Replace(RootPath, ""))
                });
            }

            return installedProductNames.ToArray();
        }

        public static ProductLookup[] GetAllUnratedProducts()
        {
            return GetAllProducts().Where(o => o.hasReview == false).ToArray();
        }

        public static void SubmitProduct(ProductLookup product)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["rating"] = product.rating.ToString();
                values["message"] = product.feedback;
                values["product_name"] = product.name;
                values["email_address"] = product.email;

                client.UploadValues(ProductWebRequestUri, values);
            }
        }
    }
}
