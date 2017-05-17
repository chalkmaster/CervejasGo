using System;
using UnityEngine;

namespace Vuforia
{
    public static class ObjectHandlerHelper
    {
        public static void Show(string trackableName)
        {
            GameObject.Find(trackableName).SetActive(true);
            GameObject.Find("Checkin").SetActive(true);
            GameObject.Find("Button").SetActive(true);
        }
    }
}