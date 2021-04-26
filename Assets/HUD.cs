using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HUD : MonoBehaviour
{
    public static HUD instance = null;

    [SerializeField] GameObject pauseUI = null;
    [SerializeField] Image healthAmount = null;
    [SerializeField] Image torchIcon = null;

    [SerializeField] Sprite torchOn = null, torchOff = null;

    [SerializeField] TextMeshProUGUI stoneCount = null;

    [SerializeField] GameObject interactHint = null;
    [SerializeField] TextMeshProUGUI interactHintText = null;

    [SerializeField] Transform keyHolder = null;
    [SerializeField] GameObject keyPrefab = null;
    [SerializeField] List<KeyInstance> keys = new List<KeyInstance>();

    [SerializeField] GameObject noteUI = null;
    [SerializeField] TextMeshProUGUI noteText = null;

    public float timer, refresh, avgFramerate;
    [SerializeField] TextMeshProUGUI fpsCounter = null;

    [SerializeField] GameObject controllsUI = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        torchIcon.sprite = torchOn;
        stoneCount.text = "0";
        healthAmount.fillAmount = 1.0f; 
    }

    private void Update()
    {
        fpsCounter.text = ((int) (1.0f / Time.unscaledDeltaTime)).ToString() + " FPS";
    }

    public void OpenPause()
    {
        pauseUI.SetActive(true);
    }

    public void SetHealthAmount(float value)
    {
        healthAmount.fillAmount = value;
    }

    public void Reset()
    { 
        keys = new List<KeyInstance>();
        healthAmount.fillAmount = 1.0f;
        stoneCount.text = "0";
        torchIcon.sprite = torchOff;
        ClearKeys();
    }

    public void SetTorchOn(bool value)
    {
        torchIcon.sprite = value ? torchOn : torchOff;
    }

    public void SetStoneCount(int value)
    {
        stoneCount.text = value.ToString();
    }

    public void ShowInteractHint(string hint)
    {
        interactHintText.text = hint;
        interactHint.SetActive(true);
    }

    public void HideInteractHint() => interactHint.SetActive(false);

    public bool IsInteractHintShowing() => interactHint.activeSelf;

    public void ShowNote(string text)
    {
        noteText.text = text;
        noteUI.SetActive(true);
    }

    public void HideNote() => noteUI.SetActive(false);

    public bool IsNoteOpen() => noteUI.activeSelf;

    public void AddKey(string id, Color color)
    {
        GameObject ki = Instantiate(keyPrefab, keyHolder);
        ki.name = id;
        ki.GetComponent<Image>().color = color;
        ki.SetActive(true);
        keys.Add(new KeyInstance() { id = id, instance = ki });
    }

    public void RemoveKey(string id)
    {
        if (keys.Count(k => k.id == id) == 0)
            return;

        Destroy(keys.First(k => k.id == id).instance);
        keys.Remove(keys.First(k => k.id == id));
    }

    public void ClearKeys()
    {
        foreach (Transform t in keyHolder)
            if (t.name != keyPrefab.name) Destroy(t.gameObject);

        keys.Clear();
    }

    public void ShowControlls(bool value) => controllsUI.SetActive(value);

    class KeyInstance
    {
        public string id;
        public GameObject instance;
    }
}
