// Copyright Epic Games, Inc. All Rights Reserved.

#if DEBUG
	#define EOS_DEBUG
#endif

#if UNITY_EDITOR
	#define EOS_EDITOR
#endif

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_PS4 || UNITY_PS5 || UNITY_XBOXONE || UNITY_SWITCH || UNITY_IOS || UNITY_ANDROID || UNITY_WSA
#define EOS_UNITY
#endif

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || PLATFORM_64BITS || PLATFORM_32BITS || UNITY_WSA
#if UNITY_EDITOR_WIN || UNITY_64 || UNITY_EDITOR_64 || PLATFORM_64BITS || UNITY_WSA
#define EOS_PLATFORM_WINDOWS_64
#else
#define EOS_PLATFORM_WINDOWS_32
#endif

#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
	#define EOS_PLATFORM_OSX

#elif UNITY_EDITOR_LINUX || UNITY_STANDALONE_LINUX
	#define EOS_PLATFORM_LINUX

#elif UNITY_PS4
	#define EOS_PLATFORM_PS4

#elif UNITY_PS5
    #define EOS_PLATFORM_PS5

#elif UNITY_GAMECORE_XBOXONE
    #define EOS_PLATFORM_XBOXONE_GDK

#elif UNITY_GAMECORE_SCARLETT
   #define EOS_PLATFORM_XSX
#elif UNITY_XBOXONE
	#define EOS_PLATFORM_XBOXONE

#elif UNITY_SWITCH
	#define EOS_PLATFORM_SWITCH

#elif UNITY_IOS || __IOS__
	#define EOS_PLATFORM_IOS

#elif UNITY_ANDROID || __ANDROID__
	#define EOS_PLATFORM_ANDROID

#endif

using System.Runtime.InteropServices;

namespace Epic.OnlineServices
{
	
	public static partial class Config
	{
	
	#if EOS_PLATFORM_WINDOWS_32 || EOS_PLATFORM_WINDOWS_64 || EOS_PLATFORM_OSX || EOS_PLATFORM_LINUX || EOS_PLATFORM_IOS || EOS_PLATFORM_ANDROID
		public const string LibraryName =
		#if EOS_PLATFORM_WINDOWS_32 && EOS_UNITY
			"EOSSDK-Win32-Shipping"
		#elif EOS_PLATFORM_WINDOWS_32
			"EOSSDK-Win32-Shipping.dll"

		#elif EOS_PLATFORM_WINDOWS_64 && EOS_UNITY
			"EOSSDK-Win64-Shipping"
		#elif EOS_PLATFORM_WINDOWS_64
			"EOSSDK-Win64-Shipping.dll"

		#elif EOS_PLATFORM_OSX && EOS_UNITY
			"libEOSSDK-Mac-Shipping"
		#elif EOS_PLATFORM_OSX
			"libEOSSDK-Mac-Shipping.dylib"

		#elif EOS_PLATFORM_LINUX && EOS_UNITY
			"libEOSSDK-Linux-Shipping"
		#elif EOS_PLATFORM_LINUX
			"libEOSSDK-Linux-Shipping.so"

		#elif EOS_PLATFORM_IOS && EOS_UNITY && EOS_EDITOR
			"EOSSDK"
		#elif EOS_PLATFORM_IOS
			"EOSSDK.framework/EOSSDK"

		#elif EOS_PLATFORM_ANDROID
			"EOSSDK"

		#elif EOS_PLATFORM_PS4
        #if EOS_PLATFORM_PS4_CROSSGEN
            "EOSSDKCrossgen-PS4-Shipping.prx"
        #else
			"EOSSDK-PS4-Shipping.prx"
        #endif
		#elif EOS_PLATFORM_PS5
			"EOSSDK-PS5-Shipping.prx"

		#elif EOS_PLATFORM_SWITCH
			"EOSSDK-Switch-Shipping"

		#elif EOS_PLATFORM_XBOXONE_GDK
			"EOSSDK-XboxOneGDK-Shipping"

		#elif EOS_PLATFORM_XSX
			"EOSSDK-XSX-Shipping"

#elif EOS_DISABLE
#warning Disabling EOS

#else
#error Unable to determine the name of the EOSSDK library. Ensure you have set the correct EOS compilation symbol for the current platform, such as EOS_PLATFORM_WINDOWS_32 or EOS_PLATFORM_WINDOWS_64, so that the correct EOSSDK library can be targeted.
			"EOSSDK-UnknownPlatform-Shipping"

		#endif
		;
	#endif
	// PEW: End modify
		public const CallingConvention LibraryCallingConvention =
		#if EOS_PLATFORM_WINDOWS_32
			CallingConvention.StdCall
		#else
			CallingConvention.Cdecl
		#endif
		;
	}
}