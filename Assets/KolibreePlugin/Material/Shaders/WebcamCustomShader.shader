// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Web Camera Shader"
{
    Properties
    {
        _MainTex ( "Main Texture", 2D ) = "white" {}
    }
   
    SubShader
    {      
        Pass
        {
            CGPROGRAM
           
			#include "UnityCG.cginc"

            #pragma vertex vert
            #pragma fragment frag
           
            uniform sampler2D _MainTex;
            uniform float4x4 _Rotation;
            uniform float _Flip;

            struct vertexInput
            {
                float4 vertex : POSITION;
                float4 texcoord : TEXCOORD0;
            };
           
            struct vertexOutput
            {
                float4 pos : SV_POSITION;
                half2 uv : TEXCOORD0;
            };
           
            vertexOutput vert(vertexInput v)
            {
                vertexOutput o;
                         
				v.texcoord.xy -= 0.5;
				v.texcoord.xy = mul (v.texcoord, _Rotation);
				v.texcoord.xy += 0.5;

				if (_Flip > 0)
					v.texcoord.y = 1.0 - v.texcoord.y;
				
                o.pos = UnityObjectToClipPos (v.vertex);
                o.uv = v.texcoord;
               
                return o;
            }
           
            float4 frag(vertexOutput i) : COLOR
            {
                return tex2D( _MainTex, i.uv );
            }

            ENDCG
        }
    }
	
    Fallback Off
}