using TMPro;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public Visualizador visualizador;
    public TMP_InputField inputField;
    public TextMeshProUGUI outputText;

    void Start()
    {
        int[] values = { 0, -1, 1, -2, -4, 2, 3, 4 };
        foreach (var v in values) visualizador.arbol.Insert(v);
    }

    public void Insert()
    {
        if (int.TryParse(inputField.text, out int value))
        {
            visualizador.arbol.Insert(value);
            inputField.text = string.Empty;
            outputText.text = "Inserted: " + value;
        }
        else
        {
            outputText.text = "Invalid input!";
        }
    }

    public void Search()
    {
        if (int.TryParse(inputField.text, out int value))
        {
            bool found = visualizador.arbol.Contains(value);
            outputText.text = found ? "Found: " + value : "Not Found: " + value;
        }
        else
        {
            outputText.text = "Invalid input!";
        }
    }

    public void Remove()
    {
        if (int.TryParse(inputField.text, out int value))
        {
            visualizador.arbol.Remove(value);
            inputField.text = string.Empty;
            outputText.text = "Removed: " + value;
        }
        else
        {
            outputText.text = "Invalid input!";
        }
    }

    public void ShowInOrder() => outputText.text = "InOrder: " + string.Join(", ", visualizador.arbol.InOrder());
    public void ShowPreOrder() => outputText.text = "PreOrder: " + string.Join(", ", visualizador.arbol.PreOrder());
    public void ShowPostOrder() => outputText.text = "PostOrder: " + string.Join(", ", visualizador.arbol.PostOrder());
    public void ShowLevelOrder() => outputText.text = "LevelOrder: " + string.Join(", ", visualizador.arbol.LevelOrder());
}