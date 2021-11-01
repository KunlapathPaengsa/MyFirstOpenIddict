//using Autofac;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Options;
//using System;

//namespace MyFirstOpenIddict.Common.DependencyInjection.Autofac
//{
//    //
//    // Summary:
//    //     Autoface register extensions class
//    public static class AutofacRegisterExtentions
//    {
//        //
//        // Summary:
//        //     Registers a configuration instance which TOptions will bind against. With SingleInstance
//        //
//        // Parameters:
//        //   builder:
//        //     The ContainerBuilder to add the services.
//        //
//        //   configuration:
//        //     The configuration being bound.
//        //
//        //   sectionName:
//        //     The section name of the configuration
//        //
//        // Type parameters:
//        //   TOption:
//        //     The type of options being configured.
//        public static void RegisterConfiguration<TOption>(
//      this ContainerBuilder builder,
//      IConfiguration configuration,
//      string sectionName)
//      where TOption : class, new()
//        {
//            builder.Register<OptionsWrapper<TOption>>((Func<IComponentContext, OptionsWrapper<TOption>>)(r => new OptionsWrapper<TOption>(configuration.GetOptions<TOption>(sectionName)))).As<IOptions<TOption>>().SingleInstance();
//        }
//    }
//}
