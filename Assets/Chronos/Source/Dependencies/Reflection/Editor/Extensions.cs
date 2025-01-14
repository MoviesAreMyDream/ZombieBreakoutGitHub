using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Chronos.Reflection
{
	public static class Extensions
	{
		// Used to print pretty type names for primities
		private static CSharpCodeProvider csharp = new CSharpCodeProvider();

		/// <summary>
		/// Returns the name for the given type where primitives are in their shortcut form.
		/// </summary>
		public static string PrettyName(this Type type)
		{
			string cSharpOutput = csharp.GetTypeOutput(new CodeTypeReference(type));

			if (cSharpOutput.Contains('.'))
			{
				return cSharpOutput.Substring(cSharpOutput.LastIndexOf('.') + 1);
			}
			else
			{
				return cSharpOutput;
			}
		}
	}
}
