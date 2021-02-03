using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject activitMenu;
    [SerializeField] GameObject taskMenu;
    
    [SerializeField] GameObject taskPanel;
    [SerializeField] Text taskText;
    [SerializeField] Text subTaskText;
    [SerializeField] GameObject doneButton;
    [SerializeField] GameObject undoButton;
    
    int currentTaskOpened;

    private void Update()
    {
        if(Time.frameCount % 3 == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoBack();
            }
        }
    }
    public void GoToActivityMenu()
    {
        mainMenu.SetActive(false);
        taskMenu.SetActive(false);
        activitMenu.SetActive(true);
    }
    public void GoToMainMenu()
    {
        mainMenu.SetActive(true);
        activitMenu.SetActive(false);
    }
    public void GoToThisTask(int taskNum)
    {
        currentTaskOpened = taskNum;

        string taskString = " ";
        string subString = " ";
        Color backgroundColor = new Color32();

        switch (currentTaskOpened)
        {
            case 0:
                taskString = "TRY TO BREAK A WORLD RECORD";
                backgroundColor = new Color32(234, 15, 15, 255);
                break;
            case 1:
                taskString = "SELL THINGS YOU DO NOT USE ANYMORE ON OLX OR QUIKR";
                backgroundColor = new Color32(250, 153, 23, 255);
                break;
            case 2:
                taskString = "LEARN SOME KEYBOARD SHORTCUTS";
                subString = "Ctrl + n";
                backgroundColor = new Color32(39, 118, 132, 255);
                break;
            case 3:
                taskString = "LEARN A MAGIC TRICK";
                backgroundColor = new Color32(255, 199, 53, 255);
                break;
            case 4:
                taskString = "WRITE AND POST A LETTER TO SOMEONE";
                backgroundColor = new Color32(118, 105, 86, 255);
                break;
            case 5:
                taskString = "CALL AN OLD FRIEND YOU HAVEN'T SPOKEN TO IN LONG";
                backgroundColor = new Color32(255, 95, 88, 255);
                break;
            case 6:
                taskString = "CLEAN YOUR ROOM";
                subString = "DO IT!" + System.Environment.NewLine + "DO IT!" + System.Environment.NewLine + "DO IT!";
                backgroundColor = new Color32(51, 225, 255, 255);
                break;
            case 7:
                taskString = "TEXT SOMEONE YOU WANT TO MEND THINGS WITH";
                subString = "*This is the sign you were waiting for.";
                backgroundColor = new Color32(159, 196, 179, 255);
                break;
            case 8:
                taskString = "EMAIL SOMEONE YOU ADMIRE";
                backgroundColor = new Color32(35, 232, 18, 255);
                break;
            case 9:
                taskString = "PAINT A PICTURE OF YOUR FAVORITE CHILDHOOD MEMORY";
                backgroundColor = new Color32(255, 95, 88, 255);
                break;
            case 10:
                taskString = "HOST A VIRTUAL GAME NIGHT WITH FRIENDS";
                backgroundColor = new Color32(248, 247, 200, 255);
                break;
            case 11:
                taskString = "PRINT POSTERS YOU LIKE AND PUT THEM ON YOUR WALL";
                backgroundColor = new Color32(250, 153, 23, 255);
                break;
            case 12:
                taskString = "DRAW IMAGINARY CREATURES";
                backgroundColor = new Color32(189, 100, 58, 255);
                break;
            case 13:
                taskString = "WATCH A TED TALK";
                backgroundColor = new Color32(227, 185, 65, 255);
                break;
            case 14:
                taskString = "UPLOAD AN OLD PHOTO ON YOUR SOCIAL MEDIA";
                backgroundColor = new Color32(255, 95, 88, 255);
                break;
            case 15:
                taskString = "FREE UP SPACE ON YOUR PHONE";
                backgroundColor = new Color32(15, 217, 132, 255);
                break;
            case 16:
                taskString = "UPCYCLE";
                backgroundColor = new Color32(192, 214, 228, 255);
                break;
            case 17:
                taskString = "READ A BOOK THAT'S BEEN SITTING ON YOUR SHELF";
                backgroundColor = new Color32(248, 247, 200, 255);
                break;
            case 18:
                taskString = "SLEEPzzz";
                backgroundColor = new Color32(51, 153, 255, 255);
                break;
            case 19:
                taskString = "SEPARATE YOUR OLD CLOTHES FOR DONATION";
                backgroundColor = new Color32(232, 15, 15, 255);
                break;
            case 20:
                taskString = "PAINT YOUR BEDROOM WALLS";
                backgroundColor = new Color32(39, 118, 132, 255);
                break;
            case 21:
                taskString = "VISIT THE WORLD WITH GOOGLE EARTH";
                backgroundColor = new Color32(35, 232, 18, 255);
                break;
            case 22:
                taskString = "WATCH A FILM THAT'S WON THE OSCAR";
                backgroundColor = new Color32(62, 69, 98, 255);
                break;
            case 23:
                taskString = "LEARN TO JUGGLE";
                backgroundColor = new Color32(16, 240, 137, 255);
                break;
        }
        OpenTaskMenu(taskString, subString,backgroundColor);
    }

    void OpenTaskMenu(string displayText, string displaySubText, Color backGround)
    {
        taskPanel.GetComponent<Image>().color = backGround;
        taskText.text = displayText;
        subTaskText.text = displaySubText;

        int isComplete = PlayerPrefs.GetInt(currentTaskOpened.ToString(), 0);
        if (isComplete == 0)
        {
            undoButton.SetActive(false);
            doneButton.SetActive(true);
        }
        else
        {
            doneButton.SetActive(false);
            undoButton.SetActive(true);
        }

        taskMenu.SetActive(true);
        activitMenu.SetActive(false);
    }

    public void MarkTaskDone()
    {
        PlayerPrefs.SetInt(currentTaskOpened.ToString(), 1);
        doneButton.SetActive(false);
        undoButton.SetActive(true);
    }
    public void MarkTaskUndone()
    {
        PlayerPrefs.SetInt(currentTaskOpened.ToString(), 0);
        undoButton.SetActive(false);
        doneButton.SetActive(true);
    }

    void GoBack()
    {
        if (taskMenu.activeSelf)
            GoToActivityMenu();
        else if (activitMenu.activeSelf)
            GoToMainMenu();
    }
}
