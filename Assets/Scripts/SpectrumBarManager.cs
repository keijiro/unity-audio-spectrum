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
            if (barCount != spectrum.Levels.Length) {
                // Destroy the old bars.
                foreach (var child in transform) {
                    Destroy ((child as Transform).gameObject);
                }

                // Change the number of bars.
                barCount = spectrum.Levels.Length;
                var barWidth = 6.0f / barCount;
                var barScale = new Vector3 (barWidth * 0.9f, 1, 0.75f);

                // Create new bars.
                for (var barType = 0; barType < 3; barType++) {
                    for (var i = 0; i < barCount; i++) {
                        var x = 6.0f * i / barCount - 3.0f + barWidth / 2;
                        var z = 2.0f * (barType - 1);

                        var bar = Instantiate (barPrefab, new Vector3 (x, 0, z), transform.rotation) as GameObject;

                        bar.GetComponent<SpectrumBar> ().index = i;
                        bar.GetComponent<SpectrumBar> ().barType = (SpectrumBar.BarType)barType;

                        bar.transform.parent = transform;
                        bar.transform.localScale = barScale;
                    }
                }
            }
            yield return null;
        }
    }
}