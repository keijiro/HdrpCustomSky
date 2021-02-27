using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace HdrpExtra.Sky {

public class DarkSkyRenderer : SkyRenderer
{
    #region Property ID

    readonly int StarColorID = Shader.PropertyToID("_StarColor");
    readonly int SkyParamsID = Shader.PropertyToID("_SkyParams");
    readonly int PC2ViewID = Shader.PropertyToID("_PixelCoordToViewDirWS");

    #endregion

    #region Private objects

    Material _material;
    MaterialPropertyBlock _props = new MaterialPropertyBlock();

    static Shader GetShader()
      => Resources.Load<Shader>("HdrpExtraDarkSky");

    #endregion

    #region SkyRenderer overrides

    public override void Build()
      => _material = CoreUtils.CreateEngineMaterial(GetShader());

    public override void Cleanup()
      => CoreUtils.Destroy(_material);

    protected override bool Update(BuiltinSkyParameters builtinParams)
      => false;

    public override void RenderSky
      (BuiltinSkyParameters builtinParams,
       bool renderForCubemap, bool renderSunDisk)
    {
        var settings = builtinParams.skySettings as DarkSky;

        var skyParams = new Vector4
          (GetSkyIntensity(settings, builtinParams.debugSettings),
           settings.rotation.value * Mathf.Deg2Rad,
           settings.horizonPower.value,
           settings.polarPower.value);

        _props.SetColor(StarColorID, settings.starColor.value);
        _props.SetVector(SkyParamsID, skyParams);
        _props.SetMatrix(PC2ViewID, builtinParams.pixelCoordToViewDirMatrix);

        var pass = renderForCubemap ? 0 : 1;
        CoreUtils.DrawFullScreen
          (builtinParams.commandBuffer, _material, _props, pass);
    }

    #endregion
}

} // namespace HdrpExtra.Sky
