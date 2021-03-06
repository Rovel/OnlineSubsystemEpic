// Fill out your copyright notice in the Description page of Project Settings.

using System.IO;
using UnrealBuildTool;

public class OnlineSubsystemEpicLibrary : ModuleRules
{
    public OnlineSubsystemEpicLibrary(ReadOnlyTargetRules Target) : base(Target)
    {
        Type = ModuleType.External;
                
        // Add header files to include path
        PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "Include"));
        string BaseDirectory = Path.GetFullPath(Path.Combine(ModuleDirectory, "..", "..", "ThirdParty", "OnlineSubsystemEpicLibrary"));

        PublicIncludePaths.Add(Path.Combine(BaseDirectory, "Include"));

        // Handle libraries
        if (Target.Platform == UnrealTargetPlatform.Win64) {
            // Add the import library
            PublicAdditionalLibraries.Add(Path.Combine(BaseDirectory, "Lib", "EOSSDK-Win64-Shipping.lib"));

            // Dlls
            RuntimeDependencies.Add(Path.Combine(BaseDirectory, "Bin", "EOSSDK-Win64-Shipping.dll"));
            PublicDelayLoadDLLs.Add("EOSSDK-Win64-Shipping.dll");
        } else if (Target.Platform == UnrealTargetPlatform.Win32) {
            // Add the import library
            PublicAdditionalLibraries.Add(Path.Combine(BaseDirectory, "Lib", "EOSSDK-Win32-Shipping.lib"));

            // Dlls
            RuntimeDependencies.Add(Path.Combine(BaseDirectory, "Bin", "EOSSDK-Win32-Shipping.dll"));
            PublicDelayLoadDLLs.Add("EOSSDK-Win32-Shipping.dll");
        } else if (Target.Platform == UnrealTargetPlatform.Linux) {
            // Add the import library
            PublicAdditionalLibraries.Add(Path.Combine(BaseDirectory, "Bin", "libEOSSDK-Linux-Shipping.so"));
            RuntimeDependencies.Add(Path.Combine(BaseDirectory, "Bin", "libEOSSDK-Linux-Shipping.so"));
        } else if (Target.Platform == UnrealTargetPlatform.Mac) {
            // Add the import library
            PublicAdditionalLibraries.Add(Path.Combine(BaseDirectory, "Bin", "libEOSSDK-Mac-Shipping.dylib"));
            RuntimeDependencies.Add(Path.Combine(BaseDirectory, "Bin", "libEOSSDK-Mac-Shipping.dylib"));
        }
    }
}
