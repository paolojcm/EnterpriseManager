using DatabaseUtilities.General.Services;
using EnterpriseManager.Application.V1.Specific.City.Objects;
using EnterpriseManager.Application.V1.Specific.City.Services;
using EnterpriseManager.Application.V1.Specific.City.UseCases;
using EnterpriseManager.Application.V1.Specific.Country.Objects;
using EnterpriseManager.Application.V1.Specific.Country.Services;
using EnterpriseManager.Application.V1.Specific.Country.UseCases;
using EnterpriseManager.Application.V1.Specific.Enterprise.Objects;
using EnterpriseManager.Application.V1.Specific.Enterprise.Services;
using EnterpriseManager.Application.V1.Specific.Enterprise.UseCases;
using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Objects;
using EnterpriseManager.Application.V1.Specific.EnterpriseContact.Services;
using EnterpriseManager.Application.V1.Specific.EnterpriseContact.UseCases;
using EnterpriseManager.Application.V1.Specific.Entrepreneur.Objects;
using EnterpriseManager.Application.V1.Specific.Entrepreneur.Services;
using EnterpriseManager.Application.V1.Specific.Entrepreneur.UseCases;
using EnterpriseManager.Application.V1.Specific.MeanOfContact.Objects;
using EnterpriseManager.Application.V1.Specific.MeanOfContact.Services;
using EnterpriseManager.Application.V1.Specific.MeanOfContact.UseCases;
using EnterpriseManager.Application.V1.Specific.OperatingSegment.Objects;
using EnterpriseManager.Application.V1.Specific.OperatingSegment.Services;
using EnterpriseManager.Application.V1.Specific.OperatingSegment.UseCases;
using EnterpriseManager.Application.V1.Specific.State.Objects;
using EnterpriseManager.Application.V1.Specific.State.Services;
using EnterpriseManager.Application.V1.Specific.State.UseCases;
using EnterpriseManager.Domain.Specific.City.Repositories;
using EnterpriseManager.Domain.Specific.Country.Repositories;
using EnterpriseManager.Domain.Specific.Enterprise.Repositories;
using EnterpriseManager.Domain.Specific.EnterpriseContact.Repositories;
using EnterpriseManager.Domain.Specific.Entrepreneur.Repositories;
using EnterpriseManager.Domain.Specific.MeanOfContact.Repositories;
using EnterpriseManager.Domain.Specific.OperatingSegment.Repositories;
using EnterpriseManager.Domain.Specific.State.Repositories;
using EnterpriseManager.Infrastructure.Specific.ILogger.Formatters;
using EnterpriseManager.Infrastructure.Specific.MeanOfContact.Repositories;
using EnterpriseManager.Persistence.Specific.City.Repositories;
using EnterpriseManager.Persistence.Specific.Country.Repositories;
using EnterpriseManager.Persistence.Specific.Enterprise.Repositories;
using EnterpriseManager.Persistence.Specific.EnterpriseContact.Repositories;
using EnterpriseManager.Persistence.Specific.Entrepreneur.Repositories;
using EnterpriseManager.Persistence.Specific.OperatingSegment.Repositories;
using EnterpriseManager.Persistence.Specific.State.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.OpenApi;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace EnterpriseManager.Infrastructure.General
{
	///<Summary>
	/// This class is the application engine.
	///</Summary>
	public class Engine
	{
		private void LoadInfrastructureServices(IServiceCollection iServiceCollection)
		{
		}

		private void ConnectToTheDatabase(IServiceCollection iServiceCollection)
		{
			iServiceCollection.AddSingleton<IDatabaseUtilitiesSpecServ, DatabaseUtilitiesSpecServ>(_ =>
			{
				string fullPathToTheDatabaseFile = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", ".."));
				fullPathToTheDatabaseFile = Path.Combine(fullPathToTheDatabaseFile, @"Database\Enterprise.sqlite");
				SqliteConnection sqliteConnection = new SqliteConnection($@"Data Source={fullPathToTheDatabaseFile}");

				try
				{
					sqliteConnection.Open();
				}
				catch (Exception exception)
				{
					Console.WriteLine($"An error occurred: {exception}");
				}

				return new DatabaseUtilitiesSpecServ(sqliteConnection);
			});
		}

		private void LoadPersistenceRepositories(IServiceCollection iServiceCollection)
		{
			iServiceCollection.AddSingleton<ICityDomaSpecRepo, CityInfrSpecRepo>();
			iServiceCollection.AddSingleton<ICountryDomaSpecRepo, CountryInfrSpecRepo>();
			iServiceCollection.AddSingleton<IEnterpriseDomaSpecRepo, EnterpriseInfrSpecRepo>();
			iServiceCollection.AddSingleton<IEnterpriseContactDomaSpecRepo, EnterpriseContactInfrSpecRepo>();
			iServiceCollection.AddSingleton<IEntrepreneurDomaSpecRepo, EntrepreneurInfrSpecRepo>();
			iServiceCollection.AddSingleton<IMeanOfContactDomaSpecRepo, MeanOfContactInfrSpecRepo>();
			iServiceCollection.AddSingleton<IOperatingSegmentDomaSpecRepo, OperatingSegmentInfrSpecRepo>();
			iServiceCollection.AddSingleton<IStateDomaSpecRepo, StateInfrSpecRepo>();
		}

		private void LoadApplicationServices(IServiceCollection iServiceCollection)
		{
			iServiceCollection.AddSingleton<ICityAppSpecServ, CityAppSpecServ>();
			iServiceCollection.AddSingleton<ICountryAppSpecServ, CountryAppSpecServ>();
			iServiceCollection.AddSingleton<IEnterpriseAppSpecServ, EnterpriseAppSpecServ>();
			iServiceCollection.AddSingleton<IEnterpriseContactAppSpecServ, EnterpriseContactAppSpecServ>();
			iServiceCollection.AddSingleton<IEntrepreneurAppSpecServ, EntrepreneurAppSpecServ>();
			iServiceCollection.AddSingleton<IMeanOfContactAppSpecServ, MeanOfContactAppSpecServ>();
			iServiceCollection.AddSingleton<IOperatingSegmentAppSpecServ, OperatingSegmentAppSpecServ>();
			iServiceCollection.AddSingleton<IStateAppSpecServ, StateAppSpecServ>();
		}

		private void LoadUseCases(IServiceCollection iServiceCollection)
		{
			iServiceCollection.AddSingleton<ICityAppSpecUseCase, CityAppSpecUseCase>();
			iServiceCollection.AddSingleton<ICountryAppSpecUseCase, CountryAppSpecUseCase>();
			iServiceCollection.AddSingleton<IEnterpriseAppSpecUseCase, EnterpriseAppSpecUseCase>();
			iServiceCollection.AddSingleton<IEnterpriseContactAppSpecUseCase, EnterpriseContactAppSpecUseCase>();
			iServiceCollection.AddSingleton<IEntrepreneurAppSpecUseCase, EntrepreneurAppSpecUseCase>();
			iServiceCollection.AddSingleton<IMeanOfContactAppSpecUseCase, MeanOfContactAppSpecUseCase>();
			iServiceCollection.AddSingleton<IOperatingSegmentAppSpecUseCase, OperatingSegmentAppSpecUseCase>();
			iServiceCollection.AddSingleton<IStateAppSpecUseCase, StateAppSpecUseCase>();
		}

		private void ConfigureSerilog(ConfigurationManager configurationManager)
		{
			string? fullPathToTheLogFile = configurationManager["EnterpriseManager.API:FullPathToTheLogFile"];

			if (string.IsNullOrWhiteSpace(fullPathToTheLogFile))
			{
				fullPathToTheLogFile = $"{Path.Combine(AppContext.BaseDirectory, @"logs\EnterpriseManager.API.log")}";
			}

			Log.Logger = new LoggerConfiguration().WriteTo.File(fullPathToTheLogFile, rollingInterval: RollingInterval.Day).CreateLogger();
		}

		///<Summary>
		/// This method starts the application engine.
		///</Summary>
		public async Task StartAsync(string[] args)
		{
			WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);
			ConnectToTheDatabase(webApplicationBuilder.Services);
			LoadPersistenceRepositories(webApplicationBuilder.Services);
			LoadInfrastructureServices(webApplicationBuilder.Services);
			LoadApplicationServices(webApplicationBuilder.Services);
			LoadUseCases(webApplicationBuilder.Services);
			webApplicationBuilder.Logging.ClearProviders();
			ConfigureSerilog(webApplicationBuilder.Configuration);
			webApplicationBuilder.Logging.AddSerilog();
			webApplicationBuilder.Logging.AddConsole(options =>
			{
				options.FormatterName = "CustomConsoleFormatter";
			});
			webApplicationBuilder.Logging.AddConsoleFormatter<CustomConsoleFormatter, ConsoleFormatterOptions>();
			webApplicationBuilder.Services.AddControllers().AddXmlSerializerFormatters();
			webApplicationBuilder.Services.AddEndpointsApiExplorer();
			webApplicationBuilder.Services.AddSwaggerGen(swaggerGenOptions =>
			{
				swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "API V1",
					Description = "An ASP.NET Core Web API for managing ToDo items",
					TermsOfService = new Uri("https://example.com/terms"),
					Contact = new OpenApiContact
					{
						Name = "Example Contact",
						Url = new Uri("https://example.com/contact")
					},
					License = new OpenApiLicense
					{
						Name = "Example License",
						Url = new Uri("https://example.com/license")
					}
				});

				swaggerGenOptions.SwaggerDoc("v2", new OpenApiInfo
				{
					Title = "API V2",
					Description = "An ASP.NET Core Web API for managing ToDo items",
					TermsOfService = new Uri("https://example.com/terms"),
					Contact = new OpenApiContact
					{
						Name = "Example Contact",
						Url = new Uri("https://example.com/contact")
					},
					License = new OpenApiLicense
					{
						Name = "Example License",
						Url = new Uri("https://example.com/license")
					}
				});

				swaggerGenOptions.SwaggerDoc("v3", new OpenApiInfo
				{
					Title = "API V3",
					Description = "An ASP.NET Core Web API for managing ToDo items",
					TermsOfService = new Uri("https://example.com/terms"),
					Contact = new OpenApiContact
					{
						Name = "Example Contact",
						Url = new Uri("https://example.com/contact")
					},
					License = new OpenApiLicense
					{
						Name = "Example License",
						Url = new Uri("https://example.com/license")
					}
				});

				swaggerGenOptions.EnableAnnotations();

				swaggerGenOptions.DocInclusionPredicate((docName, apiDescription) =>
				{
					bool output = false;

					if (apiDescription.TryGetMethodInfo(out var methodInfo))
					{
						if (methodInfo != null)
						{
							if (methodInfo.DeclaringType != null)
							{
								if (!string.IsNullOrWhiteSpace(methodInfo.DeclaringType.Namespace))
								{
									string declaringTypeNamespace = methodInfo.DeclaringType.Namespace.Trim();
									switch (docName)
									{
										case "v1":
											output = declaringTypeNamespace.Contains(".V1");
											break;
										case "v2":
											output = declaringTypeNamespace.Contains(".V2");
											break;
										case "v3":
											output = declaringTypeNamespace.Contains(".V3");
											break;
										default:
											break;
									}
								}
							}
						}
					}

					return output;
				});

				Assembly assembly = Assembly.GetExecutingAssembly();
				if (assembly != null)
				{
					AssemblyName assemblyName = assembly.GetName();
					if (assemblyName != null)
					{
						if (!string.IsNullOrWhiteSpace(assemblyName.Name))
						{
							string fullFilePath = $"{Path.Combine(AppContext.BaseDirectory, assemblyName.Name)}.xml";

							if (File.Exists(fullFilePath))
							{
								swaggerGenOptions.IncludeXmlComments(fullFilePath);
							}
						}
					}
				}
			});
			webApplicationBuilder.Services.AddCors(corsOptions =>
			{
				corsOptions.AddPolicy("AllowAll", policy =>
				{
					policy.AllowAnyOrigin();
					policy.AllowAnyMethod();
					policy.AllowAnyHeader();
				});
			});

			WebApplication webApplication = webApplicationBuilder.Build();

			// Configure the HTTP request pipeline.
			if (webApplication.Environment.IsDevelopment())
			{
				webApplication.UseSwagger();
				webApplication.UseSwaggerUI(swaggerUIOption =>
				{
					swaggerUIOption.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
					swaggerUIOption.SwaggerEndpoint("/swagger/v2/swagger.json", "API V2");
					swaggerUIOption.SwaggerEndpoint("/swagger/v3/swagger.json", "API V3");
					swaggerUIOption.RoutePrefix = string.Empty;
				});
			}
			webApplication.UseHttpsRedirection();
			webApplication.UseCors("AllowAll");
			webApplication.UseAuthorization();
			webApplication.Use(async (context, next) =>
			{
				ILoggerFactory iLoggerFactory = context.RequestServices.GetRequiredService<ILoggerFactory>();
				Microsoft.Extensions.Logging.ILogger iLogger = iLoggerFactory.CreateLogger("RequestLogger");
				iLogger.LogInformation(
					"Request: {Method} {Path} {QueryString}",
					context.Request.Method,
					context.Request.Path,
					context.Request.QueryString);

				await next();

				iLogger.LogInformation(
					"Response: {StatusCode}",
					context.Response.StatusCode);
			});
			webApplication.MapControllers();
			await webApplication.RunAsync();
		}
	}
}