Shader "Custom/ExtrudeColor"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_ColorGreen("GreenColor", Color) = (0.0,1.0,0.0,1.0)
		_ColorTrans("TransColor", Color) = (1.0,1.0,1.0,0.0)
		_ColorWhite("WhiteColor", Color) = (1.0,1.0,1.0,1.0)
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM

			#include "UnityCG.cginc"

			#pragma vertex vert
			#pragma fragment frag

			sampler2D _MainTex;

			float3 _CCenter;
			float3 _HCenter;
			float _CRayon;
			float _HRayon;
			float _Width;
			float _Height;
			fixed4 _ColorGreen;
			fixed4 _ColorTrans;
			fixed4 _ColorWhite;
			float _ValidEffect;

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

				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;

				return o;
			}

			float4 frag(vertexOutput i) : COLOR
			{
				float delta = 2500.0;

				float x = i.uv.x * _Width;
				float y = i.uv.y * _Height;

				float val = (x - _CCenter.x) * (x - _CCenter.x) + (y - _CCenter.y) * (y - _CCenter.y);
				float ray = _CRayon * _CRayon;
				float distance = (_HCenter.x - _CCenter.x) * (_HCenter.x - _CCenter.x) + (_HCenter.y - _CCenter.y) * (_HCenter.y - _CCenter.y);
				
				fixed4 colorFinal = tex2D(_MainTex, i.uv);

				if (val > ray - delta && val < ray && distance < ray && _ValidEffect > 0.0)
					colorFinal = _ColorTrans;
				else if (val > ray - delta && val < ray && distance < ray && _ValidEffect == 0.0)
					colorFinal = _ColorTrans;
				else if (val < ray)
					colorFinal = _ColorTrans;
				else if (_HRayon > 0.0)
				{
					val = (x - _HCenter.x) * (x - _HCenter.x) + (y - _HCenter.y) * (y - _HCenter.y);
					ray = _HRayon * _HRayon;

					if (val > ray - delta && val < ray && distance < ray && _ValidEffect > 0.0)
						colorFinal = _ColorWhite;
					else if (val > ray - delta && val < ray)
						colorFinal = _ColorWhite;
					else if (val < ray)
						colorFinal = _ColorTrans;
				}

				return colorFinal;
			}

			ENDCG
		}
	}
	
	FallBack Off
}