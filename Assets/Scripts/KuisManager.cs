using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KuisManager : MonoBehaviour
{
    public Text soal;

    public List<Button> tombolJawaban;

    public List<string> operasi;

    public List<int> ListJawaban;
    public PlayerManager playerManager;
    public Events eventsManager;

    public int jawaban;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomSoal()
    {
        for (int i = 0; i < ListJawaban.Count; i++)
        {
            if (ListJawaban[i] == jawaban)
            {
                tombolJawaban[i].onClick.RemoveListener(playerManager.Revive);
            }
            else
            {
                tombolJawaban[i].onClick.RemoveListener(eventsManager.MainMenuKalah);
            }
        }
        ListJawaban.Clear();
        var angka1 = Random.Range(1, 100);
        var angka2 = Random.Range(1, 100);
        var operasiSoal = Random.Range(0, operasi.Count);
        if (operasiSoal == 0)
        {
            soal.text = angka1.ToString() + " + " + angka2.ToString() + " = ";
            jawaban = angka1 + angka2;
        }
        else
        {
            soal.text = angka1.ToString() + " - " + angka2.ToString() + " = ";
            jawaban = angka1 - angka2;
        }

        for (int i = 0; i < 2; i++)
        {
            var jawabanSalah = Random.Range(0, jawaban + 20);
            ListJawaban.Add(jawabanSalah);
        }
        
        var index = Random.Range(0, ListJawaban.Count + 1);
        ListJawaban.Insert(index, jawaban);
        Debug.Log(index);

        for (int i = 0; i < ListJawaban.Count; i++)
        {
            if (ListJawaban[i] == jawaban)
            {
                tombolJawaban[i].onClick.AddListener(playerManager.Revive);
            }
            else
            {
                tombolJawaban[i].onClick.AddListener(eventsManager.MainMenuKalah);
            }
            Debug.Log(tombolJawaban[i].GetComponentInChildren<TextMeshPro>());
            tombolJawaban[i].GetComponentInChildren<Text>().text = ListJawaban[i].ToString();
        }
    }
}
