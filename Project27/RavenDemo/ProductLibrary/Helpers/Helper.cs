using System;

namespace ProductLibrary.Helpers
{
    public static class Helper
    {
        public static string GetRandomName()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
