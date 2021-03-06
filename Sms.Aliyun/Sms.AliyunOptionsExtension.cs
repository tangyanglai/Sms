﻿using Sms;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sms.Aliyun;
using Sms.Aliyun.Internal;

namespace Sms.ChinaMobile
{
    public class AliyunOptionsExtension : ISmsOptionsExtension
    {
        private readonly Action<AliyunOptions> _configure;

        public AliyunOptionsExtension(Action<AliyunOptions> configure)
        {
            _configure = configure;
        }

        public void AddServices(IServiceCollection services)
        {
            //Inject Services
            //services.TryAddTransient<AliyunClient>();
            services.TryAddEnumerable(ServiceDescriptor.Transient<ISmsService, AliyunService>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<IAliSmsService, AliyunService>());

            //Add ChinaMobileOptions
            services.Configure(_configure);
            services.AddSingleton<IConfigureOptions<AliyunOptions>, ConfigureAliyunOptions>();

        }
    }
}
