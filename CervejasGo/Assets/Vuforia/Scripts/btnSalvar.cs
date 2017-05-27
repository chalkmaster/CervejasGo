using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class btnSalvar : MonoBehaviour {

    public Button yourButton;
    public InputField nome;
    public InputField email;
    public InputField telefone;
    public InputField endereco;

    // Use this for initialization
    void Start () {
        yourButton.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        var salvoEm = DateTime.Now.ToString();
        var sb = new StringBuilder();
        sb.AppendLine(nome.text);
        sb.AppendLine(email.text);
        sb.AppendLine(telefone.text);
        sb.AppendLine(salvoEm);
        sb.AppendLine(endereco.text.Replace("\n", "@@@@@@"));
        System.IO.File.WriteAllText(Application.persistentDataPath + "/dados.txt", sb.ToString());

        GameObject.Find("lblSalvo").GetComponent<Text>().text = "Dados salvos em " + salvoEm + " \n\n apresente esta tela para um dos organizadores do evento.";
        yourButton.gameObject.SetActive(false);
    }
}
