using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour
{

    public GameObject questprefab;
    public GameObject questpanel;
    public GameObject infopanel;

    public Quest quest1;
    public Quest quest2;
    public Quest quest3;

    public Text qtitle;
    public Text qdesc;

    public Text Status;

    public GameObject canvas;

    bool enableQuestUI = true;

    

    // void Start()
    // {
    //     List<Quest>activelist = QuestManager.Instance.activeQuests;

    //     Debug.Log("running");

    //     activelist.Add(quest1);
    //     //activelist.Add(quest2);
    //     activelist.Add(quest3);

    //     foreach(Quest q in  activelist){
    //         Debug.Log(q.name); 
    //         GameObject questInstance = Instantiate(questprefab);
    //         //questInstance.GetComponentInChildren<Text>().text = q.name;
    //         TMP_Text textComponent = questInstance.GetComponentInChildren<TMP_Text>();
    //         if(textComponent != null)
    //         {
    //             textComponent.text = q.name;
    //         }

    //         Button b = questInstance.GetComponentInChildren<Button>();
    //         b.onClick.AddListener(() => OnButtonClick(q));


            

    //         questInstance.transform.SetParent(questpanel.transform);

    //     }
    // }

    public void showQuestUI()
    {
        if(enableQuestUI)
        {

            List<Quest>activelist = QuestManager.Instance.activeQuests;
            foreach(Quest q in  activelist){
                Debug.Log(q.name); 
                GameObject questInstance = Instantiate(questprefab);
                //questInstance.GetComponentInChildren<Text>().text = q.name;
                TMP_Text textComponent = questInstance.GetComponentInChildren<TMP_Text>();
                if(textComponent != null)
                {
                    textComponent.text = q.name;
                }

                Button b = questInstance.GetComponentInChildren<Button>();
                b.onClick.AddListener(() => OnButtonClick(q));


                

                questInstance.transform.SetParent(questpanel.transform);

            }
        }
    }

    void EnableQuestUI()
    {
        canvas.SetActive(true);
    }

    void DisableQuestUI()
    {
        canvas.SetActive(false);
    }

    void OnButtonClick(Quest q)
    {
        qtitle.text = q.name;
        qdesc.text = q.description;

        if(q.isCompleted)
        {
            Status.text="Status:Completed";
        }
        else
            Status.text="Status:Incomplete";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
