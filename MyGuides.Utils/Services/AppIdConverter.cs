namespace MyGuides.Utils
{
    public static class AppIdConverter
    {
        public static string GetAppId(string appId)
        {
            List<string> url = appId.Split('/').ToList();
            if (url != null && url.Count() > 0)
            {
                foreach (var item in url)
                {
                    if (Utils.IsNumeric(item))
                    {
                        appId = item;
                        break;
                    }
                }
            }

            return appId;
        }
    }
}