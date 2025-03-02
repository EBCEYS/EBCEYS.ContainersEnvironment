# EBCEYS.ContainersEnvironment

[![.NET](https://github.com/EBCEYS/EBCEYS.ContainersEnvironment/actions/workflows/dotnet.yml/badge.svg)](https://github.com/EBCEYS/EBCEYS.ContainersEnvironment/actions/workflows/dotnet.yml)

## Описание

Библиотека для удобной работы сервисов внутри docker контейнера.

## Переменные окружения

`public class ServiceEnvironmentVariable<T>` используется для доступа к переменным окружения.

`public static class DefaultEnvironmentVariables` содержит внутри себя инстансы переменных окружения общих для контейнеров.

`public interface IEnvironmentConverter` интерфейс описывающий методы для конвертации переменной окружения в нужный тип.

## Изменения
### v0.0.2:
1. Исправил ReadMe в пакете.
1. Добавлена сущность `public class ContainerLabelInfo<T>` для работы с *labels* контейнера.
1. Добавлен экстеншн метод `public static ContainerLabelInfo<T>? GetLabel<T>(this IDictionary<string, string> labels, string key, IEnvironmentConverter? converter = null)` создающий экземпляр `public class ContainerLabelInfo<T>`.
### v0.0.1:

1. Работа с переменными окружения.