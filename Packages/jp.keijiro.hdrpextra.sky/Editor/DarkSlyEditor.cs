using UnityEditor;
using UnityEditor.Rendering;
using UnityEditor.Rendering.HighDefinition;

namespace HdrpExtra.Sky.Editor {

[CanEditMultipleObjects]
[CustomEditor(typeof(DarkSky))]
class DarkSkySettingsEditor : SkySettingsEditor
{
    SerializedDataParameter _starColor;
    SerializedDataParameter _horizonPower;
    SerializedDataParameter _polarPower;
    SerializedDataParameter _foreColor;
    SerializedDataParameter _backColor;

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
        _foreColor    = Unpack(o.Find(x => x.foreColor));
        _backColor    = Unpack(o.Find(x => x.backColor));
    }

    public override void OnInspectorGUI()
    {
        PropertyField(_starColor);
        PropertyField(_horizonPower);
        PropertyField(_polarPower);
        PropertyField(_foreColor);
        PropertyField(_backColor);

        base.CommonSkySettingsGUI();
    }
}

} // namespace HdrpExtra.Sky.Editor
