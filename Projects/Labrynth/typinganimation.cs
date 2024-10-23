using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class typinganimation : MonoBehaviour
{
    string _deathMessage;
    Text _tutorialText;
    [SerializeField] float _textInterval = 0.1f;

    private void Awake()
    {
        _tutorialText = GetComponent<Text>();
        _deathMessage = _tutorialText.text;
        _tutorialText.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char c in _deathMessage)
        {
            _tutorialText.text += c;

            yield return new WaitForSeconds(_textInterval);

        }
    }
}
