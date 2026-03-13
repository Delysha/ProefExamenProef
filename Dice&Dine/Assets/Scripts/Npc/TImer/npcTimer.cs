using System.Collections;
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
    
    [SerializeField] private Color white;
    [SerializeField] private Color red;
    private SpriteRenderer sprite;
    
    public float maxPatience = 60f;
    public float currentPatience;

    private bool isWaiting = false;
    private float timerSpeed = 1f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); 
    }
    private void Update()
    {
        if (!isWaiting) return;

        currentPatience -= Time.deltaTime * timerSpeed;

        var t = 1f - (currentPatience / maxPatience);
        var lerpedColor = Color.Lerp(Color.white, Color.red, t);

        sprite.color = lerpedColor;

        if (currentPatience <= 0f)
        {
            StartCoroutine(Leave());
        }
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

    private IEnumerator Leave ()
    {
        yield return new WaitForSeconds(3f);
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
