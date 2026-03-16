using UnityEngine;

public class DrinkAnim : MonoBehaviour
{
    [Header("Drinking drinks")]
    public bool DrinkChampagne;
    public bool DrinkCocktail;
    public bool DrinkWhiskey;

    [Header("Not Drinking")]
    public bool NotDrinking;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DrinkingChampagne()
    {
        _animator.SetTrigger("IsDrinkingChampagne");
    }

    public void DrinkingCocktail()
    {
        if(!DrinkCocktail) { return; }
        _animator.SetBool("IsDrinkingCocktail", true);
    }

    public void DrinkingWishkey()
    {
        if (!DrinkWhiskey) { return; }
        _animator.SetBool("IsDrinkingWhishkey", true);
    }

    public void StopDrinking()
    {
        if (NotDrinking)
        {
            _animator.SetBool("IsNotDrinking", true);
            _animator.SetBool("IsDrinkingWhishkey", false);
            _animator.SetBool("IsDrinkingCocktail", false);
            _animator.SetBool("IsDrinkingChampagne", false);
        }
        else
        {
            _animator.SetBool("IsNotDrinking", false);
        }
    }
}
