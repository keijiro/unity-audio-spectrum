using UnityEngine;
using System.Collections;

public class SpectrumBar : MonoBehaviour
{
    public enum BarType { realtime, peak, mean };

    public int index;
    public BarType barType;

    AudioSpectrum spectrum;

    void Awake()
    {
        spectrum = FindObjectOfType(typeof(AudioSpectrum)) as AudioSpectrum;
    }

    void Update ()
    {
        if (index < spectrum.Levels.Length) {
            float scale = 0.0f;

            switch (barType) {
            case BarType.realtime:
                scale = spectrum.Levels[index];
                break;
            case BarType.peak:
                scale = spectrum.PeakLevels[index];
                break;
            case BarType.mean:
                scale = spectrum.MeanLevels[index];
                break;
            }

            var vs = transform.localScale;
            vs.y = scale * 20.0f;
            transform.localScale = vs;
        }
    }
}