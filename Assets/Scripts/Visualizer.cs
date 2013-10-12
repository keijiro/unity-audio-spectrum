using UnityEngine;
using System.Collections;

public class Visualizer : MonoBehaviour
{
    public SpectrumBar.BarType barType;
    public GameObject barPrefab;
    public GUIStyle labelStyle;

    AudioSpectrum spectrum;
    SpectrumBar.BarType prevBarType;
    int barCount;

    void Start ()
    {
        spectrum = FindObjectOfType (typeof(AudioSpectrum)) as AudioSpectrum;
    }

    void Update ()
    {
        if (barCount == spectrum.Levels.Length && barType == prevBarType) {
            return;
        }

        // Destroy the old bars.
        foreach (var child in transform) {
            Destroy ((child as Transform).gameObject);
        }

        // Change the number of bars.
        barCount = spectrum.Levels.Length;
        var barWidth = 6.0f / barCount;
        var barScale = new Vector3 (barWidth * 0.9f, 1, 0.75f);

        // Create new bars.
        for (var i = 0; i < barCount; i++) {
            var x = 6.0f * i / barCount - 3.0f + barWidth / 2;

            var bar = Instantiate (barPrefab, Vector3.right * x, transform.rotation) as GameObject;

            bar.GetComponent<SpectrumBar> ().index = i;
            bar.GetComponent<SpectrumBar> ().barType = barType;

            bar.transform.parent = transform;
            bar.transform.localScale = barScale;
        }

        prevBarType = barType;
    }

    void OnGUI ()
    {
        var text = "Current mode: " + barType + "\n";
        text += "Use the inspector to change the mode.\n";
        text += "(see 'Bar Type' in 'Visualizer').";
        GUI.Label (new Rect(0, 0, Screen.width, Screen.height), text, labelStyle);
    }
}