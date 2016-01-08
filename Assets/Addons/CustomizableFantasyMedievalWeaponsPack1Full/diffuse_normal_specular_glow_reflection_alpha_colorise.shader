Shader "diffuse_normal_specular_glow_reflection_alpha"
{
	Properties 
	{
_diffuse_color("_diffuse_color", Color) = (1,1,1,1)
_specular_color("_specular_color", Color) = (1,1,1,1)
_glow_color("_glow_color", Color) = (1,1,1,1)
_colorise_color_red_channel("_colorise_color_red_channel", Color) = (1,1,1,1)
_colorise_color_green_channel("_colorise_color_green_channel", Color) = (1,1,1,1)
_colorise_color_blue_channel("_colorise_color_blue_channel", Color) = (1,1,1,1)
_colorise_color_Alpha("_colorise_color_Alpha", Color) = (1,1,1,1)
_glossiness("_glossiness", Range(0,1) ) = 0.5
_glowness("_glowness", Range(0,2) ) = 0.5
_reflectioness("_reflectioness", Range(0,1) ) = 0.5
_diffuse("_diffuse", 2D) = "black" {}
_normalmap("_normalmap", 2D) = "black" {}
_specular("_specular", 2D) = "black" {}
_glow("_glow", 2D) = "black" {}
_reflection("_reflection", 2D) = "black" {}
_cubemap("_cubemap", Cube) = "black" {}
_colorise("_colorise", 2D) = "black" {}

	}
	
	SubShader 
	{
		Tags
		{
"Queue"="Transparent"
"IgnoreProjector"="False"
"RenderType"="Transparent"

		}

		
Cull Back
ZWrite On
ZTest LEqual
ColorMask RGBA
Blend SrcAlpha OneMinusSrcAlpha
Fog{
}


		CGPROGRAM
#pragma surface surf BlinnPhongEditor  vertex:vert
#pragma target 3.0


float4 _diffuse_color;
float4 _specular_color;
float4 _glow_color;
float4 _colorise_color_red_channel;
float4 _colorise_color_green_channel;
float4 _colorise_color_blue_channel;
float4 _colorise_color_Alpha;
float _glossiness;
float _glowness;
float _reflectioness;
sampler2D _diffuse;
sampler2D _normalmap;
sampler2D _specular;
sampler2D _glow;
sampler2D _reflection;
samplerCUBE _cubemap;
sampler2D _colorise;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
half3 spec = light.a * s.Gloss;
half4 c;
c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
c.a = s.Alpha;
return c;

			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot ( lightDir, s.Normal ));
				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;

				return LightingBlinnPhongEditor_PrePass( s, res );
			}
			
			struct Input {
				float2 uv_colorise;
float2 uv_diffuse;
float3 simpleWorldRefl;
float2 uv_reflection;
float2 uv_normalmap;
float2 uv_glow;
float2 uv_specular;

			};

			void vert (inout appdata_full v, out Input o) {
float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);

o.simpleWorldRefl = -reflect( normalize(WorldSpaceViewDir(v.vertex)), normalize(mul((float3x3)_Object2World, SCALED_NORMAL)));

			}
			

			void surf (Input IN, inout EditorSurfaceOutput o) {
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
float4 Sampled2D4=tex2D(_colorise,IN.uv_colorise.xy);
float4 Splat0=Sampled2D4.x;
float4 Multiply5=Splat0 * _colorise_color_red_channel;
float4 Splat1=Sampled2D4.y;
float4 Multiply9=Splat1 * _colorise_color_green_channel;
float4 Add2=Multiply5 + Multiply9;
float4 Splat2=Sampled2D4.z;
float4 Multiply10=Splat2 * _colorise_color_blue_channel;
float4 Splat3=Sampled2D4.aaaa.w;
float4 Multiply11=Splat3 * _colorise_color_Alpha;
float4 Add3=Multiply10 + Multiply11;
float4 Add4=Add2 + Add3;
float4 Sampled2D0=tex2D(_diffuse,IN.uv_diffuse.xy);
float4 Multiply1=_diffuse_color * Sampled2D0;
float4 TexCUBE0=texCUBE(_cubemap,float4( IN.simpleWorldRefl.x, IN.simpleWorldRefl.y,IN.simpleWorldRefl.z,1.0 ));
float4 Sampled2D3=tex2D(_reflection,IN.uv_reflection.xy);
float4 Multiply6=_reflectioness.xxxx * Sampled2D3;
float4 Multiply2=TexCUBE0 * Multiply6;
float4 Add0=Multiply1 + Multiply2;
float4 Multiply8=Add4 * Add0;
float4 Tex2DNormal0=float4(UnpackNormal( tex2D(_normalmap,(IN.uv_normalmap.xyxy).xy)).xyz, 1.0 );
float4 Sampled2D1=tex2D(_glow,IN.uv_glow.xy);
float4 Multiply3=_glow_color * Sampled2D1;
float4 Multiply0=_glowness.xxxx * Multiply3;
float4 Sampled2D2=tex2D(_specular,IN.uv_specular.xy);
float4 Multiply4=_specular_color * Sampled2D2;
float4 Master0_7_NoInput = float4(0,0,0,0);
float4 Master0_6_NoInput = float4(1,1,1,1);
o.Albedo = Multiply8;
o.Normal = Tex2DNormal0;
o.Emission = Multiply0;
o.Specular = _glossiness.xxxx;
o.Gloss = Multiply4;
o.Alpha = Sampled2D0.aaaa;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}