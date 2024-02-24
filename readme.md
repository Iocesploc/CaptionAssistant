# Caption Assistant

Helps edit YouTube closed captioning with features such as bulk caption Find and Replace, indication and adjustment of short/long caption display times, and shifting of captions forward.
Works with the .SBV (Subviewer) closed captioning format.

<img src = 'captasst.png'></img>

## How To Use

Load and Save Files using the File Menu.
Once a file is loaded, you will observe:

Each screen of closed captioning is in its own block.
Each block contains, from left to right:
* The caption
* Above indicator is highlighted if the previous caption ends at the same time that this caption block begins
* The line of text below is the number of characters, the number of seconds, and the characters per second ratio (a rough measure of how readable a caption is in the alloted time
* Word indicator is highlighted if this caption has no spaces
* Short indicator is highlighted if the caption is on screen for less than the minimum (measured in ms)
* Long indicator is highlighted if the caption is on screen for longer than the maximum.
* Below indicator is highlighted if the next caption begins at the same time that this caption block ends
* Merge button is used to concatenate the text of this caption block with that of the previous, keeping the start time of the previous with the end time of this block
* Delete button deletes this caption block altogether.
* Split button splits this caption block into two.  The split time varies based on where you cursor is horizontally on the button, as indicated by the timestamp at the top
* Start time
* End time
* Scrollbar.  Scrolling through captions can be done by clicking on the scrollbar for coarse adjustment or by setting the value in the number box on the right.



