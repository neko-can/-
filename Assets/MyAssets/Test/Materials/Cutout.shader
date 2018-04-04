Shader "Custom/Cutout" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
	}

		SubShader{
		Tags{ "Queue" = "Geometry-2" }

		Pass{
		Zwrite On
		ColorMask 0
	}
	}
}