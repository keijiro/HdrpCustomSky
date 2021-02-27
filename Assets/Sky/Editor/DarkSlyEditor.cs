using UnityEditor;
using UnityEditor.Rendering;
using UnityEditor.Rendering.HighDefinition;

namespace DxrCrystal.Editor {

[CanEditMultipleObjects]
[VolumeComponentEditor(typeof(DarkSky))]
class DarkSkySettingsEditor : SkySettingsEditor
{
    SerializedDataParameter _starColor;
    SerializedDataParameter _horizonPower;
    SerializedDataParameter _polarPower;

    public override void OnEnable()
    {
        base.OnEnable();

        m_CommonUIElementsMask =
          (uint)SkySettingsUIElement.SkyIntensity |
          (uint)SkySettingsUIElement.Rotation |
          (uint)SkySettingsUIElement.UpdateMode;

        var o = new PropertyFetcher<DarkSky>(serializedObject);

        _starColor    = Unpack(o.Find(x => x.starColor));
        _horizonPower = Unpack(o.Find(x => x.horizonPower));
        _polarPower   = Unpack(o.Find(x => x.polarPower));
    }

    public override void OnInspectorGUI()
    {
        PropertyField(_starColor);
        PropertyField(_horizonPower);
        PropertyField(_polarPower);

        base.CommonSkySettingsGUI();
    }
}

} // namespace DxrCrystal
