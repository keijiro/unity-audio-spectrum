unity-audio-spectrum
====================

![Screenshot](http://keijiro.github.io/unity-audio-spectrum/Screenshot.png)

This is a set of C# scripts which provides spectrum data with audio output.
It provides spectrum data as a set of [octave bands]
(http://en.wikipedia.org/wiki/Octave_band) which is commonly used in music visualizers.
You can easily use these data to make audio visualization in Unity apps.

For a detailed example, see [the test branch]
(https://github.com/keijiro/unity-audio-spectrum/tree/test).

Setup
-----

1. Import AudioSpectrum.cs.
1. Import AudioSpectrumEditor.cs into the "Editor" directory.
1. Add AudioSpectrum to a game object.

Options
-------

![Inspector](http://keijiro.github.io/unity-audio-spectrum/Inspector.png)

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

License
-------

Copyright (C) 2013 Keijiro Takahashi

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
