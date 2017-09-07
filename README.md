# Chordinary World
A service that provides the number of harmonies in a song: http://chordinary.world

### How does it work?
Chordinary World currently looks for the best chords for a song in the internet, extracts the chords themselves and does some theoretical analysis on that to bring the number of harmonies.

### Any plans for future?
Apart from fixing current issues, it would be nice to have the harmonies based on some hardcore math analysis rather than on people's input. Also some statistics are going to be introduced.

### What is the tech stack?
General:
- The service and the small console app is done in F#.
- The web app is done in TypeScript.

Auxiliary:
- The testing frameworks are xUnit (for F#) and Jasmine (for TS, run by Chutzpah).
- The logging framework is NLog (for F#).
- The web app is obviously done with the help of Bootstrap and jQuery.

### More info?
Some more info is at the [about](http://chordinary.world/about.html) page of the site. My contacts are also there.
