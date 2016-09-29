/////////////////////////////////////////////
// Parameters
/////////////////////////////////////////////

//FloatParam("xFactor", 0.0, 10.0) = 0.5
//Texture2DParam("xAmbiantTex" ) = 0

/////////////////////////////////////////////
// Declarations
/////////////////////////////////////////////

float4x4 xWorld;
float4x4 xView;
float4x4 xProjection;

float xFactor;

Texture2D  xAmbiantTex;
sampler TexSamplerAmbient = sampler_state
{
	texture = <xAmbiantTex>; magfilter = LINEAR; minfilter = LINEAR; mipfilter = LINEAR; AddressU = Wrap; AddressV = Wrap;
};

struct VertexShaderInput
{
	float4 Position : SV_POSITION;
	float3 vertexNormal     : NORMAL0;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color    : COLOR0;
	float2 TexCoords    : TEXCOORD0;
};

/////////////////////////////////////////////
// Vertex Shader
/////////////////////////////////////////////
VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
	VertexShaderOutput output;

	//Position View
	float4 worldPosition = mul(input.Position, xWorld);
	float4 viewPosition = mul(worldPosition, xView);
	output.Position = mul(viewPosition, xProjection);


	float4 worldNormal = mul(input.vertexNormal, xWorld);
	output.Color = worldNormal;

	output.TexCoords = viewPosition;

	return output;
}

/////////////////////////////////////////////
// Pixel Shader
/////////////////////////////////////////////
float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	float4 tex0Color = tex2D(TexSamplerAmbient, input.TexCoords);
	return saturate(tex0Color * input.Color) * xFactor;
}

/////////////////////////////////////////////
// Technique
/////////////////////////////////////////////
technique Technique1
{
	pass Pass1
	{
		VertexShader = compile vs_4_0 VertexShaderFunction();
		PixelShader = compile ps_4_0 PixelShaderFunction();
	}
}
