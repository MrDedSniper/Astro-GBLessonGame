using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal sealed class CommandUI : MonoBehaviour
{
    public GameObject menuScreen;
    
    [SerializeField] private PanelOne _panelOne;
    [SerializeField] private PanelTwo _panelTwo;
    private readonly Stack<Panels.StateUI> _stateUi = new Stack<Panels.StateUI>();
    private BaseUi _currentWindow;
    
    private bool isMenuActive = false;
    
    private AudioSource[] audioSources;

    private void Start()
    {
        _panelOne.Cancel();
        _panelTwo.Cancel();
        
        audioSources = FindObjectsOfType<AudioSource>();
    }
    private void Execute(Panels.StateUI stateUI, bool isSave = true)
    {
        if (_currentWindow != null)
        {
            _currentWindow.Cancel();
        }
        switch (stateUI)
        {
            case Panels.StateUI.PanelOne:
                _currentWindow = _panelOne;
                break;
            case Panels.StateUI.PanelTwo:
                _currentWindow =_panelTwo;
                break;
            default:
                break;
        }
        _currentWindow.Execute();
        if (isSave)
        {
            _stateUi.Push(stateUI);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isMenuActive)
            {
                menuScreen.SetActive(true);
                isMenuActive = true;
                Time.timeScale = 0;
                   
                foreach (AudioSource audioSource in audioSources)
                {
                    audioSource.volume = 0f;
                }
            }
            else
            {
                menuScreen.SetActive(false);
                isMenuActive = false;
                Time.timeScale = 1;
                   
                foreach (AudioSource audioSource in audioSources)
                {
                    audioSource.volume = 1f;
                }
            }
        }

    }

    public void Continue()
    {
        menuScreen.SetActive(false);
        isMenuActive = false;
        Time.timeScale = 1;
                   
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = 1f;
        }
    }
}
