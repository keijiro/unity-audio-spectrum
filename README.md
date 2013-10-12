unity-audio-spectrum
====================

This is a set of C# scripts which provides spectrum data with audio output.
It provides spectrum data as a set of [octave bands]
(http://en.wikipedia.org/wiki/Octave_band) which is commonly used in music visualizers.
You can easily use these data to make audio visualization in Unity apps.

Setup
-----

1. Import AudioSpectrum.cs.
1. Import AudioSpectrumEditor.cs into the "Editor" directory.
1. Add AudioSpectrum to a game object.

Options
-------

#### Number of samples

The number of samples which is fed to FFT. The higher number, the more accurate result,
but reduce performance.

#### Band type

There are several octave band types.

- 4 band
- 4 band (visual) - only covers low and middle ranges
- 8 band
- 10 band (ISO standard)
- 24 band 
- 31 band (FBQ3012)

#### Fall speed

The fall-down speed of the peak levels.

#### Sensibility

The coefficient which is used to calculate the mean levels. The higher value, the faster movement.

Properties
----------

#### float[] Levels

The array which provides the level of the each octave band.

#### float[] PeakLevels

The array which provides the peak level of the each band.

#### float[] MeanLevels

The array which provides the mean level for a short period of the time.
These values respond slower than real-time values and suit for make smooth animations.
