using TMPro;
using UnityEngine;

public class RoskaUIManager : MonoBehaviour
{
    public static RoskaUIManager Instance;

    [SerializeField] private TMP_Text interactionText;

    private void Awake()
    {
        Instance = this;
    }

    public void Show(string text)
    {
        if (interactionText != null)
            interactionText.text = text;
    }

    public void Hide()
    {
        if (interactionText != null)
            interactionText.text = "";
    }
}