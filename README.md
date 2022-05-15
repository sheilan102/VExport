### Tested on VEGAS Pro 16+ & Unreal Engine 4.26

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

## VELO file structure
```cs
struct VeloHeader
{
    ushort OriginalFPS; // FPS of the footage we applied velocity to 
    ushort TargetFPS; // Final FPS
    byte VideoCutCount; // The count of cuts we have for that footage
}

struct VideoCut
{
    uint startFrame; // Original Footage frame that cut starts from
    uint endFrame; // Original Footage frame that cut ends at
    // Frames
    // Key - Original Footage Frame
    // Value - New frame after velocity
    // Count - VideoCutCount
    Dictionary<double, double> Frames;
}
```