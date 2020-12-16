import json

def addVideoCut(track, seq_asset, cut):
	section = track.add_section()
	section.set_editor_property('sub_sequence', seq_asset)
	section.parameters.start_frame_offset.value = cut['startFrame'] * 800

	return section
def createNewLevelSequence(dest, name):
	return unreal.AssetToolsHelpers.get_asset_tools().create_asset(asset_name = name, package_path = dest, asset_class = unreal.LevelSequence, factory=unreal.LevelSequenceFactoryNew())

path_velocity = 'D:\\velostuff\\frag.json'
with open(path_velocity) as json_file:
    data = json.load(json_file)
utility_library = unreal.EditorUtilityLibrary
seq_asset = utility_library.get_selected_assets()[0]
assetName = seq_asset.get_name()
assetPath = seq_asset.get_path_name()[:-(len(assetName)*2+2)]
master_sequence = createNewLevelSequence(assetPath, assetName + "_new")

# add MovieSceneCinematicShotTrack track to your master_sequence
shotsTrack = master_sequence.add_master_track(unreal.MovieSceneCinematicShotTrack)
timescaleTrack = master_sequence.add_master_track(unreal.MovieSceneSlomoTrack)
timescale_channel = timescaleTrack.add_section().get_channels()[0]

frameCounter = 0
for index, cut in enumerate(data):
	totalFrames = cut['endFrame'] - cut['startFrame']
	velocity = cut['velocity']
	section = addVideoCut(shotsTrack, seq_asset, cut)
	section.set_end_frame(totalFrames + frameCounter)
	if index > 0:
		section.set_start_frame(frameCounter)
	if len(velocity) > 0:
		for frame, value in velocity.items():
			keyframe = timescale_channel.add_key(unreal.FrameNumber(int(frame) + frameCounter), value)
			keyframe.set_interpolation_mode = 0
	frameCounter += totalFrames
