### Tested on VEGAS Pro 16

## Using export script

- Drop 'Script Menu' folder into your VEGAS Pro folder
- In VEGAS Pro go to Tools > Scripting > Rescan Script Menu Folder
- You should now find 'Export Velocity' under Tools > Scripting
- Select your high FPS footage with velocity (including all cuts) and hit 'Export Velocity'

## Using import scripts
- Unreal Engine
  - Inside Unreal, go to Edit > Plugins, look for 'Python Editor Script Plugin' and Enable it (might ask for restart)
  - Locate the level sequence you rendered for Velocity in VEGAS
  - Make sure the start/end frames are the same as the footage you worked with in VEGAS
  - Open the `ue_velocity_import.py` and set the path to your velocity file (Line 12).
  - In Unreal, bring up the console with the ~ key, change from Cmd to Python, paste the code and press enter.
  - New level sequence should be created with the suffix `_new`, with all the cuts and timescale keyframes.
