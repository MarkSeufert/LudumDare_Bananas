using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    public Color[] _themes;
    public Color[] _lightThemes;
    public Camera _mainCamera;
    public Light _mainLight;
    public float _themeChangeSpeed = 1f;
    private int _currentTheme = 0;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogColor = _themes[0];
        _mainCamera.backgroundColor = _themes[0];
        _mainLight.color = _lightThemes[0];
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, _themes[_currentTheme], _themeChangeSpeed * Time.deltaTime);
        _mainCamera.backgroundColor = Color.Lerp(_mainCamera.backgroundColor, _themes[_currentTheme], _themeChangeSpeed * Time.deltaTime);
        _mainLight.color = Color.Lerp(_mainLight.color, _lightThemes[_currentTheme], _themeChangeSpeed * Time.deltaTime);
    }

    // Sets a theme for the game
    // 0: Peaceful
    // 1: Dark
    // 2: Bloody
    public void SetTheme(int theme) {
        _currentTheme = theme;
    }
}
