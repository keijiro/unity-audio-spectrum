using UnityEngine;
using System.Collections;

public class SpectrumBarManager : MonoBehaviour
{
    public GameObject barPrefab;

    IEnumerator Start ()
    {
        var spectrum = FindObjectOfType (typeof(AudioSpectrum)) as AudioSpectrum;
        var barCount = 0;

        while (true) {
            if (barCount != spectrum.BandLevels.Length) {
                // Destroy the old bars.
                foreach (var child in transform) {
                    Destroy ((child as Transform).gameObject);
                }

                barCount = spectrum.BandLevels.Length;
                var barWidth = 6.0f / barCount;

                // Create new bars.
                for (var i = 0; i < barCount; i++) {
                    var x = 6.0f * i / barCount - 3.0f + barWidth / 2;
                    var bar = Instantiate (barPrefab, Vector3.right * x, transform.rotation) as GameObject;
                    bar.GetComponent<SpectrumBar> ().index = i;
                    bar.GetComponent<SpectrumBar> ().showPeak = true;
                    bar.transform.parent = transform;
                    var scale = bar.transform.localScale;
                    scale.x = barWidth * 0.9f;
                    bar.transform.localScale = scale;
                }
            }
            yield return null;
        }
    }
}