
using Microsoft.Extensions.Configuration;

namespace MyFirstOpenIddict.Common.DependencyInjection
{
    public static class ConfigurationExtension
    {
        /// <summary>Get configuration options</summary>
        /// <typeparam name="TModel">Type</typeparam>
        /// <param name="configuration">IConfiguration</param>
        /// <param name="section">Section name</param>
        /// <returns></returns>
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        {
            TModel model = new TModel();
            configuration.GetSection(section).Bind((object)model);
            return model;
        }
    }
}
