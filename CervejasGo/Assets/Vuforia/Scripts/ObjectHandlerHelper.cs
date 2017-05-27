using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Text;

namespace Vuforia
{

    public static class ObjectHandlerHelper
    {
        private static Dictionary<string, GameObject> _imgs;
        private static Text _qtd;
        public static Text Qtd { get { return _qtd ?? (_qtd = GameObject.Find("qtd").GetComponent<Text>()); } }
        private static GameObject _dados;
        private static List<string> _loadedTargets;
        private static bool _loaded = false;
        private static InputField txtNome;
        private static InputField txtEmail;
        private static InputField txtTelefone;
        private static InputField txtEndereco;
        private static Text lblSalvo;
        private static Button btnSalvar;


        public static Dictionary<string, GameObject> Images
        {
            get { return _imgs ?? (_imgs = InitializeImages()); }
        }
        public static void Initilize()
        {
            var a = Qtd;
            _loadedTargets = _loadedTargets ?? new List<string>();
            _dados = _dados ?? GameObject.Find("Dados");
            foreach (var image in Images)
                if(image.Key != "Wizard")
                    image.Value.SetActive(false);

            TryLoadData();
            _loaded = true;

            txtNome = txtNome ?? GameObject.Find("txtNome").GetComponent<InputField>();
            txtEmail = txtEmail ?? GameObject.Find("txtEmail").GetComponent<InputField>();
            txtTelefone = txtTelefone ?? GameObject.Find("txtTelefone").GetComponent<InputField>();
            txtEndereco = txtEndereco ?? GameObject.Find("txtEndereco").GetComponent<InputField>();

            lblSalvo = lblSalvo ?? GameObject.Find("lblSalvo").GetComponent<Text>();
            btnSalvar = btnSalvar ?? GameObject.Find("btnSalvar").GetComponent<Button>();            
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
            if (targetName == "LogoConfece" && Qtd.text != "82")
                return;

            var finalName = "ri" + targetName;
            if (Images.ContainsKey(finalName))
            {
                Images[finalName].SetActive(true);
                if (!_loadedTargets.Contains(targetName))
                {
                    _loadedTargets.Add(targetName);
                    IncrementQtd();
                }
                SaveCheckedTarget();
            }
            if (Qtd.text == "83")
            {
                _dados.SetActive(true);
                tryLoadUserData();

            }
        }

        public static void tryLoadUserData()
        {
            if (!File.Exists(Application.persistentDataPath + "/dados.txt"))
                return;

            var f = File.ReadAllText(Application.persistentDataPath + "/dados.txt");
            var data = f.Split('\n');
            var nome = data[0];
            var email = data[1];
            var telefone = data[2];
            var salvoEm = data[3];
            var endereco = data[4].Replace("@@@@@@", "\n");
            txtNome.text = nome;
            txtEmail.text = email;
            txtTelefone.text = telefone;
            txtEndereco.text = endereco;
            lblSalvo.text = "Dados salvos em " + salvoEm + " \n\n apresente esta tela para um dos organizadores do evento.";
            btnSalvar.gameObject.SetActive(false);
        }

        public static void TryLoadData()
        {
            if (!_loaded || !File.Exists(Application.persistentDataPath + "/checkedTargets.txt"))
                return;

            var f = File.ReadAllText(Application.persistentDataPath + "/checkedTargets.txt");
            var data = f.Split('\n');
            foreach (var item in data)
            {
                var finalName = "ri" + item;
                if (Images.ContainsKey(finalName))
                {
                    Images[finalName].SetActive(true);
                    if (!_loadedTargets.Contains(item))
                    {
                        _loadedTargets.Add(item);
                        IncrementQtd();
                    }
                }
            }
        }

        public static void SaveCheckedTarget()
        {
            File.WriteAllText(Application.persistentDataPath + "/checkedTargets.txt", string.Join("\n", _loadedTargets.ToArray()));
        }
    }
}