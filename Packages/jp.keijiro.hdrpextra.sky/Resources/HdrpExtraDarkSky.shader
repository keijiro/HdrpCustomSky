Shader "Hidden/HdrpExtra/Sky/DarkSky"
{
    HLSLINCLUDE

    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/CommonLighting.hlsl"
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Sky/SkyUtils.hlsl"

    float3 _StarColor;
    float4 _SkyParams;

    float3x3 GetRotationMatrix()
    {
        float cs = cos(_SkyParams.y), sn = sin(_SkyParams.y);
        return float3x3(cs, 0, sn, 0, 1,  0, -sn, 0, cs);
    }

    float4 Vertex(uint vertexID : SV_VertexID) : SV_POSITION
    {
        return GetFullScreenTriangleVertexPosition
          (vertexID, UNITY_RAW_FAR_CLIP_VALUE);
    }

    float4 RenderSky(float4 positionCS, float exposure)
    {
        float3 viewDirWS = GetSkyViewDirWS(positionCS.xy);
        viewDirWS = mul(GetRotationMatrix(), viewDirWS);

        float y = viewDirWS.y;
        float z = max(0, -viewDirWS.z);

        float3 color = _StarColor * _SkyParams.x * exposure;
        color *= pow(saturate(1 - abs(y)), _SkyParams.z);
        color *= pow(abs(z), _SkyParams.w);

        return float4(ClampToFloat16Max(color), 1);
    }

    float4 FragmentBaking(float4 positionCS : SV_POSITION) : SV_Target
    {
        return RenderSky(positionCS, 1);
    }

    float4 FragmentRender(float4 positionCS : SV_POSITION) : SV_Target
    {
        return RenderSky(positionCS, GetCurrentExposureMultiplier());
    }

    ENDHLSL

    SubShader
    {
        Pass
        {
            ZWrite Off ZTest Always Blend Off Cull Off
            HLSLPROGRAM
            #pragma vertex Vertex
            #pragma fragment FragmentBaking
            ENDHLSL
        }

        Pass
        {
            ZWrite Off ZTest LEqual Blend Off Cull Off
            HLSLPROGRAM
            #pragma vertex Vertex
            #pragma fragment FragmentRender
            ENDHLSL
        }
    }

    Fallback Off
}
