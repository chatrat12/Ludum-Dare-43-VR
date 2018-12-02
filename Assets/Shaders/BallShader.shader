Shader "Custom/GameBall"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color1 ("Color 1", Color) = (1, 1, 1, 1)
		_Color2 ("Color 2", Color) = (0, 0, 0, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog
            
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
				float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
				float3 viewDir : TEXCOORD1;
				float3 normal : NORMAL;
				UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			fixed3 _Color1;
			fixed3 _Color2;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				o.viewDir = WorldSpaceViewDir(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
				o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
				col.rgb = i.viewDir*0.5 + 0.5;
				float f = 1 - dot(normalize(i.viewDir), i.normal);
				f = pow(f, .75);
				if (f < .25)
					f = 0;
				col.rgb = lerp(_Color1, _Color2, f);

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}