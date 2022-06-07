Shader "MyShaders/DamageFeedback2" {
    Properties{
        _MainTex("Texture", 2D) = "white" { }
        _DisplaceTex("Displacement Texture", 2D) = "White" {}
        _Magnitude("Magnitude", Range(0,0.1)) = 1
    }
        SubShader{
            Pass {

        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag

        #include "UnityCG.cginc"

        sampler2D _MainTex;

        struct v2f {
            float4  pos : SV_POSITION;
            float2  uv : TEXCOORD0;
        };

        float4 _MainTex_ST;

        v2f vert(appdata_base v)
        {
            v2f o;
            o.pos = UnityObjectToClipPos(v.vertex);
            o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
            return o;
        }

        half4 frag(v2f i) : COLOR
        {
            half4 texcol = tex2D(_MainTex, i.uv);
            texcol.rgb = dot(texcol.rgb, float3(0.9245283, 0.05582049, 0.05582049));
            return texcol;
        }
        ENDCG

            }
    }
        Fallback "VertexLit"
}