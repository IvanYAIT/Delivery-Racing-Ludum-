using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Button okBtn;
    [SerializeField] private TextMeshProUGUI dialogField;
    [SerializeField] private List<string> dialogs;

    private int _counter;

    void Start()
    {
        Time.timeScale = 0;
        okBtn.onClick.AddListener(NextDialog);
        dialogField.text = dialogs[0];
    }

    private void NextDialog()
    {
        _counter++;
        if (_counter < dialogs.Count)
            dialogField.text = dialogs[_counter];
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            okBtn.onClick.RemoveListener(NextDialog);
        }
    }
}
