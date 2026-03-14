using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace EnterpriseManager.API
{
	///<Summary>
	/// This class is the application engine.
	///</Summary>
	public class Engine
	{
		private void LoadInfrastructureServices(IServiceCollection iServiceCollection)
		{
		}

		private void LoadApplicationServices(IServiceCollection iServiceCollection)
		{
		}

		///<Summary>
		/// This method starts the application engine.
		///</Summary>
		public async Task StartAsync(string[] args)
		{
			WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);
			LoadInfrastructureServices(webApplicationBuilder.Services);
			LoadApplicationServices(webApplicationBuilder.Services);
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
			webApplication.MapControllers();
			await webApplication.RunAsync();
		}
	}
}