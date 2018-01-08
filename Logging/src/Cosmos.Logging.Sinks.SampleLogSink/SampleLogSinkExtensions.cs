﻿using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public static class SampleLogSinkExtensions {
        public static ILogServiceCollection WriteToSampleLog(this ILogServiceCollection services) {
            return services.WriteToSampleLog((Action<SampleLogSinkSettings>) null);
        }
        
        public static ILogServiceCollection WriteToSampleLog(this ILogServiceCollection services, Action<SampleLogSinkSettings> sinkSettingAct) {

            var settings = new SampleLogSinkSettings();
            sinkSettingAct?.Invoke(settings);
            return services.WriteToSampleLog(settings);
        }

        public static ILogServiceCollection WriteToSampleLog(this ILogServiceCollection services, SampleLogSinkSettings settings) {
            return services.WriteToSampleLog(Options.Create(settings));
        }

        public static ILogServiceCollection WriteToSampleLog(this ILogServiceCollection service, IOptions<SampleLogSinkSettings> settings) {
            service.AddSinkSettings(settings.Value);
            service.AddDependency(s => {
                s.AddScoped<ILogPayloadClient, SampleLogPayloadClient>();
                s.AddScoped<ILogPayloadClientProvider, SampleLogPayloadClientProvider>();
                s.AddSingleton(settings);
            });
            return service;
        }
    }
}