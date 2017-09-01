using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyCompany(ProductInformation.Company)]
[assembly: AssemblyProduct(ProductInformation.Name)]
[assembly: AssemblyCopyright(ProductInformation.Copyright)]
[assembly: AssemblyTrademark(ProductInformation.Trademark)]

[assembly: AssemblyVersion(ProductInformation.VersionString)]
[assembly: AssemblyInformationalVersion(ProductInformation.InformationalVersion)]

[assembly: CLSCompliant(true)]

[assembly: AssemblyConfiguration(ProductInformation.Configuration)]

internal static class ProductInformation
{
    internal const string VersionString = "17.3.144";

    internal const string Company = "XX";
    internal const string Name = "SmartBed";
    internal const string Copyright = "Copyright © 2000 - 2016 XX. All Rights Reserved.";
    internal const string Trademark = "";
    internal const string InformationalVersion = VersionString;
    internal const string Configuration = "Debug";
}