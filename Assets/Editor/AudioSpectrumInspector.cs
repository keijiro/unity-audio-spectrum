using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(AudioSpectrum))]
public class AudioSpectrumInspector : Editor
{
    static string[] sampleOptionStrings = {
        "256", "512", "1024", "2048", "4096"
    };
    static int[] sampleOptions = {
        256, 512, 1024, 2048, 4096
    };
    static string[] bandOptionStrings = {
        "4 band", "4 band (visual)", "8 band", "10 band (ISO standard)", "26 band (custom)", "31 band (FBQ3102)"
    };
    static int[] bandOptions = {
        (int)AudioSpectrum.BandType.fourBand,
        (int)AudioSpectrum.BandType.fourBandVisual,
        (int)AudioSpectrum.BandType.eightBand,
        (int)AudioSpectrum.BandType.tenBand,
        (int)AudioSpectrum.BandType.twentySixBandCustom,
        (int)AudioSpectrum.BandType.thirtyOneBand
    };

    AnimationCurve curve;

    void UpdateCurve ()
    {
        curve = new AnimationCurve ();

        var spectrum = target as AudioSpectrum;
        var bands = spectrum.BandLevels;
        var time = 0.0f;
        foreach (var band in bands) {
            curve.AddKey (time, band);
            time += 1.0f / bands.Length;
        }
    }

    public override void OnInspectorGUI ()
    {
        var spectrum = target as AudioSpectrum;

        if (EditorApplication.isPlaying) {
            UpdateCurve ();
        } else if (curve == null) {
            curve = new AnimationCurve ();
        }

        spectrum.numberOfSamples = EditorGUILayout.IntPopup ("Number of Samples", spectrum.numberOfSamples, sampleOptionStrings, sampleOptions);
        spectrum.bandType = (AudioSpectrum.BandType)EditorGUILayout.IntPopup ("Band type", (int)spectrum.bandType, bandOptionStrings, bandOptions);

        EditorGUILayout.CurveField (curve, Color.white, new Rect (0, 0, 1.0f, 0.2f), GUILayout.Height (64));

        if (EditorApplication.isPlaying) {
            EditorUtility.SetDirty (target);
        }
    }
}