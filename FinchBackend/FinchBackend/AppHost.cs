using Funq;
using ServiceStack;
using FinchBackend.ServiceInterface;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Auth;
using ServiceStack.Caching;

namespace FinchBackend
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyAspNet
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("FinchBackend", typeof(SearchServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            Plugins.Add(new CorsFeature());

            this.GlobalRequestFilters.Add((httpReq, httpRes, requestDto) => {
                // Handles Request and closes Responses after emitting global HTTP Headers
                if (httpReq.GetHttpMethodOverride() == "OPTIONS")
                    httpRes.EndRequest();
            });

            container.Register(c => DatabaseProvider.PrepareDatabase());

            container.Register<IAuthRepository>(c =>
                new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));
            container.Resolve<IAuthRepository>().InitSchema();

            container.Register<ICacheClient>(new MemoryCacheClient());

            Plugins.Add(new AuthFeature(
                () => new AuthUserSession(),
                new IAuthProvider[] {
                    new JwtAuthProvider(AppSettings) { AuthKey = AesUtils.CreateKey() },
                    new BasicAuthProvider(),
                    new CredentialsAuthProvider(),
                }
            ));
            Plugins.Add(new RegistrationFeature());
        }
    }
}