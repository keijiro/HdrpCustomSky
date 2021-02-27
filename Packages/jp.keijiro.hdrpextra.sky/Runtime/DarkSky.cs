using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace HdrpExtra.Sky {

[VolumeComponentMenu("Sky/Dark Sky"), SkyUniqueID(UNIQUE_ID)]
public class DarkSky : SkySettings
{
    #region Sky unique ID

    const int UNIQUE_ID = 0x0e186f1;

    #endregion

    #region Sky attributes

    public ColorParameter starColor =
      new ColorParameter(Color.white, false, false, true);

    public FloatParameter horizonPower =
      new FloatParameter(10);

    public FloatParameter polarPower =
      new FloatParameter(10);

    public ColorParameter foreColor =
      new ColorParameter(Color.black, false, false, true);

    public ColorParameter backColor =
      new ColorParameter(Color.black, false, false, true);

    #endregion

    #region SkySettings overrides

    public override System.Type GetSkyRendererType()
      => typeof(DarkSkyRenderer);

    public override int GetHashCode()
      => base.GetHashCode() * 23 +
           starColor.GetHashCode() +
           horizonPower.GetHashCode() +
           polarPower.GetHashCode() +
           foreColor.GetHashCode() +
           backColor.GetHashCode();

    #endregion
}

} // namespace HdrpExtra.Sky
