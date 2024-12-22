using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    private string _correctGemValue = "BlueRedGreen";
    private string _enteredGemValue = string.Empty;
    [SerializeField]
    private Animator _boxAnimator;
    private int _amountOfGems = 3;
    private int _currentGem = 0;

    private List<Gem> gems = new List<Gem>();

    public void GemSelect(Gem currentSelectedGem)
    {
        _enteredGemValue += currentSelectedGem.gemColorName;
        gems.Add(currentSelectedGem);
        _currentGem++;
        if (_currentGem == _amountOfGems)
        {
            CompareGemOrder();
        }
    }

    public void CompareGemOrder()
    {
        if (_enteredGemValue == _correctGemValue)
        {
            _boxAnimator.SetTrigger("Open");
        }
        else
        {
            _enteredGemValue = string.Empty;
            _currentGem = 0;
            foreach (var gem in gems)
            {
                gem.ChangeEmission(false);
            }
            gems.Clear();

        }
    }
}
