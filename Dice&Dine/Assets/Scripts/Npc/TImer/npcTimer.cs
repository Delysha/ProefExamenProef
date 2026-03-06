using UnityEngine;

public enum NPCType
{
    Normal,
    Impatient,
    Dealer,
    Critic,
    Drunk
}

public class npcTimer : MonoBehaviour
{
    public NPCType npcType;

    private SpriteRenderer sprite;
    public SpriteRenderer angerOverlay;

    public float maxPatience = 60f;
    public float currentPatience;

    private bool isWaiting = false;
    private float timerSpeed = 1f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); 

        //test inputs
        Debug.Log("Press 1 = Start Waiting");
        Debug.Log("Press 2 = Stop Waiting");
        Debug.Log("Press 3 = Add Patience (Drunk)");
        Debug.Log("Press 4 = Remove Patience (Drunk)");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            StartWaiting();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            StopWaiting();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            ModifyPatience(10f);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            ModifyPatience(-10f);

        if (!isWaiting) return;

        currentPatience -= Time.deltaTime * timerSpeed;

        if (currentPatience <= 0f )
        {
            Leave();
        }

        float normalized = currentPatience / maxPatience; 

        float anger = 1f - normalized;

        Color c = angerOverlay.color;
        c.a = anger;
        angerOverlay.color = c;
    }

    public void StartWaiting()
    {
        SetBasePatience();
        currentPatience = maxPatience;
        isWaiting = true;

    }

    public void StopWaiting()
    {
        isWaiting = false;
    }

    void Leave ()
    {
        isWaiting = false;
        Destroy(gameObject);
    }

    void SetBasePatience()
    {
        switch (npcType)
        {
            case NPCType.Normal:
                maxPatience = 60f;
                timerSpeed = 1f;
                break;

            case NPCType.Impatient:
                maxPatience = 35f;
                timerSpeed = 1f;
                break;

            case NPCType.Dealer:
                maxPatience = 50f;
                timerSpeed = 1f;
                break;

            case NPCType.Critic:
                maxPatience = 40f;
                timerSpeed = 1f;
                break;

            case NPCType.Drunk:
                maxPatience = 80f;
                timerSpeed = Random.Range(0.5f, 1.5f);
                break;
        }
    }

    public void ModifyPatience(float amount)
    {
        if (npcType == NPCType.Drunk)
        {
            currentPatience += amount;
            currentPatience = Mathf.Clamp(currentPatience, 0, maxPatience);
        }
    }
}
