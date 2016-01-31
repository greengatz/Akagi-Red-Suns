using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour
{

    //public string descriptor = "event descriptor";
	public string[] descriptor;

    public int eventID;
    public float useTime = 1f;
    public bool hideGuy = false;
    public AudioSource eventAudio = null;
    public SpriteRenderer objectSprite;
    public Animator fridge;
    private bool running = false;
    private bool completed = false;

    // Use this for initialization
    public void Start()
    {
        if (GlobalState.events.ContainsKey(eventID))
        {
            GlobalState.events.Remove(eventID);
        }

        GlobalState.events.Add(eventID, this);

        if (GlobalState.current > eventID)
        {
            completed = true;
        }

        eventAudio = GetComponent<AudioSource>();
        objectSprite = GetComponent<SpriteRenderer>();
        fridge = GetComponent<Animator>();
    }

    public void startEvent()
    {
        running = true;
    }

    public bool isRunning()
    {
        return running;
    }

    public bool isCompleted()
    {
        return completed;
    }

    public void finishEvent()
    {
        running = false;
        completed = true;
    }


    public void selected()
    {
        //Debug.Log ("selected");
        if (isRunning())
        {
            Debug.Log("selected");
            StartCoroutine(waitSelected());
        }
    }

    IEnumerator waitSelected()
    {
        // get the guy, hide him if we should

        // get the guy, hide him if we should
        // start animation or whatever
        // play start sound

        // start animation or whatever
        // play start sound
        // wait for time amount

        if (eventAudio != null)
        {
            eventAudio.Play();
        }

        if (eventID == 0)
        {
            eventAudio.mute = true;
        }
        else if (eventID == 5)
        {
            Sprite coffeeFull = Resources.Load("coffeeFull2", typeof(Sprite)) as Sprite;
            objectSprite.sprite = coffeeFull;
        }
        else if (eventID == 6)
        {
            Sprite fridgeOpen = Resources.Load("RefrigeratorOpen", typeof(Sprite)) as Sprite;
            objectSprite.sprite = fridgeOpen;
            
        }
        else if (eventID == 2)
        {
            Sprite isInShower = Resources.Load("BathtubClosedCurtain", typeof(Sprite)) as Sprite;

            objectSprite.sprite = isInShower;
        }
        else if (eventID == 4)
        {
            Sprite dogFood = Resources.Load("dogBowlFull", typeof(Sprite)) as Sprite;
            objectSprite.sprite = dogFood;
        }

        GlobalState.characterActing = true;
        GlobalState.characterVis = !hideGuy;

        Debug.Log("starting wait");
        yield return new WaitForSeconds(useTime);
        Debug.Log("ending wait");

        if (eventID == 2)
        {
            Sprite isNotInShower = Resources.Load("BathtubOpenCurtain", typeof(Sprite)) as Sprite;
            objectSprite.sprite = isNotInShower;
        }
        else if (eventID == 6)
        {
            Sprite fridgeClose = Resources.Load("Refrigerator", typeof(Sprite)) as Sprite;
            objectSprite.sprite = fridgeClose;
        }

        GlobalState.characterActing = false;
        GlobalState.characterVis = true;
        // wait for time amount       
        // play Loop sound
        // kill animation or whatever
        // stop loop sound
        // play Loop sound
        // kill animation or whatever
        // stop loop sound

        // play end sound
        // make guy visible again
        // play end sound
        // make guy visible again

        finishEvent();
    }
}