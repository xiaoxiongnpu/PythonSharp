﻿namespace PythonSharp.Tests.Functions
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PythonSharp.Functions;
    using PythonSharp.Exceptions;

    [TestClass]
    public class EvalFunctionTests
    {
        private EvalFunction eval;

        [TestInitialize]
        public void Setup()
        {
            this.eval = new EvalFunction();
        }

        [TestMethod]
        public void EvalSimpleText()
        {
            Assert.AreEqual(0, eval.Apply(null, new object[] { "0" }, null));
        }

        [TestMethod]
        public void RaiseIfNoArgument()
        {
            try
            {
                eval.Apply(null, null, null);
                Assert.Fail("Exception expected");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(TypeError));
                Assert.AreEqual("eval expected at least 1 arguments, got 0", ex.Message);
            }
        }

        [TestMethod]
        public void RaiseIfFirstArgumentIsNotAString()
        {
            try
            {
                eval.Apply(null, new object[] { 0 }, null);
                Assert.Fail("Exception expected");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(TypeError));
                Assert.AreEqual("eval() arg 1 must be a string, bytes or code object", ex.Message);
            }
        }
    }
}
