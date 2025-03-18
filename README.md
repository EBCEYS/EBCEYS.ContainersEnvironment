# EBCEYS.ContainersEnvironment

[![.NET](https://github.com/EBCEYS/EBCEYS.ContainersEnvironment/actions/workflows/dotnet.yml/badge.svg)](https://github.com/EBCEYS/EBCEYS.ContainersEnvironment/actions/workflows/dotnet.yml)

## Описание

Библиотека для удобной работы сервисов внутри docker контейнера.

## Переменные окружения

`public class ServiceEnvironmentVariable<T>` используется для доступа к переменным окружения.

`public static class DefaultEnvironmentVariables` содержит внутри себя инстансы переменных окружения общих для контейнеров.

`public interface IEnvironmentConverter` интерфейс описывающий методы для конвертации переменной окружения в нужный тип.

## Конфигурация сервисов

Создано для работы с [сервисом конфигурации](https://github.com/EBCEYS/EBCEYS.Server-Configuration).

`public class ConfigurationFileInfo` - объект, возвращаемым сервисом, содержащий информацию о конфигурации контейнера.
`public static class ConfigurationEnvironment` - статический класс, содержащий переменные окружения для конфигурации.

## *HealthChecks*

Для добавления *HealthCheck*-ов в сервис используются экстеншон методы:
* `public static IServiceCollection ConfigureHealthChecks(this IServiceCollection sc)` - добавляет *HealthCheck* в сервис и `PingServiceHealthStatusInfo` как *singleton*, чтобы его можно было использовать далее в сервисах.
* `public static IApplicationBuilder ConfigureHealthChecks(this IApplicationBuilder app, int port)` на `IApplicationBuilder`.

Добавляет поддержку переменной окружения *HEALTHCHECKS_ENABLE=bool*, которая включает и выключает *HealthChecks*. По умолчанию *true*.

Добавляет поддержку переменной окружения *HEALTHCHECKS_STARTING_PORT=int*, в которой указывается порт запуска *HealthCheck*-ов. По умолчанию *8080*.

*Routes*:
```cs
/// <summary>
/// The ping route.
/// </summary>
public const string PingRoute = "/ping";
/// <summary>
/// The healthz route.
/// </summary>
public const string HealthzRoute = "/healthz";
/// <summary>
/// The healthz status route.
/// </summary>
public const string HealthzStatusRoute = "/healthz/status";
```

## Изменения
### v0.0.8:
1. В стартовую настройку *HealthChecks* добавлена настройка по выбору режима работы. С кодогенерацией или без (по умолчанию без).
### v0.0.7:
1. Попытка сделать сериализацию *HealthReports* под *trimmed* публикацию.
### v0.0.6:
1. Сборка под AOT.
1. *HEALTHCHECKS_STARTING_PORT* - сделан опциональным. По умолчанию *8080*.
### v0.0.5:
1. Добавлена переменная окружения *HEALTHCHECKS_ENABLE=true*, которая включает и выключает *HealthChecks*.
### v0.0.4:
1. Добавлены *HealthChecks*.
### v0.0.3:
1. Добавлены переменные окружения для конфигурации.
1. Добавлен класс `public class ConfigurationFileInfo(string serverFileFullPath, DateTimeOffset lastWriteUTC, string containerTypeName, string fileSaveFullPath)`, служащий для передачи информации о файле конфигурации от сервера.
### v0.0.2:
1. Исправил ReadMe в пакете.
1. Добавлена сущность `public class ContainerLabelInfo<T>` для работы с *labels* контейнера.
1. Добавлен экстеншн метод `public static ContainerLabelInfo<T>? GetLabel<T>(this IDictionary<string, string> labels, string key, IEnvironmentConverter? converter = null)` создающий экземпляр `public class ContainerLabelInfo<T>`.
### v0.0.1:

1. Работа с переменными окружения.