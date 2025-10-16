using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoffeePot : MonoBehaviour
{
    public float t;
    public float brewingTime;
    public Slider CoffeeProgress;

    public TextMeshProUGUI CoffeeText;
    public int coffeesMade;

    public Transform dragCoffee;
    public SpriteRenderer dcSprite;

    //public Transform tiredWorker;
    public SpriteRenderer emoji;
    public SpriteRenderer greenArrow;
    public SpriteRenderer otherArrow;
    bool showArrow;
    float timer = 0;
    bool holdingCoffee;

    Vector2 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coffeesMade = 0;
        t = 0;
        CoffeeProgress.maxValue = brewingTime;
        dcSprite.enabled = false;
        holdingCoffee = false;
        showArrow = false;
        greenArrow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragCoffee.position = mousePos;

        t += Time.deltaTime;
        CoffeeProgress.value = t;

        if (t> brewingTime)
        {
            t = 0;
            coffeesMade++;
        }

        CoffeeText.text = coffeesMade.ToString() + "x Coffees";

        if (showArrow)
        {
            greenArrow.enabled = true;
            
            timer += Time.deltaTime;
            if(timer > 2)
            {
                showArrow = false;
                greenArrow.enabled = false;
                timer = 0;
            }
        }

    }
    public void click()
    {
        dcSprite.enabled = true;
        holdingCoffee = true;
        coffeesMade -= 1;
    }
    

    public void release()
    {
        Debug.Log("release drag");
        dcSprite.enabled = false;
        holdingCoffee = false;

    }

    public void inWorkerBounds()
    {
        Debug.Log("yup that's coffee");
        if (holdingCoffee)
        {
            dcSprite.enabled = false;
            Debug.Log("mmmm, coffee");
            emoji.enabled = false;
            showArrow = true;
        }


    }

    
}
