using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(AudioSpectrum))]
public class AudioSpectrumInspector : Editor
{
    static string[] sampleOptionStrings = {
        "64", "128", "256", "512", "1024", "2048", "4096"
    };
    static int[] sampleOptions = {
        64, 128, 256, 512, 1024, 2048, 4096
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

        spectrum.NumberOfBands = EditorGUILayout.IntField ("Number of Bands", spectrum.NumberOfBands);
        spectrum.NumberOfSamples = EditorGUILayout.IntPopup ("Number of Samples", spectrum.NumberOfSamples, sampleOptionStrings, sampleOptions);

        EditorGUILayout.CurveField (curve, Color.white, new Rect (0, 0, 1.0f, 0.5f), GUILayout.Height (64));

        if (EditorApplication.isPlaying) {
            EditorUtility.SetDirty (target);
        }
    }
}