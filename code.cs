public class LightControlClip : PlayableAsset, ITimelineClipAsset
{
    public LightControlBehaviour template = new LightControlBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Blending; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<LightControlBehaviour>.Create (graph, template);
        return playable;
	}
}

public class LightControlTrack : TrackAsset
	{
	    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
	    {
	        return ScriptPlayable<LightControlMixerBehaviour>.Create (graph, inputCount);
	    }

	    public override void GatherProperties (PlayableDirector director, IPropertyCollector driver)//hello
	    {
	#if UNITY_EDITOR
	        Light trackBinding = director.GetGenericBinding(this) as Light;
	        if (trackBinding == null)
	            return;
 var serializedObject = new UnityEditor.SerializedObject (trackBinding);
	        var iterator = serializedObject.GetIterator();
	        while (iterator.NextVisible(true))
	        {
	            if (iterator.hasVisibleChildren)
	                continue;
