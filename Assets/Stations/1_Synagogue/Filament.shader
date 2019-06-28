// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Shader Forge/Filament" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TrailTexture ("TrailTexture", 2D) = "white" {}
        _FrameFadeAmount ("FrameFadeAmount", Float ) = 0.1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 1
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
           
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _TrailTexture; uniform float4 _TrailTexture_ST;
            uniform float _FrameFadeAmount;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _TrailTexture_var = tex2D(_TrailTexture,TRANSFORM_TEX(i.uv0, _TrailTexture));
                float3 emissive = ((_MainTex_var.rgb*_MainTex_var.a)+((1.0 - _MainTex_var.a)*_TrailTexture_var.rgb));
                float3 finalColor = emissive;
                return fixed4(finalColor,max(_MainTex_var.a,saturate((_TrailTexture_var.a+(-1*_FrameFadeAmount)))));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}