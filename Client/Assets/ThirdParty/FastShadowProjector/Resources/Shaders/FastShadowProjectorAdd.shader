 Shader "Fast Shadow Projector/Add"
 {
     Properties
     {
         _ShadowTex ("Cookie", 2D) = "gray"
     }
      
     Subshader
     {
         Tags { "RenderType"="Transparent" "Queue"="Transparent-1" }
         Pass
         {
             ZWrite Off
             ColorMask RGBA
             Blend One One
			 Offset -1, -1
			 Fog { Color (0, 0, 0) }
                          
             CGPROGRAM
             #pragma vertex vert
             #pragma fragment frag
   
             #include "UnityCG.cginc"
              
             struct v2f
             {
                 float4 pos : SV_POSITION;
                 float4 uv_Main : TEXCOORD0;
                 float4 uv_MainClip : TEXCOORD1;
             };
             
              
             sampler2D _ShadowTex;
             float4x4 _GlobalProjector;
             float4x4 _GlobalProjectorClip;
              
             v2f vert(appdata_tan v)
             {
                 v2f o;
                 o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
                 o.uv_Main = mul (_GlobalProjector, v.vertex);
                 o.uv_MainClip = mul (_GlobalProjectorClip, v.vertex);
                 return o;
             }
              
             half4 frag (v2f i) : COLOR
             {
                half4 tex = half4(0, 0, 0, 0);
                 
                if (i.uv_MainClip.w < 1.0f) {
               
                 	tex = tex2D(_ShadowTex, i.uv_Main.xy);
                 }
          
 
                 return tex;
             }
             ENDCG
      
         }
     }
 }