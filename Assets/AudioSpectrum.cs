using UnityEngine;
using System.Collections;

public class AudioSpectrum : MonoBehaviour
{
    [SerializeField]
    int numberOfSamples = 1024;

    [SerializeField]
    int numberOfBands = 8;

    float[] rawSpectrum;
    float[] bandLevels;

    public float[] BandLevels {
        get {
            return bandLevels;
        }
    }

    public int NumberOfSamples {
        get {
            return numberOfSamples;
        }
        set {
            numberOfSamples = value;
            CheckBufferUpdate();
        }
    }

    public int NumberOfBands {
        get {
            return numberOfBands;
        }
        set {
            numberOfBands = value;
            CheckBufferUpdate();
        }
    }

    void CheckBufferUpdate()
    {
        if (rawSpectrum != null && numberOfSamples != rawSpectrum.Length) {
            rawSpectrum = new float[numberOfSamples];
        }
        if (bandLevels != null && numberOfBands != bandLevels.Length) {
            bandLevels = new float[numberOfBands];
        }
    }

    void Awake ()
    {
        rawSpectrum = new float[numberOfSamples];
        bandLevels = new float[numberOfBands];
    }
    
    void Update ()
    {
        AudioListener.GetSpectrumData (rawSpectrum, 0, FFTWindow.BlackmanHarris);
        
        var coeff = Mathf.Log (rawSpectrum.Length);
        var offs = 0;
        for (var i = 0; i < bandLevels.Length; i++) {
            var next = Mathf.Exp (coeff / bandLevels.Length * (i + 1));
            var weight = 1.0f / (next - offs);
            var sum = 0.0f;
            for (; offs < next; offs++) {
                sum += rawSpectrum [offs];
            }
            bandLevels [i] = Mathf.Sqrt (weight * sum);
        }
    }
}