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
        _animator.SetBool("IsDrinkingChampagne", true);
    }

    public void DrinkingCocktail()
    {
        _animator.SetBool("IsDrinkingCocktail", true);
    }

    public void DrinkingWishkey()
    {
        _animator.SetBool("IsDrinkingWhishkey", true);
    }

    public void StopDrinking()
    {
        _animator.SetBool("IsNotDrinking", true);
    }
}
