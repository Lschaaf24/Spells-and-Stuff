Shader "Custom/FIreDude"
{
    Properties
    {
        [MainColor] _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        [MainTexture] _BaseMap("Base Map", 2D) = "white" {}

        [HDR] _EmissionColor("Emission Color", Color) = (0, 0, 0, 1)
        _EmissionMap("Emission Map", 2D) = "white" {}

        _NoiseMap("Noise Map", 2D) = "gray" {}
        _WarpStrength("Warp Strength", Range(0, 0.2)) = 0.05
        _NoiseScrollSpeed("Noise Scroll Speed (XY)", Vector) = (0.1, 0.1, 0, 0)
        _NoiseScale("Noise Scale (Tiling)", Float) = 1.0
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

\

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            TEXTURE2D(_EmissionMap);
            SAMPLER(sampler_EmissionMap);

            TEXTURE2D(_NoiseMap);
            SAMPLER(sampler_NoiseMap);

            CBUFFER_START(UnityPerMaterial)
                half4 _BaseColor;
                float4 _BaseMap_ST;
                half4 _EmissionColor;
                float4 _EmissionMap_ST;

                float4 _NoiseMap_ST;
                float _WarpStrength;
                float2 _NoiseScrollSpeed;
                float _NoiseScale;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                float3 modifiedPosition = IN.positionOS.xyz;
                modifiedPosition.y += (sin(((modifiedPosition.z * 50.0f) - _Time.y) * 3.0f) * IN.uv.y) / 100.0f;
                OUT.positionHCS = TransformObjectToHClip(modifiedPosition.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);
                return OUT;
            }

           half4 frag(Varyings IN) : SV_Target
            {
                // 1. Base color sampling
                half4 baseColor = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv) * _BaseColor;

                // 2. Animate and tile the noise UVs
                float2 noiseUV = (IN.uv * _NoiseScale) + (_Time.y * _NoiseScrollSpeed);

                // 3. Sample noise (centered from [0, 1] to [-0.5, 0.5] for bi-directional offset)
                half2 noiseOffset = (SAMPLE_TEXTURE2D(_NoiseMap, sampler_NoiseMap, noiseUV).rg - 0.5) * 2.0;

                // 4. Offset emission UVs using the noise vector
                float2 warpedEmissionUV = IN.uv + (noiseOffset * _WarpStrength);

                // 5. Sample warped emission texture
                half3 emission = SAMPLE_TEXTURE2D(_EmissionMap, sampler_EmissionMap, warpedEmissionUV).rgb * _EmissionColor.rgb;

                // 6. Combine base color and emission
                half4 finalColor = baseColor;
                finalColor.rgb += emission;

                return finalColor;
            }
            ENDHLSL
        }
    }
}
