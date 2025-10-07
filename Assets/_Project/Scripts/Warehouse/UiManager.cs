using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _tutorialText;
    [SerializeField] private TextsListSO _tutorialTextsSO;
    
    public void UpdateText(int tutorIndex)
    {
        _tutorialText.text = _tutorialTextsSO._textsList[tutorIndex].Text;
    }

    public void ClearText()
    {
        _tutorialText.text = null;
    }
}
