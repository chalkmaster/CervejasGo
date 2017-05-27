using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Vuforia
{

    public static class ObjectHandlerHelper
    {
        private static Dictionary<string, GameObject> _imgs;
        private static Text _qtd;
        private static Text Qtd { get { return _qtd ?? (_qtd = GameObject.Find("qtd").GetComponent<Text>()); } }
        public static Dictionary<string, GameObject> Images
        {
            get { return _imgs ?? (_imgs = InitializeImages()); }
        }
        public static void Initilize()
        {
            var a = Qtd;
            foreach (var image in Images)
                if(image.Key != "Wizard")
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
            Qtd.text = ((int.Parse(Qtd.text) + 1).ToString());
        }

        public static void SetActive(string targetName)
        {
            var finalName = "ri" + targetName;
            if (Images.ContainsKey(finalName))
                Images[finalName].SetActive(true);
        }
    }
}