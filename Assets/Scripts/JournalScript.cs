using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class JournalScript : MonoBehaviour
{

    //Array to store the available pages that can be displayed
    [SerializeField] Texture[] pages;

    //Positions of the journal when it is on and off screen
    private Vector3 onScreenPosition = new Vector3(110, 40, 0);
    private Vector3 offScreenPosition = new Vector3(110, -1040, 0);

    //Sets how smoothly the journal goes on or off screen
    [SerializeField] float smoothSpeed = 0f;

    //Tracks if the journal is currently displayed. Is a public static boolean so that player control can be removed while the journal is displayed
    public static bool isJournalDisplayed = false;

    //Tracks which bugs have been captured, so it displays empty pages if not caught
    public static bool isButterflyCaught = false;
    public static bool isCaterpillarCaught = false;
    public static bool isDamselflyCaught = false;

    [SerializeField] int currentPage;

    //Sound used for when the page turns
    public AudioSource pageTurnSound;

    public RawImage journalPageDisplayed;

    void Start()
    {
        journalPageDisplayed = GameObject.Find("Journal").GetComponent<RawImage>();
        currentPage = 1;
    }
   
    // Update is called once per frame
    void Update()
    {
        //When tab is pressed, move journal to be in frame
        if (isJournalDisplayed == false)
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, offScreenPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else //When tab is pressed and the journal is currently displayed, move off screen
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, onScreenPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

        //Sets isJournalDisplayed to true or false based on Tab being pressed
        if (Input.GetKeyDown(KeyCode.Tab) && isJournalDisplayed == true)
        {
            Time.timeScale = 1; //Resumes the world and player being able to move
            isJournalDisplayed = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isJournalDisplayed == false)
        {
            Time.timeScale = 0; //Freezes time to prevent player and world movement while in the journal
            isJournalDisplayed = true;
        }

        //If the journal is displayed and left/A is pressed, go to the previous page, with the lowest page being page 1
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && isJournalDisplayed == true)
        {
            if (currentPage > 1)
            {
                currentPage--;
                pageTurnSound.Play();
            }
        }

        //If the journal is displayed and right/D is pressed, go to the next page, with the last page being page 5
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && isJournalDisplayed == true)
        {
            if (currentPage < 5)
            {
                currentPage++;
                pageTurnSound.Play();
            }
        }

        //Displays the correct page based on the currentPage number, and whether the corresponding critter has been caught or not
        switch (currentPage)
        {
            case 1:
                journalPageDisplayed.texture = pages[currentPage];
                break;
            case 2:
                journalPageDisplayed.texture = pages[currentPage];
                break;
            case 3:
                if (isButterflyCaught)
                {
                    journalPageDisplayed.texture = pages[currentPage];
                }
                else
                {
                    journalPageDisplayed.texture = pages[0];
                }
                break;
            case 4:
                if (isCaterpillarCaught)
                {
                    journalPageDisplayed.texture = pages[currentPage];
                }
                else
                {
                    journalPageDisplayed.texture = pages[0];
                }
                break;
            case 5:
                if (isDamselflyCaught)
                {
                    journalPageDisplayed.texture = pages[currentPage];
                }
                else
                {
                    journalPageDisplayed.texture = pages[0];
                }
                break;
            default:
                journalPageDisplayed.texture = pages[1];
                break;
        }
    }
}

