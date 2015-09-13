float4x4 xWorld;
float4x4 xView;
float4x4 xProjection;


struct VertexShaderInput
{
	float4 Position : SV_POSITION;
	float3 vertexNormal     : NORMAL0;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color    : COLOR0;
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

	return output;
}

/////////////////////////////////////////////
// Pixel Shader
/////////////////////////////////////////////
float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	return input.Color;
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
