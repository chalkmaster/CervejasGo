using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Vuforia
{

    public static class ObjectHandlerHelper
    {
        private static Dictionary<string, GameObject> _imgs;
        private static GameObject Qtd { get; set; }
        public static Dictionary<string, GameObject> Images
        {
            get { return _imgs ?? (_imgs = InitializeImages()); }
        }
        public static void Initilize()
        {
            Qtd = GameObject.Find("qtd");
            foreach (var image in Images)
                image.Value.SetActive(false);
        }
        public static Dictionary<string, GameObject> InitializeImages()
        {
            var list = new Dictionary<string, GameObject>();
            var allImages = Resources.FindObjectsOfTypeAll<RawImage>();
            foreach (var image in allImages)
                list.Add(image.name, image.gameObject);

            return list;
        }

        public static void IncrementQtd()
        {
            Qtd.GetComponent<Text>().text = ((int.Parse(Qtd.GetComponent<Text>().text) + 1).ToString());
        }

        public static void SetActive(string targetName)
        {
            var finalName = "ri" + targetName;
            if (Images.ContainsKey(finalName))
                Images[finalName].SetActive(true);
        }
    }
}