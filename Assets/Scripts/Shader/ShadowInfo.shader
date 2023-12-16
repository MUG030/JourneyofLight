Shader "Custom/ShadowInfo"
{
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 shadowCoord : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.shadowCoord = o.pos;
                return o;
            }

            sampler2D _ShadowMap;

            fixed4 frag(v2f i) : SV_Target
            {
                float4 shadowCoord = i.shadowCoord / i.shadowCoord.w;
                float shadow = tex2D(_ShadowMap, shadowCoord.xy).r;
                return shadow < 0.5 ? fixed4(0, 0, 0, 1) : fixed4(1, 1, 1, 1);
            }
            ENDCG
        }
    }
}