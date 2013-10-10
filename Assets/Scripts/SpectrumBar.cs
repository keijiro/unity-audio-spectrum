using UnityEngine;
using System.Collections;

public class SpectrumBar : MonoBehaviour
{
    public int index;
    AudioSpectrum spectrum;

    void Awake()
    {
        spectrum = FindObjectOfType(typeof(AudioSpectrum)) as AudioSpectrum;
    }

    void Update ()
    {
        if (index < spectrum.BandLevels.Length) {
            var scale = transform.localScale;
            scale.y = spectrum.BandLevels[index] * 20;
            transform.localScale = scale;
        }
    }
}