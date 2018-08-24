using System;
using System.Collections.Generic;


namespace PLib.Utils
{

	public static class Assert
	{

		#region [ Conditions ]

		/// <summary>
		///     Asserts that a condition is <see langword="false"/>.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="condition">The condition result.</param>
		/// <exception cref="ArgumentException">If <paramref name="condition"/> is true.</exception>
		public static void IsFalse(string paramName, bool condition)
		{
			if (condition)
			{
				throw new ArgumentException("Argument not false.", paramName);
			}
		}



		/// <summary>
		///     Asserts that a condition is <see langword="true"/>.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="condition">The condition result.</param>
		/// <exception cref="ArgumentException">If <paramref name="condition"/> is false.</exception>
		public static void IsTrue(string paramName, bool condition)
		{
			if (!condition)
			{
				throw new ArgumentException("Argument not true.", paramName);
			}
		}

		#endregion [ Conditions ]



		#region [ Objects ]

		/// <summary>
		///     Asserts that an object is <see langword="null"/>.
		/// </summary>
		/// <param name="obj">The object to test.</param>
		/// <exception cref="ArgumentException">If <paramref name="obj"/> is not <see langword="null"/>.</exception>
		public static void IsNull(object obj)
		{
			if (obj != null)
			{
				throw new ArgumentException("Argument not null.");
			}
		}



		/// <summary>
		///     Asserts that an object is <see langword="null"/>.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="obj">The object to test.</param>
		/// <exception cref="ArgumentException">If <paramref name="obj"/> is not <see langword="null"/>.</exception>
		public static void IsNull(string paramName, object obj)
		{
			if (obj != null)
			{
				throw new ArgumentException("Argument not null.", paramName);
			}
		}



		/// <summary>
		///     Asserts that an object is not <see langword="null"/>.
		/// </summary>
		/// <param name="obj">The object to test.</param>
		/// <exception cref="ArgumentNullException">if <paramref name="obj"/> is <see langword="null"/>.</exception>
		public static void IsNotNull(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException();
			}
		}



		/// <summary>
		///     Asserts that an object is not <see langword="null"/>.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="obj">The object to test.</param>
		/// <exception cref="ArgumentNullException">If <paramref name="obj"/> is <see langword="null"/>.</exception>
		public static void IsNotNull(string paramName, object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(paramName);
			}
		}

		#endregion [ Objects ]



		#region [ Strings ]

		/// <summary>
		///     Asserts that a string is empty.
		/// </summary>
		/// <param name="str">The string to test.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="str"/> is <see langword="null"/> or has at least one character.
		/// </exception>
		public static void IsEmpty(string str)
		{
			if (str == null || str.Length > 0)
			{
				throw new ArgumentException("String is not empty.");
			}
		}



		/// <summary>
		///     Asserts that a string is empty.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="str">The string to test.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="str"/> is <see langword="null"/> or has at least one character.
		/// </exception>
		public static void IsEmpty(string paramName, string str)
		{
			if (str == null || str.Length > 0)
			{
				throw new ArgumentException("String is not empty.", paramName);
			}
		}



		/// <summary>
		///     Asserts that a string is not empty.
		/// </summary>
		/// <param name="str">The string to test.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="str"/> is not <see langword="null"/>, but empty.
		/// </exception>
		public static void IsNotEmpty(string str)
		{
			if (str != null && str.Length == 0)
			{
				throw new ArgumentException("String is empty.");
			}
		}



		/// <summary>
		///     Asserts that a string is not empty.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="str">The string to test.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="str"/> is not <see langword="null"/>, but empty.
		/// </exception>
		public static void IsNotEmpty(string paramName, string str)
		{
			if (str != null && str.Length == 0)
			{
				throw new ArgumentException("String is empty.", paramName);
			}
		}



		/// <summary>
		///     Asserts that a string is <see langword="null"/> or empty.
		/// </summary>
		/// <param name="str">The string to test.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="str"/> is not <see langword="null"/>, nor empty.
		/// </exception>
		public static void IsNullOrEmpty(string str)
		{
			if (!string.IsNullOrEmpty(str))
			{
				throw new ArgumentException("String contains characters.");
			}
		}



		/// <summary>
		///     Asserts that a string is <see langword="null"/> or empty.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="str">The string to test.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="str"/> is not <see langword="null"/>, nor empty.
		/// </exception>
		public static void IsNullOrEmpty(string paramName, string str)
		{
			if (!string.IsNullOrEmpty(str))
			{
				throw new ArgumentException("String contains characters.", paramName);
			}
		}



		/// <summary>
		///     Asserts that a string is not null, nor an empty string.
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <exception cref="ArgumentException">
		///     if <paramref name="value"/> is <see langword="null"/> or an emty string.
		/// </exception>
		public static void IsNotNullNorEmpty(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("String is null or empty.");
			}
		}



		/// <summary>
		///     Asserts that a string is not null, nor an empty string.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="value">The string to test.</param>
		/// <exception cref="ArgumentException">
		///     if <paramref name="value"/> is <see langword="null"/> or an emty string.
		/// </exception>
		public static void IsNotNullNorEmpty(string paramName, string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("String is null or empty.", paramName);
			}
		}



		/// <summary>
		///     Asserts that a string is <see langword="null"/>, an empty string, or contains only
		///     white-space characters.
		/// </summary>
		/// <param name="str">The string to test.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="str"/> is not <see langword="null"/>, not an empty string, and
		///     contains non-white-space characters.
		/// </exception>
		public static void IsNullOrWhiteSpace(string str)
		{
			if (!string.IsNullOrWhiteSpace(str))
			{
				throw new ArgumentException("String contains non-white-space characters.");
			}
		}



		/// <summary>
		///     Asserts that a string is <see langword="null"/>, an empty string, or contains only
		///     white-space characters.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="str">The string to test.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="str"/> is not <see langword="null"/>, not an empty string, and
		///     contains non-white-space characters.
		/// </exception>
		public static void IsNullOrWhiteSpace(string paramName, string str)
		{
			if (!string.IsNullOrWhiteSpace(str))
			{
				throw new ArgumentException("String contains non-white-space characters.", paramName);
			}
		}



		/// <summary>
		///     Asserts that a string is not null, not an empty string, and does not contains of only
		///     whitespace characters.
		/// </summary>
		/// <param name="str">The string to test.</param>
		/// <exception cref="ArgumentException">
		///     if <paramref name="str"/> is <see langword="null"/>, an emty string, or contains of
		///     only whitespace characters.
		/// </exception>
		public static void IsNotNullNorWhitespace(string str)
		{
			if (string.IsNullOrWhiteSpace(str))
			{
				throw new ArgumentException("String is null, empty or blank.");
			}
		}



		/// <summary>
		///     Asserts that a string is not null, not an empty string, and does not contains of only
		///     whitespace characters.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="str">The string to test.</param>
		/// <exception cref="ArgumentException">
		///     if <paramref name="str"/> is <see langword="null"/>, an emty string, or contains of
		///     only whitespace characters.
		/// </exception>
		public static void IsNotNullNorWhitespace(string paramName, string str)
		{
			if (string.IsNullOrWhiteSpace(str))
			{
				throw new ArgumentException("String is null, empty or blank.", paramName);
			}
		}

		#endregion [ Strings ]



		#region [ Arrays ]

		/// <summary>
		///     sserts that an array is empty.
		/// </summary>
		/// <param name="array">The array to test.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="array"/> is <see langword="null"/>, or contains at least one element.
		/// </exception>
		/// <remarks>
		///     By empty means that the <paramref name="array"/> is not null and contains no
		///     elements. So if it is either null, or does contain at least one element, an exception
		///     will be thrown.
		/// </remarks>
		public static void IsEmpty(Array array)
		{
			if (array == null || array.Length > 0)
			{
				throw new ArgumentException("Array is not empty.");
			}
		}



		/// <summary>
		///     Asserts that an array is empty.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="array">The array to test.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="array"/> is <see langword="null"/>, or contains at least one element.
		/// </exception>
		/// <remarks>
		///     By empty means that the <paramref name="array"/> is not null and contains no
		///     elements. So if it is either null, or does contain at least one element, an exception
		///     will be thrown.
		/// </remarks>
		public static void IsEmpty(string paramName, Array array)
		{
			if (array == null || array.Length > 0)
			{
				throw new ArgumentException("Array is not empty.", paramName);
			}
		}



		/// <summary>
		///     Asserts that an array is not empty.
		/// </summary>
		/// <param name="array">The array to test.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="array"/> is not <see langword="null"/>, but empty.
		/// </exception>
		/// <remarks>
		///     By not empty means that the <paramref name="array"/> is either <see langword="null"/>
		///     or has at least one element. So, if it is not null and contains no elements an
		///     exception will be thrown.
		/// </remarks>
		public static void IsNotEmpty(Array array)
		{
			if (array != null && array.Length == 0)
			{
				throw new ArgumentException("Array is empty.");
			}
		}



		/// <summary>
		///     Asserts that an array is not empty.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="array">The array to test.</param>
		/// <exception cref="ArgumentException">
		///     If <paramref name="array"/> is not <see langword="null"/>, but empty.
		/// </exception>
		/// <remarks>
		///     By not empty means that the <paramref name="array"/> is either <see langword="null"/>
		///     or has at least one element. So, if it is not null and contains no elements an
		///     exception will be thrown.
		/// </remarks>
		public static void IsNotEmpty(string paramName, Array array)
		{
			if (array != null && array.Length == 0)
			{
				throw new ArgumentException("Array is empty.", paramName);
			}
		}



		/// <summary>
		///     Asserts that an array has at least one element.
		/// </summary>
		/// <param name="array">The array to check.</param>
		/// <exception cref="System.ArgumentException">
		///     If <paramref name="array"/> is <see langword="null"/> or empty.
		/// </exception>
		public static void IsNotNullNorEmpty(Array array)
		{
			if (array == null || array.Length == 0)
			{
				throw new ArgumentException("Array is null or empty.");
			}
		}



		/// <summary>
		///     Asserts that an array has at least one element.
		/// </summary>
		/// <param name="paramName">The parameter name.</param>
		/// <param name="array">The array to check.</param>
		/// <exception cref="System.ArgumentException">
		///     If <paramref name="array"/> is <see langword="null"/> or empty.
		/// </exception>
		public static void IsNotNullNorEmpty(string paramName, Array array)
		{
			if (array == null || array.Length == 0)
			{
				throw new ArgumentException("Array is null or empty.", paramName);
			}
		}

		#endregion [ Arrays ]

	}

}
