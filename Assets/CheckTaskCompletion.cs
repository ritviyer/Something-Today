using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTaskCompletion : MonoBehaviour
{
    [SerializeField] int taskID;
    [SerializeField] Sprite completed;
    [SerializeField] Sprite notCompleted;

    private void OnEnable()
    {
        int isComplete = PlayerPrefs.GetInt(taskID.ToString(), 0);
        if (isComplete == 0)
        {
            GetComponent<Image>().sprite = notCompleted;
        }
        else
        {
            GetComponent<Image>().sprite = completed;
        }
    }
}
