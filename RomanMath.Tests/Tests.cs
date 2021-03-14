using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RomanMath.Impl;
using System;
using Assert = NUnit.Framework.Assert;

namespace RomanMath.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Test1()
		{
			
			var exception = Assert.Throws<ArgumentException>(() => Service.Evaluate("IV+II/V"));
			Assert.AreEqual(null, null);

		}
		[Test]
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Test6()
		{

			var exception = Assert.Throws<ArgumentException>(() => Service.Evaluate(""));
			Assert.AreEqual(null, null);

		}
		[Test]
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Test7()
		{

			var exception = Assert.Throws<System.Data.SyntaxErrorException>(() => Service.Evaluate("*"));
			Assert.AreEqual(null, null);

		}
		[Test]
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]

  
        public void Test2()
		{
			var result = Service.Evaluate("IV+II*V");
			Assert.AreEqual(14, result);
		}
		[Test]
		public void Test3()
		{
			var result = Service.Evaluate("MD+X-IX");
			Assert.AreEqual(1501, result);
		}
		[Test]
		public void Test4()
		{
			var result = Service.Evaluate("I+II-I");
			Assert.AreEqual(2, result);
		}
		[Test]
		public void Test5()
		{
			var result = Service.Evaluate("X-V");
			Assert.AreEqual(5, result);
		}
	}
}