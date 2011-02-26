using System;

namespace Griz.Tests.Helpers
{
    /// <summary>
    /// When this is applied to a test class that inherits from DataTestBase, it causes all tests
    /// in that class to be wrapped in "auto rollback transactions". As such, any database
    /// changes caused by those tests are automatically rolled back in the test teardown
    /// method.
    /// 
    /// IMPORTANT: if you apply this attribute to a test class that needs custom setup or teardown
    /// methods, those methods MUST call "base.Setup()" and "base.Teardown()" in addition to their
    /// custom work. Otherwise, the automatic transaction will not be started or reverted.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AutoRollbackAttribute : Attribute
    {

        public AutoRollbackAttribute()
        {
            // nothing to do, presence of attribute is enough
        }
    }
}
