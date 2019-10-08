using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[DefaultExecutionOrder(-200)]
public class NavMeshSourceTag : MonoBehaviour
{
    public static List<MeshFilter> Meshes = new List<MeshFilter>();
    public static List<NavMeshModifierVolume> VolumeModifiers = new List<NavMeshModifierVolume>();
    public static int AgentTypeId;

    //----------------------------------------------------------------------------------------
    private void OnEnable()
    {
        var volumes = GetComponents<NavMeshModifierVolume>();
        if (volumes != null)
            VolumeModifiers.AddRange(volumes);

        var modifier = GetComponent<NavMeshModifier>();
        if ((modifier != null) && (!modifier.AffectsAgentType(AgentTypeId) || (modifier.ignoreFromBuild) && modifier.AffectsAgentType(AgentTypeId)))
            return;

        var meshes = GetComponentsInChildren<MeshFilter>();
        if (meshes != null && meshes.Length > 0)
            Meshes.AddRange(meshes);
    }

    //----------------------------------------------------------------------------------------
    private void OnDisable()
    {
        var volumes = GetComponents<NavMeshModifierVolume>();
        if (volumes != null)
        {
            for (int index = 0; index < volumes.Length; index++)
                VolumeModifiers.Remove(volumes[index]);
        }

        var modifier = GetComponent<NavMeshModifier>();
        if ((modifier != null) && (modifier.ignoreFromBuild))
            return;

        var mesh = GetComponent<MeshFilter>();
        if (mesh != null)
            Meshes.Remove(mesh);
    }

    //----------------------------------------------------------------------------------------
    public static void CollectMeshes(ref List<NavMeshBuildSource> _sources)
    {
        _sources.Clear();
        for (var i = 0; i < Meshes.Count; ++i)
        {
            var mf = Meshes[i];

            if (mf == null)
                continue;

            var m = mf.sharedMesh;
            if (m == null)
                continue;

            var s = new NavMeshBuildSource();
            s.shape = NavMeshBuildSourceShape.Mesh;
            s.sourceObject = m;
            s.transform = mf.transform.localToWorldMatrix;
            var modifier = mf.GetComponent<NavMeshModifier>();
            s.area = modifier && modifier.overrideArea ? modifier.area : 0;
            _sources.Add(s);
        }
    }

    //----------------------------------------------------------------------------------------
    public static void CollectModifierVolumes(int _layerMask, ref List<NavMeshBuildSource> _sources)
    {
        foreach (var m in VolumeModifiers)
        {
            if ((_layerMask & (1 << m.gameObject.layer)) == 0)
                continue;
            if (!m.AffectsAgentType(AgentTypeId))
                continue;

            var mcenter = m.transform.TransformPoint(m.center);
            var scale = m.transform.lossyScale;
            var msize = new Vector3(m.size.x * Mathf.Abs(scale.x), m.size.y * Mathf.Abs(scale.y), m.size.z * Mathf.Abs(scale.z));

            var src = new NavMeshBuildSource();
            src.shape = NavMeshBuildSourceShape.ModifierBox;
            src.transform = Matrix4x4.TRS(mcenter, m.transform.rotation, Vector3.one);
            src.size = msize;
            src.area = m.area;
            _sources.Add(src);
        }
    }
}